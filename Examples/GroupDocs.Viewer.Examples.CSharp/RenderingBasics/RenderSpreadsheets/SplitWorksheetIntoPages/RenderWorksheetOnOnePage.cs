namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SplitWorksheetIntoPages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWorksheetOnOnePage
{
    public static void Run()
    {
        // ...

        // Create PDF view options for rendering to PDF
        PdfViewOptions viewOptions = new PdfViewOptions("output.pdf");

        // Create spreadsheet options to render each worksheet to one page
        viewOptions.SpreadsheetOptions = SpreadsheetOptions.ForOnePagePerSheet();

        // Create a Viewer instance and specify the input XLSX
        using (Viewer viewer = new Viewer("products.xlsx"))
        {
            // Render the XLSX to PDF
            viewer.View(viewOptions);
        }
    }
}
