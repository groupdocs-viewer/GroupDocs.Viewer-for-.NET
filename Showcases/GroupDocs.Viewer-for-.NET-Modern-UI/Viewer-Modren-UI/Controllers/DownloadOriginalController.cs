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
    [RoutePrefix("download/original")]
    public class DownloadOriginalController : Controller
    {
        [Route("")]
        public ActionResult Get(string file)
        {
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            Stream original = null;
            try
            {
                original = handler.GetFile(file).Stream;
            }
            catch (Exception x)
            {
                throw x;
            }

            using (var ms = new MemoryStream())
            {
                original.CopyTo(ms);
                return File(ms.ToArray(), "application/octet-stream", file);
            }
        }
    }
}