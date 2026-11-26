namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.RenderExcelAndAppleNumbersSpreadsheets;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderCsvWithSeparatorDetection
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.csv"))
        {
            // Convert the spreadsheet to HTML.
            // {0} is replaced with the current page number in the file names.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("render-csv-with-separator-detection_{0}.html");
            // Detect a CSV/TSV separator.
            viewOptions.SpreadsheetOptions.DetectSeparator = true;
            viewer.View(viewOptions);
        }
    }
}
