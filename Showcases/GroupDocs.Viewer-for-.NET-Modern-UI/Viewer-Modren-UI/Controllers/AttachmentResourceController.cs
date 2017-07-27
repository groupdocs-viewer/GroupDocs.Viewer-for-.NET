using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;
using GroupDocs.Viewer.Domain.Html;
using GroupDocs.Viewer.Handler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Viewer_Modren_UI.Helpers;

namespace Viewer_Modren_UI.Controllers
{
    [RoutePrefix("attachment/resource")]
    public class AttachmentResourceController : Controller
    {
        [Route("")]
        public ActionResult Index(string file, string attachment, int page, string resource)
        {
            var attachmentPath = "cache\\" + Path.GetFileNameWithoutExtension(file) + Path.GetExtension(file).Replace(".", "_") + "\\attachments\\" + attachment;
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            DocumentInfoContainer info = handler.GetDocumentInfo(file);
            List<int> pageNumberstoRender = new List<int>();
            pageNumberstoRender.Add(page);
            HtmlOptions o = new HtmlOptions();
            int pageNumber = page;
            o.PageNumbersToRender = pageNumberstoRender;
            o.PageNumber = page;
            o.CountPagesToRender = 1;
            List<PageHtml> pages = handler.GetPages(attachmentPath, o);
            List<HtmlResource> htmlResources = pages.Where(x => x.PageNumber == page).Select(x => x.HtmlResources).FirstOrDefault();
            var fileResource = htmlResources.Where(x => x.ResourceName == resource).FirstOrDefault();
            string type = "";
            if (fileResource != null)
            {
                switch ((int)fileResource.ResourceType)
                {
                    case 2:
                        type = "application/font-woff";
                        break;
                    case 3:

                        type = "text/css";
                        break;
                    case 1:
                        type = "image/jpeg";
                        break;
                }
                Stream stream = handler.GetResource(attachmentPath, fileResource);
                return new FileStreamResult(stream, type);
            }
            return null;
        }
    }
}