using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingTextDocuments
{
    /// <summary>
    /// This example demonstrates how to render TXT document into HTML, JPG, PNG, PDF.
    /// </summary>
    public class RenderingTxt
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFileFullPath = Path.Combine(outputDirectory, "Txt_result.html");

            // TO MULTI PAGES HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_TXT))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFileFullPath);

                viewer.View(options);
            }

            pageFileFullPath = Path.Combine(outputDirectory, "Txt_result_single_page.html");

            // TO SINGLE HTML 
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_2_TXT))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFileFullPath);
                options.RenderToSinglePage = true;

                viewer.View(options);
            }

            // TO JPG
            pageFileFullPath = Path.Combine(outputDirectory, "Txt_result.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_TXT))
            {
                JpgViewOptions options = new JpgViewOptions(pageFileFullPath);

                viewer.View(options);
            }

            // TO PNG
            pageFileFullPath = Path.Combine(outputDirectory, "Txt_result.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_TXT))
            {
                PngViewOptions options = new PngViewOptions(pageFileFullPath);

                viewer.View(options);
            }

            // TO PDF
            pageFileFullPath = Path.Combine(outputDirectory, "Txt_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_TXT))
            {
                PdfViewOptions options = new PdfViewOptions(pageFileFullPath);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}