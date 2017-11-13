﻿using GroupDocs.Viewer.Converter.Options;
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
    [RoutePrefix("page/resource")]
    public class PageResourceController : Controller
    {
        [Route("")]
        public ActionResult Index(string file, int page, string resource )
        {
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            List<int> pageNumberstoRender = new List<int>();
            pageNumberstoRender.Add(page);
            HtmlOptions o = new HtmlOptions();
            int pageNumber = page;
            o.PageNumbersToRender = pageNumberstoRender;
            o.PageNumber = page;
            o.CountPagesToRender = 1;

            List<PageHtml> list = Utils.LoadPageHtmlList(handler,file, o);
            List<HtmlResource> htmlResources = list.Where(x => x.PageNumber == page).Select(x=>x.HtmlResources).FirstOrDefault();
            var fileResource =  htmlResources.Where(x => x.ResourceName == resource).FirstOrDefault();
            string type = "";
            if (fileResource != null)
            {
                switch (fileResource.ResourceType)
                {
                    case HtmlResourceType.Font:
                        type = "application/font-woff";
                        break;
                    case HtmlResourceType.Style:

                        type = "text/css";
                        break;
                    case HtmlResourceType.Image:
                        type = "image/jpeg";
                        break;
                    case HtmlResourceType.Graphics:
                        type = "image/svg+xml";
                        break;
                }
                Stream stream = handler.GetResource(file, fileResource);
                return new FileStreamResult(stream, type);
            }
            return null;
        }
    }
}