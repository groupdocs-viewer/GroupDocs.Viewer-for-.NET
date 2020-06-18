using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingSpreadsheets
{
    /// <summary>
    /// This example demonstrates how to render row and column headings.
    /// </summary>
    public class RenderRowAndColumnHeadings
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_XLSX))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.SpreadsheetOptions.RenderHeadings = true;

                viewer.View(options,1, 2, 3);
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_XLSX))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);
                options.SpreadsheetOptions.RenderHeadings = true;

                viewer.View(options, 1, 2, 3);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_XLSX))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);
                options.SpreadsheetOptions.RenderHeadings = true;

                viewer.View(options, 1, 2, 3);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "output.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_XLSX))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);
                options.SpreadsheetOptions.RenderHeadings = true;

                viewer.View(options, 1, 2, 3);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
