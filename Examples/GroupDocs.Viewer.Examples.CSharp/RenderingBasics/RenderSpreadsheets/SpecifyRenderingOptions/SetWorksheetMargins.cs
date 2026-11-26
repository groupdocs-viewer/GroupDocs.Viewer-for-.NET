namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderSpreadsheets.SpecifyRenderingOptions;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SetWorksheetMargins
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("invoice.xlsx"))
        {
            var viewOptions = new PdfViewOptions("set-worksheet-margins.pdf");

            // Set margins for worksheets in the output pdf pages
            viewOptions.SpreadsheetOptions.LeftMargin = 0;
            viewOptions.SpreadsheetOptions.RightMargin = 0.5;
            viewOptions.SpreadsheetOptions.TopMargin = 1;
            viewOptions.SpreadsheetOptions.BottomMargin = -10; // set to default value

            viewer.View(viewOptions);
        }
    }
}
