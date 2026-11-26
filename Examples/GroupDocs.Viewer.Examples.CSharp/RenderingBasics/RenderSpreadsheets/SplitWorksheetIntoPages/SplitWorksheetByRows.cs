namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SplitWorksheetIntoPages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SplitWorksheetByRows
{
    public static void Run()
    {
        // ...

        // Create PDF view options for rendering to PDF
        PdfViewOptions viewOptions = new PdfViewOptions("output.pdf");

        // Specify number of rows for every page
        int rowsPerPage = 15;

        // Create spreadsheet options to split worksheet by number of rows
        viewOptions.SpreadsheetOptions = SpreadsheetOptions.ForSplitSheetIntoPages(rowsPerPage);

        // Create a Viewer instance and specify the input XLSX
        using (Viewer viewer = new Viewer("two-pages.xlsx"))
        {
            // Render the XLSX to PDF
            viewer.View(viewOptions);
        }
    }
}
