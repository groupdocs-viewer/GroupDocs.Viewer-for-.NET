namespace GroupDocs.Viewer.Examples.CSharp;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderDocxToHtml
{
    public static void Run()
    {
        // Render a DOCX file to HTML with embedded resources
        using (Viewer viewer = new Viewer("sample.docx"))
        {
            viewer.View(HtmlViewOptions.ForEmbeddedResources("page_{0}.html"));
        }
    }
}
