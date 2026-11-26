namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives._index;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderArchiveWithOptions
{
    public static void Run()
    {
        // ...

        HtmlViewOptions htmlEmbeddedOptions = HtmlViewOptions.ForEmbeddedResources("FolderAndFileName.html");
        htmlEmbeddedOptions.ArchiveOptions.Folder = "Invoices";
        htmlEmbeddedOptions.ArchiveOptions.FileName = new FileName("The Invoices folder of documents.zip");

        using (Viewer viewer = new Viewer("documents.zip"))
        {
            viewer.View(htmlEmbeddedOptions);
        }
    }
}
