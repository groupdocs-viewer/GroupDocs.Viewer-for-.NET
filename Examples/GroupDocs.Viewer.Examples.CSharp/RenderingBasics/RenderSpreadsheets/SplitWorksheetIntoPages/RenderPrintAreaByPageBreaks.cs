namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SplitWorksheetIntoPages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPrintAreaByPageBreaks
{
    public static void Run()
    {
        // ...

        // Create PDF view options for rendering to PDF
        PdfViewOptions viewOptions = new PdfViewOptions("Financial Sample.pdf");

        // Render a Print Area and split by page breaks
        viewOptions.SpreadsheetOptions = SpreadsheetOptions.ForRenderingPrintAreaAndPageBreaks();

        // Create a Viewer instance and specify the input XLSX
        using (Viewer viewer = new Viewer("products.xlsx"))
        {
            // Render the XLSX to PDF
            viewer.View(viewOptions);
        }
    }
}
