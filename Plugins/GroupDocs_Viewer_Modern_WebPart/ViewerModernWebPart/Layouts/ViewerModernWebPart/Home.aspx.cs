using System;
using Microsoft.SharePoint.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Collections.Generic;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;
using GroupDocs.Viewer.Domain.Html;
using GroupDocs.Viewer.Handler;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI.WebControls;
using ViewerModernWebPart.Helpers;
using GroupDocs.Viewer;
using GroupDocs.Viewer.Domain.Options;

namespace ViewerModernWebPart.Layouts.ViewerModernWebPart
{
    public partial class Home : LayoutsPageBase
    {
        private static string _licensePath = "D:\\GroupDocs.Total.lic";
        protected void Page_Load(object sender, EventArgs e)
        {
            License l = new License();
            if (System.IO.File.Exists(_licensePath))
            {
                try
                {
                    l.SetLicense(_licensePath);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static List<string> files()
        {
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            List<FileDescription> tree = null;
            try
            {
                tree = handler.GetFileList().Files;
            }
            catch (Exception)
            {
                throw;
            }
            List<String> result = tree.Where(x => x.Name != "README.txt"
                                             && !x.IsDirectory
                                             && !String.IsNullOrWhiteSpace(x.Name)
                                             && !String.IsNullOrWhiteSpace(x.DocumentType))
                                             .Select(x => x.Name).ToList();

            return result;
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static HttpResponseMessage GetPageHtml(string file, int page)
        {
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

            List<PageHtml> list = Utils.LoadPageHtmlList(handler, file, o);

            string fullHtml = "";
            foreach (PageHtml pageHtml in list.Where(x => x.PageNumber == page)) { fullHtml = pageHtml.HtmlContent; };
            var response = new HttpResponseMessage();
            response.Content = new StringContent(fullHtml);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static ResultModel GetDocumentPages(string file)
        {
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            DocumentInfoContainer info = null;
            ResultModel model = new ResultModel();
     
            try
            {
                info = handler.GetDocumentInfo(file);
            }
            catch (Exception x)
            {
                throw x;
            }
            model.pages = Convert(info.Pages);
            List<Attachment> attachmentList = new List<Attachment>();
            foreach (AttachmentBase attachment in info.Attachments)
            {
                List<int> count = new List<int>();
                List<PageHtml> pages = handler.GetPages(attachment);
                for (int i = 1; i <= pages.Count; i++)
                {
                    count.Add(i);
                }
                model.attachments.Add(new Attachment(attachment.Name, count));
            }

            return model;
        }
        public class ResultModel
        {
            public ResultModel()
            {
                pages = new List<PageDataModel>();
                attachments = new List<Attachment>();
            }
            public List<PageDataModel> pages { get; set; }
            public List<Attachment> attachments { get; set; }
        }
        public class Attachment
        {
            public Attachment(string name, List<int> count)
            {
                Name = name;
                Count = count;
            }
            public string Name { get; set; }
            public List<int> Count { get; set; }
        }
        public class PageDataModel
        {
            //
            // Summary:
            //     Gets or sets the angle.
            public int angle { get; set; }
            //
            // Summary:
            //     Gets or sets the height.
            public int height { get; set; }
            //
            // Summary:
            //     Gets or sets page visibility.
            public bool isVisible { get; set; }
            //
            // Summary:
            //     Gets or sets the name.
            public string name { get; set; }
            //
            // Summary:
            //     Gets or sets the number.
            public int number { get; set; }
            //
            // Summary:
            //     Gets or sets the rows.
            public List<RowData> rows { get; set; }
            //
            // Summary:
            //     Gets or sets the width.
            public int width { get; set; }
        }

        private static List<PageDataModel> Convert(List<PageData> pageDataList)
        {
            List<PageDataModel> list = new List<PageDataModel>();
            foreach (var page in pageDataList)
            {
                PageDataModel model = new PageDataModel();
                model.angle = page.Angle;
                model.height = page.Height;
                model.isVisible = page.IsVisible;
                model.name = page.Name;
                model.number = page.Number;
                model.rows = page.Rows;
                model.width = page.Width;
                list.Add(model);
            }

            return list;
        }
    }
}
