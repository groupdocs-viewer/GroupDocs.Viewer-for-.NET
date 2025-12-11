using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingArchiveFiles
{
    /// <summary>
    /// This example demonstrates how to render archives files into HTML.
    /// </summary>
    public class RenderingArchivesToHtml
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "RAR_result.html");

            // tune options
            HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

            // load archive file to the Viewer
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_RAR_WITH_FOLDERS))
            {
                // render to HTML using previously prepared options
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");

        }
    }
}