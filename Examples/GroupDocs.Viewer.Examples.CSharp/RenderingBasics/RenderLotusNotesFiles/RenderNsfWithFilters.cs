namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderLotusNotesFiles;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderNsfWithFilters
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.nsf"))
        {
            // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("render-nsf-with-filters_{0}.html");
            // Set filters.
            viewOptions.MailStorageOptions.TextFilter = "Viewer";
            viewOptions.MailStorageOptions.AddressFilter = "groupdocs@mail.com";
            viewer.View(viewOptions);
        }
    }
}
