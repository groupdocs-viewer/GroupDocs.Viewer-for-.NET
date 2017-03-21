using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupDocs.Viewer.Handler;
using Viewer_Modren_UI.Helpers;
using GroupDocs.Viewer.Domain;

namespace Viewer_Modren_UI.Controllers
{
    [RoutePrefix("files")]
    public class FileListController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            List<FileDescription> tree = null;
            try
            {
                tree = handler.GetFileList().Files;
            }
            catch (Exception)
            {
                throw;
            }
            List<String> result = tree.Where(x => x.Name != "README.txt" 
                                             && !x.IsDirectory
                                             && !String.IsNullOrWhiteSpace(x.Name)
                                             && !String.IsNullOrWhiteSpace(x.DocumentType))
                                             .Select(x => x.Name).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}