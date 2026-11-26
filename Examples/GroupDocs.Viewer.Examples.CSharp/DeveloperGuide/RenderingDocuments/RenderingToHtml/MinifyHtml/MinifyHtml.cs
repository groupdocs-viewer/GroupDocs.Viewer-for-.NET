namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToHtml.MinifyHtml;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class MinifyHtml
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Create view options.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources();

            // Render the minified file.
            viewOptions.Minify = true;
            viewer.View(viewOptions);
        }
    }
}
