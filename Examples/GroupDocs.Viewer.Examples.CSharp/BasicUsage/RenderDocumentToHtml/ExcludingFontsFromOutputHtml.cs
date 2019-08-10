using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.RenderDocumentToHtml
{
    /// <summary>
    /// This example demonstrates how to exclude Times New Roman font from the output when rendering into HTML.
    /// </summary>
    class ExcludingFontsFromOutputHtml
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX))
            {
                HtmlViewOptions options = 
                    HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.FontsToExclude.Add("Times New Roman");

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
