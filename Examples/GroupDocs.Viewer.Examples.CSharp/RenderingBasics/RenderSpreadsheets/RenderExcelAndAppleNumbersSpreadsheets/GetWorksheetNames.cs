namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.RenderExcelAndAppleNumbersSpreadsheets;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class GetWorksheetNames
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.xlsx"))
        {
            var viewInfoOptions = ViewInfoOptions.ForHtmlView();
            // Call this method to create a single page for each worksheet.
            viewInfoOptions.SpreadsheetOptions = SpreadsheetOptions.ForOnePagePerSheet();

            var viewInfo = viewer.GetViewInfo(viewInfoOptions);

            // Print the worksheet names in the console window.
            Console.WriteLine("The document contains the following worksheets:");
            foreach (Page page in viewInfo.Pages)
            {
                Console.WriteLine($" - Worksheet {page.Number}: '{page.Name}'");
            }
        }
    }
}
