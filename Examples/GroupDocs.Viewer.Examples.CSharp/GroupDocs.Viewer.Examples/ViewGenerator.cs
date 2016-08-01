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
using GroupDocs.Viewer.Handler.Input;
using System.Globalization;

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
        public static void RenderDocumentAsHtml(String DocumentName,String DocumentPassword=null)
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
          //  options.PageNumbersToConvert = Enumerable.Range(1, 3).ToList();
            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
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
        public static void RenderDocumentAsHtml(String DocumentName, String WatermarkText, Color WatermarkColor, WatermarkPosition position = WatermarkPosition.Diagonal, int WatermarkWidth = 100, String DocumentPassword = null)
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
            Utilities.PageTransformations.AddWatermark(ref options, WatermarkText, WatermarkColor, position, WatermarkWidth);
            
            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderAsHtmlWithWaterMark
        }
        /// <summary>
        ///  document in html representation and reorder a page
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        /// <param name="CurrentPageNumber">Page existing order number</param>
        /// <param name="NewPageNumber">Page new order number</param>
        /// <param name="DocumentPassword">Password Parameter is optional</param>
        public static void RenderDocumentAsHtml(String DocumentName, int CurrentPageNumber, int NewPageNumber, String DocumentPassword = null)
        {
            //ExStart:RenderAsHtmlAndReorderPage
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Cast ViewerHtmlHandler class object to its base class(ViewerHandler).
            ViewerHandler<PageHtml> handler = new ViewerHtmlHandler(config);

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

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
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

        public static void RenderLargeDocumentAsHtml(String DocumentName, String DocumentPassword = null)
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
            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;
            //Get Pre Render info
            int allPages = htmlHandler.GetDocumentInfo(guid).Pages.Count;

            int pageNumber = 1;

            // Get total iterations and remainder
            int totalIterations = allPages / 5;
            int remainder = allPages % 5;

            for (int i = 1; i <= totalIterations; i++)
            {
                // Set range of the pages
                options.PageNumbersToConvert = Enumerable.Range(pageNumber, 5).ToList();
                // Get pages
                List<PageHtml> pages = htmlHandler.GetPages(guid, options);
                //Save each page at disk
                foreach (PageHtml page in pages)
                {
                    //Save each page at disk
                    Utilities.SaveAsHtml("it" + i + "_" + "p" + page.PageNumber + "_" + DocumentName, page.HtmlContent);
                }
                pageNumber += 5;

            }
            if (remainder > 0)
            {
                options.PageNumbersToConvert = Enumerable.Range(pageNumber, remainder).ToList();
                List<PageHtml> pages = htmlHandler.GetPages(guid, options);
                //Save each page at disk
                foreach (PageHtml page in pages)
                {
                    //Save each page at disk
                    Utilities.SaveAsHtml("it" + (totalIterations + 1) + "_" + "p" + page.PageNumber + "_" + DocumentName, page.HtmlContent);
                }
                pageNumber += 5;
            }

            //ExEnd:RenderAsHtml
        }
        #endregion

        #region ImageRepresentation
        /// <summary>
        /// Render simple document in image representation
        /// </summary>
        /// <param name="DocumentName">File name</param>
        /// <param name="DocumentPassword">Optional</param>
        public static void RenderDocumentAsImages(String DocumentName,String DocumentPassword=null)
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

            // Set one page per sheet option to false for Multiple pages per sheet in Excel documents, default value of this option is true
            // options.CellsOptions.OnePagePerSheet = false;

            //Get document pages in image form
            List<PageImage> Images = imageHandler.GetPages(guid, options);
          
            foreach (PageImage image in Images)
            {
                //Save each image at disk
                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream);
            }
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
        public static void RenderDocumentAsImages(String DocumentName, String WatermarkText, Color WatermarkColor, WatermarkPosition position = WatermarkPosition.Diagonal, int WatermarkWidth = 100, String DocumentPassword = null)
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

            foreach (PageImage image in Images)
            {
                //Save each image at disk
                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream);
            }
            //ExEnd:RenderAsImageWithWaterMark
        }
        /// <summary>
        /// Render the document in image form and set the rotation angle to rotate the page while display.
        /// </summary>
        /// <param name="DocumentName"></param>
        /// <param name="RotationAngle">rotation angle in digits</param>
        /// <param name="DocumentPassword"></param>
        public static void RenderDocumentAsImages(String DocumentName, int RotationAngle, String DocumentPassword = null)
        {
            //ExStart:RenderAsImageWithRotationTransformation
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create image handler
            ViewerHandler<PageImage> handler = new ViewerImageHandler(config);

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

            foreach (PageImage image in Images)
            {
                //Save each image at disk
                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream);
            }
            //ExEnd:RenderAsImageWithRotationTransformation
        }
        /// <summary>
        ///  document in image representation and reorder a page
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        /// <param name="CurrentPageNumber">Page existing order number</param>
        /// <param name="NewPageNumber">Page new order number</param>
        /// <param name="DocumentPassword">Password Parameter is optional</param>
        public static void RenderDocumentAsImages(String DocumentName, int CurrentPageNumber, int NewPageNumber, String DocumentPassword = null)
        {
            //ExStart:RenderAsImageAndReorderPage
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Cast ViewerHtmlHandler class object to its base class(ViewerHandler).
            ViewerHandler<PageImage> handler = new ViewerImageHandler(config);
            
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

            foreach (PageImage image in Images)
            {
                //Save each image at disk
                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream);
            }
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

            // To Apply transformations on PDF file
            // options.Transformations = Transformation.Rotate | Transformation.Reorder | Transformation.AddPrintAction;

            // Call GetPdfFile to get FileContainer type object which contains the stream of pdf file.
            FileContainer container = imageHandler.GetPdfFile(DocumentName);
           
            //Change the extension of the file and assign to a string type variable filename
            String filename = Path.GetFileNameWithoutExtension(DocumentName) + ".pdf";

            //Save each image at disk
            Utilities.SaveFile(filename, container.Stream);
            //ExEnd:RenderAsPdf

        }

        /// <summary>
        /// Render a document in PDF Form with watermark 
        /// </summary>
        /// <param name="DocumentName"></param>
        /// <param name="WatermarkText"></param>
        public static void RenderDocumentAsPDF(String DocumentName, String WatermarkText)
        {
            //ExStart:RenderAsPdf
            // Create/initialize image handler 
            ViewerImageHandler imageHandler = new ViewerImageHandler(Utilities.GetConfigurations());

            // Set watermark properties
            Watermark watermark = new Watermark(WatermarkText);
            watermark.Color = System.Drawing.Color.Blue;
            watermark.Position = WatermarkPosition.Diagonal;
            watermark.Width = 100;

            PdfFileOptions options = new PdfFileOptions();
            options.Watermark = watermark;
            
            // To Apply transformations on PDF file
            // options.Transformations = Transformation.Rotate | Transformation.Reorder | Transformation.AddPrintAction;
            
            // Call GetPdfFile to get FileContainer type object which contains the stream of pdf file.
            FileContainer container = imageHandler.GetPdfFile(DocumentName, options);

            //Change the extension of the file and assign to a string type variable filename
            String filename = Path.GetFileNameWithoutExtension(DocumentName) + ".pdf";

            //Save each image at disk
            Utilities.SaveFile(filename, container.Stream);
            //ExEnd:RenderAsPdf

        }

        /// <summary>
        /// Render a document in PDF Form with watermark 
        /// </summary>
        /// <param name="DocumentName"></param>
        /// <param name="WatermarkText"></param>
        /// <param name="WatermarkFontName"></param>
        public static void RenderDocumentAsPDF(String DocumentName, String WatermarkText, String WatermarkFontName = "MS Gothic")
        {
            //ExStart:RenderAsPdf
            // Create/initialize image handler 
            ViewerImageHandler imageHandler = new ViewerImageHandler(Utilities.GetConfigurations());

            // Set watermark properties
            Watermark watermark = new Watermark(WatermarkText);
            watermark.Color = System.Drawing.Color.Blue;
            watermark.Position = WatermarkPosition.Diagonal;
            watermark.Width = 100;

            // Set watermark font name which contains Japanese characters
            watermark.FontName = WatermarkFontName;

            PdfFileOptions options = new PdfFileOptions();
            options.Watermark = watermark;

            // To Apply transformations on PDF file
            // options.Transformations = Transformation.Rotate | Transformation.Reorder | Transformation.AddPrintAction;

            // Call GetPdfFile to get FileContainer type object which contains the stream of pdf file.
            FileContainer container = imageHandler.GetPdfFile(DocumentName, options);

            //Change the extension of the file and assign to a string type variable filename
            String filename = Path.GetFileNameWithoutExtension(DocumentName) + ".pdf";

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

            //ExEnd:LoadFileTree

        }
        #endregion

       
        #region InputDataHandlers

        /// <summary>
        /// Render a document from Azure Storage 
        /// </summary>
        /// <param name="DocumentName"></param>
        public static void RenderDocFromAzure(String DocumentName)
        {
            // Setup GroupDocs.Viewer config
            ViewerConfig config = Utilities.GetConfigurations();
           

            // File guid
            string guid = DocumentName;

            // Use custom IInputDataHandler implementation
            IInputDataHandler inputDataHandler = new AzureInputDataHandler("<Account_Name>","<Account_Key>","<Container_Name>");

            // Get file HTML representation
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config, inputDataHandler);

            List<PageHtml> pages = htmlHandler.GetPages(guid);
            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
        }
        /// <summary>
        /// Render a document from FTP location 
        /// </summary>
        /// <param name="DocumentName"></param>
        public static void RenderDocFromFTP(String DocumentName)
        {
            // Setup GroupDocs.Viewer config
            ViewerConfig config = Utilities.GetConfigurations();
           
            // File guid
            string guid = DocumentName;

            // Use custom IInputDataHandler implementation
            IInputDataHandler inputDataHandler = new FtpInputDataHandler();
            
            // Get file HTML representation
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config, inputDataHandler);

            List<PageHtml> pages = htmlHandler.GetPages(guid);
            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
        }
        #endregion

        #region OtherOperations
        /// <summary>
        /// Set custom fonts directory path
        /// </summary>
        /// <param name="DocumentName">Input document name</param>
        public static void SetCustomFontDirectory(String DocumentName)
        {
            try
            {
                //ExStart:SetCustomFontDirectory
                // Setup GroupDocs.Viewer config
                ViewerConfig config = Utilities.GetConfigurations();

                // Add custom fonts directories to FontDirectories list
                config.FontDirectories.Add(@"/usr/admin/Fonts");
                config.FontDirectories.Add(@"/home/admin/Fonts");

                ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

                // File guid
                string guid = DocumentName;

                List<PageHtml> pages = htmlHandler.GetPages(guid);

                foreach (PageHtml page in pages)
                {
                    //Save each page at disk
                    Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
                }
                //ExEnd:SetCustomFontDirectory
            }
            catch(System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        #endregion

        #region EmailAttachments
        /// <summary>
        /// Get attached image with email message
        /// </summary>
        /// <param name="DocumentName">Input document name</param>
        public static void GetEmailAttachments(String DocumentName)
        {
            try
            {
                //ExStart:GetEmailAttachments
                // Setup GroupDocs.Viewer config
                ViewerConfig config = Utilities.GetConfigurations();

                // Create image handler
                ViewerImageHandler handler = new ViewerImageHandler(config);
                EmailAttachment attachment = new EmailAttachment(DocumentName, "attachment-image.png");

                // Get attachment original file
                FileContainer container = handler.GetFile(attachment);

                Console.WriteLine("Attach name: {0}, Type: {1}", attachment.Name, attachment.FileType);
                Console.WriteLine("Attach stream lenght: {0}", container.Stream.Length);
                //ExEnd:GetEmailAttachments
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Get attached file's html representation
        /// </summary>
        /// <param name="DocumentName">Input document name</param>
        public static void GetEmailAttachmentHTMLRepresentation(String DocumentName)
        {
            try
            {
                //ExStart:GetEmailAttachmentHTMLRepresentation
                // Setup GroupDocs.Viewer config
                ViewerConfig config = Utilities.GetConfigurations();

                // Setup html conversion options
                HtmlOptions htmlOptions = new HtmlOptions();
                htmlOptions.IsResourcesEmbedded = false;

                // Init viewer html handler
                ViewerHtmlHandler handler = new ViewerHtmlHandler(config);

                DocumentInfoContainer info = handler.GetDocumentInfo(DocumentName);

                // Iterate over the attachments collection
                foreach (AttachmentBase attachment in info.Attachments)
                {
                    Console.WriteLine("Attach name: {0}, size: {1}", attachment.Name, attachment.FileType);

                    // Get attachment document html representation
                    List<PageHtml> pages = handler.GetPages(attachment, htmlOptions);
                    foreach (PageHtml page in pages)
                    {
                        Console.WriteLine("  Page: {0}, size: {1}", page.PageNumber, page.HtmlContent.Length);
                        foreach (HtmlResource htmlResource in page.HtmlResources)
                        {
                            Stream resourceStream = handler.GetResource(attachment, htmlResource);
                            Console.WriteLine("     Resource: {0}, size: {1}", htmlResource.ResourceName, resourceStream.Length);
                        }
                    }
                }
                //ExEnd:GetEmailAttachmentHTMLRepresentation
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Get attached file's image representation
        /// </summary>
        /// <param name="DocumentName">Input document name</param>
        public static void GetEmailAttachmentImageRepresentation(String DocumentName)
        {
            try
            {
                //ExStart:GetEmailAttachmentImageRepresentation
                // Setup GroupDocs.Viewer config
                ViewerConfig config = Utilities.GetConfigurations();

                // Init viewer image handler
                ViewerImageHandler handler = new ViewerImageHandler(config);

                DocumentInfoContainer info = handler.GetDocumentInfo(DocumentName);

                // Iterate over the attachments collection
                foreach (AttachmentBase attachment in info.Attachments)
                {
                    Console.WriteLine("Attach name: {0}, size: {1}", attachment.Name, attachment.FileType);

                    // Get attachment document image representation
                    List<PageImage> pages = handler.GetPages(attachment);
                    foreach (PageImage page in pages)
                        Console.WriteLine("  Page: {0}, size: {1}", page.PageNumber, page.Stream.Length);
                }
                //ExEnd:GetEmailAttachmentImageRepresentation
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        #endregion 

        #region DocumentInformation
        /// <summary>
        /// Get document information by guid
        /// </summary>
        /// <param name="DocumentName">Input document name</param>
        public static void GetDocumentInfoByGuid(String DocumentName)
        {
            try
            {
                //ExStart:GetDocumentInfoByGuid
                // Setup GroupDocs.Viewer config
                ViewerConfig config = Utilities.GetConfigurations();

                // Create html handler
                ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

                string guid = DocumentName;
                // Get document information
                DocumentInfoOptions options = new DocumentInfoOptions();
                DocumentInfoContainer documentInfo = htmlHandler.GetDocumentInfo(guid, options);

                Console.WriteLine("DateCreated: {0}", documentInfo.DateCreated);
                Console.WriteLine("DocumentType: {0}", documentInfo.DocumentType);
                Console.WriteLine("DocumentTypeFormat: {0}", documentInfo.DocumentTypeFormat);
                Console.WriteLine("Extension: {0}", documentInfo.Extension);
                Console.WriteLine("FileType: {0}", documentInfo.FileType);
                Console.WriteLine("Guid: {0}", documentInfo.Guid);
                Console.WriteLine("LastModificationDate: {0}", documentInfo.LastModificationDate);
                Console.WriteLine("Name: {0}", documentInfo.Name);
                Console.WriteLine("PageCount: {0}", documentInfo.Pages.Count);
                Console.WriteLine("Size: {0}", documentInfo.Size);

                foreach (PageData pageData in documentInfo.Pages)
                {
                    Console.WriteLine("Page number: {0}", pageData.Number);
                    Console.WriteLine("Page name: {0}", pageData.Name);
                }
                //ExEnd:GetDocumentInfoByGuid
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Get document information by Uri
        /// </summary>
        /// <param name="Uri">Uri of input document</param>
        public static void GetDocumentInfoByUri(String Uri)
        {
            try
            {
                //ExStart:GetDocumentInfoByUri
                // Setup GroupDocs.Viewer config
                ViewerConfig config = Utilities.GetConfigurations();

                // Create html handler
                ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

                Uri uri = new Uri(Uri);

                // Get document information
                DocumentInfoOptions options = new DocumentInfoOptions();
                DocumentInfoContainer documentInfo = htmlHandler.GetDocumentInfo(uri, options);

                Console.WriteLine("DateCreated: {0}", documentInfo.DateCreated);
                Console.WriteLine("DocumentType: {0}", documentInfo.DocumentType);
                Console.WriteLine("DocumentTypeFormat: {0}", documentInfo.DocumentTypeFormat);
                Console.WriteLine("Extension: {0}", documentInfo.Extension);
                Console.WriteLine("FileType: {0}", documentInfo.FileType);
                Console.WriteLine("Guid: {0}", documentInfo.Guid);
                Console.WriteLine("LastModificationDate: {0}", documentInfo.LastModificationDate);
                Console.WriteLine("Name: {0}", documentInfo.Name);
                Console.WriteLine("PageCount: {0}", documentInfo.Pages.Count);
                Console.WriteLine("Size: {0}", documentInfo.Size);

                foreach (PageData pageData in documentInfo.Pages)
                {
                    Console.WriteLine("Page number: {0}", pageData.Number);
                    Console.WriteLine("Page name: {0}", pageData.Name);
                }
                //ExEnd:GetDocumentInfoByUri
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        /// <summary>
        /// Get document information by stream
        /// </summary>
        /// <param name="DocumentName">Name of input document</param>
        public static void GetDocumentInfoByStream(String DocumentName)
        {
            try
            {
                //ExStart:GetDocumentInfoByStream
                // Setup GroupDocs.Viewer config
                ViewerConfig config = Utilities.GetConfigurations();

                // Create html handler
                ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

                // Get document stream
                Stream stream = Utilities.GetDocumentStream(DocumentName);
                // Get document information
                DocumentInfoOptions options = new DocumentInfoOptions();
                DocumentInfoContainer documentInfo = htmlHandler.GetDocumentInfo(stream, options);

                Console.WriteLine("DateCreated: {0}", documentInfo.DateCreated);
                Console.WriteLine("DocumentType: {0}", documentInfo.DocumentType);
                Console.WriteLine("DocumentTypeFormat: {0}", documentInfo.DocumentTypeFormat);
                Console.WriteLine("Extension: {0}", documentInfo.Extension);
                Console.WriteLine("FileType: {0}", documentInfo.FileType);
                Console.WriteLine("Guid: {0}", documentInfo.Guid);
                Console.WriteLine("LastModificationDate: {0}", documentInfo.LastModificationDate);
                Console.WriteLine("Name: {0}", documentInfo.Name);
                Console.WriteLine("PageCount: {0}", documentInfo.Pages.Count);
                Console.WriteLine("Size: {0}", documentInfo.Size);

                foreach (PageData pageData in documentInfo.Pages)
                {
                    Console.WriteLine("Page number: {0}", pageData.Number);
                    Console.WriteLine("Page name: {0}", pageData.Name);
                }
                stream.Close();
                //ExEnd:GetDocumentInfoByStream
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        
        #endregion

        #region DocumentCache
        /// <summary>
        /// Remove cache files 
        /// </summary>
        public static void RemoveCacheFiles()
        {
            try
            {
                //ExStart:RemoveCacheFiles
                // Setup GroupDocs.Viewer config
                ViewerConfig config = Utilities.GetConfigurations();

                // Init viewer image or html handler
                ViewerHtmlHandler viewerImageHandler = new ViewerHtmlHandler(config);

                //Clear all cache files 
                viewerImageHandler.ClearCache();
                //ExEnd:RemoveCacheFiles
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        /// <summary>
        /// Remove cache file older than specified date 
        /// </summary>
        public static void RemoveCacheFiles(TimeSpan OlderThanDays)
        {
            try
            {
                //ExStart:RemoveCacheFilesTimeSpan
                // Setup GroupDocs.Viewer config
                ViewerConfig config = Utilities.GetConfigurations();

                // Init viewer image or html handler
                ViewerImageHandler viewerImageHandler = new ViewerImageHandler(config);

                //Clear files from cache older than specified time interval 
                viewerImageHandler.ClearCache(OlderThanDays);
                //ExEnd:RemoveCacheFilesTimeSpan
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        #endregion


        #region OtherImprovements

        /* Working from 3.2.0*/
       /// <summary>
        /// Show grid lines for Excel files in html representation
       /// </summary>
       /// <param name="DocumentName"></param>
        public static void RenderWithGridLinesInExcel(String DocumentName)
        {
            // Setup GroupDocs.Viewer config
            ViewerConfig config = Utilities.GetConfigurations();
           
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // File guid
            string guid = DocumentName;

            // Set html options to show grid lines
            HtmlOptions options = new HtmlOptions();
            //do same while using ImageOptions
            options.CellsOptions.ShowGridLines = true;

            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
        }
        /// <summary>
        /// Multiple pages per sheet
        /// </summary>
        /// <param name="DocumentName"></param>
        public static void RenderMultiExcelSheetsInOnePage(String DocumentName)
        {
            // Setup GroupDocs.Viewer config
            ViewerConfig config = Utilities.GetConfigurations();
           
            // Create image or html handler
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);
            string guid = DocumentName;

            // Set pdf file one page per sheet option to false, default value of this option is true
            PdfFileOptions pdfFileOptions = new PdfFileOptions(); 
            pdfFileOptions.CellsOptions.OnePagePerSheet = false;

            //Get pdf file
            FileContainer fileContainer = imageHandler.GetPdfFile(DocumentName, pdfFileOptions);

            Utilities.SaveFile("test.pdf", fileContainer.Stream);
        }
        /// <summary>
        /// Get all supported document formats
        /// </summary>
        
        public static void ShowAllSupportedFormats()
        {
            // Setup GroupDocs.Viewer config
            ViewerConfig config = Utilities.GetConfigurations();

            // Create image or html handler
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);

            // Get supported document formats
            DocumentFormatsContainer documentFormatsContainer = imageHandler.GetSupportedDocumentFormats();
            Dictionary<string, string> supportedDocumentFormats = documentFormatsContainer.SupportedDocumentFormats;

            foreach (KeyValuePair<string, string> supportedDocumentFormat in supportedDocumentFormats)
            {
                Console.WriteLine(string.Format("Extension: '{0}'; Document format: '{1}'", supportedDocumentFormat.Key, supportedDocumentFormat.Value));
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Show hidden sheets for Excel files in image representation
        /// </summary>
        /// <param name="DocumentName"></param>
        public static void RenderWithHiddenSheetsInExcel(String DocumentName)
        {
            // Setup GroupDocs.Viewer config
            ViewerConfig config = Utilities.GetConfigurations();

            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // File guid
            string guid = DocumentName;

            // Set html options to show grid lines
            HtmlOptions options = new HtmlOptions();
            //do same while using ImageOptions
            options.CellsOptions.ShowHiddenSheets = true;

            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
        }
        /// <summary>
        /// create and use file with localized string
        /// </summary>
        /// <param name="DocumentName"></param>
        public static void RenderWithLocales(String DocumentName)
        {
            // Setup GroupDocs.Viewer config
            ViewerConfig config = Utilities.GetConfigurations();
            config.LocalesPath = @"D:\from office working\for aspose\GroupDocsViewer\GroupDocs.Viewer.Examples\Data\Locale";

            CultureInfo cultureInfo = new CultureInfo("fr-FR");
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config, cultureInfo); 

            // File guid
            string guid = DocumentName;

            // Set html options to show grid lines
            HtmlOptions options = new HtmlOptions();
            
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
        }

        #endregion
    }

    
    
}
