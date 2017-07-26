using GroupDocs.Viewer.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Viewer_Modren_UI.Helpers;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain.Html;
using System.Net.Http.Headers;
using System.IO;
using GroupDocs.Viewer.Domain;

namespace WebForm_Modern_UI.Controllers
{
    public class AttachmentHtmlController : ApiController
    {
        private static string _cachePath = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\cache";
        public HttpResponseMessage Get(string file, string attachment, int page, string watermarkText, int? watermarkColor, WatermarkPosition? watermarkPosition, int? watermarkWidth, byte watermarkOpacity)
        {
            var attachmentPath = "cache\\" + Path.GetFileNameWithoutExtension(file) + Path.GetExtension(file).Replace(".", "_") + "\\attachments\\" + attachment;
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            var docInfo = handler.GetDocumentInfo(file);
            List<int> pageNumberstoRender = new List<int>();
            pageNumberstoRender.Add(page);
            HtmlOptions o = new HtmlOptions();
            o.PageNumbersToRender = pageNumberstoRender;
            o.PageNumber = page;
            o.CountPagesToRender = 1;
            o.HtmlResourcePrefix = "/AttachmentResource?file=" + file + "&attachment=" + attachment + "&page=" + page + "&resource=";
            if (watermarkText != "")
                o.Watermark = Utils.GetWatermark(watermarkText, watermarkColor, watermarkPosition, watermarkWidth, watermarkOpacity);
            string fullHtml = "";
            var attachmentFile = _cachePath + "\\" + Path.GetFileNameWithoutExtension(file) + Path.GetExtension(file).Replace(".", "_") + "\\attachments";
            if (Directory.Exists(attachmentFile.Replace(@"\\", @"\")))
            {
                List<PageHtml> pages = handler.GetPages(attachmentPath, o);
                foreach (PageHtml pageHtml in pages.Where(x => x.PageNumber == page)) { fullHtml += pageHtml.HtmlContent; };
            }
            else
            {

                foreach (AttachmentBase attachmentBase in docInfo.Attachments.Where(x => x.Name == attachment))
                {
                    // Get attachment document html representation
                    List<PageHtml> pages = handler.GetPages(attachmentBase, o);
                    foreach (PageHtml pageHtml in pages.Where(x => x.PageNumber == page)) { fullHtml += pageHtml.HtmlContent; };
                }
            }
            var response = new HttpResponseMessage();
            response.Content = new StringContent(fullHtml);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}