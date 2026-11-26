namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderArchiveToHtml
{
    public static void Run()
    {
        // ...

        HtmlViewOptions htmlEmbeddedOptions = HtmlViewOptions.ForEmbeddedResources("Embedded.html");
        HtmlViewOptions htmlExternalOptions = HtmlViewOptions.ForExternalResources("External.html", "External_files/resource-{1}", "External_files/resource-{1}");

        using (Viewer viewer = new Viewer("documents.zip"))
        {
            viewer.View(htmlEmbeddedOptions);
            viewer.View(htmlExternalOptions);
        }
    }
}
