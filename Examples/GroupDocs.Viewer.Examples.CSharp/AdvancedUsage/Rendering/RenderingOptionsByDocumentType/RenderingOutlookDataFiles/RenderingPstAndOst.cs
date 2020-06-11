using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingOutlookDataFiles
{
    /// <summary>
    /// This example demonstrates how to render PST/OST document into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingPstAndOst
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "PST_result.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_PST))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "PST_result_{0}.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_PST))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "PST_result_{0}.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_PST))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "PST_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_PST))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}