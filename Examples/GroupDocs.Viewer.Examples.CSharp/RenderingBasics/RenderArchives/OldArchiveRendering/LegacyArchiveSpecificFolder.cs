namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives.OldArchiveRendering;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class LegacyArchiveSpecificFolder
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("documents.zip"))
        {
            // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("output.html");
            // Specify a folder to render items from.
            viewOptions.ArchiveOptions.Folder = "Documents/CAD files";
            viewer.View(viewOptions);
        }
    }
}
