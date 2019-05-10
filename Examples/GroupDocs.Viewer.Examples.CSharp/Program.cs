using Amazon.S3;
using GroupDocs.Viewer.Config;
using GroupDocs.Viewer.Handler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GroupDocs.Viewer.Examples.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            /**
             *  Applying product license
             *  Please uncomment the statement if you do have license.
             */
            Utilities.ApplyLicense();

            #region ViewerHtmlPresentation

            //Render a document in html form
            //Renderer.HTMLRepresentation.RenderDocument("word.doc");

            //Render a spreadsheet in html form
            //Renderer.HTMLRepresentation.RenderDocument("spreadsheet.xlsx");

            //Render a word document in html form and also apply a text as watermark on each page
            //Renderer.HTMLRepresentation.RenderDocument("word.doc", "Show me as watermark", Color.Purple);

            //Render a document located at a web location
            //Renderer.HTMLRepresentation.RenderDocument(new Uri("http://www.example.com/sample.doc"));

            //Render a document in html form with resource prefix
            //Renderer.HTMLRepresentation.RenderDocumentWithResourcePrefix("word.doc");

            //Render hidden pages in Visio file in html form 
            //Renderer.HTMLRepresentation.RenderHiddenPagesOfVisio("sample.vdx");

            //Render Excel document in html form with internal hyperlink prefix
            //Renderer.HTMLRepresentation.RenderExcelWithInternalHyperlinkPrefix("sample.xlsx");

            //Render simple document into html with PreventGlyphsGrouping settings
            //Renderer.HTMLRepresentation.RenderPDFDocumentWithEnablePreciseRendering("sample.pdf");

            //Render Excel file as Html specifying number of rows per page
            //Renderer.HTMLRepresentation.RenderExcelWithCountRowsPerPage("sample.xlsx");

            //Render Excel file as Html specifying text overflow mode
            //Renderer.HTMLRepresentation.RenderExcelWithTextOverflowMode("sample.xlsx");

            //Render CAD document including the layouts 
            //Renderer.HTMLRepresentation.RenderLayoutsOfCADDocument("sample.dwg");

            //Render Excel file as Html specifying text overflow mode
            //Renderer.HTMLRepresentation.RenderSpecificLayoutOfCADDocument("sample.dwg");

            //Gets list of all Layouts from CAD document
            //Renderer.HTMLRepresentation.RenderPDFDocumentWithEnablePreciseRendering("sample.pdf");

            //Render document with comments as HTML
            //Renderer.HTMLRepresentation.RenderDocumentWithComments("sample.doc");

            //Render Excel document ignoring empty rows
            //Renderer.HTMLRepresentation.RenderExcelIgnoringEmptyRows("sample.xlsx");

            //Render Excel document ignoring empty columns
            //Renderer.HTMLRepresentation.RenderExcelIgnoringEmptyColumns("sample.xlsx");

            //Render CAD document as responsive HTML
            //Renderer.HTMLRepresentation.RenderDocumentAsResponsiveHtml("sample.dwg");

            //Render document as Html with resource minification
            //Renderer.HTMLRepresentation.RenderDocumentWithEnableMinification("candy.pdf");

            //Render MS Project document as Html with PorjectOptions
            //Renderer.HTMLRepresentation.RenderProjectDocumentWithProjectOptions("sample.mpp");

            //Render document with default font setting
            //Renderer.HTMLRepresentation.RenderDocumentWithDefaultFontSetting("sample.pdf");

            //Render document excluding fonts list
            //Renderer.HTMLRepresentation.RenderDocumentExcludingFontsList("sample.pptx");

            //Render specific layers of Cad document
            //Renderer.HTMLRepresentation.RenderSpecificLayerOfCADDocument("sample.dwg");

            //Render Presentation document containing slide notes
            //Renderer.HTMLRepresentation.RenderPresentationDocumentWithNotes("sample.pptx");

            //Render Excel document as HTML with print area only settings
            //Renderer.HTMLRepresentation.RenderPrintAreaOnlyInExcel("sample.xlsx");

            //Render hidden columns and rows in Excel document
            //Renderer.HTMLRepresentation.RenderHiddenContentInExcel("sample.xlsx");

            //Set header fields' labels when rendering email messages
            //Renderer.HTMLRepresentation.RenderEmailMessageWithCustomFieldLabels("sample.msg");

            //Render password protected document with force password validation
            //Renderer.HTMLRepresentation.RenderDocumentWithForcePasswordValidation("sample.docx");

            //Render Outlook data files with limit of items
            //Renderer.HTMLRepresentation.RenderOutlookDataFileWithLimitOfItems("sample.ost");

            //Reoreder document pages
            //Renderer.HTMLRepresentation.ReorderDocumentPages("sample.pptx", 1, 2);

            //Rotates document page
            //Renderer.HTMLRepresentation.RotateDocumentPages("sample.pptx", 90);

            //Render email messages from Outlook Data Files
            //Renderer.HTMLRepresentation.RenderEmailAttachmentsFromOutlookDataFile("sample.pst");

            //Renders Outlook Data Files using filters for the Subject and content of the message
            //Renderer.HTMLRepresentation.RenderOutlookDataFileUsingFilters("sample.pst");

            //Show grid lines for Excel files in html representation 
            //Renderer.HTMLRepresentation.RenderExcelWithGridLinesOptions("spreadsheet.xlsx");

            //Multiple pages per sheet 
            //Renderer.HTMLRepresentation.RenderMultipleExcelSheetsInOnePage("spreadsheet.xlsx");

            //Show hidden sheets for Excel files in image representation 
            //Renderer.HTMLRepresentation.RenderHiddenSheetsInExcel("spreadsheet.xlsx");
            #endregion

            #region ViewerImagePresentation

            //Render a PowerPoint presentation in images form.
            //Renderer.ImageRepresentation.RenderDocument("sample.cdr");

            //Render a spreadsheet in images form.
            //Renderer.ImageRepresentation.RenderDocument("spreadsheet.xlsx");

            //Reorder document pages
            //Renderer.ImageRepresentation.ReorderDocumentPages("word.doc", 1, 2);

            //Rotate document pages
            //Renderer.ImageRepresentation.RotateDocumentPages("word.doc", 180);

            //Render a Word document with watermark on each page.
            //Renderer.ImageRepresentation.RenderDocument("sample.pdf", "Show me as watermark", Color.Purple);

            //Render a document located at a web location
            //Renderer.ImageRepresentation.RenderDocument(new Uri("http://www.example.com/sample.doc"));

            //Render hidden pages in Visio file in image form
            //Renderer.ImageRepresentation.RenderHiddenPagesOfVisio("sample.vdx");

            //Get text coordinates in image based rendering
            //Renderer.ImageRepresentation.GetTextCorrdinates("sample.docx");

            //Render MS Project document as Image with PorjectOptions
            //Renderer.ImageRepresentation.RenderProjectDocumentWithProjectOptions("sample.mpp");

            //Render Excel document as image with print area only settings
            //Renderer.ImageRepresentation.RenderPrintAreaOnlyInExcel("sample.xlsx");

            //Render hidden columns and rows in Excel document
            //Renderer.ImageRepresentation.RenderHiddenContentInExcel("sample.xlsx");

            //Render email messages with page size settings
            //Renderer.ImageRepresentation.RenderEmailDocumentWithPageSizeSettings("sample.msg");

            //Tiled rendering of CAD documents
            //Renderer.ImageRepresentation.TiledRenderingOfCADDocuments("sample.dwg");

            //Tiled rendering of CAD documents with manual size setting
            //Renderer.ImageRepresentation.TiledRenderingOfCADDocumentsWithManualSizeSettings("sample.dwg");

            //Render messages from specified folder in Outlook document
            //Renderer.ImageRepresentation.RenderMessagesFromSpecifiedOutlookFolder("sample.ost");

            //Added support to Renders Zips and Tars
            //Renderer.ImageRepresentation.RenderCompressedFiles("sample.zip");

            //Render files contained in zip archives that are stored on disk
            //Renderer.ImageRepresentation.RenderFilesFromDiskZips("sample.zip");

            //Render files contained in password protected zip archives that are stored on disk
            //Renderer.ImageRepresentation.RenderFilesFromPasswordProtectedDiskZips("password-protected.zip");

            //Render files contained in zip archives using stream
            //Renderer.ImageRepresentation.RenderZipFilesFromStream("sample.zip");

            //Render files contained in password protected zip archives using stream
            //Renderer.ImageRepresentation.RenderContainedFileinPasswordProtectedZipFromStream("password-protected.zip");

            //Retrieving the list of root folders from archive documents
            //Renderer.ImageRepresentation.GetArchiveRootFoldersList("sample.zip");

            //Retrieving the list of folders from the certain folder inside the archive
            // Renderer.ImageRepresentation.GetNestedLevelArchiveFoldersList("sample.zip");

            //Rendering the list of folders from the certain folder inside the archive
            //Renderer.ImageRepresentation.RenderCertainArchiveFolder("sample.zip");

            //Rendering to PDF with Security Settings
            //Renderer.ImageRepresentation.RenderWithSecuritySettings("word.doc");

            #endregion

            #region PFDRepresentation
            //Render the word document in the form of pdf markup
            //Renderer.PDFRepresentation.RenderDocument("test.pdf");

            //Render document as PDF with JpegQuality settings
            //Renderer.PDFRepresentation.RenderDocumentWithJpegQualitySettings("word.doc");

            //Render document as PDF with comments
            //Renderer.PDFRepresentation.RenderDocumentWithComments("sample.doc");

            //Render Excel document as PDF with print area only settings
            //Renderer.PDFRepresentation.RenderPrintAreasInExcel("sample.xlsx");

            //Render MS Project document as PDF with PorjectOptions
            //Renderer.PDFRepresentation.RenderProjectDocumentWithProjectOptions("sample.mpp");

            //Render hidden columns and rows in Excel document
            //Renderer.PDFRepresentation.RenderHiddenContentInExcel("sample.xlsx");

            //Render email messages with page size settings
            //Renderer.PDFRepresentation.RenderEmailDocumentWithPageSizeSettings("sample.msg");

            // Render Outlook Data Files with limit of items
            //Renderer.PDFRepresentation.RenderOutlookDataFileWithLimitOfItems("sample.ost");

            // Render messages as PDF from specified folder in Outlook document
            // Renderer.PDFRepresentation.RenderMessagesFromSpecifiedOutlookFolder("sample.ost");

            //Check printing restriction before PDF Rendering
            //Renderer.PDFRepresentation.CheckPrintingRestriction("candy.pdf");

            #endregion

            //Render the document as it is (Original form)
            //Renderer.GetOriginalDocument("test.pdf");

            #region InputDataHandlers
            //Render a document from Azure Storage 
            //Renderer.RenderDocFromAzure("word.doc");

            //Render a document from ftp location 
            //Renderer.RenderDocFromAzure("word.doc");

            //Render document from Amazon S3 file storage
            //Renderer.GetHtmlPagesFromAmazonS3FileStorage("sample.doc", "your-bucket-name");
            #endregion

            #region OtherImprovements

            //Render a document from ftp location 
            //Renderer.HTMLRepresentation.RenderWithLocales("word.doc");

            //Get all supported document formats 
            //Renderer.ShowAllSupportedFormats();

            #endregion

            #region DocumentCache
            //Removes cache files
            //Renderer.RemoveCacheFiles();

            //Removes cache files for specific document
            //Renderer.RemoveCacheFiles("candy.pdf");
            #endregion

            #region DocumentInfo
            //Get document info by guid
            //Renderer.GetDocumentInfoByGuid("word.doc");

            //Get document info by uri
            //Renderer.GetDocumentInfoByUri("http://www.example.com/sample.doc");

            //Get document info by stream
            //Renderer.GetDocumentInfoByStream("word.doc"); 

            //Get layers' info in Cad document
            //Renderer.GetLayersInfoForCadDcouments("sample.dwg");

            //Get list of folders from Outlook message
            //Renderer.GetListOfOutlookFolders("sample.ost");

            //Get list of sub-folders from a folder
            //Renderer.GetListOfSubFoldersFromSpecifiedFolder("sample.ost");

            //Obtain start and end date from MS Project document
            //Renderer.ObtainStartAndEndDateFromMSProjectDocument("sample.mpp");

            #endregion

            #region EmailAttachments
            //Get email attachment files
            //Renderer.GetEmailAttachments("sample.msg");

            //Get email attachments from document stream
            //Renderer.GetEmailAttachmentsFromStream("sample.msg");

            //Get email attachment's HTML representation
            //Renderer.RenderEmailAttachmentAsHTML("sample.msg");

            //Get email attachment's HTML representation from document stream
            //Renderer.RenderEmailAttachmentAsHTMLFromStream("sample.msg");

            //Get email attachment image representation
            //Renderer.RenderEmailAttachmentAsImage("sample.msg");

            //Gets list of all Layouts from CAD document
            //Renderer.GetListOfLayoutsOfCADDocument("sample.dwg");

            #endregion

            #region CustomFonts
            //Set custom font directories
            //Renderer.SetCustomFontDirectory("word.doc");

            #endregion

            #region CustomCacheDataHandler
            // Following section demonstrates the usage of ICacheDataHandler
            /*

            //NOTES: 1. Set your credentials in app.config
            //       2. Set bucket name

            ViewerConfig config = Utilities.GetConfigurations();

            var amazonS3Client = new AmazonS3Client();
            var amazonS3FileManager = new AmazonS3FileManager(amazonS3Client, "usman-aziz-test-bucket");
            var amazonS3CacheDataHandler = new AmazonS3CacheDataHanlder(amazonS3FileManager);
             
            var handler = new ViewerHtmlHandler(config, null, amazonS3CacheDataHandler);

            var pagesHtml = handler.GetPages("candy.pdf");

            // To clear cache
            //handler.ClearCache("candy.pdf");

            Debug.Assert(pagesHtml.Count > 0);
            Debug.Assert(!string.IsNullOrEmpty(pagesHtml[0].HtmlContent));
            */

            #endregion

            Console.WriteLine("All done.");
            Console.ReadKey();
        }
    }
}
