using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Loading
{
    /// <summary>
    /// This example demonstrates how to set timeout for loading external resources contained by a document.
    /// </summary>
    class SetResourceLoadingTimeout
    {
        public static void Run()
        {                       
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");
            
            LoadOptions loadOptions = new LoadOptions
            {
                ResourceLoadingTimeout = TimeSpan.FromSeconds(5)
            };

            using (Viewer viewer = new Viewer(TestFiles.WITH_EXTERNAL_IMAGE_DOC, loadOptions))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
