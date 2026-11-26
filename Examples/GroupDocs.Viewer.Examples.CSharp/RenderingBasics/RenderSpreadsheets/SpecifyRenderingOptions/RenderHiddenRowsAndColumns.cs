namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SpecifyRenderingOptions;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderHiddenRowsAndColumns
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("invoice.xlsx"))
        {
            // Convert the spreadsheet to PDF.
            var viewOptions = new PdfViewOptions("render-hidden-rows-and-columns.pdf");
            // Enable rendering hidden rows and columns.
            viewOptions.SpreadsheetOptions.RenderHiddenRows = true;
            viewOptions.SpreadsheetOptions.RenderHiddenColumns = true;
            viewer.View(viewOptions);
        }
    }
}
