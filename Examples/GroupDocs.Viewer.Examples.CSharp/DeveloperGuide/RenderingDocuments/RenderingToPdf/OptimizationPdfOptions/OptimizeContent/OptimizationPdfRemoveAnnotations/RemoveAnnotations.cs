namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizeContent.OptimizationPdfRemoveAnnotations;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RemoveAnnotations
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("order_form.pdf"))
        {
            PdfViewOptions viewOptions = new PdfViewOptions();
            viewOptions.PdfOptimizationOptions = new PdfOptimizationOptions();
            viewOptions.PdfOptimizationOptions.RemoveAnnotations = true;

            viewer.View(viewOptions);
        }
    }
}
