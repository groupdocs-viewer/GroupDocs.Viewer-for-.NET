using GroupDocs.Viewer.Handler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viewer_Modren_UI.Helpers;

namespace Viewer_Modren_UI.Controllers
{
    [RoutePrefix("download/pdf")]
    public class DownloadPdfController : Controller
    {
        [Route("")]
        public ActionResult Get(string file)
        {
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();

            Stream pdf = null;
            try
            {
                pdf = handler.GetPdfFile(file).Stream;
            }
            catch (Exception x)
            {
                throw x;
            }

            return new FileStreamResult(pdf, "application/pdf");
        }
    }
}