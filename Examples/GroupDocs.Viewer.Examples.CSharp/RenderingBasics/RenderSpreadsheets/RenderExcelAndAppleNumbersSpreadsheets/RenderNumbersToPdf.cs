namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.RenderExcelAndAppleNumbersSpreadsheets;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderNumbersToPdf
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.numbers"))
        {
            // Convert the spreadsheet to PDF.
            var viewOptions = new PdfViewOptions("render-numbers-to-pdf.pdf");
            viewer.View(viewOptions);
        }
    }
}
