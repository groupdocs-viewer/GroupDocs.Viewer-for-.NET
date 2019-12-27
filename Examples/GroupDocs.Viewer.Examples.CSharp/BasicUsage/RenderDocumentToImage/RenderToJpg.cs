using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.RenderDocumentToImage
{
    /// <summary>
    /// This example demonstrates how to render document into JPG image.
    /// </summary>
    class RenderToJpg
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.jpg");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_DOCX))
            {
                JpgViewOptions options = new JpgViewOptions(pageFilePathFormat);
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
