using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.QuickStart
{
    /// <summary>
    /// This example demonstrates how to render document into HTML.
    /// </summary>
    class HelloWorld
    {
        public static void Run()
        {
            string outputDirectory = Directory.GetCurrentDirectory();
            string filePath = Utils.SAMPLE_DOCX;
            
            using (Viewer viewer = new Viewer(filePath))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources();
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
