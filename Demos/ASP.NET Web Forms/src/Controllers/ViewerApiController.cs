using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using GroupDocs.Viewer.AspNetWebForms.ActionResults;
using GroupDocs.Viewer.AspNetWebForms.Core;
using GroupDocs.Viewer.AspNetWebForms.Core.Configuration;
using GroupDocs.Viewer.AspNetWebForms.Core.Entities;
using GroupDocs.Viewer.AspNetWebForms.Core.Extensions;
using GroupDocs.Viewer.AspNetWebForms.Core.Utils;
using GroupDocs.Viewer.AspNetWebForms.Models;

namespace GroupDocs.Viewer.AspNetWebForms.Controllers
{
    [RoutePrefix(Constants.API_PATH)]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ViewerApiController : ApiController
    {
        private readonly UIConfig _config;
        private readonly IFileStorage _fileStorage;
        private readonly IViewer _viewer;

        public ViewerApiController(
            UIConfig uiConfig, 
            IFileStorage fileStorage, 
            IViewer viewer)
        {
            _config = uiConfig;
            _fileStorage = fileStorage;
            _viewer = viewer;
        }

        [HttpGet]
        [Route(Constants.LOAD_CONFIG_ACTION_NAME)]
        public IHttpActionResult LoadConfig()
        {
            var config = new LoadConfigResponse
            {
                PageSelector = _config.PageSelector,
                Download = _config.Download,
                Upload = _config.Upload,
                Print = _config.Print,
                Browse = _config.Browse,
                Rewrite = _config.Rewrite,
                EnableRightClick = _config.EnableRightClick,
                DefaultDocument = _config.DefaultDocument,
                PreloadPageCount = _config.PreloadPageCount,
                Zoom = _config.Zoom,
                Search = _config.Search,
                Thumbnails = _config.Thumbnails,
                HtmlMode = _config.HtmlMode,
                PrintAllowed = _config.PrintAllowed,
                Rotate = _config.Rotate,
                SaveRotateState = _config.SaveRotateState,
                DefaultLanguage = _config.DefaultLanguage,
                SupportedLanguages = _config.SupportedLanguages,
                ShowLanguageMenu = _config.ShowLanguageMenu
            };

            return OkJsonResult(config);
        }

        [HttpPost]
        [Route(Constants.LOAD_FILE_TREE_ACTION_NAME)]
        public async Task<IHttpActionResult> GetFileTree(LoadFileTreeRequest request)
        {
            if (!_config.Browse)
                return ErrorJsonResult("Browsing files is disabled.");

            try
            {
                var files =
                    await _fileStorage.ListDirsAndFilesAsync(request.Path);

                var result = files
                    .Select(entity => new FileDescription(entity.FilePath, entity.FilePath, entity.IsDirectory, entity.Size))
                    .ToList();

                return OkJsonResult(result);
            }
            catch (Exception ex)
            {
                return ErrorJsonResult(ex.Message);
            }
        }

        [HttpGet]
        [Route(Constants.DOWNLOAD_DOCUMENT_ACTION_NAME)]
        public async Task<IHttpActionResult> DownloadDocument(string path)
        {
            if (!_config.Download)
                return ErrorJsonResult("Downloading files is disabled.");

            try
            {
                var fileName = Path.GetFileName(path);
                var bytes = await _fileStorage.ReadFileAsync(path);

                return FileResult(bytes, fileName);
            }
            catch (Exception ex)
            {
                return ErrorJsonResult(ex.Message);
            }
        }

        [HttpGet]
        [Route(Constants.LOAD_DOCUMENT_PAGE_RESOURCE_ACTION_NAME)]
        public async Task<IHttpActionResult> LoadDocumentPageResource(
            [FromUri]string guid, [FromUri] int pageNumber, [FromUri] string resourceName)
        {
            if (!_config.HtmlMode)
                return ErrorJsonResult("Loading page resources is disabled in image mode.");

            try
            {
                var fileCredentials =
                    new FileCredentials(guid, "", "");
                var bytes =
                    await _viewer.GetPageResourceAsync(fileCredentials, pageNumber, resourceName);

                if (bytes.Length == 0)
                    return NotFoundJsonResult($"Resource {resourceName} was not found");

                var contentType = resourceName.ContentTypeFromFileName();

                return ResourceFileResult(bytes, contentType);
            }
            catch (Exception ex)
            {
                return ErrorJsonResult(ex.Message);
            }
        }

        [HttpPost]
        [Route(Constants.UPLOAD_DOCUMENT_ACTION_NAME)]
        public async Task<IHttpActionResult> UploadDocument()
        {
            if (!_config.Upload)
                return ErrorJsonResult("Uploading files is disabled.");

            try
            {
                var url = HttpContext.Current.Request.Form["url"];
                var (fileName, bytes) = await ReadOrDownloadFile(url);
                bool.TryParse(HttpContext.Current.Request.Form["rewrite"], out var rewrite);

                var filePath = await _fileStorage.WriteFileAsync(fileName, bytes, rewrite);
                var result = new UploadFileResponse(filePath);

                return OkJsonResult(result);
            }
            catch (Exception ex)
            {
                return ErrorJsonResult(ex.Message);
            }
        }

        [HttpPost]
        [Route(Constants.PRINT_PDF_ACTION_NAME)]
        public async Task<IHttpActionResult> PrintPdf([FromBody] PrintPdfRequest request)
        {
            if (!_config.Print)
                return ErrorJsonResult("Printing files is disabled.");

            try
            {
                var fileCredentials =
                    new FileCredentials(request.Guid, request.FileType, request.Password);

                var filename = Path.GetFileName(request.Guid);
                var pdfFileName = Path.ChangeExtension(filename, ".pdf");
                var pdfFileBytes = await _viewer.GetPdfAsync(fileCredentials);

                return FileResult(pdfFileBytes, pdfFileName, "application/pdf");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("password"))
                {
                    var message = string.IsNullOrEmpty(request.Password)
                        ? "Password Required"
                        : "Incorrect Password";

                    return ForbiddenJsonResult(message);
                }

                return ErrorJsonResult(ex.Message);
            }
        }

        [HttpPost]
        [Route(Constants.LOAD_DOCUMENT_DESCRIPTION_ACTION_NAME)]
        public async Task<IHttpActionResult> LoadDocumentDescription([FromBody] LoadDocumentDescriptionRequest request)
        {
            try
            {
                var fileCredentials =
                    new FileCredentials(request.Guid, request.FileType, request.Password);
                var documentDescription =
                    await _viewer.GetDocumentInfoAsync(fileCredentials);

                var pageNumbers = GetPageNumbers(documentDescription.Pages.Count());
                var pagesData = await _viewer.GetPagesAsync(fileCredentials, pageNumbers);

                var pages = new List<PageDescription>();
                foreach (PageInfo pageInfo in documentDescription.Pages)
                {
                    var pageData = pagesData.FirstOrDefault(p => p.PageNumber == pageInfo.Number);
                    var pageDescription = new PageDescription
                    {
                        Width = pageInfo.Width,
                        Height = pageInfo.Height,
                        Number = pageInfo.Number,
                        SheetName = pageInfo.Name,
                        Data = pageData?.GetContent()
                    };

                    pages.Add(pageDescription);
                }

                var result = new LoadDocumentDescriptionResponse
                {
                    Guid = request.Guid,
                    FileType = documentDescription.FileType,
                    PrintAllowed = documentDescription.PrintAllowed,
                    Pages = pages
                };

                return OkJsonResult(result);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("password"))
                {
                    var message = string.IsNullOrEmpty(request.Password)
                            ? "Password Required"
                            : "Incorrect Password";

                    return ForbiddenJsonResult(message);
                }

                return ErrorJsonResult(ex.Message);
            }
        }

        private int[] GetPageNumbers(int totalPageCount)
        {
            if (_config.PreloadPageCount == 0)
                return Enumerable.Range(1, totalPageCount).ToArray();

            var pageCount =
            Math.Min(totalPageCount, _config.PreloadPageCount);

            return Enumerable.Range(1, pageCount).ToArray();
        }

        [HttpPost]
        [Route(Constants.LOAD_DOCUMENT_PAGES_ACTION_NAME)]
        public async Task<IHttpActionResult> LoadDocumentPages([FromBody] LoadDocumentPagesRequest request)
        {
            try
            {
                var fileCredentials =
                    new FileCredentials(request.Guid, request.FileType, request.Password);
                var pages = await _viewer.GetPagesAsync(fileCredentials, request.Pages);
                var pageContents = pages
                    .Select(page => new PageContent { Number = page.PageNumber, Data = page.GetContent() })
                    .ToList();

                return OkJsonResult(pageContents);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("password"))
                {
                    var message = string.IsNullOrEmpty(request.Password)
                        ? "Password Required"
                        : "Incorrect Password";

                    return ForbiddenJsonResult(message);
                }

                return ErrorJsonResult(ex.Message);
            }
        }

        [HttpPost]
        [Route(Constants.LOAD_DOCUMENT_PAGE_ACTION_NAME)]
        public async Task<IHttpActionResult> LoadDocumentPage([FromBody] LoadDocumentPageRequest request)
        {
            try
            {
                var fileCredentials =
                    new FileCredentials(request.Guid, request.FileType, request.Password);
                var page = await _viewer.GetPageAsync(fileCredentials, request.Page);
                var pageContent = new PageContent { Number = page.PageNumber, Data = page.GetContent() };

                return OkJsonResult(pageContent);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("password"))
                {
                    var message = string.IsNullOrEmpty(request.Password)
                        ? "Password Required"
                        : "Incorrect Password";

                    return ForbiddenJsonResult(message);
                }

                return ErrorJsonResult(ex.Message);
            }
        }

        private Task<(string, byte[])> ReadOrDownloadFile(string url)
        {
            return string.IsNullOrEmpty(url)
                ? ReadFileFromRequest()
                : DownloadFileAsync(url);
        }

        private async Task<(string, byte[])> ReadFileFromRequest()
        {
            var provider = await Request.Content.ReadAsMultipartAsync();
            var firstFile = provider.Contents.First();

            var bytes = await firstFile.ReadAsByteArrayAsync();
            var fileName = PathUtils.RemoveInvalidFileNameChars(
                firstFile.Headers.ContentDisposition.FileName);

            return (fileName, bytes);
        }

        private async Task<(string, byte[])> DownloadFileAsync(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Other");

                Uri uri = new Uri(url);
                string fileName = Path.GetFileName(uri.LocalPath);
                byte[] bytes = await httpClient.GetByteArrayAsync(uri);

                return (fileName, bytes);
            }
        }

        private IHttpActionResult ErrorJsonResult(string message) =>
            new JsonActionResult(new ErrorResponse(message), Request)
            {
                StatusCode = HttpStatusCode.InternalServerError
            };

        private IHttpActionResult ForbiddenJsonResult(string message) =>
            new JsonActionResult(new ErrorResponse(message), Request)
            {
                StatusCode = HttpStatusCode.Forbidden
            };

        private IHttpActionResult NotFoundJsonResult(string message) =>
            new JsonActionResult(new ErrorResponse(message), Request)
            {
                StatusCode = HttpStatusCode.NotFound
            };

        private IHttpActionResult OkJsonResult(object result) =>
            new JsonActionResult(result, Request);

        private IHttpActionResult FileResult(byte[] data, string fileName) =>
            new FileActionResult(data, fileName, "application/octet-stream", Request);

        private IHttpActionResult FileResult(byte[] data, string fileName, string contentType) =>
            new FileActionResult(data, fileName, contentType, Request);

        private IHttpActionResult ResourceFileResult(byte[] data, string contentType) =>
            new ResourceActionResult(data, contentType, Request);
    }
}