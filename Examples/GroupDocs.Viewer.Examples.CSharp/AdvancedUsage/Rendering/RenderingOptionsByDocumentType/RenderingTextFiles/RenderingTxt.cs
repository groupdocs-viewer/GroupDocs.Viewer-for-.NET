using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using GroupDocs.Viewer.Options;

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
            string pageFilePathFormat = Path.Combine(outputDirectory, "Txt_result.html");

            // TO HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_TXT))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            // TO JPG
            pageFilePathFormat = Path.Combine(outputDirectory, "Txt_result.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_TXT))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            // TO PNG
            pageFilePathFormat = Path.Combine(outputDirectory, "Txt_result.png");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_TXT))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            // TO PDF
            pageFilePathFormat = Path.Combine(outputDirectory, "Txt_result.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_TXT))
            {
                PdfViewOptions options = new PdfViewOptions(pageFilePathFormat);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}