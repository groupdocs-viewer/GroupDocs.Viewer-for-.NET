using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingSpreadsheets
{
    /// <summary>
    /// This example demonstrates how to render Excel 2003 SpreadSheetML XML document into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingXmlSpreadSheetML
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFileFullPath = Path.Combine(outputDirectory, "Excel_2003_Xml_result.html");

            /* Because the XML extension is associated with both an XML text document and Excel 2003 XML SpreadSheetML, 
             * please specify the Excel2003XML fileType explicitly to render it as Excel 2003 XML SpreadSheetML.
             */

            LoadOptions loadOptions = new LoadOptions(FileType.Excel2003XML);

            // TO MULTI PAGES HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_XML_SPREADSHEETML, loadOptions))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFileFullPath);

                viewer.View(options);
            }

            // TO JPG
            pageFileFullPath = Path.Combine(outputDirectory, "Excel_2003_Xml_result.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_XML_SPREADSHEETML, loadOptions))
            {
                JpgViewOptions options = new JpgViewOptions(pageFileFullPath);

                viewer.View(options);
            }

            // TO PNG
            pageFileFullPath = Path.Combine(outputDirectory, "Excel_2003_Xml_result.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_XML_SPREADSHEETML, loadOptions))
            {
                PngViewOptions options = new PngViewOptions(pageFileFullPath);

                viewer.View(options);
            }

            // TO PDF
            pageFileFullPath = Path.Combine(outputDirectory, "Excel_2003_Xml_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_XML_SPREADSHEETML, loadOptions))
            {
                PdfViewOptions options = new PdfViewOptions(pageFileFullPath);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}