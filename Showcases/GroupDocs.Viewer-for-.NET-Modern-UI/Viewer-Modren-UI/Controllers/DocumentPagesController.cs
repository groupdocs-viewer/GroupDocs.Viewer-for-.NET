using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;
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
    [RoutePrefix("document/pages")]
    public class DocumentPagesController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Get(string file)
        {
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            DocumentInfoContainer info = null;
            try
            {
                DocumentInfoOptions options = new DocumentInfoOptions(file);
                info = handler.GetDocumentInfo(file,options);
            }
            catch (Exception x)
            {
                throw x;
            }

            List<PageData> result = new List<PageData>();
            foreach(PageData pageData in info.Pages)
            {
               
                result.Add(pageData);

            }
            return Content(JsonConvert.SerializeObject(
                        result,
                        Formatting.Indented,
                        new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
                         ), "application/json");
        }
    }
}