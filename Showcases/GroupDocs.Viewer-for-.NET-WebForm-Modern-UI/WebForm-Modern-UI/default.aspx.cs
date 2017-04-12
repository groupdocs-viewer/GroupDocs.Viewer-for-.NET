using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Handler;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viewer_Modren_UI.Helpers;

namespace WebForm_Modern_UI
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
     //   [ScriptMethod(UseHttpGet = true)]
        public static string files()
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

            return JsonConvert.SerializeObject(
                       result   
                        );
        }
    }
}