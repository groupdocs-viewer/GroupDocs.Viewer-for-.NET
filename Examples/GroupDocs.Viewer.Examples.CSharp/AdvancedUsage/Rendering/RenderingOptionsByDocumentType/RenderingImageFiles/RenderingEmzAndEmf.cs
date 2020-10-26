using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingImageFiles
{
    /// <summary>
    /// This example demonstrates how to render EMZ/EMF document into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingEmzAndEmf
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "emz_result.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_EMZ))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "emz_result.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_EMZ))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);
                
                viewer.View(options);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "emz_result.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_EMZ))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);
               
                viewer.View(options);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "emz_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_EMZ))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);
               
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
