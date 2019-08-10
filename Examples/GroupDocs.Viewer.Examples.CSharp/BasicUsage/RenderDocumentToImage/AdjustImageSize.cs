using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.RenderDocumentToImage
{
    /// <summary>
    /// This example demonstrates how to adjust size width and height of the output images.
    /// </summary>
    class AdjustImageSize
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.jpg");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);
                options.Width = 600;
                options.Height = 800;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
