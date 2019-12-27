using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingEMailMessages
{
    /// <summary>
    /// This example demonstrates how to change page size when rendering email messages.
    /// </summary>
    class AdjustPageSize
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string filePath = Path.Combine(outputDirectory, "output.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_MSG))
            {
                PdfViewOptions options = new PdfViewOptions(filePath);
                options.EmailOptions.PageSize = PageSize.A4;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}