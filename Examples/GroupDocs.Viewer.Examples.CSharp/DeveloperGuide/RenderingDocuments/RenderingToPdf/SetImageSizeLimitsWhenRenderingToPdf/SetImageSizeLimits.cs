namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.SetImageSizeLimitsWhenRenderingToPdf;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SetImageSizeLimits
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.jpg"))
        {
            // Create a PDF file.
            PdfViewOptions viewOptions = new PdfViewOptions();

            // Specify the maximum width and height.
            viewOptions.ImageMaxWidth = 800;
            viewOptions.ImageMaxHeight = 600;
            viewer.View(viewOptions);
        }
    }
}
