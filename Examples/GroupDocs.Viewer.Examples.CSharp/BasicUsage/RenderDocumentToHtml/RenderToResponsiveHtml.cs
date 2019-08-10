using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.RenderDocumentToHtml
{
    /// <summary>
    /// This example demonstrates how to render document into responsive HTML.
    /// </summary>
    class RenderToResponsiveHtml
    {
        public static void Run()
        {                       
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.RenderResponsive = true;                

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
