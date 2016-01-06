using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupDocs.Viewer.Config;
using GroupDocs.Viewer.Handler;
using GroupDocs.Viewer.Converter.Options;
using GroupDocs.Viewer.Domain.Html;
using GroupDocs.Viewer.Domain.Image;
using GroupDocs.Viewer.Domain.Options;
using System.Drawing;
using GroupDocs.Viewer.Domain;
using GroupDocs.Viewer.Domain.Containers;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp
{
    public static class ViewGenerator
    {
       
        #region HTMLRepresentation
        /// <summary>
        /// Render simple document in html representation
        /// </summary>
        /// <param name="DocumentName">File name</param>
        /// <param name="DocumentPassword">Optional</param>
        public static void RenderAsHtml(String DocumentName,String DocumentPassword=null)
        {
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
            string guid = DocumentName;

            HtmlOptions options = new HtmlOptions();

            //to get pages html representations with embedded resources
            options.IsResourcesEmbedded = true;

            if(!String.IsNullOrEmpty(DocumentPassword))
            options.Password = DocumentPassword;

            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {

                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
        }
        /// <summary>
        /// Render document in html representation with watermark
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        /// <param name="WatermarkText">watermark text</param>
        /// <param name="WatermarkColor"> System.Drawing.Color</param>
        /// <param name="position">Watermark Position is optional parameter. Default value is WatermarkPosition.Diagonal</param>
        /// <param name="WatermarkWidth"> width of watermark as integer. it is optional Parameter default value is 100</param>
        /// <param name="DocumentPassword">Password Parameter is optional</param>
        public static void RenderAsHtml(String DocumentName, String WatermarkText, Color WatermarkColor, WatermarkPosition position=WatermarkPosition.Diagonal, int WatermarkWidth=100, String DocumentPassword=null )
        {
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
            string guid = DocumentName;
            
            
            HtmlOptions options = new HtmlOptions();
            

            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;

            Utilities.PageTransformations.AddWatermark(ref options, WatermarkText, WatermarkColor, position, WatermarkWidth);
            
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {

                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
        }
        /// <summary>
        ///  document in html representation and reorder a page
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        /// <param name="CurrentPageNumber">Page existing order number</param>
        /// <param name="NewPageNumber">Page new order number</param>
        /// <param name="DocumentPassword">Password Parameter is optional</param>
        public static void RenderAsHtml(String DocumentName, int CurrentPageNumber, int NewPageNumber, String DocumentPassword = null)
        {
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHandler handler = new ViewerHtmlHandler(config);
            string guid = DocumentName;

            HtmlOptions options = new HtmlOptions();

            //to get pages html representations with embedded resources
            options.IsResourcesEmbedded = true;

             if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;
            //reorder page. pass handler parameter by reference. 
            Utilities.PageTransformations.ReorderPage(ref handler, guid, CurrentPageNumber, NewPageNumber);
            
            //down cast the handler to viewerHtmlHandler
            ViewerHtmlHandler htmlHandler = (ViewerHtmlHandler)handler;
         

            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {

                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
        }
        /// <summary>
        /// Render a document in html representation whom located at web/remote location.
        /// </summary>
        /// <param name="DocumentURL">URL of the document</param>
        /// <param name="DocumentPassword">Password Parameter is optional</param>
        public static void RenderAsHtml(Uri DocumentURL, String DocumentPassword = null)
        {
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
            

            HtmlOptions options = new HtmlOptions();

            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;

            List<PageHtml> pages = htmlHandler.GetPages(DocumentURL,options);
            
            foreach (PageHtml page in pages)
            {

                Utilities.SaveAsHtml(page.PageNumber + "_" + Path.GetFileName(DocumentURL.LocalPath), page.HtmlContent);
            }
        }
       
        #endregion

        #region ImageRepresentation
        /// <summary>
        /// Render simple document in image representation
        /// </summary>
        /// <param name="DocumentName">File name</param>
        /// <param name="DocumentPassword">Optional</param>
        public static void RenderAsImages(String DocumentName,String DocumentPassword=null)
        {
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);
            
            string guid = DocumentName;
            
            ImageOptions options = new ImageOptions();
           
            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;

            List<PageImage> Images = imageHandler.GetPages(guid, options);
          
            foreach (PageImage image in Images)
            {

                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream);
            }

        }
        /// <summary>
        /// Render document in image representation with watermark
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        /// <param name="WatermarkText">watermark text</param>
        /// <param name="WatermarkColor"> System.Drawing.Color</param>
        /// <param name="position">Watermark Position is optional parameter. Default value is WatermarkPosition.Diagonal</param>
        /// <param name="WatermarkWidth"> width of watermark as integer. it is optional Parameter default value is 100</param>
        /// <param name="DocumentPassword">Password Parameter is optional</param>
        public static void RenderAsImages(String DocumentName, String WatermarkText, Color WatermarkColor, WatermarkPosition position = WatermarkPosition.Diagonal, int WatermarkWidth = 100, String DocumentPassword = null)
        {
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);
            string guid = DocumentName;

            ImageOptions options = new ImageOptions();


            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;

            Utilities.PageTransformations.AddWatermark(ref options, WatermarkText, WatermarkColor, position, WatermarkWidth);

            List<PageImage> Images = imageHandler.GetPages(guid, options);

            foreach (PageImage image in Images)
            {

                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream);
            }
        }
        /// <summary>
        /// Render the document in image form and set the rotation angle to rotate the page while display.
        /// </summary>
        /// <param name="DocumentName"></param>
        /// <param name="RotationAngle">rotation angle in digits</param>
        /// <param name="DocumentPassword"></param>
        public static void RenderAsImages(String DocumentName, int RotationAngle, String DocumentPassword = null)
        {
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);
            string guid = DocumentName;

            ImageOptions options = new ImageOptions();


            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;
            //apply page rotation
            Utilities.PageTransformations.RotatePages(ref options,RotationAngle);

            List<PageImage> Images = imageHandler.GetPages(guid, options);

            foreach (PageImage image in Images)
            {

                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream);
            }
        }
        /// <summary>
        ///  document in image representation and reorder a page
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        /// <param name="CurrentPageNumber">Page existing order number</param>
        /// <param name="NewPageNumber">Page new order number</param>
        /// <param name="DocumentPassword">Password Parameter is optional</param>
        public static void RenderAsImages(String DocumentName, int CurrentPageNumber, int NewPageNumber, String DocumentPassword = null)
        {
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHandler handler = new ViewerImageHandler(config);
            string guid = DocumentName;

            ImageOptions options = new ImageOptions();


            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;

            Utilities.PageTransformations.ReorderPage(ref handler,guid,CurrentPageNumber,NewPageNumber);

            ViewerImageHandler imageHandler = (ViewerImageHandler)handler;
            List<PageImage> Images = imageHandler.GetPages(guid, options);

            foreach (PageImage image in Images)
            {

                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream);
            }
        }
        /// <summary>
        /// Render a document in image representation whom located at web/remote location.
        /// </summary>
        /// <param name="DocumentURL">URL of the document</param>
        /// <param name="DocumentPassword">Password Parameter is optional</param>
        public static void RenderAsImages(Uri DocumentURL, String DocumentPassword = null)
        {
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);

            

            ImageOptions options = new ImageOptions();

            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;

            List<PageImage> Images = imageHandler.GetPages(DocumentURL, options);

            foreach (PageImage image in Images)
            {

                Utilities.SaveAsImage(image.PageNumber + "_" + Path.GetFileName(DocumentURL.LocalPath), image.Stream);
            }

        }

        #endregion

        #region GeneralRepresentation
        /// <summary>
        /// Render a document as it is (original form)
        /// </summary>
        /// <param name="DocumentName"></param>
        public static void RenderOriginal(String DocumentName)
        {

            ViewerImageHandler imageHandler = new ViewerImageHandler(Utilities.GetConfigurations());

            string guid = DocumentName;

            // Get original file
            FileContainer container = imageHandler.GetFile(guid);

            Utilities.SaveAsImage(DocumentName, container.Stream);

        }
       /// <summary>
       /// Render a document in PDF Form
       /// </summary>
       /// <param name="DocumentName"></param>
        public static void RenderAsPDF(String DocumentName)
        {

            ViewerImageHandler imageHandler = new ViewerImageHandler(Utilities.GetConfigurations());
            
            PdfFileOptions options = new PdfFileOptions();
            options.Guid = DocumentName;

            // Get Pdf file
            FileContainer container = imageHandler.GetPdfFile(options);
           
            //Change the extension of file
            String filename=Path.GetFileNameWithoutExtension(DocumentName)+".pdf";
            Utilities.SaveFile(filename, container.Stream);

        }

        #endregion

    }

    
    
}
