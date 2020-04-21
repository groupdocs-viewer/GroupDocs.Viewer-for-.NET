using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingCadDrawings
{
    /// <summary>
    /// This example demonstrates how to render PLT document into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingPlt
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "plt_result.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_PLT))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "plt_result.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_PLT))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "plt_result.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_PLT))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "plt_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_PLT))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}