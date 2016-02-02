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
using GroupDocs.Viewer.Model.BusinessObjects;
using System.Text.RegularExpressions;

namespace GroupDocs.Viewer.Model
{
    public static class ViewGenerator
    {
       
        #region HTMLRepresentation
        /// <summary>
        /// Render simple document in html representation
        /// </summary>
        /// <param name="DocumentName">File name</param>
        /// <param name="DocumentPassword">Optional</param>
        public static List<HtmlInfo> RenderDocumentAsHtml(String DocumentName, String DocumentPassword = null)
        {
           //ExStart:RenderAsHtml
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            
            // Guid implies that unique document name 
            string guid = DocumentName;

            //Instantiate the HtmlOptions object
            HtmlOptions options = new HtmlOptions();
            
            //to get html representations of pages with embedded resources
            options.IsResourcesEmbedded = true;

            // Set password if document is password protected. 
            if(!String.IsNullOrEmpty(DocumentPassword))
            options.Password = DocumentPassword;
            
            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);
            List<HtmlInfo> contents = new List<HtmlInfo>();
            
            foreach (PageHtml page in pages)
            {
                HtmlInfo htmlInfo = new HtmlInfo();
                htmlInfo.HtmlContent = page.HtmlContent;
                htmlInfo.PageNmber = page.PageNumber;
                contents.Add(htmlInfo);
            }

            return contents;
            //ExEnd:RenderAsHtml
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
        public static List<HtmlInfo> RenderDocumentAsHtml(String DocumentName, String WatermarkText, Color WatermarkColor,  int WatermarkWidth = 100, String DocumentPassword = null)
        {
            //ExStart:RenderAsHtmlWithWaterMark
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            //Instantiate the HtmlOptions object 
            HtmlOptions options = new HtmlOptions();

            options.IsResourcesEmbedded = false;
            // Set password if document is password protected. 
            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;

            // Call AddWatermark and pass the reference of HtmlOptions object as 1st parameter
            Utilities.PageTransformations.AddWatermark(ref options, WatermarkText, WatermarkColor, WatermarkPosition.Diagonal, WatermarkWidth);
            
            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            List<HtmlInfo> contents = new List<HtmlInfo>();

            foreach (PageHtml page in pages)
            {
                HtmlInfo htmlInfo = new HtmlInfo();
                htmlInfo.HtmlContent = page.HtmlContent;
                htmlInfo.PageNmber = page.PageNumber;
                contents.Add(htmlInfo);
            }

            return contents;
            //ExEnd:RenderAsHtmlWithWaterMark
        }
        public static List<HtmlInfo> RotateDocumentAsHtml(String DocumentName, int pageNumber, int RotationAngle, String DocumentPassword = null)
        {
            //ExStart:RenderAsImageWithRotationTransformation
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create image handler
            ViewerHandler handler = new ViewerHtmlHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            //Initialize ImageOptions Object and setting Rotate Transformation
            HtmlOptions options = new HtmlOptions { Transformations = Transformation.Rotate };

            // Set password if document is password protected. 
            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;

            //Call RotatePages to apply rotate transformation to a page
            Utilities.PageTransformations.RotatePages(ref handler, guid, pageNumber, RotationAngle);

            //down cast the handler(ViewerHandler) to viewerHtmlHandler
            ViewerHtmlHandler htmlHandler = (ViewerHtmlHandler)handler;

            //Get document pages in image form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            List<HtmlInfo> contents = new List<HtmlInfo>();

            foreach (PageHtml page in pages)
            {
                HtmlInfo htmlInfo = new HtmlInfo();
                htmlInfo.HtmlContent = page.HtmlContent;
                htmlInfo.PageNmber = page.PageNumber;
                contents.Add(htmlInfo);
            }

            return contents;
            //ExEnd:RenderAsImageWithRotationTransformation
        }
        /// <summary>
        ///  document in html representation and reorder a page
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        /// <param name="CurrentPageNumber">Page existing order number</param>
        /// <param name="NewPageNumber">Page new order number</param>
        /// <param name="DocumentPassword">Password Parameter is optional</param>
        public static List<HtmlInfo> RenderDocumentAsHtml(String DocumentName, int CurrentPageNumber, int NewPageNumber, String DocumentPassword = null)
        {
            //ExStart:RenderAsHtmlAndReorderPage
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Cast ViewerHtmlHandler class object to its base class(ViewerHandler).
            ViewerHandler handler = new ViewerHtmlHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            //Instantiate the HtmlOptions object with setting of Reorder Transformation
            HtmlOptions options = new HtmlOptions {  Transformations=Transformation.Reorder };

            //to get html representations of pages with embedded resources
            options.IsResourcesEmbedded = true;
            
            // Set password if document is password protected. 
             if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;
           
            //Call ReorderPage and pass the reference of ViewerHandler's class  parameter by reference. 
            Utilities.PageTransformations.ReorderPage(ref handler, guid, CurrentPageNumber, NewPageNumber);
            
            //down cast the handler(ViewerHandler) to viewerHtmlHandler
            ViewerHtmlHandler htmlHandler = (ViewerHtmlHandler)handler;

           //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            List<HtmlInfo> contents = new List<HtmlInfo>();

            foreach (PageHtml page in pages)
            {
                HtmlInfo htmlInfo = new HtmlInfo();
                htmlInfo.HtmlContent = page.HtmlContent;
                htmlInfo.PageNmber = page.PageNumber;
                contents.Add(htmlInfo);
            }
            return contents;
            //ExEnd:RenderAsHtmlAndReorderPage
        }
        /// <summary>
        /// Render a document in html representation whom located at web/remote location.
        /// </summary>
        /// <param name="DocumentURL">URL of the document</param>
        /// <param name="DocumentPassword">Password Parameter is optional</param>
        public static void RenderDocumentAsHtml(Uri DocumentURL, String DocumentPassword = null)
        {
            //ExStart:RenderRemoteDocAsHtml
           //Get Configurations 
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

           //Instantiate the HtmlOptions object
            HtmlOptions options = new HtmlOptions();

            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;
            
            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(DocumentURL,options);
            
            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + Path.GetFileName(DocumentURL.LocalPath), page.HtmlContent);
            }
            //ExEnd:RenderRemoteDocAsHtml
        }
       
        #endregion

        #region ImageRepresentation
        /// <summary>
        /// Render simple document in image representation
        /// </summary>
        /// <param name="DocumentName">File name</param>
        /// <param name="DocumentPassword">Optional</param>
        public static List<ImageInfo> RenderDocumentAsImages(String DocumentName,String DocumentPassword=null)
        {
            //ExStart:RenderAsImage
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create image handler 
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);
            
            // Guid implies that unique document name 
            string guid = DocumentName;
            
            //Initialize ImageOptions Object
            ImageOptions options = new ImageOptions();

            // Set password if document is password protected. 
            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;

            //Get document pages in image form
            List<PageImage> Images = imageHandler.GetPages(guid, options);

            List<ImageInfo> contents = new List<ImageInfo>();

            foreach (PageImage image in Images)
            {
                string imgname=image.PageNumber + "_" + Path.GetFileNameWithoutExtension(DocumentName);
                imgname = Regex.Replace(imgname, @"\s+", "_");
                Utilities.SaveAsImage(imgname, image.Stream);
                
                ImageInfo imageInfo = new ImageInfo();
                imageInfo.ImageUrl = @"../Uploads/images/" + imgname + ".jpg";
                imageInfo.PageNmber = image.PageNumber;
                imageInfo.HtmlContent = @"<div class='image_page'><img src='" + imageInfo.ImageUrl + "' /></div>";
                contents.Add(imageInfo);
            }

            return contents;
            //ExEnd:RenderAsImage

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
        public static List<ImageInfo> RenderDocumentAsImages(String DocumentName, String WatermarkText, Color WatermarkColor, WatermarkPosition position = WatermarkPosition.Diagonal, int WatermarkWidth = 100, String DocumentPassword = null)
        {
            //ExStart:RenderAsImageWithWaterMark
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create image handler
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);

            // Guid implies that unique document name
            string guid = DocumentName;

            //Initialize ImageOptions Object
            ImageOptions options = new ImageOptions();

            // Set password if document is password protected. 
            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;
           
            // Call AddWatermark and pass the reference of ImageOptions object as 1st parameter
            Utilities.PageTransformations.AddWatermark(ref options, WatermarkText, WatermarkColor, position, WatermarkWidth);
            
            //Get document pages in image form
            List<PageImage> Images = imageHandler.GetPages(guid, options);

            List<ImageInfo> contents = new List<ImageInfo>();

            foreach (PageImage image in Images)
            {
                string imgname = image.PageNumber + "_" + Path.GetFileNameWithoutExtension(DocumentName);
                imgname = Regex.Replace(imgname, @"\s+", "_");
                Utilities.SaveAsImage(imgname, image.Stream);

                ImageInfo imageInfo = new ImageInfo();
                imageInfo.ImageUrl = @"../Uploads/images/" + imgname + ".jpg";
                imageInfo.PageNmber = image.PageNumber;
                imageInfo.HtmlContent = @"<div class='image_page'><img src='" + imageInfo.ImageUrl + "' /></div>";
                contents.Add(imageInfo);
            }

            return contents;
            //ExEnd:RenderAsImageWithWaterMark
        }
        /// <summary>
        /// Render the document in image form and set the rotation angle to rotate the page while display.
        /// </summary>
        /// <param name="DocumentName"></param>
        /// <param name="RotationAngle">rotation angle in digits</param>
        /// <param name="DocumentPassword"></param>
        public static List<ImageInfo> RotateDocumentAsImages(String DocumentName, int pageNumber, int RotationAngle, String DocumentPassword = null)
        {
            //ExStart:RenderAsImageWithRotationTransformation
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create image handler
            ViewerHandler handler = new ViewerImageHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;
           
            //Initialize ImageOptions Object and setting Rotate Transformation
            ImageOptions options = new ImageOptions { Transformations=Transformation.Rotate  };

            // Set password if document is password protected. 
            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;

            //Call RotatePages to apply rotate transformation to a page
            Utilities.PageTransformations.RotatePages(ref handler, guid,1,RotationAngle);

            //down cast the handler(ViewerHandler) to viewerHtmlHandler
            ViewerImageHandler imageHandler = (ViewerImageHandler)handler;
            
            //Get document pages in image form
            List<PageImage> Images = imageHandler.GetPages(guid, options);

            List<ImageInfo> contents = new List<ImageInfo>();

            foreach (PageImage image in Images)
            {
                string imgname = image.PageNumber + "_" + Path.GetFileNameWithoutExtension(DocumentName);
                imgname = Regex.Replace(imgname, @"\s+", "_");
                Utilities.SaveAsImage(imgname, image.Stream);

                ImageInfo imageInfo = new ImageInfo();
                imageInfo.ImageUrl = @"../Uploads/images/" + imgname + ".jpg";
                imageInfo.PageNmber = image.PageNumber;
                imageInfo.HtmlContent = @"<div class='image_page'><img src='" + imageInfo.ImageUrl + "' /></div>";
                contents.Add(imageInfo);
            }

            return contents;
            //ExEnd:RenderAsImageWithRotationTransformation
        }
        /// <summary>
        ///  document in image representation and reorder a page
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        /// <param name="CurrentPageNumber">Page existing order number</param>
        /// <param name="NewPageNumber">Page new order number</param>
        /// <param name="DocumentPassword">Password Parameter is optional</param>
        public static List<ImageInfo> RenderDocumentAsImages(String DocumentName, int CurrentPageNumber, int NewPageNumber, String DocumentPassword = null)
        {
            //ExStart:RenderAsImageAndReorderPage
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Cast ViewerHtmlHandler class object to its base class(ViewerHandler).
            ViewerHandler handler = new ViewerImageHandler(config);
            
            // Guid implies that unique document name 
            string guid = DocumentName;

            //Initialize ImageOptions Object and setting Reorder Transformation
            ImageOptions options = new ImageOptions  {  Transformations=Transformation.Reorder  };

            // Set password if document is password protected. 
            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;
           
            //Call ReorderPage and pass the reference of ViewerHandler's class  parameter by reference. 
            Utilities.PageTransformations.ReorderPage(ref handler,guid,CurrentPageNumber,NewPageNumber);
           
            //down cast the handler(ViewerHandler) to viewerHtmlHandler
            ViewerImageHandler imageHandler = (ViewerImageHandler)handler;
            
            //Get document pages in image form
            List<PageImage> Images = imageHandler.GetPages(guid, options);

            List<ImageInfo> contents = new List<ImageInfo>();

            foreach (PageImage image in Images)
            {
                string imgname = image.PageNumber + "_" + Path.GetFileNameWithoutExtension(DocumentName);
                imgname = Regex.Replace(imgname, @"\s+", "_");
                Utilities.SaveAsImage(imgname, image.Stream);

                ImageInfo imageInfo = new ImageInfo();
                imageInfo.ImageUrl = @"../Uploads/images/" + imgname + ".jpg";
                imageInfo.PageNmber = image.PageNumber;
                imageInfo.HtmlContent = @"<div class='image_page'><img src='" + imageInfo.ImageUrl + "' /></div>";
                contents.Add(imageInfo);
            }

            return contents;
            //ExEnd:RenderAsImageAndReorderPage
        }
        /// <summary>
        /// Render a document in image representation whom located at web/remote location.
        /// </summary>
        /// <param name="DocumentURL">URL of the document</param>
        /// <param name="DocumentPassword">Password Parameter is optional</param>
        public static void RenderDocumentAsImages(Uri DocumentURL, String DocumentPassword = null)
        {
            //ExStart:RenderRemoteDocAsImages
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create image handler
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);
                                  
            //Initialize ImageOptions Object
            ImageOptions options = new ImageOptions();

            // Set password if document is password protected. 
            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;
           
            //Get document pages in image form
            List<PageImage> Images = imageHandler.GetPages(DocumentURL, options);

            foreach (PageImage image in Images)
            {
                //Save each image at disk
                Utilities.SaveAsImage(image.PageNumber + "_" + Path.GetFileName(DocumentURL.LocalPath), image.Stream);
            }
            //ExEnd:RenderRemoteDocAsImages
        }

        #endregion

        #region GeneralRepresentation
        /// <summary>
        /// Render a document as it is (original form)
        /// </summary>
        /// <param name="DocumentName"></param>
        public static void RenderDocumentAsOriginal(String DocumentName)
        {
            //ExStart:RenderOriginal
            // Create image handler 
            ViewerImageHandler imageHandler = new ViewerImageHandler(Utilities.GetConfigurations());
            
           // Guid implies that unique document name 
            string guid = DocumentName;

            // Get original file
            FileContainer container = imageHandler.GetFile(guid);
           
            //Save each image at disk
            Utilities.SaveAsImage(DocumentName, container.Stream);
            //ExEnd:RenderOriginal

        }
       /// <summary>
       /// Render a document in PDF Form
       /// </summary>
       /// <param name="DocumentName"></param>
        public static void RenderDocumentAsPDF(String DocumentName)
        {
            //ExStart:RenderAsPdf
            // Create/initialize image handler 
            ViewerImageHandler imageHandler = new ViewerImageHandler(Utilities.GetConfigurations());

           //Initialize PdfFileOptions object
            PdfFileOptions options = new PdfFileOptions();
           
            // Guid implies that unique document name 
            options.Guid = DocumentName;

            // Call GetPdfFile to get FileContainer type object which contains the stream of pdf file.
            FileContainer container = imageHandler.GetPdfFile(options);
           
            //Change the extension of the file and assign to a string type variable filename
            String filename=Path.GetFileNameWithoutExtension(DocumentName)+".pdf";

            //Save each image at disk
            Utilities.SaveFile(filename, container.Stream);
            //ExEnd:RenderAsPdf

        }
        /// <summary>
        /// Load directory structure as file tree
        /// </summary>
        /// <param name="Path"></param>
        public static void LoadFileTree(String Path)
        {
            //ExStart:LoadFileTree
            // Create/initialize image handler 
            ViewerImageHandler imageHandler = new ViewerImageHandler(Utilities.GetConfigurations());

            // Load file tree list for custom path 
            var options = new FileTreeOptions(Path);

           // Load file tree list for ViewerConfig.StoragePath
            FileTreeContainer container = imageHandler.LoadFileTree(options);

            foreach (var node in container.FileTree)
            {
                if (node.IsDirectory)
                {
                    Console.WriteLine("Guid: {0} | Name: {1} | LastModificationDate: {2}",
                        node.Guid,
                        node.Name,
                        node.LastModificationDate);
                }
                else
                    Console.WriteLine("Guid: {0} | Name: {1} | Document type: {2} | File type: {3} | Extension: {4} | Size: {5} | LastModificationDate: {6}",
                        node.Guid,
                        node.Name,
                        node.DocumentType,
                        node.FileType,
                        node.Extension,
                        node.Size,
                        node.LastModificationDate);
            }

            //ExEnd:LoadFioleTree

        }
        #endregion

    }

    
    
}
