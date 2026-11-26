namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderLotusNotesFiles;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderNsfToHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.nsf"))
        {
           // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("output.html");
            viewer.View(viewOptions);
        }
    }
}
