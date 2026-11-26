namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SplitWorksheetIntoPages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SplitWorksheetByRowsAndColumns
{
    public static void Run()
    {
        // ...

        // Create PDF view options for rendering to PDF
        PdfViewOptions viewOptions = new PdfViewOptions("output.pdf");

        // Specify number of rows and columns for every page
        int rowsPerPage = 15;
        int columnsPerPage = 7;

        // Create spreadsheet options to split worksheet by number of rows and columns
        viewOptions.SpreadsheetOptions = SpreadsheetOptions.ForSplitSheetIntoPages(rowsPerPage, columnsPerPage);

        // Create a Viewer instance and specify the input XLSX
        using (Viewer viewer = new Viewer("four-pages.xlsx"))
        {
            // Render the XLSX to PDF
            viewer.View(viewOptions);
        }
    }
}
