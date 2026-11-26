namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizationPdfResources;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class OptimizePdfResources
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.docx"))
        {
            PdfViewOptions viewOptions = new PdfViewOptions();
            viewOptions.PdfOptimizationOptions = new PdfOptimizationOptions();

            viewer.View(viewOptions);
        }
    }
}
