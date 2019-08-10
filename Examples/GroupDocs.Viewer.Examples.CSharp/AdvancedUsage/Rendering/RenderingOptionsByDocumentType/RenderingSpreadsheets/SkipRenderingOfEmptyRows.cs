using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingSpreadsheets
{
    /// <summary>
    /// This example demonstrates how to skip rendering of empty rows.
    /// </summary>
    class SkipRenderingOfEmptyRows
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(Constants.SAMPLE_XLSX_WITH_EMPTY_ROW))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.SpreadsheetOptions.SkipEmptyRows = true;

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

