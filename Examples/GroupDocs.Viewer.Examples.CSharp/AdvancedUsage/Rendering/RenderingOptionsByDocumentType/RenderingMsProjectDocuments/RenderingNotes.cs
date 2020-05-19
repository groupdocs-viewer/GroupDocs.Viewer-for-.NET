using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingMsProjectDocuments
{
    /// <summary>
    /// This example demonstrates how to render MS Project document into HTML, JPG, PNG, PDF with notes.
    /// </summary>
    public class RenderingNotes
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "mpp_result.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_MPP))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.RenderNotes = true;

                viewer.View(options);
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "mpp_{0}_result.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_MPP))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);
                options.RenderNotes = true;

                viewer.View(options);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "mpp_{0}_result.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_MPP))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);
                options.RenderNotes = true;

                viewer.View(options);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "mpp_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_MPP))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);
                options.RenderNotes = true;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
