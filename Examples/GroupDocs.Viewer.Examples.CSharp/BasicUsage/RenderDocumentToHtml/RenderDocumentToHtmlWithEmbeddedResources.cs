using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.RenderDocumentToHtml
{
    /// <summary>
    /// This example demonstrates how to render document into HTML with embedded resources.
    /// </summary>
    class RenderToHtmlWithEmbeddedResources
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_DOCX))
            {                
                HtmlViewOptions options = 
                    HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);    
                
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in: {outputDirectory}");
        }
    }
}
