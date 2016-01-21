using GroupDocs.Viewer;
using GroupDocs.Viewer.Config;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Options;
using GroupDocs.Viewer.Handler;
using MvcSample.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WatermarkPosition = MvcSample.Models.WatermarkPosition;

namespace MvcSample.Controllers
{
    public class ViewerController : Controller
    {
        private readonly ViewerHtmlHandler _htmlHandler;
        private readonly ViewerImageHandler _imageHandler;

        private string _licensePath = @"";
        private string _storagePath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString(); // App_Data folder path
        private string _tempPath = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\Temp";
        private readonly ViewerConfig _config;

        public ViewerController()
        {
         

            _config = new ViewerConfig
            {
                StoragePath = _storagePath,
                TempPath = _tempPath,
                UseCache = true
            };

            _htmlHandler = new ViewerHtmlHandler(_config);
            _imageHandler = new ViewerImageHandler(_config);

            
        }

        // GET: /Viewer/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewDocument(ViewDocumentParameters request)
        {
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
            {
                
                var docInfo = _htmlHandler.GetDocumentInfo(new DocumentInfoOptions(request.Path));
                
                result.documentDescription = new FileDataJsonSerializer( docInfo.Pages,new FileDataOptions()).Serialize(false);
                result.docType = docInfo.DocumentType;
                result.fileType = docInfo.FileType;

                var htmlOptions = new HtmlOptions { IsResourcesEmbedded = true, Watermark = GetWatermark(request) };
                var htmlPages = _htmlHandler.GetPages(request.Path, htmlOptions);
                result.pageHtml = htmlPages.Select(_ => _.HtmlContent).ToArray();

                //NOTE: Fix for incomplete cells document
                for (int i = 0; i < result.pageHtml.Length; i++)
                {
                    var html = result.pageHtml[i];
                    var indexOfScript = html.IndexOf("script");
                    if (indexOfScript > 0)
                        result.pageHtml[i] = html.Substring(0, indexOfScript);
                }
            }
            else
            {
                var docInfo = _imageHandler.GetDocumentInfo(new DocumentInfoOptions(request.Path));
                result.documentDescription = new FileDataJsonSerializer(docInfo.Pages, new FileDataOptions()).Serialize(true);
                result.docType = docInfo.DocumentType;
                result.fileType = docInfo.FileType;

                var imageOptions = new ImageOptions { Watermark = GetWatermark(request) };
                var imagePages = _imageHandler.GetPages(request.Path, imageOptions);

                // Provide images urls
                var urls = new List<string>();

                // If no cache - save images to temp folder
                var tempFolderPath = Path.Combine(Server.MapPath("~"), "Content", "TempStorage");

                foreach (var pageImage in imagePages)
                {
                    var docFoldePath = Path.Combine(tempFolderPath, request.Path);

                    if (!Directory.Exists(docFoldePath))
                        Directory.CreateDirectory(docFoldePath);

                    var pageImageName = string.Format("{0}\\{1}.png", docFoldePath, pageImage.PageNumber);

                    using (var stream = pageImage.Stream)
                    using (FileStream fileStream = new FileStream(pageImageName, FileMode.Create))
                    {
                        stream.Seek(0, SeekOrigin.Begin);
                        stream.CopyTo(fileStream);
                    }

                    var baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                    urls.Add(string.Format("{0}Content/TempStorage/{1}/{2}.png", baseUrl, request.Path, pageImage.PageNumber));
                }

                result.imageUrls = urls.ToArray();
            }
            var serializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };

            var serializedData = serializer.Serialize(result);
            return Content(serializedData, "application/json");
        }

        public ActionResult LoadFileBrowserTreeData(LoadFileBrowserTreeDataParameters parameters)
        {
            
            var path = _storagePath;
            if (!string.IsNullOrEmpty(parameters.Path))
                path = Path.Combine(path, parameters.Path);

         

            var tree = _htmlHandler.LoadFileTree(new FileTreeOptions(path));
            var treeNodes = tree.FileTree;
            var data = new FileBrowserTreeDataResponse
            {
                nodes = ToFileTreeNodes(parameters.Path, treeNodes).ToArray(),
                count = tree.FileTree.Count
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            var serializedData = serializer.Serialize(data);
            return Content(serializedData, "application/json");
             
        }
        
        
        public ActionResult GetImageUrls(GetImageUrlsParameters parameters)
        {
            if (string.IsNullOrEmpty(parameters.Path))
            {
                GetImageUrlsResponse empty = new GetImageUrlsResponse { imageUrls = new string[0] };

                var serialized = new JavaScriptSerializer().Serialize(empty);
                return Content(serialized, "application/json");
            }

            var imageOptions = new ImageOptions();
            var imagePages = _imageHandler.GetPages(parameters.Path, imageOptions);

            // Save images some where and provide urls
            var urls = new List<string>();
            var tempFolderPath = Path.Combine(Server.MapPath("~"), "Content", "TempStorage");

            foreach (var pageImage in imagePages)
            {
                var docFoldePath = Path.Combine(tempFolderPath, parameters.Path);

                if (!Directory.Exists(docFoldePath))
                    Directory.CreateDirectory(docFoldePath);

                var pageImageName = string.Format("{0}\\{1}.png", docFoldePath, pageImage.PageNumber);

                using (var stream = pageImage.Stream)
                using (FileStream fileStream = new FileStream(pageImageName, FileMode.Create))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }

                var baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                urls.Add(string.Format("{0}Content/TempStorage/{1}/{2}.png", baseUrl, parameters.Path, pageImage.PageNumber));
            }

            GetImageUrlsResponse result = new GetImageUrlsResponse { imageUrls = urls.ToArray() };

            var serializedData = new JavaScriptSerializer().Serialize(result);
            return Content(serializedData, "application/json");
        }

       public ActionResult GetFile(GetFileParameters parameters)
        {
            var displayName = string.IsNullOrEmpty(parameters.DisplayName) ?
                Path.GetFileName(parameters.Path) : Uri.EscapeDataString(parameters.DisplayName);

            Stream fileStream;
            if (parameters.GetPdf)
            {
                displayName = Path.ChangeExtension(displayName, "pdf");

                var getPdfFileRequest = new PdfFileOptions
                {
                    Guid = parameters.Path,
                    AddPrintAction = parameters.IsPrintable,
                    Transformations = Transformation.Rotate | Transformation.Reorder,
                    Watermark = GetWatermark(parameters),
                };

                var pdfFileResponse = _htmlHandler.GetPdfFile(getPdfFileRequest);
                fileStream = pdfFileResponse.Stream;
            }
            else
            {
                var fileResponse = _htmlHandler.GetFile(parameters.Path);
                fileStream = fileResponse.Stream;
            }

            //jquery.fileDownload uses this cookie to determine that a file download has completed successfully
            Response.SetCookie(new HttpCookie("jqueryFileDownloadJSForGD", "true") { Path = "/" });

            return File(GetBytes(fileStream), "application/octet-stream", displayName);
        }

       public ActionResult GetPdfWithPrintDialog(GetFileParameters parameters)
        {
            var displayName = string.IsNullOrEmpty(parameters.DisplayName) ?
               Path.GetFileName(parameters.Path) : Uri.EscapeDataString(parameters.DisplayName);

            var pdfFileOptions = new PdfFileOptions
            {
                Guid = parameters.Path,
                AddPrintAction = parameters.IsPrintable,
                Transformations = Transformation.Rotate | Transformation.Reorder,
                Watermark = GetWatermark(parameters),
            };
            var response = _htmlHandler.GetPdfFile(pdfFileOptions);
            
            string contentDispositionString = new ContentDisposition { FileName = displayName, Inline = true }.ToString();
            Response.AddHeader("Content-Disposition", contentDispositionString);

            return File(((MemoryStream)response.Stream).ToArray(), "application/pdf");
        }

        private Watermark GetWatermark(ViewDocumentParameters request)
        {
            if (string.IsNullOrWhiteSpace(request.WatermarkText))
                return null;

            return new Watermark(request.WatermarkText)
                {
                    Color = request.WatermarkColor.HasValue
                        ? Color.FromArgb(request.WatermarkColor.Value)
                        : Color.Red,
                    Position = ToWatermarkPosition(request.WatermarkPosition),
                    Width = request.WatermarkWidth
                };
        }

        private Watermark GetWatermark(GetFileParameters request)
        {
            if (string.IsNullOrWhiteSpace(request.WatermarkText))
                return null;

            return new Watermark(request.WatermarkText)
                {
                    Color = request.WatermarkColor.HasValue
                        ? Color.FromArgb(request.WatermarkColor.Value)
                        : Color.Red,
                    Position = ToWatermarkPosition(request.WatermarkPosition),
                    Width = request.WatermarkWidth
                };
        }

        private GroupDocs.Viewer.Domain.WatermarkPosition? ToWatermarkPosition(WatermarkPosition? watermarkPosition)
        {
            if (!watermarkPosition.HasValue)
                return GroupDocs.Viewer.Domain.WatermarkPosition.Diagonal;

            switch (watermarkPosition.Value)
            {
                case WatermarkPosition.Diagonal:
                    return GroupDocs.Viewer.Domain.WatermarkPosition.Diagonal;
                case WatermarkPosition.TopLeft:
                    return GroupDocs.Viewer.Domain.WatermarkPosition.TopLeft;
                case WatermarkPosition.TopCenter:
                    return GroupDocs.Viewer.Domain.WatermarkPosition.TopCenter;
                case WatermarkPosition.TopRight:
                    return GroupDocs.Viewer.Domain.WatermarkPosition.TopRight;
                case WatermarkPosition.BottomLeft:
                    return GroupDocs.Viewer.Domain.WatermarkPosition.BottomLeft;
                case WatermarkPosition.BottomCenter:
                    return GroupDocs.Viewer.Domain.WatermarkPosition.BottomCenter;
                case WatermarkPosition.BottomRight:
                    return GroupDocs.Viewer.Domain.WatermarkPosition.BottomRight;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

       private List<FileBrowserTreeNode> ToFileTreeNodes(string path, List<FileDescription> nodes)
        {
            return nodes.Select(_ =>
                new FileBrowserTreeNode
                {
                   path = string.IsNullOrEmpty(path) ? _.Name : string.Format("{0}/{1}", path, _.Name),
                    docType = string.IsNullOrEmpty(_.DocumentType) ? _.DocumentType : _.DocumentType.ToLower(),
                    fileType = string.IsNullOrEmpty(_.FileType) ? _.FileType : _.FileType.ToLower(),
                    name = _.Name,
                    size = _.Size,
                    modifyTime = (long)(_.LastModificationDate - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds,
                    type = _.IsDirectory? "folder":"file"
                    
                })
                .ToList();
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

        public string GetFileUrl(string path, bool getPdf, bool isPrintable, string fileDisplayName = null,
                               string watermarkText = null, int? watermarkColor = null,
                               WatermarkPosition? watermarkPosition = WatermarkPosition.Diagonal, float? watermarkWidth = 0,
                               bool ignoreDocumentAbsence = false,
                               bool useHtmlBasedEngine = false,
                               bool supportPageRotation = false)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
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

            string fileUrl = string.Format("{0}{1}?{2}", baseUrl, handlerName, queryString);
            return fileUrl;
        }

        private byte[] GetBytes(Stream input)
        {
            input.Position = 0;

            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        } 
    }
}