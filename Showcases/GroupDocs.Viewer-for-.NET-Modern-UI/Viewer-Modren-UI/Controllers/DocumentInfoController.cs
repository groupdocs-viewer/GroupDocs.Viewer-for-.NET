using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;
using GroupDocs.Viewer.Domain.Html;
using GroupDocs.Viewer.Domain.Options;
using GroupDocs.Viewer.Handler;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viewer_Modren_UI.Helpers;

namespace Viewer_Modren_UI.Controllers
{
    [RoutePrefix("document/info")]
    public class DocumentInfoController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Get(string file)
        {
            if (Utils.IsValidUrl(file))
                file = Utils.DownloadToStorage(file);
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            DocumentInfoContainer info = null;
            ResultModel model = new ResultModel();
            DocumentInfoOptions options = new DocumentInfoOptions(file);
            try
            {
               
                info = handler.GetDocumentInfo(file,options);
            }
            catch (Exception x)
            {
                throw x;
            }
            model.pages = info.Pages;
            List<Attachment> attachmentList = new List<Attachment>();
            foreach(AttachmentBase attachment in info.Attachments)
            {
                List<int> count = new List<int>();
                List<PageHtml> pages = handler.GetPages(attachment);
                for (int i = 1; i <= pages.Count; i++)
                {
                    count.Add(i);
                }
                model.attachments.Add(new Attachment(attachment.Name, count));
            }
            return Content(JsonConvert.SerializeObject(
                        model,
                        Formatting.Indented,
                        new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
                         ), "application/json");
        }
        private class ResultModel
        {
            public ResultModel()
            {
                pages = new List<PageData>();
                attachments = new List<Attachment>();
            }
            public List<PageData> pages { get; set; }
            public List<Attachment> attachments { get; set; }
        }
        private class Attachment
        {
            public Attachment(string name, List<int> count)
            {
                Name = name;
                Count = count;
            }
            public string Name { get; set; }
            public List<int> Count { get; set; }
        }

    }
}