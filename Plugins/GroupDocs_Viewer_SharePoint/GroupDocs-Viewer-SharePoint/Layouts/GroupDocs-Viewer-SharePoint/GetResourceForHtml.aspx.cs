using System;
using GroupDocs.Viewer.Config;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;
using GroupDocs.Viewer.Domain.Html;
using GroupDocs.Viewer.Domain.Options;
using GroupDocs.Viewer.Handler;
using GroupDocs_Viewer_SharePoint.Layouts.GroupDocs_Viewer_SharePoint.BusinessLayer;
using GroupDocs_Viewer_SharePoint.Layouts.GroupDocs_Viewer_SharePoint.BusinessLayer.Helpers;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI.WebControls;
using WatermarkPosition = GroupDocs_Viewer_SharePoint.Layouts.GroupDocs_Viewer_SharePoint.BusinessLayer.WatermarkPosition;
using Microsoft.SharePoint.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Net;

namespace GroupDocs_Viewer_SharePoint.Layouts.GroupDocs_Viewer_SharePoint
{
    public partial class GetResourceForHtml : LayoutsPageBase
    {
        private static ViewerHtmlHandler _htmlHandler;
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
