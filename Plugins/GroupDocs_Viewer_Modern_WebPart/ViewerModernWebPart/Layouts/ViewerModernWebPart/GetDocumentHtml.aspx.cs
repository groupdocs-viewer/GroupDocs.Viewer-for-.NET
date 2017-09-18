using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;
using GroupDocs.Viewer.Domain.Html;
using GroupDocs.Viewer.Handler;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Results;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewerModernWebPart.Helpers;

namespace ViewerModernWebPart.Layouts.ViewerModernWebPart
{
    public partial class GetDocumentHtml : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var file = GetValueFromQueryString("file");
            var page = Convert.ToInt32(GetValueFromQueryString("page"));

            string watermarkText = GetValueFromQueryString("watermarkText");
            int? watermarkColor = Convert.ToInt32(GetValueFromQueryString("watermarkColor"));
            WatermarkPosition watermarkPosition = (WatermarkPosition)Enum.Parse(typeof(WatermarkPosition), GetValueFromQueryString("watermarkPosition"), true);
            string widthFromQuery  = GetValueFromQueryString("watermarkWidth");
            int? watermarkWidth = GetValueFromQueryString("watermarkWidth") == "null" ? null : (int?)Convert.ToInt32(GetValueFromQueryString("watermarkWidth"));
            byte watermarkOpacity = Convert.ToByte(GetValueFromQueryString("watermarkOpacity"));

            if (Utils.IsValidUrl(file))
                file = Utils.DownloadToStorage(file);
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            List<int> pageNumberstoRender = new List<int>();
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
            if (watermarkText != "")
                o.Watermark = Utils.GetWatermark(watermarkText, watermarkColor, watermarkPosition, watermarkWidth, watermarkOpacity);

            List<PageHtml> list = Utils.LoadPageHtmlList(handler, file, o);

            string fullHtml = "";
            foreach (PageHtml pageHtml in list.Where(x => x.PageNumber == page)) { fullHtml = pageHtml.HtmlContent; };

            HttpContext.Current.Response.ContentType = "text/html";
            HttpContext.Current.Response.Write(fullHtml);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
        private String GetValueFromQueryString(String value)
        {
            try
            {
                return Request.QueryString[value].ToString();

            }
            catch (System.Exception exp)
            {
                return String.Empty;
            }
        }
    }
}
