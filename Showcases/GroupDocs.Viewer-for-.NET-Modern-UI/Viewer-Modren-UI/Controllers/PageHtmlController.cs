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
    [RoutePrefix("page/html")]
    public class PageHtmlController : Controller
    {
        [Route("")]
        public ActionResult Get(string file, int page)
        {
            
            if (Utils.IsValidUrl(file))
                file = Utils.DownloadToStorage(file);
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
          
            List<int> pageNumberstoRender = new List<int>();
            pageNumberstoRender.Add(page);
            HtmlOptions o = new HtmlOptions();
            o.PageNumbersToRender = pageNumberstoRender;
            o.PageNumber = page;
            o.CountPagesToRender = 1;
            o.HtmlResourcePrefix = "/page/resource?file="+file+"&page="+page+"&resource=";
            List<PageHtml> list = Utils.LoadPageHtmlList(handler, file, o);
            string fullHtml = "";
            foreach (PageHtml pageHtml in list.Where(x => x.PageNumber == page)) { fullHtml = pageHtml.HtmlContent; };
            return Content(fullHtml);
        }

    }
}