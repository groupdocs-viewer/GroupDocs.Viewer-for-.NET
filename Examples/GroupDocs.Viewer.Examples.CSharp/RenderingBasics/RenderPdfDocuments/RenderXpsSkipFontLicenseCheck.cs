namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPdfDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderXpsSkipFontLicenseCheck
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.oxps"))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewOptions.PdfOptions.DisableFontLicenseVerifications = true;
            viewer.View(viewOptions);
        }
    }
}
