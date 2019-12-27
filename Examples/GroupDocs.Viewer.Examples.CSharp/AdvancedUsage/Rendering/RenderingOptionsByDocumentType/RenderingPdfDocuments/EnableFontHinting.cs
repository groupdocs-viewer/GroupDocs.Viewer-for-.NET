using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingPdfDocuments
{
    /// <summary>
    /// This example demonstrates how to adjust the display of outline font when rendering PDF documents.
    /// </summary>
    class EnableFontHinting
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.png");

            using (Viewer viewer = new Viewer(TestFiles.HIEROGLYPHS_1_PDF))
            {
                PngViewOptions options = new PngViewOptions(pageFilePathFormat);
                options.PdfOptions.EnableFontHinting = true;

                viewer.View(options, 1);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

