namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SpecifyRenderingOptions;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SkipEmptyRowsAndColumns
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("invoice.xlsx"))
        {
            // Convert the spreadsheet to PDF.
            var viewOptions = new PdfViewOptions("output.pdf");
            // Enable skipping blank rows and columns.
            viewOptions.SpreadsheetOptions.SkipEmptyRows = true;
            viewOptions.SpreadsheetOptions.SkipEmptyColumns = true;
            viewer.View(viewOptions);
        }
    }
}
