using GroupDocs.Viewer;
using GroupDocs.Viewer.Config;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain.Html;
using GroupDocs.Viewer.Domain.Image;
using GroupDocs.Viewer.Handler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace Viewer_Modren_UI.Helpers
{
    public class Utils
    {
      
        private static string _storagePath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        private static string _tempPath = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\temp";
        private static string _cachePath = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\cache";
        public static ViewerHtmlHandler CreateViewerHtmlHandler()
        {
            ViewerHtmlHandler handler = new ViewerHtmlHandler(CreateViewerConfig());
            return handler;
        }
        public static ViewerImageHandler CreateViewerImageHandler()
        {
            ViewerImageHandler handler = new ViewerImageHandler(CreateViewerConfig());
            return handler;
        }

        public static ViewerConfig CreateViewerConfig()
        {
            ViewerConfig cfg = new ViewerConfig
            {
                StoragePath = _storagePath,
                CachePath = _cachePath,
                UseCache = false
            };
            return cfg;
        }
        public static List<PageHtml> LoadPageHtmlList(ViewerHtmlHandler handler, String filename, HtmlOptions options)
        {
            try
            {
                return handler.GetPages(filename, options);
            }
            catch (Exception x)
            {
                throw x;
            }
        }
        public static List<PageImage> LoadPageImageList(ViewerImageHandler handler, String filename, ImageOptions options)
        {
            try
            {
                return handler.GetPages(filename, options);
            }
            catch (Exception x)
            {
                throw x;
            }
        }
        public static bool IsValidUrl(string urlToValidate)
        {
            if (string.IsNullOrWhiteSpace(urlToValidate))
            {
                return false;
            }
            //http://stackoverflow.com/a/27443764
            Uri uriResult;
            bool result = Uri.TryCreate(urlToValidate, UriKind.Absolute, out uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp
                              || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }
        public static string DownloadToStorage(string url)
        {
            var fileNameFromUrl = Utils.GetFilenameFromUrl(url);
            var filePath = Path.Combine(_storagePath, fileNameFromUrl);
            Utils.DownloadFile(url, filePath);
            return fileNameFromUrl;
        }
        public static string GetFilenameFromUrl(string name)
        {
            string filename = Regex.Replace(name, @"[\:\/\?\&\%\=\#]", "_");

            const int maxFilenameLength = 200;
            int length = filename.Length;
            if (length > maxFilenameLength)
                length = maxFilenameLength;

            filename = filename.Substring(0, length);

            filename = filename.Replace("___", "_");
            filename = filename.Replace("__", "_");

            return filename;
        }
        public static string DownloadFile(string url, string outputFilePath)
        {
            string resultPath = outputFilePath;
            const int bufferSize = 16 * 1024;

            // MHT, MHTML, VDX, VSS, VSX, VST, VTX, VSDX, VDW, MPT, MSG
            Dictionary<string, string> supportedMimeTypes = new Dictionary<string, string>()
            {
                {"application/msword", "doc"},
                {"application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx"},
                {"application/vnd.ms-word.document.macroenabled.12", "docm"},
                {"application/vnd.openxmlformats-officedocument.wordprocessingml.template", "dotx"},
                {"application/vnd.ms-word.template.macroenabled.12", "dotm"},

                {"application/vnd.ms-excel", "xls"},
                {"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx"},
                {"application/vnd.ms-excel.sheet.macroenabled.12", "xlsm"},
                {"application/vnd.ms-excel.sheet.binary.macroenabled.12", "xlsb"},

                {"application/vnd.ms-powerpoint", "ppt"},
                {"application/vnd.openxmlformats-officedocument.presentationml.presentation", "pptx"},

                {"application/vnd.visio", "vsd"},
                {"application/x-visio", "vsd"},

                {"application/vnd.ms-project", "mpp"},
                {"application/x-project", "mpt "},

                {"application/vnd.ms-outlook", "msg"},
                {"message/rfc822", "eml"},

                {"application/vnd.oasis.opendocument.text", "odt"},
                {"application/vnd.oasis.opendocument.text-template", "ott"},
                {"application/vnd.oasis.opendocument.spreadsheet", "ods"},
                {"application/vnd.oasis.opendocument.presentation", "odp"},
                {"text/plain", "txt"},
                {"application/x-mimearchive", "mhtml"}, // MIME type for MHTML is not well agreed upon.
                
                {"application/vnd.ms-xpsdocument", "xps"},
                {" image/vnd.dxf", "dxf"},
                {"application/epub+zip", "epub"}
            };

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            // Must assign a cookie container for the request to pull the cookies
            request.CookieContainer = new CookieContainer();

            using (WebResponse response = request.GetResponse())
            {
                string fileName = null;
                string fileNameExtension = null;
                string contentDisposition = response.Headers["Content-Disposition"];
                if (contentDisposition != null)
                {
                    Match fileNameMatch = Regex.Match(contentDisposition, "filename=(.+?)$");
                    if (fileNameMatch.Success)
                        fileName = fileNameMatch.Result("$1");
                }

                string contentType = response.Headers["Content-Type"];
                if (contentType != null)
                {
                    bool mimeTypeIsFound = supportedMimeTypes.TryGetValue(contentType, out fileNameExtension);
                    if (!mimeTypeIsFound)
                    {
                        int slashPosition = contentType.LastIndexOf('/');
                        if (slashPosition != -1 && slashPosition + 1 < contentType.Length - 1)
                        {
                            int semicolonPosition = contentType.LastIndexOf(';');
                            int length = contentType.Length - (slashPosition + 1);
                            if (semicolonPosition != -1 && semicolonPosition - 1 > slashPosition)
                                length = semicolonPosition - 1 - slashPosition;
                            fileNameExtension = contentType.Substring(slashPosition + 1, length);
                        }
                    }
                }

                if (fileName != null)
                {
                    fileName = fileName.Trim('\"').Trim(';').Trim('\"');
                    string ext = Path.GetExtension(fileName);
                    resultPath = Path.ChangeExtension(outputFilePath, ext);
                }
                else if (fileNameExtension != null)
                    resultPath = Path.ChangeExtension(outputFilePath, fileNameExtension);

                if (!System.IO.File.Exists(resultPath))
                {
                    using (var outputFileStream = System.IO.File.Create(resultPath, bufferSize))
                    {
                        using (var responseStream = response.GetResponseStream())
                        {
                            if (responseStream != null)
                            {
                                var buffer = new byte[bufferSize];
                                int bytesRead;

                                do
                                {
                                    bytesRead = responseStream.Read(buffer, 0, bufferSize);
                                    outputFileStream.Write(buffer, 0, bytesRead);
                                } while (bytesRead > 0);
                            }
                        }
                    }
                }
            }
            return resultPath;
        }
        public static List<PageHtml> LoadAttachmentHtmlList(ViewerHtmlHandler handler, String filename, String attahchment, HtmlOptions options)
        {
            try
            {
                return handler.GetPages(_cachePath + "\\" + Path.GetFileNameWithoutExtension(filename) + Path.GetExtension(filename).Replace(".", "_") + "\\attachments\\" + attahchment, options);
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
       
    
}