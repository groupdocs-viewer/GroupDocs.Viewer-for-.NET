namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizationPdfSpreadsheets;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class OptimizeSpreadsheets
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("invoice.xlsx"))
        {
            PdfViewOptions viewOptions = new PdfViewOptions();
            viewOptions.PdfOptimizationOptions = new PdfOptimizationOptions 
            {
                OptimizeSpreadsheets = true
            };

            viewer.View(viewOptions);
        }
    }
}
