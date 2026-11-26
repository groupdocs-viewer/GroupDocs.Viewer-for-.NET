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
            var viewOptions = new PdfViewOptions("output.pdf");
            viewer.View(viewOptions);
        }
    }
}
