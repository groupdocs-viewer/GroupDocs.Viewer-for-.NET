using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingSpreadsheets
{
    /// <summary>
    /// This example demonstrates how to render Apple Numbers document into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingNumbers
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFileFullPath = Path.Combine(outputDirectory, "Numbers_result.html");

            // TO MULTI PAGES HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_NUMBERS))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFileFullPath);

                viewer.View(options);
            }

            // TO JPG
            pageFileFullPath = Path.Combine(outputDirectory, "Numbers_result.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_NUMBERS))
            {
                JpgViewOptions options = new JpgViewOptions(pageFileFullPath);

                viewer.View(options);
            }

            // TO PNG
            pageFileFullPath = Path.Combine(outputDirectory, "Numbers_result.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_NUMBERS))
            {
                PngViewOptions options = new PngViewOptions(pageFileFullPath);

                viewer.View(options);
            }

            // TO PDF
            pageFileFullPath = Path.Combine(outputDirectory, "Numbers_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_NUMBERS))
            {
                PdfViewOptions options = new PdfViewOptions(pageFileFullPath);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}