namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizeContent.OptimizationPdfRemoveFields;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RemoveFormFields
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("order_form.pdf"))
        {
            PdfViewOptions viewOptions = new PdfViewOptions();
            viewOptions.PdfOptimizationOptions = new PdfOptimizationOptions
            {
                RemoveFormFields = true
            };

            viewer.View(viewOptions);
        }
    }
}
