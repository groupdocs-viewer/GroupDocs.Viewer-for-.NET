using System;
using System.Collections.Generic;
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
            Utilities.ApplyLicense();
            //ExEnd:ApplyingLicense

            #region ViewerHtmlPresentation
            
            //Render a power point presentation in html form
            //ViewGenerator.RenderDocumentAsHtml("word.doc");
           
            //Render a spreadsheet in html form
            //ViewGenerator.RenderDocumentAsHtml("spreadsheet.xlsx");
            
            //Render a MS word document by replacing its 1st page order with 2nd page 
            //ViewGenerator.RenderDocumentAsHtml("large_will_not_getting_processed.docx");
        
             //Render a word document in html form and also apply a text as watermark on each page
            //ViewGenerator.RenderDocumentAsHtml("word.doc", "Show me as watermark", Color.Purple);
            
            //Render a document located at a web location
            // ViewGenerator.RenderDocumentAsHtml(new Uri("http://www.example.com/sample.doc"));

             #endregion
             
             #region ViewerImagePresentation
            
            //Render a power point presentation in images form.
            //ViewGenerator.RenderDocumentAsImages("sample.pptx");
           
            //Render a spreadsheet in images form.
            //ViewGenerator.RenderDocumentAsImages("spreadsheet.xlsx");
            
            //Render a MS word document by replacing its 1st page order with 2nd page. 
            // ViewGenerator.RenderDocumentAsImages("word.doc",1,2);
            
            //Render a word document in images form and also apply a text as watermark on each page.
            // ViewGenerator.RenderDocumentAsImages("word.doc", "Show me as watermark", Color.Purple);
            
            //Render a word document in images form and set the rotation angle to display the rotated page.
            // ViewGenerator.RenderDocumentAsImages("word.doc", 180);
            
            //Render a document located at a web location
            // ViewGenerator.RenderDocumentAsImages(new Uri("http://www.example.com/sample.doc"));

             #endregion

            #region GeneralRepresentation
            //Render the word document in the form of pdf markup
             ViewGenerator.RenderDocumentAsPDF("test.pdf");

            //Render the document as it is (Original form)
            //ViewGenerator.RenderDocumentAsOriginal("factsheet.pdf");
            #endregion

            #region InputDataHandlers
            //Render a document from Azure Storage 
            //ViewGenerator.RenderDocFromAzure("word.doc");
            //Render a document from ftp location 
            //ViewGenerator.RenderDocFromAzure("word.doc");
            #endregion


        }
    }
}
