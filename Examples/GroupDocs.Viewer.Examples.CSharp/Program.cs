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

            //ExStart:ApplyingLicense
            /**
             *  Applying product license
             *  Please uncomment the statement if you do have license.
             */
            //Utilities.ApplyLicense();
            //ExEnd:ApplyingLicense

            #region ViewerHtmlPresentation

            //Render a document in html form
            //ViewGenerator.RenderDocumentAsHtml("word.doc");

            //Render a spreadsheet in html form
            //ViewGenerator.RenderDocumentAsHtml("spreadsheet.xlsx");

            //Render a MS word document by replacing its 1st page order with 2nd page 
            //ViewGenerator.RenderDocumentAsHtml("large_will_not_getting_processed.docx");

            //Render a word document in html form and also apply a text as watermark on each page
            //ViewGenerator.RenderDocumentAsHtml("word.doc", "Show me as watermark", Color.Purple);

            //Render a document located at a web location
            // ViewGenerator.RenderDocumentAsHtml(new Uri("http://www.example.com/sample.doc"));

            //Render a document in html form with resource prefix
            //ViewGenerator.RenderDocumentAsHtmlWithResourcePrefix("word.doc");

            //Render hidden pages in Visio file in html form 
            //ViewGenerator.RenderHiddenPagesOfVisioAsHtml("sample.vdx");

            //Render Excel document in html form with internal hyperlink prefix
            //ViewGenerator.RenderExcelAsHtmlWithInternalHyperlinkPrefix("sample.xlsx");

            //Render simple document into html with PreventGlyphsGrouping settings
            //ViewGenerator.RenderDocumentAsHtmlWithEnablePreciseRendering("sample.pdf");

            //Render Excel file as Html specifying number of rows per page
            //ViewGenerator.RenderExcelAsHtmlWithCountRowsPerPage("sample.xlsx");

            //Render Excel file as Html specifying text overflow mode
            //ViewGenerator.RenderExcelAsHtmlWithTextOverflowMode("sample.xlsx");

            //Render CAD document including the layouts 
            //ViewGenerator.RenderLayoutsOfCADDocument("sample.dwg");

            //Render Excel file as Html specifying text overflow mode
            //ViewGenerator.RenderSpecificLayoutOfCADDocument("sample.dwg");

            //Gets list of all Layouts from CAD document
            //ViewGenerator.GetListOfLayoutsOfCADDocument("sample.dwg");

            //Gets list of all Layouts from CAD document
            //ViewGenerator.RenderDocumentAsHtmlWithEnablePreciseRendering("sample.pdf");

            //Render document with comments as HTML
            //ViewGenerator.RenderDocumentAsHtmlWithComments("sample.doc");

            //Render Excel document ignoring empty rows
            //ViewGenerator.RenderExcelAsHtmlIgnoringEmptyRows("sample.xlsx");

            //Render Excel document ignoring empty columns
            //ViewGenerator.RenderExcelAsHtmlIgnoringEmptyColumns("sample.xlsx");

            //Render CAD document as responsive HTML
            //ViewGenerator.RenderDocumentAsResponsiveHtml("sample.dwg");

            //Render document as Html with resource minification
            //ViewGenerator.RenderDocumentAsHtmlWithEnableMinification("candy.pdf");

            //Render MS Project document as Html with PorjectOptions
            //ViewGenerator.RenderProjectDocumentAsHtmlWithProjectOptions("sample.mpp");

            //Render document with default font setting
            //ViewGenerator.RenderDocumentAsHtmlWithDefaultFontSetting("sample.pdf");

            //Render document excluding fonts list
            //ViewGenerator.RenderDocumentAsHtmlExcludingFontsList("sample.pptx");

            //Render specific layers of Cad document
            //ViewGenerator.RenderSpecificLayerOfCadDocument("sample.dwg");

            //Render Presentation document containing slide notes
            //ViewGenerator.RenderPresentationDocumentWithNotes("sample.pptx");

            //Render Excel document as HTML with print area only settings
            //ViewGenerator.RenderPrintAreaOnlyInExcel("sample.xlsx");

            //Render hidden columns and rows in Excel document
            //ViewGenerator.RenderHiddenContentInExcel("sample.xlsx");

            //Set header fields' labels when rendering email messages
            //ViewGenerator.SetFieldLabelsWhenRenderingEmailMessage("sample.msg");

            // Render password protected document with force password validation
            //ViewGenerator.RenderDocumentAsHtmlWithForcePasswordValidation("sample.docx");

            // Render Outlook data files with limit of items
            //ViewGenerator.RenderOutlookDataFileWithLimitOfItems("sample.ost");

            #endregion

            #region ViewerImagePresentation

            //Render a power point presentation in images form.
            //ViewGenerator.RenderDocumentAsImages("sample.pptx");

            //Render a spreadsheet in images form.
            //ViewGenerator.RenderDocumentAsImages("spreadsheet.xlsx");

            //Render a MS word document by replacing its 1st page order with 2nd page. 
            // ViewGenerator.RenderDocumentAsImages("word.doc",1,2);

            //Render a word document in images form and also apply a text as watermark on each page.
            // ViewGenerator.RenderDocumentAsImages("f1.pdf", "Show me as watermark", Color.Purple);

            //Render a word document in images form and set the rotation angle to display the rotated page.
            // ViewGenerator.RenderDocumentAsImages("word.doc", 180);

            //Render a document located at a web location
            // ViewGenerator.RenderDocumentAsImages(new Uri("http://www.example.com/sample.doc"));

            //Render hidden pages in Visio file in image form 
            //ViewGenerator.RenderHiddenPagesOfVisioAsImage("sample.vdx");

            //Get text coordinates in image based rendering
            //ViewGenerator.GetTextCorrdinates("sample.docx");

            //Render MS Project document as Image with PorjectOptions
            //ViewGenerator.RenderProjectDocumentAsImageWithProjectOptions("sample.mpp");

            //Render Excel document as image with print area only settings
            //ViewGenerator.RenderPrintAreaOnlyAsImageInExcel("sample.xlsx");

            //Render hidden columns and rows in Excel document
            //ViewGenerator.RenderHiddenContentInExcelAsImage("sample.xlsx");

            //Render email messages with page size settings
            //ViewGenerator.RenderEmailDocumentAsImageWithPageSizeSettings("sample.msg");

            // Tiled rendering of CAD documents
            //ViewGenerator.TiledRenderingOfCADDocuments("sample.dwg");

            // Tiled rendering of CAD documents with manual size setting
            //ViewGenerator.TiledRenderingOfCADDocumentsWithManualSizeSettings("sample.dwg");

            // Obtain start and end date from MS Project document
            //ViewGenerator.ObtainStartAndEndDateFromMSProjectDocument("sample.mpp");

            // Render messages from specified folder in Outlook document
            //ViewGenerator.RenderMessagesFromSpecifiedOutlookFolder("sample.ost");
            #endregion

            #region GeneralRepresentation
            //Render the word document in the form of pdf markup
            //ViewGenerator.RenderDocumentAsPDF("test.pdf");

            //Render the document as it is (Original form)
            //ViewGenerator.RenderDocumentAsOriginal("factsheet.pdf");

            //Render document as PDF with JpegQuality settings
            //ViewGenerator.RenderDocumentAsPDFWithJpegQualitySettings("word.doc");

            //Render document as PDF with comments
            //ViewGenerator.RenderDocumentWithCommentsAsPDF("sample.doc");

            //Render Excel document as PDF with print area only settings
            //ViewGenerator.RenderPrintAreasInExcelAsPDF("sample.xlsx");

            //Render MS Project document as PDF with PorjectOptions
            //ViewGenerator.RenderProjectDocumentAsPDFWithProjectOptions("sample.mpp");

            //Render hidden columns and rows in Excel document
            //ViewGenerator.RenderHiddenContentInExcelAsPDF("sample.xlsx");

            //Render email messages with page size settings
            //ViewGenerator.RenderEmailDocumentAsPDFWithPageSizeSettings("sample.msg");

            // Render Outlook Data Files with limit of items
            //ViewGenerator.RenderOutlookDataFileWithLimitOfItemsAsPDF("sample.ost");

            // Render messages as PDF from specified folder in Outlook document
            //ViewGenerator.RenderMessagesFromSpecifiedOutlookFolderAsPDF("sample.ost");
            #endregion

            #region InputDataHandlers
            //Render a document from Azure Storage 
            //ViewGenerator.RenderDocFromAzure("word.doc");

            //Render a document from ftp location 
            //ViewGenerator.RenderDocFromAzure("word.doc");

            //Render document from Amazon S3 file storage
            //ViewGenerator.GetHtmlPagesFromAmazonS3FileStorage("sample.doc", "your-bucket-name");
            #endregion

            #region OtherImprovements
            //Show grid lines for Excel files in html representation 
            //ViewGenerator.RenderWithGridLinesInExcel("spreadsheet.xlsx");
            //Multiple pages per sheet 
            // ViewGenerator.RenderMultiExcelSheetsInOnePage("testcc1.xlsx");
            //Show hidden sheets for Excel files in image representation 
            // ViewGenerator.RenderWithHiddenSheetsInExcel("spreadsheet.xlsx");
            //Render a document from ftp location 
            //ViewGenerator.RenderWithLocales("word.doc");
            //Get all supported document formats 
            //ViewGenerator.ShowAllSupportedFormats();

            #endregion

            #region DocumentCache
            //Removes cache files
            //ViewGenerator.RemoveCacheFiles();

            //Removes cache files for specific document
            //ViewGenerator.RemoveCacheFiles("candy.pdf");
            #endregion

            #region DocumentInfo
            //Get document info by guid
            //ViewGenerator.GetDocumentInfoByGuid("word.doc");

            //Get document info by uri
            //ViewGenerator.GetDocumentInfoByUri("http://www.example.com/sample.doc");

            //Get document info by stream
            //ViewGenerator.GetDocumentInfoByStream("word.doc"); 

            //Get layers' info in Cad document
            //ViewGenerator.GetLayersInfoForCadDcouments("sample.dwg");

            //Get list of folders from Outlook message
            //ViewGenerator.GetListOfOutlookFolders("sample.ost");

            //Get list of sub-folders from a folder
            //ViewGenerator.GetListOfSubFoldersFromSpecifiedFolder("sample.ost");

            #endregion

            #region EmailAttachments
            //Get email attachment files
            //ViewGenerator.GetEmailAttachments("sample.msg");

            //Get email attachments from document stream
            //ViewGenerator.GetEmailAttachmentsFromStream("sample.msg");

            //Get email attachment's HTML representation
            //ViewGenerator.GetEmailAttachmentHTMLRepresentation("sample.msg");

            //Get email attachment's HTML representation from document stream
            //ViewGenerator.GetEmailAttachmentHTMLRepresentationFromStream("sample.msg");

            //Get email attachment image representation
            //ViewGenerator.GetEmailAttachmentImageRepresentation("sample.msg");

            #endregion

            #region CustomFonts
            //Set custom font directories
            //ViewGenerator.SetCustomFontDirectory("word.doc");

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
        }
    }
}
