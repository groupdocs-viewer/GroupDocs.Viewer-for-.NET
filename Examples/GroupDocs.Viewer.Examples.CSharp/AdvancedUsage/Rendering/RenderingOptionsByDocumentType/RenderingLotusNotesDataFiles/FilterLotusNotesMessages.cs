using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingLotusNotesDataFiles
{
    /// <summary>
    /// This example demonstrates how to filter messages by text/sender/recipient when rendering Lotus Notes data files.
    /// </summary>
    class FilterLotusNotesMessages
    {
        public static void Run()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(TestFiles.SAMPLE_NSF))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.MailStorageOptions.TextFilter = "April 2015";
                options.MailStorageOptions.AddressFilter = "campaign@banckle.com";

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

