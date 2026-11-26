namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizeFonts.OptimizationPdfSubsetFonts;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SubsetFonts
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.docx"))
        {
            PdfViewOptions viewOptions = new PdfViewOptions();
            viewOptions.PdfOptimizationOptions = new PdfOptimizationOptions
            {
                SubsetFonts = true
            };

            viewer.View(viewOptions);
        }
    }
}
