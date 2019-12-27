using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.RenderDocumentToPdf
{
    /// <summary>
    /// This example demonstrates how to adjust quality of JPG images of the output PDF document.
    /// </summary>
    class AdjustQualityOfJpgImages
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string filePath = Path.Combine(outputDirectory, "output.pdf");

            using (Viewer viewer = new Viewer(TestFiles.JPG_IMAGE_PPTX))
            {               
                PdfViewOptions options = new PdfViewOptions(filePath);
                options.JpgQuality = 10;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

