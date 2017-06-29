using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Html;
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
    [RoutePrefix("Attachment/html")]
    public class AttachmentHtmlController : Controller
    {
        [Route("")]
        public ActionResult Get(string file, string attachment, int page)
        {
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();

            List<int> pageNumberstoRender = new List<int>();
            var docInfo = handler.GetDocumentInfo(file);
            pageNumberstoRender.Add(page);
            HtmlOptions o = new HtmlOptions();
            o.PageNumbersToRender = pageNumberstoRender;
            o.PageNumber = page;
            o.CountPagesToRender = 1;
            o.HtmlResourcePrefix = (String.Format(
                    "/page/resource?file=%s&page=%d&resource=",
                    file,
                    page
            ));

            List<PageHtml> list = Utils.LoadPageHtmlList(handler, file, o);
            string fullHtml = "";
            foreach (AttachmentBase attachmentBase in docInfo.Attachments.Where(x => x.Name == attachment))
            {
                // Get attachment document html representation
                List<PageHtml> pages = handler.GetPages(attachmentBase, o);
                foreach (PageHtml pageHtml in pages.Where(x => x.PageNumber == page)) { fullHtml += pageHtml.HtmlContent; };
            }


            return Content(fullHtml);
        }
    }
}