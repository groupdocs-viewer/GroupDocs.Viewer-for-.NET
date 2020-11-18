using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingLotusNotesDataFiles
{
    /// <summary>
    /// This example demonstrates how to render NSF document into HTML
    /// </summary>
    public class RenderingNsf
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string outputFilePath = Path.Combine(outputDirectory, "NSF_result.html");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_NSF))
            {
                viewer.View(HtmlViewOptions.ForEmbeddedResources(outputFilePath));
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}