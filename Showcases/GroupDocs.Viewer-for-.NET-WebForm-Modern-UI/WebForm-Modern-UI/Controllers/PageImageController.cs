using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain.Image;
using GroupDocs.Viewer.Handler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Viewer_Modren_UI.Helpers;

namespace WebForm_Modern_UI.Controllers
{
    public class PageImageController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get(int? width,string file, int page, int? height = null)
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
            foreach (PageImage pageImage in list.Where(x => x.PageNumber == page)) { stream = pageImage.Stream; };
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            Image image = Image.FromStream(stream);
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            result.Content = new ByteArrayContent(memoryStream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            return result;
        }

    }
}