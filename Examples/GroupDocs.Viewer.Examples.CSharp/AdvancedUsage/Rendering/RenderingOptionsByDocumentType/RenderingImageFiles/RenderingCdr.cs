using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingImageFiles
{
    /// <summary>
    /// This example demonstrates how to render CDR document into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingCdr
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "cdr_result_{0}.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CDR))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);

                // To render 2nd image, just specify
                //viewer.View(options,2);
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "cdr_result_{0}.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CDR))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);
                
                viewer.View(options);

                // To render 2nd image, just specify
                //viewer.View(options,2);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "cdr_result_{0}.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CDR))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);
               
                viewer.View(options);

                // To render 2nd image, just specify
                //viewer.View(options,2);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "cdr_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CDR))
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
