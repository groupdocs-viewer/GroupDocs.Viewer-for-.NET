using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Loading
{
    /// <summary>
    /// This example demonstrates how to render password-protected document.
    /// </summary>
    class LoadPasswordProtectedDocument
    {
        public static void Run()
        {                       
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            LoadOptions loadOptions = new LoadOptions
            {
                Password = "12345"
            };

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_DOCX_WITH_PASSWORD, loadOptions))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
