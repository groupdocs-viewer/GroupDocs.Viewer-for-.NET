using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.CommonRenderingOptions
{
    /// <summary>
    /// This example demonstrates how to render document and add watermark to each page.
    /// </summary>
    class AddWatermark
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX))
            {
                HtmlViewOptions options = 
                    HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.Watermark = new Watermark("This is a watermark");
                
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
