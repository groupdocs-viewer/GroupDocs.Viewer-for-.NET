
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Text

Namespace GroupDocs.Viewer.Examples

    Module Module1

        Sub Main()


            'ExStart:ApplyingLicense  
            '*
            '*  Applying product license
            '*  Please uncomment the statement if you do have license.
            '
            'Utilities.ApplyLicense()

            'ExEnd:ApplyingLicense

            '#Region "ViewerHtmlPresentation"

            'Render a power point presentation in html form
            'ViewGenerator.RenderDocumentAsHtml("sample.pptx")

            'Render a spreadsheet in html form
            'ViewGenerator.RenderDocumentAsHtml("spreadsheet.xlsx")

            'Render a MS word document by replacing its 1st page order with 2nd page 
            ' ViewGenerator.RenderDocumentAsHtml("word.doc",1,2)

            'Render a word document in html form and also apply a text as watermark on each page
            'ViewGenerator.RenderDocumentAsHtml("word.doc", "Show me as watermark", Color.Purple)

            'Render a document located at a web location
            ' ViewGenerator.RenderDocumentAsHtml(new Uri("http://www.example.com/sample.doc"))

            'Render a document in html form with resource prefix
            'ViewGenerator.RenderDocumentAsHtmlWithResourcePrefix("word.doc")

            'Render hidden pages in Visio file in html form 
            'ViewGenerator.RenderHiddenPagesOfVisioAsHtml("sample.vdx")

            'Render Excel document in html form with internal hyperlink prefix
            'ViewGenerator.RenderExcelAsHtmlWithInternalHyperlinkPrefix("sample.xlsx")

            'Render Excel file as Html specifying text overflow mode
            'ViewGenerator.RenderExcelAsHtmlWithTextOverflowMode("sample.xlsx")

            'Render CAD document including the layouts 
            'ViewGenerator.RenderLayoutsOfCADDocument("sample.dwg")

            'Render Excel file as Html specifying text overflow mode
            'ViewGenerator.RenderSpecificLayoutOfCADDocument("sample.dwg")

            'Gets list of all Layouts from CAD document
            'ViewGenerator.GetListOfLayoutsOfCADDocument("sample.dwg")

            'Gets list of all Layouts from CAD document
            'ViewGenerator.RenderDocumentAsHtmlWithEnablePreciseRendering("sample.pdf")

            'Render document with comments as HTML
            'ViewGenerator.RenderDocumentAsHtmlWithComments("sample.doc")

            '#End Region

            '#Region "ViewerImagePresentation"

            'Render a power point presentation in images form.
            'ViewGenerator.RenderDocumentAsImages("sample.pptx")

            'Render a spreadsheet in images form.
            'ViewGenerator.RenderDocumentAsImages("spreadsheet.xlsx")

            'Render a MS word document by replacing its 1st page order with 2nd page. 
            ' ViewGenerator.RenderDocumentAsImages("word.doc",1,2)

            'Render a word document in images form and also apply a text as watermark on each page.
            ' ViewGenerator.RenderDocumentAsImages("word.doc", "Show me as watermark", Color.Purple)

            'Render a word document in images form and set the rotation angle to display the rotated page.
            ' ViewGenerator.RenderDocumentAsImages("word.doc", 180);

            'Render a document located at a web location
            ' ViewGenerator.RenderDocumentAsImages(new Uri("http://www.example.com/sample.doc"))

            'Render hidden pages in Visio file in image form 
            'ViewGenerator.RenderHiddenPagesOfVisioAsImage("sample.vdx")

            'Get text coordinates in image based rendering
            'ViewGenerator.GetTextCorrdinates("sample.docx")
            '#End Region

            '#Region "GeneralRepresentation"
            'Render the word document in the form of pdf markup
            'ViewGenerator.RenderDocumentAsPDF("word.doc")

            'Render the document as it is (Original form)
            'ViewGenerator.RenderDocumentAsOriginal("factsheet.pdf")

            'Render document as PDF with JpegQuality settings
            'ViewGenerator.RenderDocumentAsPDFWithJpegQualitySettings("sample.doc")

            'Render document as PDF with comments
            'ViewGenerator.RenderDocumentWithCommentsAsPDF("sample.doc")
            '#End Region

            '#Region "InputDataHandlers"
            'Render a document from Azure Storage 
            'ViewGenerator.RenderDocFromAzure("word.doc");

            'Render a document from ftp location 
            'ViewGenerator.RenderDocFromAzure("word.doc");
            '#End Region

            ' #Region "OtherImprovements"
            'Show grid lines for Excel files in html representation 
            'ViewGenerator.RenderWithGridLinesInExcel("spreadsheet.xlsx");

            'Multiple pages per sheet 
            ' ViewGenerator.RenderMultiExcelSheetsInOnePage("testcc1.xlsx");

            'Show hidden sheets for Excel files in image representation 
            ' ViewGenerator.RenderWithHiddenSheetsInExcel("spreadsheet.xlsx");

            'Render a document from ftp location 
            'ViewGenerator.RenderWithLocales("word.doc");

            'Get all supported document formats 
            'ViewGenerator.ShowAllSupportedFormats();

            '#End Region
        End Sub
    End Module
End Namespace

