using GroupDocs.Viewer.Options;
using System;
using System.IO;


namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingImageFiles
{
    /// <summary>
    /// This example demonstrates how to render FODG/ODG document into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingFodgAndOdg
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "fodg_result.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_FODG))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "fodg_result.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_FODG))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);
                
                viewer.View(options);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "fodg_result.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_FODG))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);
               
                viewer.View(options);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "fodg_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_FODG))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);
               
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
