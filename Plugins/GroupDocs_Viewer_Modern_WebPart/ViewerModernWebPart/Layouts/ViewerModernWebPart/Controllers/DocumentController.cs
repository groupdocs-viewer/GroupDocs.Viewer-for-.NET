using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;
using GroupDocs.Viewer.Handler;
using System;
using System.Collections.Generic;
using System.Web.Http;
using ViewerModernWebPart.Helpers;

namespace ViewerModernWebPart.Controllers
{
    [RoutePrefix("document/pages")]
    public class DocumentController : ApiController
    {
        [HttpGet]
        [Route("")]
        public List<PageDataModel> Get(string file)
        {
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();

            DocumentInfoContainer info = null;
            try
            {
                info = handler.GetDocumentInfo(file);
            }
            catch (Exception x)
            {
                throw x;
            }

            List<PageData> result = new List<PageData>();
            foreach (PageData pageData in info.Pages)
            {
                result.Add(pageData);
            }

            return Convert(result);
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

        private List<PageDataModel> Convert(List<PageData> pageDataList)
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

     
    }
}