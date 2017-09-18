using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;
using GroupDocs.Viewer.Domain.Image;
using GroupDocs.Viewer.Domain.Options;
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
        public ActionResult Get(int? width, int? height,string file, int page, string watermarkText, int? watermarkColor, WatermarkPosition? watermarkPosition, int? watermarkWidth, byte watermarkOpacity,int? rotate,int? zoom)
        {
            if (Utils.IsValidUrl(file))
                file = Utils.DownloadToStorage(file);
            ViewerImageHandler handler = Utils.CreateViewerImageHandler();
            ImageOptions o = new ImageOptions();
            List<int> pageNumberstoRender = new List<int>();
            pageNumberstoRender.Add(page);
            o.PageNumbersToRender = pageNumberstoRender;
            o.PageNumber = page;
            o.CountPagesToRender = 1;
            if(watermarkText!="")
                o.Watermark = Utils.GetWatermark(watermarkText, watermarkColor, watermarkPosition, watermarkWidth, watermarkOpacity);
            if (width.HasValue)
            {
                int w= Convert.ToInt32(width);
                if (zoom.HasValue)
                    w = w + zoom.Value;
                o.Width = w;
            }
            //if (height.HasValue)
            //{
            //    o.Height = Convert.ToInt32(height*10);
            //}
            if (rotate.HasValue)
            {
                o.Transformations = Transformation.Rotate;
                //Call RotatePages to apply rotate transformation to a page
                handler.RotatePage(file, new RotatePageOptions(page, rotate.Value));

            }
            Stream stream = null;
            List<PageImage> list = Utils.LoadPageImageList(handler, file, o);
            foreach (PageImage pageImage in list.Where(x => x.PageNumber == page)) { stream =  pageImage.Stream; };
            return new FileStreamResult(stream,"image/png");
        }
    }
}