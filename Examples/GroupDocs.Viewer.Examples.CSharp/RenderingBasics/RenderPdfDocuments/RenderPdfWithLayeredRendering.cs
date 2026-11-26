namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPdfDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPdfWithLayeredRendering
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pdf"))
        {
            // Create an HTML file for each document page.
            // {0} is replaced with the current page number in the file name.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("page_{0}.html");
            // Enable the multi-layer rendering.
            viewOptions.PdfOptions.EnableLayeredRendering = true;
            viewer.View(viewOptions);
        }
    }
}
