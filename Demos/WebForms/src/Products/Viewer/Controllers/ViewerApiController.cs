using GroupDocs.Viewer.Exceptions;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer.WebForms.Products.Common.Entity.Web;
using GroupDocs.Viewer.WebForms.Products.Common.Resources;
using GroupDocs.Viewer.WebForms.Products.Common.Util.Comparator;
using GroupDocs.Viewer.WebForms.Products.Viewer.Cache;
using GroupDocs.Viewer.WebForms.Products.Viewer.Config;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Xml.Linq;
using WebGrease.Css.Extensions;

namespace GroupDocs.Viewer.WebForms.Products.Viewer.Controllers
{
    /// <summary>
    /// ViewerApiController.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ViewerApiController : ApiController
    {
        /// <summary>
        /// Map for locking keys in viewer cache.
        /// </summary>
        protected static readonly ConcurrentDictionary<string, object> KeyLockerMap = new ConcurrentDictionary<string, object>();

        private static readonly Common.Config.GlobalConfiguration globalConfiguration = new Common.Config.GlobalConfiguration();

        private static readonly string cachePath = Path.Combine(globalConfiguration.Viewer.GetFilesDirectory(), globalConfiguration.Viewer.GetCacheFolderName());

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewerApiController"/> class.
        /// </summary>
        public ViewerApiController()
        {
            List<string> fontsDirectory = new List<string>();
            if (!string.IsNullOrEmpty(globalConfiguration.Viewer.GetFontsDirectory()))
            {
                fontsDirectory.Add(globalConfiguration.Viewer.GetFontsDirectory());
            }
        }

        /// <summary>
        /// Loads Viewer configuration.
        /// </summary>
        /// <returns>Viewer configuration.</returns>
        [HttpGet]
        [Route("loadConfig")]
        public ViewerConfiguration LoadConfig()
        {
            return globalConfiguration.Viewer;
        }

        /// <summary>
        /// Gets all files and directories from sample directory:
        /// src/DocumentSamples/Viewer/.
        /// </summary>
        /// <returns>List of files and directories.</returns>
        [HttpPost]
        [Route("loadFileTree")]
        public HttpResponseMessage GetFileTree()
        {
            try
            {
                List<FileDescriptionEntity> filesList = new List<FileDescriptionEntity>();

                if (!string.IsNullOrEmpty(globalConfiguration.Viewer.GetFilesDirectory()))
                {
                    var currentPath = globalConfiguration.Viewer.GetFilesDirectory();
                    List<string> allFiles = new List<string>(Directory.GetFiles(currentPath));
                    allFiles.AddRange(Directory.GetDirectories(currentPath));

                    string cacheFolderName = globalConfiguration.Viewer.GetCacheFolderName();

                    allFiles.Sort(new FileNameComparator());
                    allFiles.Sort(new FileDateComparator());

                    foreach (string file in allFiles)
                    {
                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);

                        // check if current file/folder is hidden
                        if (!(cacheFolderName.Equals(Path.GetFileName(file)) ||
                              Path.GetFileName(file).StartsWith(".") ||
                              fileInfo.Attributes.HasFlag(FileAttributes.Hidden) ||
                              Path.GetFileName(file).Equals(Path.GetFileName(globalConfiguration.Viewer.GetFilesDirectory()))))
                        {
                            FileDescriptionEntity fileDescription = new FileDescriptionEntity
                            {
                                guid = Path.GetFullPath(file),
                                name = Path.GetFileName(file),

                                // set is directory true/false
                                isDirectory = fileInfo.Attributes.HasFlag(FileAttributes.Directory),
                            };

                            // set file size
                            if (!fileDescription.isDirectory)
                            {
                                fileDescription.size = fileInfo.Length;
                            }

                            // add object to array list
                            filesList.Add(fileDescription);
                        }
                    }
                }

                return this.Request.CreateResponse(HttpStatusCode.OK, filesList);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, Resources.GenerateException(ex));
            }
        }

        /// <summary>
        /// Gets document pages data, dimensions and angles.
        /// </summary>
        /// <param name="postedData">Posted data with document guid.</param>
        /// <returns>Document pages data, dimensions and angles.</returns>
        [HttpPost]
        [Route("loadDocumentDescription")]
        public HttpResponseMessage GetDocumentData(PostedDataEntity postedData)
        {
            try
            {
                LoadDocumentEntity loadDocumentEntity = GetDocumentPages(postedData, globalConfiguration.Viewer.GetPreloadPageCount() == 0);

                // return document description
                return this.Request.CreateResponse(HttpStatusCode.OK, loadDocumentEntity);
            }
            catch (PasswordRequiredException ex)
            {
                // set exception message
                return this.Request.CreateResponse(HttpStatusCode.Forbidden, Resources.GenerateException(ex, postedData.password));
            }
            catch (Exception ex)
            {
                // set exception message
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, Resources.GenerateException(ex, postedData.password));
            }
        }

        /// <summary>
        /// Gets document page info.
        /// </summary>
        /// <param name="postedData">Posted data with page number.</param>
        /// <returns>Document page info.</returns>
        [HttpPost]
        [Route("loadDocumentPage")]
        public HttpResponseMessage GetDocumentPage(PostedDataEntity postedData)
        {
            string password = string.Empty;
            try
            {
                string documentGuid = postedData.guid;
                int pageNumber = postedData.page;
                password = string.IsNullOrEmpty(postedData.password) ? null : postedData.password;

                var fileFolderName = Path.GetFileName(documentGuid).Replace(".", "_");
                string fileCacheSubFolder = Path.Combine(cachePath, fileFolderName);

                IViewerCache cache = new FileViewerCache(cachePath, fileCacheSubFolder);

                PageDescriptionEntity page;
                if (globalConfiguration.Viewer.GetIsHtmlMode())
                {
                    using (HtmlViewer htmlViewer = new HtmlViewer(documentGuid, cache, GetLoadOptions(password)))
                    {
                        page = this.GetPageDescritpionEntity(htmlViewer, documentGuid, pageNumber, fileCacheSubFolder);
                    }
                }
                else
                {
                    using (PngViewer pngViewer = new PngViewer(documentGuid, cache, GetLoadOptions(password)))
                    {
                        page = this.GetPageDescritpionEntity(pngViewer, documentGuid, pageNumber, fileCacheSubFolder);
                    }
                }

                return this.Request.CreateResponse(HttpStatusCode.OK, page);
            }
            catch (Exception ex)
            {
                // set exception message
                return this.Request.CreateResponse(HttpStatusCode.Forbidden, Resources.GenerateException(ex, password));
            }
        }

        /// <summary>
        /// Rotates specific page(s) of the document.
        /// </summary>
        /// <param name="postedData">Document page number to rotate and rotation angle.</param>
        /// <returns>Rotated document page object.</returns>
        [HttpPost]
        [Route("rotateDocumentPages")]
        public HttpResponseMessage RotateDocumentPages(PostedDataEntity postedData)
        {
            try
            {
                var documentGuid = postedData.guid;
                var pageNumber = postedData.pages[0];
                string password = string.IsNullOrEmpty(postedData.password) ? null : postedData.password;

                var fileFolderName = Path.GetFileName(documentGuid).Replace(".", "_");
                string fileCacheSubFolder = Path.Combine(cachePath, fileFolderName);

                // Delete page cache-files before regenerating with another angle.
                var cacheFiles = Directory.GetFiles(fileCacheSubFolder).Where(f => Path.GetFileName(f).StartsWith($"p{pageNumber}"));
                cacheFiles.ForEach(f => File.Delete(f));

                // Getting new rotation angle value.
                var currentAngle = GetCurrentAngle(pageNumber, Path.Combine(fileCacheSubFolder, "PagesInfo.xml"));
                int newAngle = GetNewAngleValue(currentAngle, postedData.angle);
                SaveChangedAngleInCache(fileCacheSubFolder, pageNumber, newAngle);

                IViewerCache cache = new FileViewerCache(cachePath, fileCacheSubFolder);
                PageDescriptionEntity page;
                if (globalConfiguration.Viewer.GetIsHtmlMode())
                {
                    using (HtmlViewer htmlViewer = new HtmlViewer(documentGuid, cache, GetLoadOptions(password), pageNumber, newAngle))
                    {
                        page = this.GetPageDescritpionEntity(htmlViewer, documentGuid, pageNumber, fileCacheSubFolder);
                    }
                }
                else
                {
                    using (PngViewer pngViewer = new PngViewer(documentGuid, cache, GetLoadOptions(password), pageNumber, newAngle))
                    {
                        page = this.GetPageDescritpionEntity(pngViewer, documentGuid, pageNumber, fileCacheSubFolder);
                    }
                }

                return this.Request.CreateResponse(HttpStatusCode.OK, page);
            }
            catch (Exception ex)
            {
                // set exception message
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, Resources.GenerateException(ex));
            }
        }

        /// <summary>
        /// Downloads curerntly viewed document.
        /// </summary>
        /// <param name="path">Path of the document to download.</param>
        /// <returns>Document stream as attachement.</returns>
        [HttpGet]
        [Route("downloadDocument")]
        public HttpResponseMessage DownloadDocument(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                if (File.Exists(path))
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    var fileStream = new FileStream(path, FileMode.Open);
                    response.Content = new StreamContent(fileStream);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = Path.GetFileName(path);
                    return response;
                }
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Downloads requested resource file.
        /// </summary>
        /// <param name="guid">Name of the file containing resource.</param>
        /// <param name="resourceName">Name of the resource file.</param>
        /// <returns>Document stream as attachement.</returns>
        [HttpGet]
        [Route("resources/{guid}/{resourceName}")]
        public HttpResponseMessage GetResource(string guid, string resourceName)
        {
            if (!string.IsNullOrEmpty(guid))
            {
                var path = Path.Combine(globalConfiguration.Viewer.GetFilesDirectory(), globalConfiguration.Viewer.GetCacheFolderName());
                path = Path.Combine(path, guid);
                path = Path.Combine(path, resourceName);

                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                response.Content = new StreamContent(fileStream);
                var fileName = Path.GetFileName(path);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(fileName));
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline");
                response.Content.Headers.ContentDisposition.FileName = fileName;
                return response;
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Uploads document.
        /// </summary>
        /// <returns>Uploaded document object.</returns>
        [HttpPost]
        [Route("uploadDocument")]
        public HttpResponseMessage UploadDocument()
        {
            try
            {
                string url = HttpContext.Current.Request.Form["url"];

                // get documents storage path
                string documentStoragePath = globalConfiguration.Viewer.GetFilesDirectory();
                bool rewrite = bool.Parse(HttpContext.Current.Request.Form["rewrite"]);
                string fileSavePath = string.Empty;
                if (string.IsNullOrEmpty(url))
                {
                    if (HttpContext.Current.Request.Files.AllKeys != null)
                    {
                        // Get the uploaded document from the Files collection
                        var httpPostedFile = HttpContext.Current.Request.Files["file"];
                        if (httpPostedFile != null)
                        {
                            if (rewrite)
                            {
                                // Get the complete file path
                                fileSavePath = Path.Combine(documentStoragePath, httpPostedFile.FileName);
                            }
                            else
                            {
                                fileSavePath = Resources.GetFreeFileName(documentStoragePath, httpPostedFile.FileName);
                            }

                            // Save the uploaded file to "UploadedFiles" folder
                            httpPostedFile.SaveAs(fileSavePath);
                        }
                    }
                }
                else
                {
                    using (WebClient client = new WebClient())
                    {
                        // get file name from the URL
                        Uri uri = new Uri(url);
                        string fileName = Path.GetFileName(uri.LocalPath);
                        if (rewrite)
                        {
                            // Get the complete file path
                            fileSavePath = Path.Combine(documentStoragePath, fileName);
                        }
                        else
                        {
                            fileSavePath = Resources.GetFreeFileName(documentStoragePath, fileName);
                        }

                        // Download the Web resource and save it into the current filesystem folder.
                        client.DownloadFile(url, fileSavePath);
                    }
                }

                UploadedDocumentEntity uploadedDocument = new UploadedDocumentEntity
                {
                    guid = fileSavePath,
                };

                return this.Request.CreateResponse(HttpStatusCode.OK, uploadedDocument);
            }
            catch (Exception ex)
            {
                // set exception message
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, Resources.GenerateException(ex));
            }
        }

        /// <summary>
        /// Loads document pages thumbnails.
        /// </summary>
        /// <param name="loadDocumentRequest">Posted data with document guid.</param>
        /// <returns>Data of all document pages.</returns>
        [HttpPost]
        [Route("loadThumbnails")]
        public LoadDocumentEntity GetPagesThumbnails(PostedDataEntity loadDocumentRequest)
        {
            return GetDocumentPages(loadDocumentRequest, true);
        }

        /// <summary>
        /// Loads print version.
        /// </summary>
        /// <param name="loadDocumentRequest">PostedDataEntity.</param>
        /// <returns>Data of all document pages.</returns>
        [HttpPost]
        [Route("loadPrint")]
        public HttpResponseMessage GetPrintVersion(PostedDataEntity loadDocumentRequest)
        {
            try
            {
                LoadDocumentEntity loadPrintDocument = GetDocumentPages(loadDocumentRequest, true, true);

                // return document description
                return this.Request.CreateResponse(HttpStatusCode.OK, loadPrintDocument);
            }
            catch (Exception ex)
            {
                // set exception message
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, Resources.GenerateException(ex, loadDocumentRequest.password));
            }
        }

        /// <summary>
        /// Gets page dimensions and rotation angle.
        /// </summary>
        /// <param name="page">Page object.</param>
        /// <param name="pagesInfoPath">Path to file with pages rotation angles data.</param>
        /// <returns>Page dimensions and rotation angle.</returns>
        private static PageDescriptionEntity GetPageInfo(Page page, string pagesInfoPath)
        {
            int currentAngle = GetCurrentAngle(page.Number, pagesInfoPath);

            PageDescriptionEntity pageDescriptionEntity = new PageDescriptionEntity
            {
                number = page.Number,

                // we intentionally use the 0 here because we plan to rotate only the page background using height/width
                angle = 0,
                height = currentAngle == 0 || currentAngle == 180 ? page.Height : page.Width,
                width = currentAngle == 0 || currentAngle == 180 ? page.Width : page.Height,
                sheetName = page.Name,
            };

            return pageDescriptionEntity;
        }

        /// <summary>
        /// Gets page content as a string.
        /// </summary>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="documentGuid">Document path.</param>
        /// <param name="cachePath">Cache path.</param>
        /// <returns>Page content as a string.</returns>
        private static string GetPageContent(int pageNumber, string documentGuid, string cachePath, bool printVersion)
        {
            var fileFolderName = Path.GetFileName(documentGuid).Replace(".", "_");

            if (globalConfiguration.Viewer.GetIsHtmlMode() && !printVersion)
            {
                string htmlFilePath = $"{cachePath}/{fileFolderName}/p{pageNumber}.html";
                return File.ReadAllText(htmlFilePath);
            }
            else
            {
                string pngFilePath = $"{cachePath}/{fileFolderName}/p{pageNumber}.png";

                byte[] imageBytes = null;
                using (Image image = Image.FromFile(pngFilePath))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        imageBytes = m.ToArray();
                    }
                }

                return Convert.ToBase64String(imageBytes);
            }
        }

        /// <summary>
        /// Gets current rotation angle of the page.
        /// </summary>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="pagesInfoPath">Path to file with pages rotation angles data.</param>
        /// <returns>Current rotation angle of the page.</returns>
        private static int GetCurrentAngle(int pageNumber, string pagesInfoPath)
        {
            XDocument xdoc = XDocument.Load(pagesInfoPath);
            var pageData = xdoc.Descendants()?.Elements("Number")?.Where(x => int.Parse(x.Value) == pageNumber)?.Ancestors("PageData");
            var angle = pageData?.Elements("Angle").FirstOrDefault();

            if (angle != null)
            {
                return int.Parse(angle.Value);
            }

            return 0;
        }

        /// <summary>
        /// Gets document load options used in Viewer object constructor.
        /// </summary>
        /// <param name="password">Document password.</param>
        /// <returns>Load options object.</returns>
        private static Options.LoadOptions GetLoadOptions(string password)
        {
            Options.LoadOptions loadOptions = new Options.LoadOptions
            {
                Password = password,
            };

            return loadOptions;
        }

        /// <summary>
        /// Saves changed page rotation angle in cache.
        /// </summary>
        /// <param name="fileCacheSubFolder">Cache files path.</param>
        /// <param name="pageNumber">Page number.</param>
        /// <param name="newAngle">New angle value.</param>
        private static void SaveChangedAngleInCache(string fileCacheSubFolder, int pageNumber, int newAngle)
        {
            var pagesInfoPath = Path.Combine(fileCacheSubFolder, "PagesInfo.xml");

            if (File.Exists(pagesInfoPath))
            {
                XDocument xdoc = XDocument.Load(pagesInfoPath);
                var pageData = xdoc.Descendants()?.Elements("Number")?.Where(x => int.Parse(x.Value) == pageNumber)?.Ancestors("PageData");
                var angle = pageData?.Elements("Angle").FirstOrDefault();

                if (angle != null)
                {
                    angle.Value = newAngle.ToString(CultureInfo.InvariantCulture);
                }

                xdoc.Save(pagesInfoPath);
            }
        }

        /// <summary>
        /// Calculates new page rotation angle value.
        /// </summary>
        /// <param name="currentAngle">Current page rotation angle value.</param>
        /// <param name="postedAngle">Posted page rotation angle value.</param>
        /// <returns>New page rotation angle value.</returns>
        private static int GetNewAngleValue(int currentAngle, int postedAngle)
        {
            switch (currentAngle)
            {
                case 0:
                    return postedAngle == 90 ? 90 : 270;
                case 90:
                    return postedAngle == 90 ? 180 : 0;
                case 180:
                    return postedAngle == 90 ? 270 : 90;
                case 270:
                    return postedAngle == 90 ? 0 : 180;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Gets document pages data, dimensions and rotation angles.
        /// </summary>
        /// <param name="postedData">Posted data with document guid.</param>
        /// <param name="loadAllPages">Flag to load all pages.</param>
        /// <returns>Document pages data, dimensions and rotation angles.</returns>
        private static LoadDocumentEntity GetDocumentPages(PostedDataEntity postedData, bool loadAllPages, bool printVersion = false)
        {
            // get/set parameters
            string documentGuid = postedData.guid;
            string password = string.IsNullOrEmpty(postedData.password) ? null : postedData.password;

            var fileFolderName = Path.GetFileName(documentGuid).Replace(".", "_");
            string fileCacheSubFolder = Path.Combine(cachePath, fileFolderName);

            if (!File.Exists(documentGuid))
            {
                throw new GroupDocsViewerException("File not found.");
            }

            IViewerCache cache = new FileViewerCache(cachePath, fileCacheSubFolder);

            LoadDocumentEntity loadDocumentEntity;
            if (globalConfiguration.Viewer.GetIsHtmlMode() && !printVersion)
            {
                using (HtmlViewer htmlViewer = new HtmlViewer(documentGuid, cache, GetLoadOptions(password)))
                {
                    loadDocumentEntity = GetLoadDocumentEntity(loadAllPages, documentGuid, fileCacheSubFolder, htmlViewer, printVersion);
                }
            }
            else
            {
                using (PngViewer pngViewer = new PngViewer(documentGuid, cache, GetLoadOptions(password)))
                {
                    loadDocumentEntity = GetLoadDocumentEntity(loadAllPages, documentGuid, fileCacheSubFolder, pngViewer, printVersion);
                }
            }

            return loadDocumentEntity;
        }

        private static LoadDocumentEntity GetLoadDocumentEntity(bool loadAllPages, string documentGuid, string fileCacheSubFolder, ICustomViewer customViewer, bool printVersion)
        {
            if (loadAllPages)
            {
                customViewer.CreateCache();
            }

            dynamic viewInfo = customViewer.GetViewer().GetViewInfo(ViewInfoOptions.ForHtmlView());
            LoadDocumentEntity loadDocumentEntity = new LoadDocumentEntity();

            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }

            string pagesInfoPath;
            TryCreatePagesInfoXml(fileCacheSubFolder, viewInfo, out pagesInfoPath);

            foreach (Page page in viewInfo.Pages)
            {
                PageDescriptionEntity pageData = GetPageInfo(page, pagesInfoPath);
                if (loadAllPages)
                {
                    pageData.SetData(GetPageContent(page.Number, documentGuid, cachePath, printVersion));
                }

                loadDocumentEntity.SetPages(pageData);
            }

            loadDocumentEntity.SetGuid(documentGuid);
            return loadDocumentEntity;
        }

        private static void TryCreatePagesInfoXml(string fileCacheSubFolder, dynamic viewInfo, out string pagesInfoPath)
        {
            if (!Directory.Exists(fileCacheSubFolder))
            {
                Directory.CreateDirectory(fileCacheSubFolder);
            }

            pagesInfoPath = Path.Combine(fileCacheSubFolder, "PagesInfo.xml");

            if (!File.Exists(pagesInfoPath))
            {
                var xdoc = new XDocument(new XElement("Pages"));

                foreach (var page in viewInfo.Pages)
                {
                    xdoc.Element("Pages")
                        .Add(new XElement(
                            "PageData",
                            new XElement("Number", page.Number),
                            new XElement("Angle", 0)));
                }

                xdoc.Save(pagesInfoPath);
            }
        }

        private PageDescriptionEntity GetPageDescritpionEntity(ICustomViewer customViewer, string documentGuid, int pageNumber, string fileCacheSubFolder)
        {
            PageDescriptionEntity page;
            customViewer.CreateCache();

            var viewInfo = customViewer.GetViewer().GetViewInfo(ViewInfoOptions.ForHtmlView());
            page = GetPageInfo(viewInfo.Pages[pageNumber - 1], Path.Combine(fileCacheSubFolder, "PagesInfo.xml"));
            page.SetData(GetPageContent(pageNumber, documentGuid, cachePath, false));

            return page;
        }
    }
}