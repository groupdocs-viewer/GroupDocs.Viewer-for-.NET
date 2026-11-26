namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPdfDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPdfDisableCopyProtection
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("copy_protected.pdf"))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewOptions.PdfOptions.DisableCopyProtection = true;

            viewer.View(viewOptions);
        }
    }
}
