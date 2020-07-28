using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.RenderingOptionsByDocumentType.RenderingSpreadsheets
{
    /// <summary>
    /// This example demonstrates how to split worksheet(s) into page(s).
    /// </summary>
    class SplitWorksheetsIntoPages
    {
        public static void SplitByRows()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "SplitByRows", "page_{0}.html");

            using (Viewer viewer = new Viewer(TestFiles.TWO_PAGES_XLSX))
            {
                int countRowsPerPage = 15;

                HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                viewOptions.SpreadsheetOptions = SpreadsheetOptions.ForSplitSheetIntoPages(countRowsPerPage);

                viewer.View(viewOptions);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }

        public static void SplitByRowsAndColumns()
        {
            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "SplitByRowsAndColumns", "page_{0}.html");

            using (Viewer viewer = new Viewer(TestFiles.FOUR_PAGES_XLSX))
            {
                int countRowsPerPage = 15;
                int countColumnsPerPage = 7;

                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.SpreadsheetOptions = SpreadsheetOptions.ForSplitSheetIntoPages(countRowsPerPage, countColumnsPerPage);

                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

