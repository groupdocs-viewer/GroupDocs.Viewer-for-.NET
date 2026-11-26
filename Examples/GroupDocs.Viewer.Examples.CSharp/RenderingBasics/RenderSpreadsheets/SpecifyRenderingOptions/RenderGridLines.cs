namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SpecifyRenderingOptions;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderGridLines
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("invoice.xlsx"))
        {
            // Convert the spreadsheet to PDF.
            var viewOptions = new PdfViewOptions("output.pdf");
            // Render grid lines.
            viewOptions.SpreadsheetOptions.RenderGridLines = true;
            viewer.View(viewOptions);
        }
    }
}
