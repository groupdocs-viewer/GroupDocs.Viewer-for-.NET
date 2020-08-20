using GroupDocs.Viewer.Options;
using System;
using System.IO;


namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingImageFiles
{
    /// <summary>
    /// This example demonstrates how to render SVG/SVGZ document into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingSvgAndSvgz
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "svgz_result.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_SVGZ))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "svgz_result.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_SVGZ))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);
                
                viewer.View(options);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "svgz_result.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_SVGZ))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);
               
                viewer.View(options);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "svgz_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_SVGZ))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);
               
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
