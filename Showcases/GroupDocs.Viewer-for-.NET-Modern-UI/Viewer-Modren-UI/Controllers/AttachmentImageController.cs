using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;
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
    [RoutePrefix("attachment/image")]
    public class AttachmentImageController : Controller
    {
        [Route("")]
        public ActionResult Get(int? width, int? height, string file,string attachment, int page)
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
            DocumentInfoContainer info = handler.GetDocumentInfo(file);

            // Iterate over the attachments collection
            foreach (AttachmentBase attachmentBase in info.Attachments.Where(x=>x.Name == attachment))
            {
                List<PageImage> pages = handler.GetPages(attachmentBase);
                foreach (PageImage attachmentPage in pages.Where(x=>x.PageNumber == page)) { stream = attachmentPage.Stream; };

            }
            return new FileStreamResult(stream, "image/png");
        }
    }
}