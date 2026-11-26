namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderLotusNotesFiles;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderNsfWithMaxItems
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.nsf"))
        {
            // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources();
            // Specify the maximum items to render.
            viewOptions.MailStorageOptions.MaxItems = 20;
            viewer.View(viewOptions);
        }
    }
}
