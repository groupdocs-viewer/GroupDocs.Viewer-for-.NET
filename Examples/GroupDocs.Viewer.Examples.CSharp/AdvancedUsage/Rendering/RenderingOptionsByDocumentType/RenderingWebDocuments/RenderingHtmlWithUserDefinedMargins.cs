using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingWebDocuments
{
    /// <summary>
    /// This example demonstrates how to render HTML files with user defined margins.
    /// </summary>
    public class RenderingHtmlWithUserDefinedMargins
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "html_render_margins_page_{0}.jpg");

            /*
             You can adjust margins (top,bottom,left,right) of final document by setting following properties in
             options.WordProcessingOptions:

              LeftMargin
              RightMargin 
              TopMargin
              BottomMargin

              Default values in points are:
               LeftMargin = RightMargin = 5
               TopMargin = BottomMargin = 72
             */

            // TO JPG
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_HTML))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);
                options.WordProcessingOptions.LeftMargin = 40;
                options.WordProcessingOptions.RightMargin = 40;
                options.WordProcessingOptions.TopMargin = 40;
                options.WordProcessingOptions.BottomMargin = 40;

                viewer.View(options);
            }
            
            pageFilePathFormat = Path.Combine(outputDirectory, "html_render_margins_page_{0}.png");

            // TO PNG
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_HTML))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);
                options.WordProcessingOptions.LeftMargin = 40;
                options.WordProcessingOptions.RightMargin = 40;
                options.WordProcessingOptions.TopMargin = 40;
                options.WordProcessingOptions.BottomMargin = 40;

                viewer.View(options);
            }

            pageFilePathFormat = Path.Combine(outputDirectory, "html_render_margins.pdf");

            // TO PDF
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_HTML))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);
                options.WordProcessingOptions.LeftMargin = 40;
                options.WordProcessingOptions.RightMargin = 40;
                options.WordProcessingOptions.TopMargin = 40;
                options.WordProcessingOptions.BottomMargin = 40;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}