using System;
using Microsoft.SharePoint.WebControls;
using GroupDocs.Viewer.Handler;
using System.IO;
using System.Web;
using ViewerModernWebPart.Helpers;

namespace ViewerModernWebPart.Layouts.ViewerModernWebPart
{
    public partial class DownloadOriginal : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var file = GetValueFromQueryString("file");
            ViewerHtmlHandler handler = Utils.CreateViewerHtmlHandler();
            Stream original = null;
            try
            {
                original = handler.GetFile(file).Stream;
            }
            catch (Exception x)
            {
                throw x;
            }

            using (var ms = new MemoryStream())
            {
                original.CopyTo(ms);
                ms.WriteTo(HttpContext.Current.Response.OutputStream);
                Response.AddHeader("content-disposition", "attachment; filename=" + file);
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();

            }
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
