using System;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.BasicUsage.RenderDocumentToHtml
{
    /// <summary>
    /// This example demonstrates how to render document into HTML with external resources.
    /// </summary>
    class RenderToHtmlWithExternalResources
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();

            // The {0} and {1} patterns will be replaced with current processing page number and resource name accordingly.
            string pageFilePathFormat = $"{outputDirectory}/page_{{0}}.html";
            string resourceFilePathFormat = $"{outputDirectory}/page_{{0}}_{{1}}";
            string resourceUrlFormat = $"{outputDirectory}/page_{{0}}_{{1}}";

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX))
            {                
                HtmlViewOptions options = HtmlViewOptions
                    .ForExternalResources(pageFilePathFormat, resourceFilePathFormat, resourceUrlFormat);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
