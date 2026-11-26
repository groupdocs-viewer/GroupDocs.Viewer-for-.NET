namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives.OldArchiveRendering;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LegacyArchiveSingleHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("documents.zip"))
        {
            // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("legacy-archive-single-html.html");
            // Render the archive file to a single page.
            viewOptions.RenderToSinglePage = true;
            viewer.View(viewOptions);
        }
    }
}
