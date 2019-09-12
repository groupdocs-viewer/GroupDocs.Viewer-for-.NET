using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.RenderDocumentToPdf
{
    /// <summary>
    /// This example demonstrates how to render document into PDF file.              
    /// </summary>
    class RenderToPdf
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string outputFilePath = Path.Combine(outputDirectory, "output.pdf");

            using (Viewer viewer = new Viewer(Utils.SAMPLE_DOCX))
            {
                PdfViewOptions options = new PdfViewOptions(outputFilePath);
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }        
    }
}
