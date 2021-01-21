using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingImageFiles
{
    /// <summary>
    ///  This example demonstrates how to render Animated PNG format
    /// </summary>
    public class RenderingApng
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "apng_result.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_APNG))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }
            

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "apng_result_{0}.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_APNG))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "apng_result_{0}.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_APNG))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "apng_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_APNG))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
