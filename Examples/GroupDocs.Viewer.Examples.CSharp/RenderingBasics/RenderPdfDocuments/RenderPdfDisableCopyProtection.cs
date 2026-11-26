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
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources("render-pdf-disable-copy-protection_{0}.html");
            viewOptions.PdfOptions.DisableCopyProtection = true;

            viewer.View(viewOptions);
        }
    }
}
