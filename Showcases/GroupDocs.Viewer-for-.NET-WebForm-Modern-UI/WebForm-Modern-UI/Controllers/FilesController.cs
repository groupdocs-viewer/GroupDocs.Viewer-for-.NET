using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Viewer_Modren_UI.Helpers;


namespace WebForm_Modern_UI
{

    public class FilesController : ApiController
    {
        
        public JsonResult<List<string>> Get()
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

            return Json(result);
           
        }


        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}