namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SpecifyRenderingOptions;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SetTextOverflowMode
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("invoice.xlsx"))
        {
            // Convert the spreadsheet to PDF.
            var viewOptions = new PdfViewOptions("set-text-overflow-mode.pdf");
            // Specify the AutoFitColumn mode.
            viewOptions.SpreadsheetOptions.TextOverflowMode = TextOverflowMode.AutoFitColumn;
            viewer.View(viewOptions);
        }
    }
}
