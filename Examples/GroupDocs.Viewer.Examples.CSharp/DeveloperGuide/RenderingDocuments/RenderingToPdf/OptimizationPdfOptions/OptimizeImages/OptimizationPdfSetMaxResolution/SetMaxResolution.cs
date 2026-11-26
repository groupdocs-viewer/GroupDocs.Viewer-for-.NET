namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.OptimizeImages.OptimizationPdfSetMaxResolution;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SetMaxResolution
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.docx"))
        {
            PdfViewOptions viewOptions = new PdfViewOptions();
            viewOptions.PdfOptimizationOptions = new PdfOptimizationOptions
            {
                CompressImages = true,
                ImageQuality = 50,
                ResizeImages = true,
                MaxResolution = 100
            };

            viewer.View(viewOptions);
        }
    }
}
