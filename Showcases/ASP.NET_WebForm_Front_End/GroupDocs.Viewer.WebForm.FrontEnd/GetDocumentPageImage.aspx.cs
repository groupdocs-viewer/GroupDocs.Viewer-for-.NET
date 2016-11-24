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
using GroupDocs.Viewer.Domain.Containers;
using GroupDocs.Viewer.Domain.Image;

using System.Net.Mime;
using System.Collections.Specialized;
using System.Reflection;


namespace GroupDocs.Viewer.WebForm.FrontEnd
{
    public partial class GetDocumentPageImage : System.Web.UI.Page
    {
        private static string _storagePath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString(); // App_Data folder path
        private static string _tempPath = AppDomain.CurrentDomain.GetData("DataDirectory") + "\\temp";
        private static ViewerConfig _config;

        protected void Page_Load(object sender, EventArgs e)
        {
            _config = new ViewerConfig
            {
                StoragePath = _storagePath, 
                UseCache = true
            };

            ViewerImageHandler imageHandler = (ViewerImageHandler)HttpContext.Current.Session["imageHandler"];
            ViewerHtmlHandler htmlHandler = (ViewerHtmlHandler)HttpContext.Current.Session["htmlHandler"];
            GetDocumentPageImageParameters parameters = new GetDocumentPageImageParameters();
          

            foreach (String key in Request.QueryString.AllKeys)
            {
                if (!string.IsNullOrEmpty(Request.QueryString[key]))
                {
                    var propertyInfo = parameters.GetType().GetProperty(key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                      propertyInfo.SetValue(parameters, ChangeType(Request.QueryString[key], propertyInfo.PropertyType),null);
                }
            }
            
            string guid = parameters.Path;
            int pageIndex = parameters.PageIndex;
            int pageNumber = pageIndex + 1;
            var displayName=parameters.Path;
            /*
            //NOTE: This feature is supported starting from version 3.2.0
            CultureInfo cultureInfo = string.IsNullOrEmpty(parameters.Locale)
                ? new CultureInfo("en-Us")
                : new CultureInfo(parameters.Locale);

            ViewerImageHandler viewerImageHandler = new ViewerImageHandler(viewerConfig, cultureInfo);
            */

            var imageOptions = new ImageOptions
            {
                //ConvertImageFileType = _convertImageFileType,
                ConvertImageFileType = ConvertImageFileType.JPG,
                JpegQuality = 100,
                Watermark = Utils.GetWatermark(parameters.WatermarkText, parameters.WatermarkColor,
                    parameters.WatermarkPosition, parameters.WatermarkWidth),
                Transformations = parameters.Rotate ? Transformation.Rotate : Transformation.None
            };

            if (parameters.Rotate && parameters.Width.HasValue)
            { 
                DocumentInfoContainer documentInfoContainer = imageHandler.GetDocumentInfo(guid);

                int side = parameters.Width.Value;

                int pageAngle = documentInfoContainer.Pages[pageIndex].Angle;
                if (pageAngle == 90 || pageAngle == 270)
                    imageOptions.Height = side;
                else
                    imageOptions.Width = side;
            }

            /*
            //NOTE: This feature is supported starting from version 3.2.0
            if (parameters.Quality.HasValue)
                imageOptions.JpegQuality = parameters.Quality.Value;
            */

            using (new InterProcessLock(guid))
            {
                List<PageImage> pageImages = imageHandler.GetPages(guid, imageOptions);
                PageImage pageImage = pageImages.Single(_ => _.PageNumber == pageNumber);
                var fileStream = pageImage.Stream;
               // return File(pageImage.Stream, GetContentType(_convertImageFileType));
                byte[] Bytes = new byte[fileStream.Length];
                fileStream.Read(Bytes, 0, Bytes.Length);
                string contentDispositionString = "attachment; filename=\"" + displayName + "\"";

                
                    contentDispositionString = new ContentDisposition { FileName = displayName, Inline = true }.ToString();



                    HttpContext.Current.Response.ContentType = "image/jpeg";

                HttpContext.Current.Response.AddHeader("Content-Disposition", contentDispositionString);
                HttpContext.Current.Response.AddHeader("Content-Length", fileStream.Length.ToString());
                try
                {
                    HttpContext.Current.Response.OutputStream.Write(Bytes, 0, Bytes.Length);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();
                }
                catch (HttpException x)
                {
                    // Ignore it.
                }
            }

        }
      
        public object ChangeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }
    }
}