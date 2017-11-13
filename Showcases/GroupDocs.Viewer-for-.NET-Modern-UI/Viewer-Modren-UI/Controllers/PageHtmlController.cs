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
using static Viewer_Modren_UI.Helpers.Utils;

namespace Viewer_Modren_UI.Controllers
{
    [RoutePrefix("page/html")]
    public class PageHtmlController : Controller
    {
        [Route("")]
        public ActionResult Get(string file, int page, string watermarkText, int? watermarkColor, WatermarkPosition? watermarkPosition, int? watermarkWidth, byte watermarkOpacity)
        {
            
            if (Utils.IsValidUrl(file))
                file = Utils.DownloadToStorage(file);
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            
            List<int> pageNumberstoRender = new List<int>();
            pageNumberstoRender.Add(page);
            HtmlOptions options = new HtmlOptions();

            options.PageNumbersToRender = pageNumberstoRender;
            options.PageNumber = page;
            options.CountPagesToRender = 1;
            options.HtmlResourcePrefix = "/page/resource?file="+file+"&page="+page+"&resource=";
            if(watermarkText!="")
                options.Watermark = Utils.GetWatermark(watermarkText, watermarkColor, watermarkPosition, watermarkWidth, watermarkOpacity);

            List<PageHtml> list = Utils.LoadPageHtmlList(handler, file, options);
            string fullHtml = "";
            foreach (PageHtml pageHtml in list.Where(x => x.PageNumber == page)) { fullHtml = pageHtml.HtmlContent; };
            return Content(fullHtml);
        }

    }
}