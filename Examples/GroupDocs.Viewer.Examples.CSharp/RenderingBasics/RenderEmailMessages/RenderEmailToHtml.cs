namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderEmailMessages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderEmailToHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.eml"))
        {
           // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("output.html");
            viewer.View(viewOptions);
        }
    }
}
