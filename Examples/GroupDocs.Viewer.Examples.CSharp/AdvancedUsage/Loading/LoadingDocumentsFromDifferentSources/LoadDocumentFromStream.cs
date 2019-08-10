using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Loading.LoadingDocumentsFromDifferentSources
{
    /// <summary>
    /// This example demonstrates how to render document from stream.
    /// </summary>
    class LoadDocumentFromStream
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");
                        
            using (Viewer viewer = new Viewer(GetFileStream)) 
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }

        private static Stream GetFileStream() => 
            File.OpenRead(Constants.SAMPLE_DOCX);
    }
}
