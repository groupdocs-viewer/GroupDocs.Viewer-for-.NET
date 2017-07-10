using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;
using GroupDocs.Viewer.Domain.Html;
using GroupDocs.Viewer.Handler;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Viewer_Modren_UI.Helpers;

namespace WebForm_Modern_UI.Controllers
{
    public class DocumentInfoController : ApiController
    {
        public ResultModel Get(string file)
        {
            if (Utils.IsValidUrl(file))
                file = Utils.DownloadToStorage(file);

            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            ResultModel model = new ResultModel();
            DocumentInfoContainer info = null;
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
        public List<PageDataModel> Convert(List<PageData> pageDataList)
        {
            List<PageDataModel> list = new List<PageDataModel>();
            foreach(var page in pageDataList)
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
            public Attachment(string _name, List<int> _count)
            {
                name = _name;
                count = _count;
            }
            public string name { get; set; }
            public List<int> count { get; set; }
        }
    }
}