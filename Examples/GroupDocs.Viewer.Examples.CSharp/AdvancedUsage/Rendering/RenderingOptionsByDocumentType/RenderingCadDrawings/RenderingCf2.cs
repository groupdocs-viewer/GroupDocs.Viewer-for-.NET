using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingCadDrawings
{
    /// <summary>
    /// This example demonstrates how to render CF2 document into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingCf2
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "CF2_result.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CF2))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                //options.CadOptions = CadOptions.ForRenderingByScaleFactor(0.7f); // Render image and reduce it by 30%
                //options.CadOptions = CadOptions.ForRenderingByWidthAndHeight(400,400); // Render image and set output size to 400x400
                //options.CadOptions = CadOptions.ForRenderingByWidth(500); // Render image, fix width by 500 px and recalculate height
                //options.CadOptions = CadOptions.ForRenderingByHeight(500); // Render image, fix height by 500 px and recalculate width

                viewer.View(options);
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "CF2_result.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CF2))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);
                //options.CadOptions = CadOptions.ForRenderingByScaleFactor(0.7f); // Render image and reduce it by 30%
                //options.CadOptions = CadOptions.ForRenderingByWidthAndHeight(400,400); // Render image and set output size to 400x400
                //options.CadOptions = CadOptions.ForRenderingByWidth(500); // Render image, fix width by 500 px and recalculate height
                //options.CadOptions = CadOptions.ForRenderingByHeight(500); // Render image, fix height by 500 px and recalculate width

                viewer.View(options);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "CF2_result.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CF2))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);
                //options.CadOptions = CadOptions.ForRenderingByScaleFactor(0.7f); // Render image and reduce it by 30%
                //options.CadOptions = CadOptions.ForRenderingByWidthAndHeight(400,400); // Render image and set output size to 400x400
                //options.CadOptions = CadOptions.ForRenderingByWidth(500); // Render image, fix width by 500 px and recalculate height
                //options.CadOptions = CadOptions.ForRenderingByHeight(500); // Render image, fix height by 500 px and recalculate width

                viewer.View(options);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "CF2_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CF2))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);
                //options.CadOptions = CadOptions.ForRenderingByScaleFactor(0.7f); // Render image and reduce it by 30%
                //options.CadOptions = CadOptions.ForRenderingByWidthAndHeight(400,400); // Render image and set output size to 400x400
                //options.CadOptions = CadOptions.ForRenderingByWidth(500); // Render image, fix width by 500 px and recalculate height
                //options.CadOptions = CadOptions.ForRenderingByHeight(500); // Render image, fix height by 500 px and recalculate width

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}