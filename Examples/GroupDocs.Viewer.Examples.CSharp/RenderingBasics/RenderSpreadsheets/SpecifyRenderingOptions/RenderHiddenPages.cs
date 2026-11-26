namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SpecifyRenderingOptions;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderHiddenPages
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("invoice.xlsx"))
        {
            // Convert the spreadsheet to PDF.
            var viewOptions = new PdfViewOptions("render-hidden-pages.pdf");
            // Enable rendering hidden pages.
            viewOptions.RenderHiddenPages = true;
            viewer.View(viewOptions);
        }
    }
}
