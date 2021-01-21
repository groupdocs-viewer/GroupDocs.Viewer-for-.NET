using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingWebDocuments
{
    /// <summary>
    /// This example demonstrates how to render CHM document into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingChmFiles
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "chm_result_{0}.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CHM))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.RenderToSinglePage = true; // Enable it if you want to convert all CHM content to single page

                //viewer.View(options,1,2,3); // Convert only 1,2,3 pages
                 viewer.View(options); // Convert all pages
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "chm_result_{0}.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CHM))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);

                viewer.View(options,1,2,3); // Convert only 1,2,3 pages
                //viewer.View(options); // Convert all pages
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "chm_result_{0}.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CHM))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);

                viewer.View(options,1,2,3); // Convert only 1,2,3 pages
                //viewer.View(options); // Convert all pages
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "chm_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_CHM))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);

                viewer.View(options); // Convert all pages
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}