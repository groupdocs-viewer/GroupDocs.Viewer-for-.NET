namespace GroupDocs.Viewer.Examples.CSharp.ProductOverview;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class QuickExampleHtml
{
    public static void Run()
    {
        // Render a DOCX document to HTML - the hello-world example.
        using (Viewer viewer = new Viewer("./sample.docx"))
        {
            HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("page_{0}.html");
            viewer.View(options);
        }
    }
}
