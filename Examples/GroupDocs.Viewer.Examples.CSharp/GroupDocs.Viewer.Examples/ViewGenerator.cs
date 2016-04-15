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
            int allPages = htmlHandler.GetDocumentInfo(new DocumentInfoOptions(guid)).Pages.Count;

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
            pdfFileOptions.Guid = guid;
            pdfFileOptions.CellsOptions.OnePagePerSheet = false;

            //Get pdf file
            FileContainer fileContainer = imageHandler.GetPdfFile(pdfFileOptions);

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
