namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.OptimizationPdfOptions.PdfRemoveUnusedResources;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RemoveUnusedResources
{
    public static void Run()
    {
        // ...

        const string filename = "sample.pdf";

        PdfViewOptions viewOptions1 = new PdfViewOptions("output1.pdf");
        viewOptions1.PdfOptimizationOptions = new PdfOptimizationOptions();
        viewOptions1.PdfOptimizationOptions.RemoveUnusedObjects = true;

        PdfViewOptions viewOptions2 = new PdfViewOptions("output2.pdf");
        viewOptions2.PdfOptimizationOptions = new PdfOptimizationOptions();
        viewOptions2.PdfOptimizationOptions.RemoveUnusedStreams = true;

        using (Viewer viewer = new Viewer(filename))
        {
            viewer.View(viewOptions1);
            viewer.View(viewOptions2);
        }
    }
}
