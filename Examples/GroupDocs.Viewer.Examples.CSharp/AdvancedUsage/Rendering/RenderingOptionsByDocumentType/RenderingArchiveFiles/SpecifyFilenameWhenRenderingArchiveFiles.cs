using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingArchiveFiles
{
    /// <summary>
    /// This example demonstrates how to specify filename when rendering archive files.
    /// </summary>
    class SpecifyFilenameWhenRenderingArchiveFiles
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string outputFilePath = Path.Combine(outputDirectory, "output.pdf");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_ZIP))
            {
                PdfViewOptions viewOptions = new PdfViewOptions(outputFilePath);
                viewOptions.ArchiveOptions.FileName = new FileName("my filename");

                viewer.View(viewOptions);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
