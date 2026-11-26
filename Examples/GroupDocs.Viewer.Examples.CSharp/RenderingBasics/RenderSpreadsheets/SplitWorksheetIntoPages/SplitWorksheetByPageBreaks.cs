namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SplitWorksheetIntoPages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SplitWorksheetByPageBreaks
{
    public static void Run()
    {
        // ...

        // Create PDF view options for rendering to PDF
        PdfViewOptions viewOptions = new PdfViewOptions("output.pdf");

        // Create spreadsheet options to split worksheet onto pages by page breaks
        viewOptions.SpreadsheetOptions = SpreadsheetOptions.ForRenderingByPageBreaks();

        // Create a Viewer instance and specify the input XLSX
        using (Viewer viewer = new Viewer("products.xlsx"))
        {
            // Render the XLSX to PDF
            viewer.View(viewOptions);
        }
    }
}
