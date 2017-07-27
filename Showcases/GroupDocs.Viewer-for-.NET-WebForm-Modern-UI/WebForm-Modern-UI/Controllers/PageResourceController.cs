using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;
using GroupDocs.Viewer.Domain.Html;
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
   
    public class PageResourceController : ApiController
    {
        public HttpResponseMessage Get(string file, int page, string resource)
        {
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            List<int> pageNumberstoRender = new List<int>();
            pageNumberstoRender.Add(page);
            HtmlOptions o = new HtmlOptions();
            int pageNumber = page;
            o.PageNumbersToRender = pageNumberstoRender;
            o.PageNumber = page;
            o.CountPagesToRender = 1;

            List<PageHtml> list = Utils.LoadPageHtmlList(handler, file, o);
            List<HtmlResource> htmlResources = list.Where(x => x.PageNumber == page).Select(x => x.HtmlResources).FirstOrDefault();
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
                Stream stream = handler.GetResource(file, fileResource);
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue(type);
                return result;
            }
            return null;
        }
    }
}