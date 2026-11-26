namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.AdjustJpegImagesQuality;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class AdjustJpegQuality
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create view options.
            PdfViewOptions viewOptions = new PdfViewOptions();

            // Specify the JPG image quality.
            viewOptions.PdfOptimizationOptions = new PdfOptimizationOptions();
            viewOptions.PdfOptimizationOptions.CompressImages = true;
            viewOptions.PdfOptimizationOptions.ImageQuality = 50;
            viewer.View(viewOptions);
        }
    }
}
