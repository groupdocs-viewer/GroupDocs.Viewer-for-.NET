namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPdfDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPdfImagesInSvg
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.pdf"))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewOptions.PdfOptions.WrapImagesInSvg = true;

            viewer.View(viewOptions);
        }
    }
}
