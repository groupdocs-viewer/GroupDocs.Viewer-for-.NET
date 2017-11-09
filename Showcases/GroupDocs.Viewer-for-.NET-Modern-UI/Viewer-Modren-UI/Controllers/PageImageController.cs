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
using System.Drawing;
using System.Drawing.Imaging;

namespace Viewer_Modren_UI.Controllers
{
    [RoutePrefix("page/image")]
    public class PageImageController : Controller
    {

        [Route("")]
        public ActionResult Get(int? width, int? height, string file, int page, string watermarkText, int? watermarkColor, WatermarkPosition? watermarkPosition, int? watermarkWidth, byte watermarkOpacity, int? rotate, int? zoom)
        {
            if (Utils.IsValidUrl(file))
                file = Utils.DownloadToStorage(file);
            ViewerImageHandler handler = Utils.CreateViewerImageHandler();
            ImageOptions o = new ImageOptions();
            o.PageNumbersToRender = new List<int>(new int[] { page });
            o.PageNumber = page;
            o.CountPagesToRender = 1;

            if (watermarkText != "")
                o.Watermark = Utils.GetWatermark(watermarkText, watermarkColor, watermarkPosition, watermarkWidth, watermarkOpacity);

            if (width.HasValue)
            {
                int w = Convert.ToInt32(width);
                if (zoom.HasValue)
                    w = w + zoom.Value;
                o.Width = w;
            }

            if (height.HasValue)
            {
                if (zoom.HasValue)
                    o.Height = o.Height + zoom.Value;
            }

            if (rotate.HasValue)
            {
                if (rotate.Value > 0)
                {
                    if (width.HasValue)
                    {
                        int side = o.Width;

                        DocumentInfoContainer documentInfoContainer = handler.GetDocumentInfo(file);
                        int pageAngle = documentInfoContainer.Pages[page - 1].Angle;
                        if (pageAngle == 90 || pageAngle == 270)
                            o.Height = side;
                        else
                            o.Width = side;
                    }

                    o.Transformations = Transformation.Rotate;
                    handler.RotatePage(file, new RotatePageOptions(page, rotate.Value));
                }
            }
            else
            {
                o.Transformations = Transformation.None;
                handler.RotatePage(file, new RotatePageOptions(page, 0));
            }

            using (new InterProcessLock(file))
            {
                List<PageImage> list = handler.GetPages(file, o);
                PageImage pageImage = list.Single(_ => _.PageNumber == page);

                return File(pageImage.Stream, "image/png");
            }
        }
    }
}