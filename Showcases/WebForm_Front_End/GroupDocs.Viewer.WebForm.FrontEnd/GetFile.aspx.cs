using GroupDocs.Viewer;
using GroupDocs.Viewer.Config;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Options;
using GroupDocs.Viewer.Handler;
using GroupDocs.Viewer.WebForm.FrontEnd.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WatermarkPosition = GroupDocs.Viewer.WebForm.FrontEnd.BusinessLayer.WatermarkPosition;

namespace GroupDocs.Viewer.WebForm.FrontEnd
{
    public partial class GetFile : System.Web.UI.Page
    {
        private static ViewerHtmlHandler _htmlHandler;
        private static ViewerImageHandler _imageHandler;
        private static string _storagePath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString(); // App_Data folder path
        private static string _tempPath = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\Temp";
        private static ViewerConfig _config;
        protected void Page_Load(object sender, EventArgs e)
        {
            _config = new ViewerConfig
            {
                StoragePath = _storagePath,
                TempPath = _tempPath,
                UseCache = true
            };

            _htmlHandler = new ViewerHtmlHandler(_config);
            _imageHandler = new ViewerImageHandler(_config);

            var parameters = (GetFileParameters)Session["fileparams"];
            Session.RemoveAll();
            
            var displayName = string.IsNullOrEmpty(parameters.DisplayName) ?
                           Path.GetFileName(parameters.Path) : Uri.EscapeDataString(parameters.DisplayName);

            Stream fileStream;
            if (parameters.GetPdf || parameters.IsPrintable)
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
            HttpContext.Current.Response.SetCookie(new HttpCookie("jqueryFileDownloadJSForGD", "true") { Path = "/" });
            byte[] Bytes = new byte[fileStream.Length];
            fileStream.Read(Bytes, 0, Bytes.Length);
            string contentDispositionString="attachment; filename=\"" + displayName + "\"";

            if (parameters.IsPrintable)
            {
               contentDispositionString = new ContentDisposition { FileName = displayName, Inline = true }.ToString();
            }
            if (parameters.IsPrintable)
                HttpContext.Current.Response.ContentType = "application/pdf";
            else
            HttpContext.Current.Response.ContentType = "application/octet-stream";

            HttpContext.Current.Response.AddHeader("Content-Disposition", contentDispositionString);
            HttpContext.Current.Response.AddHeader("Content-Length", fileStream.Length.ToString());
            HttpContext.Current.Response.OutputStream.Write(Bytes, 0, Bytes.Length);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        private  Watermark GetWatermark(GetFileParameters request)
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
        private  GroupDocs.Viewer.Domain.WatermarkPosition? ToWatermarkPosition(WatermarkPosition? watermarkPosition)
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
    
    }
}