namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives.OldArchiveRendering;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LegacyArchiveToHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("documents.zip"))
        {
            // Create an HTML file for the top folder and each subfolder in the archive.
            // {0} is replaced with the current page number in the output file name.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("legacy-archive-to-html_{0}.html");
            viewer.View(viewOptions);
        }
    }
}
