using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingImageFiles
{
    /// <summary>
    /// This example demonstrates how to render CMX document into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingCmx
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "cmx_result_{0}.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CMX))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);

                // To render 2nd image, just specify
                //viewer.View(options,2);
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "cmx_result_{0}.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CMX))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);

                viewer.View(options);

                // To render 2nd image, just specify
                //viewer.View(options,2);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "cmx_result_{0}.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CMX))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);

                viewer.View(options);

                // To render 2nd image, just specify
                //viewer.View(options,2);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "cmx_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CMX))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);

                viewer.View(options);

                // By default all images will be rendered in output.pdf, to render only 2nd image in output PDF
                //viewer.View(options,2);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
