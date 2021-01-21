using GroupDocs.Viewer.Options;
using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingArchiveFiles
{
    /// <summary>
    /// This example demonstrates how to render archives files into multiple/single pages HTML.
    /// </summary>
    public class RenderingArchivesToMultipleAndSinglePagesHtml
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "RAR_result.html");

            // TO single page HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_RAR_WITH_FOLDERS))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                options.RenderToSinglePage = true; 

                viewer.View(options);
            }

            // RAR_result_page_{0}.html - {0} is page number mask
            pageFilePathFormat = Path.Combine(outputDirectory, "RAR_result_page_{0}.html");

            // TO multi pages HTML
            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_RAR_WITH_FOLDERS))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                /*
                 * If options.RenderToSinglePage is set to false (by default), 
                 * you can set the number of items per page (default is 16), this property is for rendering to HTML only 
                 */
                options.ArchiveOptions.ItemsPerPage = 10;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");

        }
    }
}