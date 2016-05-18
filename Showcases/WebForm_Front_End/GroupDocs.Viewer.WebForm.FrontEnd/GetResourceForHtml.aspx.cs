using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GroupDocs.Viewer;
using GroupDocs.Viewer.Config;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Options;
using GroupDocs.Viewer.Handler;
using GroupDocs.Viewer.WebForm.FrontEnd.BusinessLayer;
using GroupDocs.Viewer.WebForm.FrontEnd.BusinessLayer.Helpers;
using GroupDocs.Viewer.Domain.Html;
using System.Net;
using System.Net.Mime;

namespace GroupDocs.Viewer.WebForm.FrontEnd
{
    public partial class GetResourceForHtml : System.Web.UI.Page
    {
        private static ViewerHtmlHandler _htmlHandler;
        private static ViewerConfig _config;
        private static string _storagePath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString(); // App_Data folder path
        private static string _tempPath = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\Temp";

        protected void Page_Load(object sender, EventArgs e) 
        {
           

            _htmlHandler = (ViewerHtmlHandler)Session["htmlHandler"];

            GetResourceForHtmlParameters parameters = new GetResourceForHtmlParameters();
           
               
                parameters.DocumentPath = GetValueFromQueryString("documentPath");
                parameters.ResourceName = GetValueFromQueryString("resourceName");
                parameters.PageNumber = int.Parse(GetValueFromQueryString("pageNumber") != String.Empty ? GetValueFromQueryString("pageNumber") : "0");

                if (!string.IsNullOrEmpty(parameters.ResourceName) &&
                               parameters.ResourceName.IndexOf("/", StringComparison.Ordinal) >= 0)
                    parameters.ResourceName = parameters.ResourceName.Replace("/", "");


                try
                {
                var resource = new HtmlResource
                {
                    ResourceName = parameters.ResourceName,
                    ResourceType = Utils.GetResourceType(parameters.ResourceName),
                    DocumentPageNumber = parameters.PageNumber
                };
                var stream = _htmlHandler.GetResource(parameters.DocumentPath, resource);
                if (stream == null || stream.Length == 0)
                {
                    Response.StatusCode = ((int)HttpStatusCode.Gone);
                    Response.End();
                }
                else
                {

                    byte[] Bytes = new byte[stream.Length];
                    stream.Read(Bytes, 0, Bytes.Length);
                    //string contentDispositionString = "attachment; filename=\"" + parameters.ResourceName + "\"";
                    string contentDispositionString = new ContentDisposition { FileName = parameters.ResourceName, Inline = true }.ToString();
                    
                    HttpContext.Current.Response.ContentType = Utils.GetImageMimeTypeFromFilename(parameters.ResourceName);
                    HttpContext.Current.Response.AddHeader("Content-Disposition", contentDispositionString);
                    HttpContext.Current.Response.AddHeader("Content-Length", stream.Length.ToString());
                    HttpContext.Current.Response.OutputStream.Write(Bytes, 0, Bytes.Length);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();
                }
            }
            catch
            {

            }
        }
        private string GetContentType(ConvertImageFileType convertImageFileType)
        {
            string contentType;
            switch (convertImageFileType)
            {
                case ConvertImageFileType.JPG:
                    contentType = "image/jpeg";
                    break;
                case ConvertImageFileType.BMP:
                    contentType = "image/bmp";
                    break;
                case ConvertImageFileType.PNG:
                    contentType = "image/png"; ;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return contentType;
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