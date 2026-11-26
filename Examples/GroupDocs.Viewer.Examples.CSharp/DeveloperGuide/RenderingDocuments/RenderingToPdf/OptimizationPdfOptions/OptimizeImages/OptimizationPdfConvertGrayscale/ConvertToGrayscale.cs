namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizeImages.OptimizationPdfConvertGrayscale;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class ConvertToGrayscale
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.docx"))
        {
            PdfViewOptions viewOptions = new PdfViewOptions();
            viewOptions.PdfOptimizationOptions = new PdfOptimizationOptions
            {
                ConvertToGrayScale = true
            };

            viewer.View(viewOptions);
        }
    }
}
