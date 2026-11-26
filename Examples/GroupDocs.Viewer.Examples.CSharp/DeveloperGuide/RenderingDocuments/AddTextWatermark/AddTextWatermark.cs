namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.AddTextWatermark;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class AddTextWatermark
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create an HTML file.
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            // Add watermark
            viewOptions.Watermark = new Watermark("This is a watermark");
            viewer.View(viewOptions);
        }
    }
}
