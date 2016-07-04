using GroupDocs.Viewer;
using GroupDocs.Viewer.Config;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;
using GroupDocs.Viewer.Domain.Html;
using GroupDocs.Viewer.Domain.Options;
using GroupDocs.Viewer.Handler;
using GroupDocs.Viewer.WebForm.FrontEnd.BusinessLayer;
using GroupDocs.Viewer.WebForm.FrontEnd.BusinessLayer.Helpers;
using MvcSample.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WatermarkPosition = GroupDocs.Viewer.WebForm.FrontEnd.BusinessLayer.WatermarkPosition;

namespace GroupDocs.Viewer.WebForm.FrontEnd
{
    public partial class _default : System.Web.UI.Page
    {
        private static ViewerHtmlHandler _htmlHandler;
        private static ViewerImageHandler _imageHandler;
        private static readonly Dictionary<string, Stream> _streams = new Dictionary<string, Stream>();

        private static string _licensePath = @"";
        private static string _storagePath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString(); // App_Data folder path
        private static string _tempPath = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\Temp";
        private static string _CachePath = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\umar";
        private static ViewerConfig _config;

        protected void Page_Load(object sender, EventArgs e)
        {

            _config = new ViewerConfig
            {
                StoragePath = _storagePath,
                TempPath = _tempPath,
                UseCache = true
                // CachePath=_CachePath 
            };

            _htmlHandler = new ViewerHtmlHandler(_config);
            _imageHandler = new ViewerImageHandler(_config);

            HttpContext.Current.Session["imageHandler"] = _imageHandler;
            HttpContext.Current.Session["htmlHandler"] = _htmlHandler;

            // _streams.Add("Stream1.pdf", HttpWebRequest.Create("http://unfccc.int/resource/docs/convkp/kpeng.pdf").GetResponse().GetResponseStream());
            //_streams.Add("StreamExample_2.doc", HttpWebRequest.Create("http://www.acm.org/sigs/publications/pubform.doc").GetResponse().GetResponseStream());

        }

        [WebMethod]
        [ScriptMethod]
        public static ViewDocumentResponse ViewDocument(ViewDocumentParameters request)
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

            return result;

        }

        [WebMethod]
        [ScriptMethod]
        public static FileBrowserTreeDataResponse LoadFileBrowserTreeData(LoadFileBrowserTreeDataParameters parameters)
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

            return data;

        }

        [WebMethod]
        [ScriptMethod]
        public static GetImageUrlsResponse GetImageUrls(GetImageUrlsParameters parameters)
        {
            if (string.IsNullOrEmpty(parameters.Path))
            {
                var empty = new GetImageUrlsResponse { imageUrls = new string[0] };
                return empty;
            }

            DocumentInfoOptions documentInfoOptions = new DocumentInfoOptions(parameters.Path);
            DocumentInfoContainer documentInfoContainer = _imageHandler.GetDocumentInfo(documentInfoOptions);

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

            return result;
        }
        private static string GetApplicationHost()
        {
            return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/');
        }

        [WebMethod]
        [ScriptMethod]
        public static void GetFile(GetFileParameters parameters)
        {
            HttpContext.Current.Session["fileparams"] = parameters;

        }

        [WebMethod]
        [ScriptMethod]
        public static String GetPdfWithPrintDialog(GetFileParameters parameters)
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
            HttpContext.Current.Response.AddHeader("Content-Disposition", contentDispositionString);

            return "";
        }


        private static Watermark GetWatermark(ViewDocumentParameters request)
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

        private static Watermark GetWatermark(GetFileParameters request)
        {
            if (string.IsNullOrWhiteSpace(request.WatermarkText))
                return null;

            return new Watermark(request.WatermarkText)
            {
                Color = request.WatermarkColor.HasValue
                    ? Color.FromArgb(request.WatermarkColor.Value)
                    : Color.Blue,
                Position = ToWatermarkPosition(request.WatermarkPosition),
                Width = request.WatermarkWidth
            };
        }

        private static GroupDocs.Viewer.Domain.WatermarkPosition? ToWatermarkPosition(WatermarkPosition? watermarkPosition)
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

        private static List<FileBrowserTreeNode> ToFileTreeNodes(string path, List<FileDescription> nodes)
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
                    type = _.IsDirectory ? "folder" : "file"

                })
                .ToList();
        }
        private static string GetFileUrl(ViewDocumentParameters request)
        {
            return GetFileUrl(request.Path, false, false, request.FileDisplayName);
        }

        private static string GetPdfPrintUrl(ViewDocumentParameters request)
        {
            return GetFileUrl(request.Path, true, true, request.FileDisplayName,
                request.WatermarkText, request.WatermarkColor,
                request.WatermarkPosition, request.WatermarkWidth,
                request.IgnoreDocumentAbsence,
                request.UseHtmlBasedEngine, request.SupportPageRotation);
        }

        private static string GetPdfDownloadUrl(ViewDocumentParameters request)
        {
            return GetFileUrl(request.Path, true, false, request.FileDisplayName,
                request.WatermarkText, request.WatermarkColor,
                request.WatermarkPosition, request.WatermarkWidth,
                request.IgnoreDocumentAbsence,
                request.UseHtmlBasedEngine, request.SupportPageRotation);
        }

        public static string GetFileUrl(string path, bool getPdf, bool isPrintable, string fileDisplayName = null,
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
            queryString["IsPrintable"] = isPrintable.ToString();
            var baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath + "default.aspx/";

            string fileUrl = string.Format("{0}{1}?{2}", baseUrl, handlerName, queryString);
            return fileUrl;
        }

        private static byte[] GetBytes(Stream input)
        {
            input.Position = 0;

            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
        private static void ViewDocumentAsImage(ViewDocumentParameters request, ViewDocumentResponse result, string fileName)
        {
            var docInfo = _imageHandler.GetDocumentInfo(new DocumentInfoOptions(request.Path));

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

            DocumentInfoOptions documentInfoOptions = new DocumentInfoOptions(request.Path);
            DocumentInfoContainer documentInfoContainer = _imageHandler.GetDocumentInfo(documentInfoOptions);

            int[] pageNumbers = new int[documentInfoContainer.Pages.Count];
            for (int i = 0; i < documentInfoContainer.Pages.Count; i++)
            {
                pageNumbers[i] = documentInfoContainer.Pages[i].Number;
            }

            string applicationHost = GetApplicationHost();
            result.imageUrls = ImageUrlHelper.GetImageUrls(applicationHost, pageNumbers, request);
        }

        private static void ViewDocumentAsHtml(ViewDocumentParameters request, ViewDocumentResponse result, string fileName)
        {
            var htmlHandler= (ViewerHtmlHandler)HttpContext.Current.Session["htmlHandler"];
            
            var docInfo = htmlHandler.GetDocumentInfo(new DocumentInfoOptions(request.Path));

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
               // IsResourcesEmbedded = Utils.IsImage(fileName),
                IsResourcesEmbedded=false,
                HtmlResourcePrefix = string.Format("/GetResourceForHtml.aspx?documentPath={0}", fileName) + "&pageNumber={page-number}&resourceName=",
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
        [WebMethod]
        [ScriptMethod]
        public static RotatePageResponse RotatePage(RotatePageParameters parameters)
        {
            string guid = parameters.Path;
            int pageIndex = parameters.PageNumber;

            DocumentInfoOptions documentInfoOptions = new DocumentInfoOptions(guid);
            DocumentInfoContainer documentInfoContainer = _imageHandler.GetDocumentInfo(documentInfoOptions);
            int pageNumber = documentInfoContainer.Pages[pageIndex].Number;

            RotatePageOptions rotatePageOptions = new RotatePageOptions(guid, pageNumber, parameters.RotationAmount);
            RotatePageContainer rotatePageContainer = _imageHandler.RotatePage(rotatePageOptions);

            RotatePageResponse response = new RotatePageResponse
            {
                resultAngle = rotatePageContainer.CurrentRotationAngle
            };

            return response;
        }
        [WebMethod]
        [ScriptMethod]
        public static object GetDocumentPageHtml(GetDocumentPageHtmlParameters parameters)
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
                    "/GetResourceForHtml.aspx?documentPath={0}", parameters.Path) +
                                     "&pageNumber={page-number}&resourceName=",
            };

            var htmlPages = GetHtmlPages(parameters.Path, htmlOptions, out cssList);

            var pageHtml = htmlPages.Count > 0 ? htmlPages[0].HtmlContent : null;
            var pageCss = cssList.Count > 0 ? new[] { string.Join(" ", cssList) } : null;

            var result = new { pageHtml, pageCss };
            return result;
        }
        [WebMethod]
        [ScriptMethod]
        public static ReorderPageResponse ReorderPage(ReorderPageParameters parameters)
        {
            string guid = parameters.Path;

            DocumentInfoOptions documentInfoOptions = new DocumentInfoOptions(guid);
            DocumentInfoContainer documentInfoContainer = _imageHandler.GetDocumentInfo(documentInfoOptions);

            int pageNumber = documentInfoContainer.Pages[parameters.OldPosition].Number;
            int newPosition = parameters.NewPosition + 1;

            ReorderPageOptions reorderPageOptions = new ReorderPageOptions(guid, pageNumber, newPosition);
            _imageHandler.ReorderPage(reorderPageOptions);

            return (new ReorderPageResponse());
        }
        private static List<PageHtml> GetHtmlPages(string filePath, HtmlOptions htmlOptions, out List<string> cssList)
        {
            var htmlHandler = (ViewerHtmlHandler)HttpContext.Current.Session["htmlHandler"];
            var htmlPages = htmlHandler.GetPages(filePath, htmlOptions);
            
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
                        text.IndexOf("url(\"/GetResourceForHtml.aspx?documentPath=", StringComparison.Ordinal) < 0)
                    {
                        needResave = true;
                        text = text.Replace("url(\"",
                        string.Format("url(\"/GetResourceForHtml.aspx?documentPath={0}&pageNumber={1}&resourceName=",
                        filePath, page.PageNumber));
                    }

                    if (text.IndexOf("url('", StringComparison.Ordinal) >= 0 &&
                        text.IndexOf("url('/GetResourceForHtml.aspx?documentPath=", StringComparison.Ordinal) < 0)
                    {
                        needResave = true;
                        text = text.Replace("url('",
                            string.Format(
                                "url('/GetResourceForHtml.aspx?documentPath={0}&pageNumber={1}&resourceName=",
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
        private static string DownloadToStorage(string url)
        {
            var fileNameFromUrl = Utils.GetFilenameFromUrl(url);
            var filePath = Path.Combine(_storagePath, fileNameFromUrl);

            using (new InterProcessLock(filePath))
                Utils.DownloadFile(url, filePath);

            return fileNameFromUrl;
        }

        private static string SaveStreamToStorage(string key)
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



    }
}