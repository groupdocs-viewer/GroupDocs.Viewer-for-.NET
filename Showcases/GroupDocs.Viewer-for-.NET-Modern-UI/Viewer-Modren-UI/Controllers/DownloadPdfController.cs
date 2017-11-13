using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Options;
using GroupDocs.Viewer.Handler;
using System;
using System.IO;
using System.Web.Mvc;
using Viewer_Modren_UI.Helpers;

namespace Viewer_Modren_UI.Controllers
{
    [RoutePrefix("download/pdf")]
    public class DownloadPdfController : Controller
    {
        [Route("")]
        public ActionResult Get(string file, string watermarkText, int? watermarkColor, WatermarkPosition? watermarkPosition, int? watermarkWidth, byte watermarkOpacity, bool isdownload)
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

            if (isdownload)
            {
                Response.Headers.Add("content-disposition", "attachment; filename=" + Path.GetFileNameWithoutExtension(file) + ".pdf");
                return new FileStreamResult(pdf, "application/octet-stream");
            }
            else
            {
                return new FileStreamResult(pdf, "application/pdf");
            }
        }
    }
}