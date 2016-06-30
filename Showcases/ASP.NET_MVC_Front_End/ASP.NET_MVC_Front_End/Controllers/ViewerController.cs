using GroupDocs.Viewer.Config;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Html;
using GroupDocs.Viewer.Domain.Options;
using GroupDocs.Viewer.Handler;
using MvcSample.Helpers;
using MvcSample.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using GroupDocs.Viewer.Domain.Containers;
using GroupDocs.Viewer.Domain.Image;
using WatermarkPosition = MvcSample.Models.WatermarkPosition;

namespace MvcSample.Controllers
{
    public class ViewerController : Controller
    {
        private readonly ViewerHtmlHandler _htmlHandler;
        private readonly ViewerImageHandler _imageHandler;

        // App_Data folder path
        private readonly string _storagePath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        private readonly string _tempPath = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\Temp";

        private readonly ConvertImageFileType _convertImageFileType = ConvertImageFileType.JPG;
        private readonly bool _usePdfInImageEngine = true;

        private readonly Dictionary<string, Stream> _streams = new Dictionary<string, Stream>();

        public ViewerController()
        {
            var htmlConfig = new ViewerConfig
            {
                StoragePath = _storagePath,
                TempPath = _tempPath,
                UseCache = true
            };

            _htmlHandler = new ViewerHtmlHandler(htmlConfig);

            var imageConfig = new ViewerConfig
            {
                StoragePath = _storagePath,
                TempPath = _tempPath,
                UseCache = true,
                UsePdf = _usePdfInImageEngine
            };

            _imageHandler = new ViewerImageHandler(imageConfig);

            _streams.Add("ProcessFileFromStreamExample_1.pdf", HttpWebRequest.Create("http://unfccc.int/resource/docs/convkp/kpeng.pdf").GetResponse().GetResponseStream());
            _streams.Add("ProcessFileFromStreamExample_2.doc", HttpWebRequest.Create("http://www.acm.org/sigs/publications/pubform.doc").GetResponse().GetResponseStream());
        }

        [HttpPost]
        public ActionResult ViewDocument(ViewDocumentParameters request)
        {
            if (Utils.IsValidUrl(request.Path))
                request.Path = DownloadToStorage(request.Path);
            else if (_streams.ContainsKey(request.Path))
                request.Path = SaveStreamToStorage(request.Path);

            var fileName = Path.GetFileName(request.Path);

            var result = new ViewDocumentResponse
            {
                pageCss = new string[] { },
                lic = true,
                pdfDownloadUrl = GetPdfDownloadUrl(request),
                pdfPrintUrl = GetPdfPrintUrl(request),
                url = GetFileUrl(request),
                path = request.Path,
                name = fileName
            };

            if (request.UseHtmlBasedEngine)
                ViewDocumentAsHtml(request, result, fileName);
            else
                ViewDocumentAsImage(request, result, fileName);

            return ToJsonResult(result);
        }

        public ActionResult LoadFileBrowserTreeData(LoadFileBrowserTreeDataParameters parameters)
        {
            var path = _storagePath;
            if (!string.IsNullOrEmpty(parameters.Path))
                path = Path.Combine(path, parameters.Path);

            var request = new FileTreeOptions(path);
            var tree = _htmlHandler.LoadFileTree(request);

            var result = new FileBrowserTreeDataResponse
            {
                nodes = Utils.ToFileTreeNodes(parameters.Path, tree.FileTree).ToArray(),
                count = tree.FileTree.Count
            };

            return ToJsonResult(result);
        }

        public ActionResult GetImageUrls(GetImageUrlsParameters parameters)
        {
            if (string.IsNullOrEmpty(parameters.Path))
            {
                var empty = new GetImageUrlsResponse { imageUrls = new string[0] };
                return ToJsonResult(empty);
            }
             
            DocumentInfoContainer documentInfoContainer = _imageHandler.GetDocumentInfo(parameters.Path);

            int[] pageNumbers = new int[documentInfoContainer.Pages.Count];
            for (int i = 0; i < documentInfoContainer.Pages.Count; i++)
            {
                pageNumbers[i] = documentInfoContainer.Pages[i].Number;
            }

            var applicationHost = GetApplicationHost();

            string[] imageUrls = ImageUrlHelper.GetImageUrls(applicationHost, pageNumbers, parameters);

            var result = new GetImageUrlsResponse
            {
                imageUrls = imageUrls
            };
            return ToJsonResult(result);
        }

        public ActionResult GetFile(GetFileParameters parameters)
        {
            var displayName = string.IsNullOrEmpty(parameters.DisplayName)
                ? Path.GetFileName(parameters.Path)
                : Uri.EscapeDataString(parameters.DisplayName);

            Stream fileStream;
            if (parameters.GetPdf)
            {
                displayName = Path.ChangeExtension(displayName, "pdf");

                var options = new PdfFileOptions
                {
                    Guid = parameters.Path,
                    Watermark = Utils.GetWatermark(parameters.WatermarkText, parameters.WatermarkColor, parameters.WatermarkPosition, parameters.WatermarkWidth),
                };

                if (parameters.IsPrintable)
                    options.Transformations |= Transformation.AddPrintAction;

                if (parameters.SupportPageRotation)
                    options.Transformations |= Transformation.Rotate;

                options.Transformations |= Transformation.Reorder;

                var pdfFileResponse = _htmlHandler.GetPdfFile(options);
                fileStream = pdfFileResponse.Stream;
            }
            else
            {
                var fileResponse = _htmlHandler.GetFile(parameters.Path);
                fileStream = fileResponse.Stream;
            }

            //jquery.fileDownload uses this cookie to determine that a file download has completed successfully
            Response.SetCookie(new HttpCookie("jqueryFileDownloadJSForGD", "true") { Path = "/" });

            fileStream.Position = 0;
            using (var ms = new MemoryStream())
            {
                fileStream.CopyTo(ms);
                return File(ms.ToArray(), "application/octet-stream", displayName);
            }
        }

        public ActionResult GetPdfWithPrintDialog(GetFileParameters parameters)
        {
            var displayName = string.IsNullOrEmpty(parameters.DisplayName)
                ? Path.GetFileName(parameters.Path)
                : Uri.EscapeDataString(parameters.DisplayName);

            var options = new PdfFileOptions
            {
                Guid = parameters.Path,
                Watermark = Utils.GetWatermark(parameters.WatermarkText, parameters.WatermarkColor, parameters.WatermarkPosition, parameters.WatermarkWidth)
            };

            if (parameters.IsPrintable)
                options.Transformations |= Transformation.AddPrintAction;

            if (parameters.SupportPageRotation)
                options.Transformations |= Transformation.Rotate;

            options.Transformations |= Transformation.Reorder;


            var response = _htmlHandler.GetPdfFile(options);

            var contentDispositionString = new ContentDisposition { FileName = displayName, Inline = true }.ToString();
            Response.AddHeader("Content-Disposition", contentDispositionString);

            return File(((MemoryStream)response.Stream).ToArray(), "application/pdf");
        }

        public string GetFileUrl(string path, bool getPdf, bool isPrintable, string fileDisplayName = null,
          string watermarkText = null, int? watermarkColor = null,
          WatermarkPosition? watermarkPosition = WatermarkPosition.Diagonal, float? watermarkWidth = 0,
          bool ignoreDocumentAbsence = false,
          bool useHtmlBasedEngine = false,
          bool supportPageRotation = false)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["path"] = path;
            if (!isPrintable)
            {
                queryString["getPdf"] = getPdf.ToString().ToLower();

                if (fileDisplayName != null)
                    queryString["displayName"] = fileDisplayName;
            }

            if (watermarkText != null)
            {
                queryString["watermarkText"] = watermarkText;
                queryString["watermarkColor"] = watermarkColor.ToString();

                if (watermarkPosition.HasValue)
                    queryString["watermarkPosition"] = watermarkPosition.ToString();

                if (watermarkWidth.HasValue)
                    queryString["watermarkWidth"] = ((float)watermarkWidth).ToString(CultureInfo.InvariantCulture);
            }

            if (ignoreDocumentAbsence)
            {
                queryString["ignoreDocumentAbsence"] = ignoreDocumentAbsence.ToString().ToLower();
            }

            queryString["useHtmlBasedEngine"] = useHtmlBasedEngine.ToString().ToLower();
            queryString["supportPageRotation"] = supportPageRotation.ToString().ToLower();

            var handlerName = isPrintable ? "GetPdfWithPrintDialog" : "GetFile";

            var baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/document-viewer/";

            var fileUrl = string.Format("{0}{1}?{2}", baseUrl, handlerName, queryString);
            return fileUrl;
        }

        public ActionResult GetDocumentPageHtml(GetDocumentPageHtmlParameters parameters)
        {
            if (Utils.IsValidUrl(parameters.Path))
                parameters.Path = Utils.GetFilenameFromUrl(parameters.Path);

            if (String.IsNullOrWhiteSpace(parameters.Path))
                throw new ArgumentException("A document path must be specified", "path");

            List<string> cssList;
            int pageNumber = parameters.PageIndex + 1;

            var htmlOptions = new HtmlOptions
            {
                PageNumber = parameters.PageIndex + 1,
                CountPagesToConvert = 1,
                IsResourcesEmbedded = false,
                HtmlResourcePrefix = string.Format(
                    "/document-viewer/GetResourceForHtml?documentPath={0}", parameters.Path) +
                                     "&pageNumber={page-number}&resourceName=",
            };

            var htmlPages = GetHtmlPages(parameters.Path, htmlOptions, out cssList);

            var pageHtml = htmlPages.Count > 0 ? htmlPages[0].HtmlContent : null;
            var pageCss = cssList.Count > 0 ? new[] { string.Join(" ", cssList) } : null;

            var result = new { pageHtml, pageCss };
            return ToJsonResult(result);
        }

        public ActionResult GetDocumentPageImage(GetDocumentPageImageParameters parameters)
        {
            //parameters.IgnoreDocumentAbsence - not supported
            //parameters.InstanceIdToken - not supported

            string guid = parameters.Path;
            int pageIndex = parameters.PageIndex;
            int pageNumber = pageIndex + 1;

            /*
            //NOTE: This feature is supported starting from version 3.2.0
            CultureInfo cultureInfo = string.IsNullOrEmpty(parameters.Locale)
                ? new CultureInfo("en-Us")
                : new CultureInfo(parameters.Locale);

            ViewerImageHandler viewerImageHandler = new ViewerImageHandler(viewerConfig, cultureInfo);
            */

            var imageOptions = new ImageOptions
            {
                ConvertImageFileType = _convertImageFileType,
                Watermark = Utils.GetWatermark(parameters.WatermarkText, parameters.WatermarkColor,
                    parameters.WatermarkPosition, parameters.WatermarkWidth),
                Transformations = parameters.Rotate ? Transformation.Rotate : Transformation.None
            };

            if (parameters.Rotate && parameters.Width.HasValue)
            { 
                DocumentInfoContainer documentInfoContainer = _imageHandler.GetDocumentInfo(guid);

                int side = parameters.Width.Value;

                int pageAngle = documentInfoContainer.Pages[pageIndex].Angle;
                if (pageAngle == 90 || pageAngle == 270)
                    imageOptions.Height = side;
                else
                    imageOptions.Width = side;
            }

            /*
            //NOTE: This feature is supported starting from version 3.2.0
            if (parameters.Quality.HasValue)
                imageOptions.JpegQuality = parameters.Quality.Value;
            */

            using (new InterProcessLock(guid))
            {
                List<PageImage> pageImages = _imageHandler.GetPages(guid, imageOptions);
                PageImage pageImage = pageImages.Single(_ => _.PageNumber == pageNumber);
                return File(pageImage.Stream, GetContentType(_convertImageFileType));
            }
        }

        public ActionResult GetResourceForHtml(GetResourceForHtmlParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.ResourceName) &&
                parameters.ResourceName.IndexOf("/", StringComparison.Ordinal) >= 0)
                parameters.ResourceName = parameters.ResourceName.Replace("/", "");

            var resource = new HtmlResource
            {
                ResourceName = parameters.ResourceName,
                ResourceType = Utils.GetResourceType(parameters.ResourceName),
                DocumentPageNumber = parameters.PageNumber
            };
            var stream = _htmlHandler.GetResource(parameters.DocumentPath, resource);

            if (stream == null || stream.Length == 0)
                return new HttpStatusCodeResult((int)HttpStatusCode.Gone);

            return File(stream, Utils.GetImageMimeTypeFromFilename(parameters.ResourceName));
        }

        public ActionResult RotatePage(RotatePageParameters parameters)
        {
            string guid = parameters.Path;
            int pageIndex = parameters.PageNumber;
            
            DocumentInfoContainer documentInfoContainer = _imageHandler.GetDocumentInfo(guid);
            int pageNumber = documentInfoContainer.Pages[pageIndex].Number;

            RotatePageOptions rotatePageOptions = new RotatePageOptions(guid, pageNumber, parameters.RotationAmount);
            RotatePageContainer rotatePageContainer = _imageHandler.RotatePage(rotatePageOptions);
            
            RotatePageResponse response = new RotatePageResponse
            {
                resultAngle = rotatePageContainer.CurrentRotationAngle
            };

            return ToJsonResult(response);
        }

        public ActionResult ReorderPage(ReorderPageParameters parameters)
        {
            string guid = parameters.Path;
             
            DocumentInfoContainer documentInfoContainer = _imageHandler.GetDocumentInfo(guid);

            int pageNumber = documentInfoContainer.Pages[parameters.OldPosition].Number;
            int newPosition = parameters.NewPosition + 1;

            ReorderPageOptions reorderPageOptions = new ReorderPageOptions(guid, pageNumber, newPosition);
            _imageHandler.ReorderPage(reorderPageOptions);

            return ToJsonResult(new ReorderPageResponse());
        }

        private List<PageHtml> GetHtmlPages(string filePath, HtmlOptions htmlOptions, out List<string> cssList)
        {
            var htmlPages = _htmlHandler.GetPages(filePath, htmlOptions);

            cssList = new List<string>();
            foreach (var page in htmlPages)
            {
                var indexOfBodyOpenTag = page.HtmlContent.IndexOf("<body>", StringComparison.InvariantCultureIgnoreCase);
                if (indexOfBodyOpenTag > 0)
                    page.HtmlContent = page.HtmlContent.Substring(indexOfBodyOpenTag + "<body>".Length);

                var indexOfBodyCloseTag = page.HtmlContent.IndexOf("</body>", StringComparison.InvariantCultureIgnoreCase);
                if (indexOfBodyCloseTag > 0)
                    page.HtmlContent = page.HtmlContent.Substring(0, indexOfBodyCloseTag);

                foreach (var resource in page.HtmlResources.Where(_ => _.ResourceType == HtmlResourceType.Style))
                {
                    var cssStream = _htmlHandler.GetResource(filePath, resource);
                    var text = new StreamReader(cssStream).ReadToEnd();

                    var needResave = false;
                    if (text.IndexOf("url(\"", StringComparison.Ordinal) >= 0 &&
                        text.IndexOf("url(\"/document-viewer/GetResourceForHtml?documentPath=", StringComparison.Ordinal) < 0)
                    {
                        needResave = true;
                        text = text.Replace("url(\"",
                        string.Format("url(\"/document-viewer/GetResourceForHtml?documentPath={0}&pageNumber={1}&resourceName=",
                        filePath, page.PageNumber));
                    }

                    if (text.IndexOf("url('", StringComparison.Ordinal) >= 0 &&
                        text.IndexOf("url('/document-viewer/GetResourceForHtml?documentPath=", StringComparison.Ordinal) < 0)
                    {
                        needResave = true;
                        text = text.Replace("url('",
                            string.Format(
                                "url('/document-viewer/GetResourceForHtml?documentPath={0}&pageNumber={1}&resourceName=",
                                filePath, page.PageNumber));
                    }

                    cssList.Add(text);

                    if (needResave)
                    {
                        var fullPath = Path.Combine(_tempPath, filePath, "html", "resources",
                            string.Format("page{0}", page.PageNumber), resource.ResourceName);

                        System.IO.File.WriteAllText(fullPath, text);
                    }
                }

                List<string> cssClasses = Utils.GetCssClasses(page.HtmlContent);
                foreach (var cssClass in cssClasses)
                {
                    var newCssClass = string.Format("page-{0}-{1}", page.PageNumber, cssClass);

                    page.HtmlContent = page.HtmlContent.Replace(cssClass, newCssClass);
                    for (int i = 0; i < cssList.Count; i++)
                        cssList[i] = cssList[i].Replace(cssClass, newCssClass);
                }
            }
            return htmlPages;
        }

        private ActionResult ToJsonResult(object result)
        {
            var serializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
            var serializedData = serializer.Serialize(result);
            return Content(serializedData, "application/json");
        }

        private string DownloadToStorage(string url)
        {
            var fileNameFromUrl = Utils.GetFilenameFromUrl(url);
            var filePath = Path.Combine(_storagePath, fileNameFromUrl);

            using (new InterProcessLock(filePath))
                Utils.DownloadFile(url, filePath);

            return fileNameFromUrl;
        }

        private string SaveStreamToStorage(string key)
        {
            var stream = _streams[key];
            var savePath = Path.Combine(_storagePath, key);

            using (new InterProcessLock(savePath))
            {
                using (var fileStream = System.IO.File.Create(savePath))
                {
                    if (stream.CanSeek)
                        stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }

                return savePath;
            }
        }

        private void ViewDocumentAsImage(ViewDocumentParameters request, ViewDocumentResponse result, string fileName)
        {
            var docInfo = _imageHandler.GetDocumentInfo(request.Path);

            var maxWidth = 0;
            var maxHeight = 0;
            foreach (var pageData in docInfo.Pages)
            {
                if (pageData.Height > maxHeight)
                {
                    maxHeight = pageData.Height;
                    maxWidth = pageData.Width;
                }
            }
            var fileData = new FileData
            {
                DateCreated = DateTime.Now,
                DateModified = docInfo.LastModificationDate,
                PageCount = docInfo.Pages.Count,
                Pages = docInfo.Pages,
                MaxWidth = maxWidth,
                MaxHeight = maxHeight
            };

            result.documentDescription = new FileDataJsonSerializer(fileData, new FileDataOptions()).Serialize(true);
            result.docType = docInfo.DocumentType;
            result.fileType = docInfo.FileType;
             
            DocumentInfoContainer documentInfoContainer = _imageHandler.GetDocumentInfo(request.Path);

            int[] pageNumbers = new int[documentInfoContainer.Pages.Count];
            for (int i = 0; i < documentInfoContainer.Pages.Count; i++)
            {
                pageNumbers[i] = documentInfoContainer.Pages[i].Number;
            }

            string applicationHost = GetApplicationHost();
            result.imageUrls = ImageUrlHelper.GetImageUrls(applicationHost, pageNumbers, request);
        }

        private void ViewDocumentAsHtml(ViewDocumentParameters request, ViewDocumentResponse result, string fileName)
        {
            var docInfo = _htmlHandler.GetDocumentInfo(request.Path);

            var maxWidth = 0;
            var maxHeight = 0;
            foreach (var pageData in docInfo.Pages)
            {
                if (pageData.Height > maxHeight)
                {
                    maxHeight = pageData.Height;
                    maxWidth = pageData.Width;
                }
            }
            var fileData = new FileData
            {
                DateCreated = DateTime.Now,
                DateModified = docInfo.LastModificationDate,
                PageCount = docInfo.Pages.Count,
                Pages = docInfo.Pages,
                MaxWidth = maxWidth,
                MaxHeight = maxHeight
            };

            result.documentDescription = new FileDataJsonSerializer(fileData, new FileDataOptions()).Serialize(false);
            result.docType = docInfo.DocumentType;
            result.fileType = docInfo.FileType;

            var htmlOptions = new HtmlOptions
            {
                IsResourcesEmbedded = Utils.IsImage(fileName),
                HtmlResourcePrefix = string.Format(
                "/document-viewer/GetResourceForHtml?documentPath={0}", fileName) + "&pageNumber={page-number}&resourceName=",
            };

            if (request.PreloadPagesCount.HasValue && request.PreloadPagesCount.Value > 0)
            {
                htmlOptions.PageNumber = 1;
                htmlOptions.CountPagesToConvert = request.PreloadPagesCount.Value;
            }

            List<string> cssList;
            var htmlPages = GetHtmlPages(fileName, htmlOptions, out cssList);
            result.pageHtml = htmlPages.Select(_ => _.HtmlContent).ToArray();
            result.pageCss = new[] { string.Join(" ", cssList) };
        }

        private string GetFileUrl(ViewDocumentParameters request)
        {
            return GetFileUrl(request.Path, false, false, request.FileDisplayName);
        }

        private string GetPdfPrintUrl(ViewDocumentParameters request)
        {
            return GetFileUrl(request.Path, true, true, request.FileDisplayName,
                request.WatermarkText, request.WatermarkColor,
                request.WatermarkPosition, request.WatermarkWidth,
                request.IgnoreDocumentAbsence,
                request.UseHtmlBasedEngine, request.SupportPageRotation);
        }

        private string GetPdfDownloadUrl(ViewDocumentParameters request)
        {
            return GetFileUrl(request.Path, true, false, request.FileDisplayName,
                request.WatermarkText, request.WatermarkColor,
                request.WatermarkPosition, request.WatermarkWidth,
                request.IgnoreDocumentAbsence,
                request.UseHtmlBasedEngine, request.SupportPageRotation);
        }

        private string GetApplicationHost()
        {
            return Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/');
        }

        private string GetContentType(ConvertImageFileType convertImageFileType)
        {
            string contentType;
            switch (convertImageFileType)
            {
                case ConvertImageFileType.JPG:
                    contentType = "image/jpeg";
                    break;
                case ConvertImageFileType.BMP:
                    contentType = "image/bmp";
                    break;
                case ConvertImageFileType.PNG:
                    contentType = "image/png"; ;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return contentType;
        }
    }
}