namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.RenderCadDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderCadToHtml
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.dwg"))
        {
            // Create an HTML file for the drawing.
            // Specify the HTML file name.
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources("render-cad-to-html.html");
            viewer.View(viewOptions);
        }
    }
}
