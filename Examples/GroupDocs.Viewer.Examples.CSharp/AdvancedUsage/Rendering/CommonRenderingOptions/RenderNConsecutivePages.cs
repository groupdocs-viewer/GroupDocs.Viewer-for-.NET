using System;
using System.IO;
using System.Linq;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.CommonRenderingOptions
{
    /// <summary>
    /// This example demonstrates how to render range of pages.
    /// </summary>
    class RenderNConsecutivePages
    {
        public static void Run()
        {                       
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");
            int[] range = Enumerable.Range(1, 3).ToArray();

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                viewer.View(options, range);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
