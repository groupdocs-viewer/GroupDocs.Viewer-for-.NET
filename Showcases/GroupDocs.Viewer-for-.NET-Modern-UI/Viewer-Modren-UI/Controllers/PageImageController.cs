using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain.Image;
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
    [RoutePrefix("page/image")]
    public class PageImageController : Controller
    {
        [Route("")]
        public ActionResult Get(int? width, int? height,string file, int page)
        {
            ViewerImageHandler handler = Utils.CreateViewerImageHandler();
            ImageOptions o = new ImageOptions();
            List<int> pageNumberstoRender = new List<int>();
            pageNumberstoRender.Add(page);
            o.PageNumbersToRender = pageNumberstoRender;
            o.PageNumber = page;
            o.CountPagesToRender = 1;
            if (width.HasValue)
            {
                o.Width = Convert.ToInt32(width);
            }
            if (height.HasValue)
            {
                o.Height = Convert.ToInt32(height);
            }
            Stream stream = null;
            List<PageImage> list = Utils.LoadPageImageList(handler, file, o);
            foreach (PageImage pageImage in list.Where(x => x.PageNumber == page)) { stream =  pageImage.Stream; };
            return new FileStreamResult(stream,"image/png");
        }
    }
}