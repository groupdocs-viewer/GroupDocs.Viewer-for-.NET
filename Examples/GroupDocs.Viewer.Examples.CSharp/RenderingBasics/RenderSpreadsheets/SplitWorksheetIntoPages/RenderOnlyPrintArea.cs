namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SplitWorksheetIntoPages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderOnlyPrintArea
{
    public static void Run()
    {
        // ...

        // Create PDF view options for rendering to PDF
        PdfViewOptions viewOptions = new PdfViewOptions("render-only-print-area.pdf");

        // Create spreadsheet options to render a Print Area only
        viewOptions.SpreadsheetOptions = SpreadsheetOptions.ForRenderingPrintArea();

        // Create a Viewer instance and specify the input XLSX
        using (Viewer viewer = new Viewer("invoice.xlsx"))
        {
            // Render the XLSX to PDF
            viewer.View(viewOptions);
        }
    }
}
