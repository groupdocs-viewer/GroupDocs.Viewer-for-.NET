using GroupDocs.Viewer.Handler;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Viewer_Modren_UI.Helpers;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Options;

namespace WebForm_Modern_UI.Controllers
{

    public class DownloadPdfController : ApiController
    {
    
        public HttpResponseMessage Get(string file, string watermarkText, int? watermarkColor, WatermarkPosition? watermarkPosition, int? watermarkWidth, byte watermarkOpacity)
        {
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();

            Stream pdf = null;
            try
            {
                PdfFileOptions o = new PdfFileOptions();
                if (watermarkText != "")
                    o.Watermark = Utils.GetWatermark(watermarkText, watermarkColor, watermarkPosition, watermarkWidth, watermarkOpacity);
                pdf = handler.GetPdfFile(file, o).Stream;
            }
            catch (Exception x)
            {
                throw x;
            }
            using (var ms = new MemoryStream())
            {
                pdf.CopyTo(ms);
                var result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(ms.ToArray())
                };
                result.Content.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = Path.GetFileNameWithoutExtension(file) + ".pdf"
                    };
                result.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/pdf");

                return result;
            }
        }
    }
}