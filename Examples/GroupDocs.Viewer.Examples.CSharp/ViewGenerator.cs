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
        /// Renders document into html
        /// </summary>
        /// <param name="DocumentName">File name</param>
        /// <param name="DocumentPassword">Optional</param>
        public static void RenderDocumentAsHtml(String DocumentName, String DocumentPassword = null)
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
            //options.PageNumbersToConvert = Enumerable.Range(1, 3).ToList();

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
        /// Renders document into html with watermark
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
        ///  Renders document into html with page reordering
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
            HtmlOptions options = new HtmlOptions { Transformations = Transformation.Reorder };

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
        /// Renders a document of web/remote location into html 
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
            List<PageHtml> pages = htmlHandler.GetPages(DocumentURL, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + Path.GetFileName(DocumentURL.LocalPath), page.HtmlContent);
            }
            //ExEnd:RenderRemoteDocAsHtml
        }

        /// <summary>
        /// Renders document into responsive html
        /// </summary>
        /// <param name="DocumentName">File name</param>
        /// <param name="DocumentPassword">Optional</param>
        public static void RenderDocumentAsResponsiveHtml(String DocumentName)
        {
            //ExStart:RenderDocumentAsResponsiveHtml
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
            options.EnableResponsiveRendering = true;

            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderDocumentAsResponsiveHtml
        }

        /// <summary>
        /// Renders PDF document's layers separately into html
        /// </summary>
        /// <param name="DocumentName">Name of the document</param>
        public static void RenderPDFLayersSeparately(String DocumentName)
        {
            //ExStart:RenderPDFLayersSeparately
            //Get Configurations 
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // Set pdf options to render pdf layers into separate html elements
            HtmlOptions options = new HtmlOptions();
            options.PdfOptions.RenderLayersSeparately = true; // Default value is false

            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(DocumentName, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderPDFLayersSeparately
        }

        /// <summary>
        /// Renders PDF document into html without annotations
        /// </summary>
        /// <param name="DocumentName">Name of the document</param>
        public static void RenderPDFDocumentWithoutAnnotations(String DocumentName)
        {
            //ExStart:RenderPDFDocumentWithoutAnnotations
            //Get Configurations 
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // Set pdf options to render content without annotations
            HtmlOptions options = new HtmlOptions();
            options.RenderComments = false; // Default value is false
            //options.RenderComments = true; // For rendering document with annotations

            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(DocumentName, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderPDFDocumentWithoutAnnotations
        }

        /// <summary>
        /// Renders Word document into html with track changes
        /// </summary>
        /// <param name="DocumentName">File name</param>
        public static void RenderWordDocumentAsHtmlWithTrackChanges(String DocumentName)
        {
            //ExStart:RenderWordDocumentAsHtmlWithTrackChanges
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            //Instantiate the HtmlOptions object
            HtmlOptions options = new HtmlOptions();

            options.WordsOptions.ShowTrackedChanges = true; // Default value is false

            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderWordDocumentAsHtmlWithTrackChanges
        }

        /// <summary>
        /// Gets printable HTML of the source document
        /// </summary>
        /// <param name="DocumentName">File name</param>
        /// <param name="DocumentPassword">Optional</param>
        public static void GetPrintableHTML(String DocumentName, String DocumentPassword = null)
        {
            //ExStart:GetPrintableHTML
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            // Setup watermark and style
            Watermark watermark = new Watermark("Watermark text");
            string css = "a { color: hotpink; }";

            // Setup printable options
            var options = new PrintableHtmlOptions();
            options.Watermark = watermark;
            options.Css = css;

            // Get document html for print with custom css and watermark
            var container = htmlHandler.GetPrintableHtml(guid, options);

            Console.WriteLine("Html content: {0}", container.HtmlContent);
            //ExEnd:GetPrintableHTML
        }

        /// <summary>
        /// Render a document into html specifying resource prefix
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        public static void RenderDocumentAsHtmlWithResourcePrefix(string DocumentName)
        {
            //ExStart:RenderDocumentAsHtmlWithResourcePrefix
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            //Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            //Guid implies that unique document name 
            string guid = DocumentName;

            //Instantiate the HtmlOptions object
            HtmlOptions options = new HtmlOptions();

            //To get html representations of pages with embedded resources
            options.IsResourcesEmbedded = false;

            //Set resource prefix
            options.HtmlResourcePrefix = "http://example.com/api/pages/{page-number}/resources/{resource-name}";
            //The {page-number} and {resource-name} patterns will be replaced with current processing page number and resource name accordingly.

            //To ignore resource prefix in CSS 
            options.IgnorePrefixInResources = true;

            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderDocumentAsHtmlWithResourcePrefix


        }

        /// <summary>
        /// Renders Excel file as html with internal hyperlink prefix
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        public static void RenderExcelAsHtmlWithInternalHyperlinkPrefix(string DocumentName)
        {

            //ExStart:RenderExcelAsHtmlWithInternalHyperlinkPrefix
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
            string guid = DocumentName;

            // Set html options to show grid lines
            HtmlOptions options = new HtmlOptions();
            options.CellsOptions.InternalHyperlinkPrefix = "http://contoso.com/api/getPage?name=";

            //InternalHyperlinkPrefix value may contain page number placeholder which will be substituted with referenced sheet number.
            options.CellsOptions.InternalHyperlinkPrefix = "http://contoso.com/api/getPage?number={page-number}";

            DocumentInfoContainer container = htmlHandler.GetDocumentInfo(guid);

            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderExcelAsHtmlWithInternalHyperlinkPrefix

        }

        /// <summary>
        /// Renders Excel file as html specifying number of rows per page
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        public static void RenderExcelAsHtmlWithCountRowsPerPage(string DocumentName)
        {

            //ExStart:RenderExcelAsHtmlWithCountRowsPerPage
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
            string guid = DocumentName;

            // Set html options to show grid lines
            HtmlOptions options = new HtmlOptions();
            options.CellsOptions.OnePagePerSheet = false;

            // Set count rows to render into one page. Default value is 50.
            options.CellsOptions.CountRowsPerPage = 50;

            // Get pages
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderExcelAsHtmlWithCountRowsPerPage

        }

        /// <summary>
        /// Renders Excel file as html specifying the mode of text overflow
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        public static void RenderExcelAsHtmlWithTextOverflowMode(string DocumentName)
        {

            //ExStart:RenderExcelAsHtmlWithTextOverflowMode
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
            string guid = DocumentName;

            // Set Cells options to hide overflowing text
            HtmlOptions options = new HtmlOptions();
            options.CellsOptions.TextOverflowMode = TextOverflowMode.HideText;

            // Get pages
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderExcelAsHtmlWithTextOverflowMode

        }

        /// <summary>
        /// Renders Excel file as Html ignoring the empty rows
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        public static void RenderExcelAsHtmlIgnoringEmptyRows(string DocumentName)
        {

            //ExStart:RenderExcelAsHtmlIgnoringEmptyRows
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
            string guid = DocumentName;

            // Set Cells options to hide overflowing text
            HtmlOptions options = new HtmlOptions();
            options.CellsOptions.IgnoreEmptyRows = true; // default value is false

            // Get pages
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderExcelAsHtmlIgnoringEmptyRows

        }

        /// <summary>
        /// Renders simple document into html with PreventGlyphsGrouping settings
        /// </summary>
        /// <param name="DocumentName">File name</param>
        /// <param name="DocumentPassword">Optional</param>
        public static void RenderDocumentAsHtmlWithEnablePreciseRendering(String DocumentName, String DocumentPassword = null)
        {
            //ExStart:RenderDocumentAsHtmlWithEnablePreciseRendering
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

            // Set pdf options to render content in precise mode
            options.PdfOptions.EnablePreciseRendering = true; // Default value is false

            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderDocumentAsHtmlWithEnablePreciseRendering
        }

        /// <summary>
        /// Renders Model and all non empty Layouts from CAD document into html
        /// </summary>
        /// <param name="DocumentName">File name</param> 
        public static void RenderLayoutsOfCADDocument(String DocumentName)
        {
            //ExStart:RenderLayoutsOfCADDocument
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            // Set CAD options to render Model and all non empty Layouts
            HtmlOptions options = new HtmlOptions();
            options.CadOptions.RenderLayouts = true;

            // Get pages 
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderLayoutsOfCADDocument
        }

        /// <summary>
        /// Renders specific Layout from CAD document into html
        /// </summary>
        /// <param name="DocumentName">File name</param> 
        public static void RenderSpecificLayoutOfCADDocument(String DocumentName)
        {
            //ExStart:RenderSpecificLayoutOfCADDocument
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            // Set CAD options to render Model and all non empty Layouts
            HtmlOptions options = new HtmlOptions();
            options.CadOptions.LayoutName = "MyFirstLayout";

            // Get pages 
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderSpecificLayoutOfCADDocument
        }

        /// <summary>
        /// Gets list of all Layouts from CAD document
        /// </summary>
        /// <param name="DocumentName">File name</param> 
        public static void GetListOfLayoutsOfCADDocument(String DocumentName)
        {
            //ExStart:GetListOfLayoutsOfCADDocument
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            // Set CAD options to get the full list of Layouts
            DocumentInfoOptions documentInfoOptions = new DocumentInfoOptions();
            documentInfoOptions.CadOptions.RenderLayouts = true;

            // Get DocumentInfoContainer and iterate through pages 
            DocumentInfoContainer documentInfoContainer = htmlHandler.GetDocumentInfo(guid, documentInfoOptions);
            foreach (PageData page in documentInfoContainer.Pages)
            {
                Console.WriteLine("Page number: {0} - {1}", page.Number, page.Name);
            }
            //ExEnd:GetListOfLayoutsOfCADDocument
        }

        /// <summary>
        /// Renders document into html with comments
        /// </summary>
        /// <param name="DocumentName">File name</param> 
        public static void RenderDocumentAsHtmlWithComments(String DocumentName)
        {
            //ExStart:RenderDocumentAsHtmlWithComments
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            // Set CAD options to render Model and all non empty Layouts
            HtmlOptions options = new HtmlOptions();
            options.RenderComments = true; // Default value is false

            // Get pages 
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderDocumentAsHtmlWithComments
        }

        /// <summary>
        /// Renders large documents in chunks
        /// </summary>
        /// <param name="DocumentName">File name</param>
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
                options.PageNumbersToRender = Enumerable.Range(pageNumber, 5).ToList();
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
                options.PageNumbersToRender = Enumerable.Range(pageNumber, remainder).ToList();
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

        /// <summary>
        /// Renders document into html excluding fonts
        /// </summary>
        /// <param name="DocumentName">File name</param>
        public static void RenderDocumentAsHtmlExcludingFonts(String DocumentName)
        {
            //ExStart:RenderDocumentAsHtmlExcludingFonts
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            //Instantiate the HtmlOptions object
            HtmlOptions options = new HtmlOptions();

            options.ExcludeFonts = true;

            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderDocumentAsHtmlExcludingFonts
        }

        /// <summary>
        /// Shows grid lines for Excel files in html representation
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
        /// Renders multiple pages per sheet
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
        /// Shows hidden sheets for Excel files in image representation
        /// </summary>
        /// <param name="DocumentName"></param>
        public static void RenderWithHiddenSheetsInExcel(String DocumentName)
        {
            // Setup GroupDocs.Viewer config
            ViewerConfig config = Utilities.GetConfigurations();

            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // File guid
            string guid = DocumentName;

            // Set html options to render hidden sheets
            HtmlOptions options = new HtmlOptions();
            //do same while using ImageOptions
            options.ShowHiddenPages = true;

            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
        }

        /// <summary>
        /// Renders hidden pages of Visio file as html
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        public static void RenderHiddenPagesOfVisioAsHtml(string DocumentName)
        {
            //ExStart:RenderHiddenPagesInVisioAsHtml
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
            string guid = DocumentName;

            // Set html options to render hidden pages
            HtmlOptions options = new HtmlOptions();
            options.ShowHiddenPages = true;

            DocumentInfoContainer container = htmlHandler.GetDocumentInfo(guid);

            foreach (PageData page in container.Pages)
                Console.WriteLine("Page number: {0}, Page Name: {1}, IsVisible: {2}", page.Number, page.Name, page.IsVisible);

            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderHiddenPagesInVisioAsHtml


        }

        /// <summary>
        /// Renders hidden pages of Visio file as html
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        public static void RenderHiddenSlidesOfPowerPointAsHtml(string DocumentName)
        {
            //ExStart:RenderHiddenSlidesOfPowerPointAsHtml
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
            string guid = DocumentName;

            // Set html options to render hidden slides
            HtmlOptions options = new HtmlOptions();
            options.ShowHiddenPages = true;

            DocumentInfoContainer container = htmlHandler.GetDocumentInfo(guid);

            foreach (PageData page in container.Pages)
                Console.WriteLine("Page number: {0}, Page Name: {1}, IsVisible: {2}", page.Number, page.Name, page.IsVisible);

            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderHiddenSlidesOfPowerPointAsHtml


        }

        /// <summary>
        /// Creates and uses file with localized string
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

        /// <summary>
        ///  Reorder pages of the document containing hidden pages in HTML based rendering
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        /// <param name="CurrentPageNumber">Page existing order number</param>
        /// <param name="NewPageNumber">Page new order number</param>
        public static void ReorderDocumentPagesWithRenderOptionsAsHtml(String DocumentName, int CurrentPageNumber, int NewPageNumber)
        {
            //ExStart:ReorderDocumentPagesWithRenderOptionsHTML
            // Get configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create ViewerHtmlHandler object 
            ViewerHtmlHandler handler = new ViewerHtmlHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            // Instantiate the HtmlOptions object  
            HtmlOptions HtmlOptions = new HtmlOptions();

            // Set ShowHiddenPages and Transformation property
            HtmlOptions.ShowHiddenPages = true;
            HtmlOptions.Transformations = Transformation.Reorder;

            // To get html representations of pages with embedded resources
            HtmlOptions.IsResourcesEmbedded = true;

            // Set reorder options
            ReorderPageOptions ReorderOptions = new ReorderPageOptions(CurrentPageNumber, NewPageNumber);

            // Call ViewerHandler's Reorder page function by passing initialized ReorderPageOptions and HtmlOptions.
            handler.ReorderPage(guid, ReorderOptions, HtmlOptions); 

            // Get document pages in html form
            List<PageHtml> pages = handler.GetPages(guid, HtmlOptions);

            foreach (PageHtml page in pages)
            {
                // Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:ReorderDocumentPagesWithRenderOptionsHTML
        }

        /// <summary>
        /// Rotates pages of the document containing hidden pages in Html based rendering
        /// </summary>
        /// <param name="DocumentName"></param>
        /// <param name="RotationAngle">Rotation angle</param>
        /// <param name="DocumentPassword"></param>
        public static void RotateDocumentPagesWithRenderOptionsAsHTML(String DocumentName, int RotationAngle)
        {
            //ExStart:RotateDocumentPagesWithRenderOptionsAsHTML
            // Get configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create Html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            string guid = DocumentName;

            // Initialize HtmlOptions object
            HtmlOptions options = new HtmlOptions();

            // Set ShowHiddenPages and Transformation property
            options.ShowHiddenPages = true;
            options.Transformations = Transformation.Rotate;

            // Call RotatePage function
            htmlHandler.RotatePage(guid, new RotatePageOptions(3, RotationAngle), options);

            // Get document pages in Html form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                // Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RotateDocumentPagesWithRenderOptionsAsHTML
        }

        /// <summary>
        /// Renders document into Html with Enable Minification setting
        /// </summary>
        /// <param name="DocumentName">File name</param> 
        public static void RenderDocumentAsHtmlWithEnableMinification(string DocumentName)
        {
            //ExStart:RenderDocumentAsHtmlWithEnableMinification_17.12
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            //Instantiate the HtmlOptions object
            HtmlOptions options = new HtmlOptions();

            options.EnableMinification = true;

            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderDocumentAsHtmlWithEnableMinification_17.12
        }

        /// <summary>
        /// Renders MS Project document into Html with ProjectOptions setting
        /// </summary>
        /// <param name="DocumentName">File name</param> 
        public static void RenderProjectDocumentAsHtmlWithProjectOptions(string DocumentName)
        {
            //ExStart:RenderProjectDocumentAsHtmlWithProjectOptions_17.12
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            //Instantiate the HtmlOptions object
            HtmlOptions options = new HtmlOptions();

            options.ProjectOptions.PageSize = PageSize.A2;
            options.ProjectOptions.TimeUnit = TimeUnit.Days;

            //Get document pages in html form
            List<PageHtml> pages = htmlHandler.GetPages(guid, options);

            foreach (PageHtml page in pages)
            {
                //Save each page at disk
                Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
            }
            //ExEnd:RenderProjectDocumentAsHtmlWithProjectOptions_17.12
        }
        #endregion

        #region ImageRepresentation

        /// <summary>
        /// Renders document into image
        /// </summary>
        /// <param name="DocumentName">File name</param>
        /// <param name="DocumentPassword">Optional</param>
        public static void RenderDocumentAsImages(String DocumentName, String DocumentPassword = null)
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
        /// Renders document into image with watermark
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
        /// Renders the document in image form and set the rotation angle to rotate the page
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
            ImageOptions options = new ImageOptions { Transformations = Transformation.Rotate };

            // Set password if document is password protected. 
            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;

            //Call RotatePages to apply rotate transformation to a page
            Utilities.PageTransformations.RotatePages(ref handler, guid, 1, RotationAngle);

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
        /// Renders document into image with page reordering
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
            ImageOptions options = new ImageOptions { Transformations = Transformation.Reorder };

            // Set password if document is password protected. 
            if (!String.IsNullOrEmpty(DocumentPassword))
                options.Password = DocumentPassword;

            //Call ReorderPage and pass the reference of ViewerHandler's class  parameter by reference. 
            Utilities.PageTransformations.ReorderPage(ref handler, guid, CurrentPageNumber, NewPageNumber);

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
        /// Renders remote document into image using URL
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

        /// <summary>
        /// Renders hidden pages of Visio file as image
        /// </summary>
        /// <param name="DocumentName">file/document name</param>
        public static void RenderHiddenPagesOfVisioAsImage(string DocumentName)
        {

            //ExStart:RenderHiddenPagesOfVisioAsImage
            ViewerConfig config = Utilities.GetConfigurations();

            // Create image handler
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);
            string guid = DocumentName;

            // Set image options to show hidden pages
            ImageOptions options = new ImageOptions();
            options.ShowHiddenPages = true;

            DocumentInfoContainer container = imageHandler.GetDocumentInfo(guid);

            foreach (PageData page in container.Pages)
                Console.WriteLine("Page number: {0}, Page Name: {1}, IsVisible: {2}", page.Number, page.Name, page.IsVisible);

            List<PageImage> pages = imageHandler.GetPages(guid, options);

            foreach (PageImage page in pages)
            {
                //Save each image at disk
                Utilities.SaveAsImage(page.PageNumber + "_" + DocumentName, page.Stream);
            }
            //ExEnd:RenderHiddenPagesOfVisioAsImage


        }

        /// <summary>
        /// Renders CAD document into image
        /// </summary>
        /// <param name="DocumentName">File name</param>
        public static void RenderCADAsImages(String DocumentName)
        {
            //ExStart:RenderCADAsImages
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create image handler 
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            // Set Cad options to render content with a specified size
            ImageOptions options = new ImageOptions();

            options.CadOptions.Height = 750;
            options.CadOptions.Width = 450;

            //Get document pages in image form
            List<PageImage> Images = imageHandler.GetPages(guid, options);

            foreach (PageImage image in Images)
            {
                //Save each image at disk
                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream);
            }
            //ExEnd:RenderCADAsImages

        }

        /// <summary>
        /// Gets text coordinates in image mode. It is used when adding text search functionality in images.
        /// </summary>
        /// <param name="DocumentName">File name</param>
        public static void GetTextCorrdinates(String DocumentName)
        {
            //ExStart:GetTextCorrdinates
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create image handler 
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            // Init viewer image handler
            ViewerImageHandler viewerImageHandler = new ViewerImageHandler(config);

            //Get document rendered as an image with text extraction enabled
            ImageOptions imageOptions = new ImageOptions();
            imageOptions.ExtractText = true;
            List<PageImage> pages = viewerImageHandler.GetPages(guid, imageOptions);

            //Get document info
            DocumentInfoOptions documentInfoOptions = new DocumentInfoOptions();
            documentInfoOptions.ExtractText = true;
            DocumentInfoContainer documentInfoContainer = viewerImageHandler.GetDocumentInfo(guid, documentInfoOptions);

            // Go through all pages
            foreach (PageData pageData in documentInfoContainer.Pages)
            {
                Console.WriteLine("Page number: " + pageData.Number);

                //Go through all page rows
                for (int i = 0; i < pageData.Rows.Count; i++)
                {
                    RowData rowData = pageData.Rows[i];

                    // Write data to console
                    Console.WriteLine("Row: " + (i + 1));
                    Console.WriteLine("Text: " + rowData.Text);
                    Console.WriteLine("Text width: " + rowData.LineWidth);
                    Console.WriteLine("Text height: " + rowData.LineHeight);
                    Console.WriteLine("Distance from left: " + rowData.LineLeft);
                    Console.WriteLine("Distance from top: " + rowData.LineTop);

                    // Get words
                    string[] words = rowData.Text.Split(' ');

                    // Go through all word coordinates
                    for (int j = 0; j < words.Length; j++)
                    {
                        int coordinateIndex = j == 0 ? 0 : j + 1;

                        // Write data to console
                        Console.WriteLine(string.Empty);
                        Console.WriteLine("Word: '" + words[j] + "'");
                        Console.WriteLine("Word distance from left: " + rowData.TextCoordinates[coordinateIndex]);
                        Console.WriteLine("Word width: " + rowData.TextCoordinates[coordinateIndex + 1]);
                        Console.WriteLine(string.Empty);
                    }
                }
            }
            //ExEnd:GetTextCorrdinates

        }

        /// <summary>
        /// Renders Excel file as Image specifying number of rows per page and options.TextExtraction= true 
        /// </summary>
        /// <param name="DocumentName">File/document name</param>
        public static void RenderExcelAsImageWithCountRowsPerPage(string DocumentName)
        {

            //ExStart:RenderExcelAsImageWithCountRowsPerPageAndTextExtraction
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);
            string guid = DocumentName;

            // Set html options to show grid lines
            ImageOptions options = new ImageOptions();
            options.ExtractText = true;
            options.CellsOptions.OnePagePerSheet = false;

            // Set count rows to render into one page. Default value is 50.
            options.CellsOptions.CountRowsPerPage = 50;

            // Get pages
            List<PageImage> pages = imageHandler.GetPages(guid, options);

            foreach (PageImage page in pages)
            {
                // Save each page at disk
                Utilities.SaveAsImage(page.PageNumber + "_" + DocumentName, page.Stream);
            }
            //ExEnd:RenderExcelAsImageWithCountRowsPerPageAndTextExtraction

        }

        /// <summary>
        ///  Reorder pages of the document containing hidden pages in image based rendering
        /// </summary>
        /// <param name="DocumentName">File/document name</param>
        /// <param name="CurrentPageNumber">Page existing order number</param>
        /// <param name="NewPageNumber">Page new order number</param>
        public static void ReorderDocumentPagesWithRenderOptionsAsImage(String DocumentName, int CurrentPageNumber, int NewPageNumber)
        {
            //ExStart:ReorderDocumentPagesWithRenderOptionsImage
            // Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create ViewerImageHandler object 
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            // Instantiate the ImageOptions object
            ImageOptions ImageOptions = new ImageOptions();

            // Set ShowHiddenPages and Transformation property
            ImageOptions.ShowHiddenPages = true;
            ImageOptions.Transformations = Transformation.Reorder;

            // Set reorder options
            ReorderPageOptions ReorderOptions = new ReorderPageOptions(CurrentPageNumber, NewPageNumber);

            // Call ViewerHandler's Reorder page function by passing initialized ReorderPageOptions and ImageOptions.
            imageHandler.ReorderPage(guid, ReorderOptions, ImageOptions);

            // Get document pages in image form
            List<PageImage> pages = imageHandler.GetPages(guid, ImageOptions);

            foreach (PageImage page in pages)
            {
                // Save each page at disk
                Utilities.SaveAsImage(page.PageNumber + "_" + DocumentName, page.Stream);
            }
            //ExEnd:ReorderDocumentPagesWithRenderOptionsImage
        }

        /// <summary>
        /// Rotates pages of the document containing hidden pages in image based rendering
        /// </summary>
        /// <param name="DocumentName"></param>
        /// <param name="RotationAngle">Rotation angle</param>
        /// <param name="DocumentPassword"></param>
        public static void RotateDocumentPagesWithRenderOptionsAsImage(String DocumentName, int RotationAngle)
        {
            //ExStart:RotateDocumentPagesWithRenderOptionsAsImage
            // Get configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create image handler
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);

            string guid = DocumentName;

            // Initialize ImageOptions object 
            ImageOptions options = new ImageOptions();

            // Set ShowHiddenPages and Transformation property
            options.ShowHiddenPages = true;
            options.Transformations = Transformation.Rotate;

            // Call RotatePage function
            imageHandler.RotatePage(guid, new RotatePageOptions(3, RotationAngle), options);

            // Get document pages in image form
            List<PageImage> Images = imageHandler.GetPages(guid, options);

            foreach (PageImage image in Images)
            {
                // Save each image at disk
                Utilities.SaveAsImage(image.PageNumber + "_" + DocumentName, image.Stream);
            }
            //ExEnd:RotateDocumentPagesWithRenderOptionsAsImage
        }

        /// <summary>
        /// Renders MS Project document into image with ProjectOptions setting
        /// </summary>
        /// <param name="DocumentName">File name</param> 
        public static void RenderProjectDocumentAsImageWithProjectOptions(string DocumentName)
        {
            //ExStart:RenderProjectDocumentAsImageWithProjectOptions_17.12
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            // Set Project options to render content with a specified size and time unit.
            ImageOptions options = new ImageOptions();
            options.ProjectOptions.PageSize = PageSize.A2;
            options.ProjectOptions.TimeUnit = TimeUnit.Days;

            // Get pages 
            List<PageImage> pages = imageHandler.GetPages(guid, options);

            foreach (PageImage page in pages)
            {
                // Save each image at disk
                Utilities.SaveAsImage(page.PageNumber + "_" + DocumentName, page.Stream);
            }
            //ExEnd:RenderProjectDocumentAsImageWithProjectOptions_17.12
        }
        #endregion

        #region GeneralRepresentation
        /// <summary>
        /// Renders a document as it is (original form)
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

            //Save file at disk
            Utilities.SaveFile(DocumentName, container.Stream);
            //ExEnd:RenderOriginal

        }

        /// <summary>
        /// Renders a document in PDF form
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

            //Save file at disk
            Utilities.SaveFile(filename, container.Stream);
            //ExEnd:RenderAsPdf

        }

        /// <summary>
        /// Renders a document in PDF without annotations
        /// </summary>
        /// <param name="DocumentName"></param>
        public static void RenderDocumentAsPDFWithoutAnnotations(String DocumentName)
        {
            //ExStart:RenderDocumentAsPDFWithoutAnnotations
            // Create/initialize image handler 
            ViewerImageHandler imageHandler = new ViewerImageHandler(Utilities.GetConfigurations());

            // Set pdf options to get original file without annotations
            PdfFileOptions options = new PdfFileOptions();
            options.RenderComments = false; // Default value is false
            //options.RenderComments = true; // Render document with annotations

            // Call GetPdfFile to get FileContainer type object which contains the stream of pdf file.
            FileContainer container = imageHandler.GetPdfFile(DocumentName, options);

            //Change the extension of the file and assign to a string type variable filename
            String filename = Path.GetFileNameWithoutExtension(DocumentName) + ".pdf";

            //Save file at disk
            Utilities.SaveFile(filename, container.Stream);
            //ExEnd:RenderDocumentAsPDFWithoutAnnotations

        }

        /// <summary>
        /// Renders Word document in PDF with tracked changes
        /// </summary>
        /// <param name="DocumentName"></param>
        public static void RenderWordDocumentAsPDFWithTrackedChanges(String DocumentName)
        {
            //ExStart:RenderWordDocumentAsPDFWithTrackedChanges
            // Create/initialize image handler 
            ViewerImageHandler imageHandler = new ViewerImageHandler(Utilities.GetConfigurations());

            // Set pdf options to get original file without annotations
            PdfFileOptions options = new PdfFileOptions();
            options.WordsOptions.ShowTrackedChanges = true; // Default value is false

            // Call GetPdfFile to get FileContainer type object which contains the stream of pdf file.
            FileContainer container = imageHandler.GetPdfFile(DocumentName, options);

            //Change the extension of the file and assign to a string type variable filename
            String filename = Path.GetFileNameWithoutExtension(DocumentName) + ".pdf";

            //Save file at disk
            Utilities.SaveFile(filename, container.Stream);
            //ExEnd:RenderWordDocumentAsPDFWithTrackedChanges

        }

        /// <summary>
        /// Renders a document in PDF form with watermark 
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

            //Save file at disk
            Utilities.SaveFile(filename, container.Stream);
            //ExEnd:RenderAsPdf

        }

        /// <summary>
        /// Renders a document in PDF form with watermark font settings
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

            //Save file at disk
            Utilities.SaveFile(filename, container.Stream);
            //ExEnd:RenderAsPdf

        }

        /// <summary>
        /// Renders document as PDF with JpegQuality option
        /// </summary>
        /// <param name="DocumentName"></param>
        public static void RenderDocumentAsPDFWithJpegQualitySettings(String DocumentName)
        {
            //ExStart:RenderDocumentAsPDFWithJpegQualitySettings
            // Create/initialize image handler 
            ViewerImageHandler imageHandler = new ViewerImageHandler(Utilities.GetConfigurations());

            // Set pdf options JpegQuality in a range between 1 and 100
            PdfFileOptions PdfFileOptions = new PdfFileOptions();
            PdfFileOptions.JpegQuality = 5;

            // Call GetPdfFile to get FileContainer type object which contains the stream of pdf file.
            FileContainer container = imageHandler.GetPdfFile(DocumentName, PdfFileOptions);

            //Change the extension of the file and assign to a string type variable filename
            String filename = Path.GetFileNameWithoutExtension(DocumentName) + ".pdf";

            //Save file at disk
            Utilities.SaveFile(filename, container.Stream);
            //ExEnd:RenderDocumentAsPDFWithJpegQualitySettings

        }

        /// <summary>
        /// Renders a document with comments as PDF
        /// </summary>
        /// <param name="DocumentName"></param> 
        public static void RenderDocumentWithCommentsAsPDF(String DocumentName)
        {
            //ExStart:RenderDocumentWithCommentsAsPDF
            // Create/initialize image handler 
            ViewerImageHandler imageHandler = new ViewerImageHandler(Utilities.GetConfigurations());

            PdfFileOptions options = new PdfFileOptions();
            options.RenderComments = true; // Default value is false

            // Call GetPdfFile to get FileContainer type object which contains the stream of pdf file.
            FileContainer container = imageHandler.GetPdfFile(DocumentName, options);

            //Change the extension of the file and assign to a string type variable filename
            String filename = Path.GetFileNameWithoutExtension(DocumentName) + ".pdf";

            //Save file at disk
            Utilities.SaveFile(filename, container.Stream);
            //ExEnd:RenderDocumentWithCommentsAsPDF
        }

        /// <summary>
        /// Renders MS Project document as PDF with ProjectOptions setting
        /// </summary>
        /// <param name="DocumentName">File name</param> 
        public static void RenderProjectDocumentAsPDFWithProjectOptions(string DocumentName)
        {
            //ExStart:RenderProjectDocumentAsPDFWithProjectOptions_17.12
            //Get Configurations
            ViewerConfig config = Utilities.GetConfigurations();

            // Create html handler
            ViewerImageHandler imageHandler = new ViewerImageHandler(config);

            // Guid implies that unique document name 
            string guid = DocumentName;

            // Set Project options to render content with a specified size and time unit.
            PdfFileOptions options = new PdfFileOptions();
            options.ProjectOptions.PageSize = PageSize.A2;
            options.ProjectOptions.TimeUnit = TimeUnit.Days;

            // Get PDF file 
            FileContainer fileContainer = imageHandler.GetPdfFile(guid, options);

            // Set file name
            String filename = Path.GetFileNameWithoutExtension(DocumentName) + ".pdf";

            //Save file at disk
            Utilities.SaveFile(filename, fileContainer.Stream);
            //ExEnd:RenderProjectDocumentAsPDFWithProjectOptions_17.12
        }


        /// <summary>
        /// Loads directory structure as file tree
        /// </summary>
        /// <param name="Path"></param>
        public static void LoadFileTree(String Path)
        {
            //ExStart:LoadFileTree
            // Create/initialize image handler 
            ViewerImageHandler imageHandler = new ViewerImageHandler(Utilities.GetConfigurations());

            // Load file list for custom path 
            FileListOptions options = new FileListOptions(Path);

            // Load file list sorted by Name and ordered Ascending for custom path
            FileListOptions options1 = new FileListOptions(Path, FileListOptions.FileListSortBy.Name, FileListOptions.FileListOrderBy.Ascending);

            // Load file list for ViewerConfig.StoragePath
            FileListContainer container = imageHandler.GetFileList();

            // Load file list for custom path
            FileListContainer container1 = imageHandler.GetFileList(options);

            foreach (var node in container.Files)
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
        /// Renders a document from Azure Storage 
        /// </summary>
        /// <param name="DocumentName"></param>
        public static void RenderDocFromAzure(String DocumentName)
        {
            // Setup GroupDocs.Viewer config
            ViewerConfig config = Utilities.GetConfigurations();


            // File guid
            string guid = DocumentName;

            // Use custom IInputDataHandler implementation
            IInputDataHandler inputDataHandler = new AzureInputDataHandler("<Account_Name>", "<Account_Key>", "<Container_Name>");

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
        /// Renders a document from FTP location 
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
        /// Sets custom fonts directory path
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
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        #endregion

        #region EmailAttachments
        /// <summary>
        /// Gets image attachment of email message
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
                Attachment attachment = new Attachment(DocumentName, "attachment-image.png");

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
        /// Gets html representation of attachment files
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
        /// Gets image representation of attachment files
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
        /// Gets document information by guid
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
        /// Gets document information by Uri
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
        /// Gets document information by stream
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
        /// Removes cache files 
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
        /// Removes cache file older than specified date 
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

        /// <summary>
        /// Removes cache files for specific document
        /// </summary>
        public static void RemoveCacheFiles(string guid)
        {
            try
            {
                //ExStart:RemoveCacheFilesForSpecificDocument_17.12
                // Setup GroupDocs.Viewer config
                ViewerConfig config = Utilities.GetConfigurations();

                // Init viewer image or html handler
                ViewerHtmlHandler viewerImageHandler = new ViewerHtmlHandler(config);

                //Clear cache files 
                viewerImageHandler.ClearCache(guid);
                //ExEnd:RemoveCacheFilesForSpecificDocument_17.12
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        #endregion

        #region Others

        /// <summary>
        /// Gets all supported document formats
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

        #endregion
    }



}
