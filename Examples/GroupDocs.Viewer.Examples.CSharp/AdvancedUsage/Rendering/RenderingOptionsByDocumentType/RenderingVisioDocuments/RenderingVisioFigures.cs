using GroupDocs.Viewer.Options;
using System;
using System.IO;


namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingImageFiles
{
    /// <summary>
    /// This example demonstrates how to render Visio documents figures into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingVisioDocumentsFigures
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "result_page.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_VISIO))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.VisioRenderingOptions.RenderFiguresOnly = true;
                options.VisioRenderingOptions.FigureWidth = 250;

                viewer.View(options);
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "visio_result.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_VISIO))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);
                options.VisioRenderingOptions.RenderFiguresOnly = true;
                options.VisioRenderingOptions.FigureWidth = 250;

                viewer.View(options);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "visio_result.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_VISIO))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);
                options.VisioRenderingOptions.RenderFiguresOnly = true;
                options.VisioRenderingOptions.FigureWidth = 250;

                viewer.View(options);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "visio_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_VISIO))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);
                options.VisioRenderingOptions.RenderFiguresOnly = true;
                options.VisioRenderingOptions.FigureWidth = 250;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
