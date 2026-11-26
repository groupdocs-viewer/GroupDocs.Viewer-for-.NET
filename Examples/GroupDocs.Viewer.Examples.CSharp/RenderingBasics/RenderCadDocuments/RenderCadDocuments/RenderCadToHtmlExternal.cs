namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.RenderCadDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderCadToHtmlExternal
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.dwg"))
        {
            // Create an HTML file for the drawing.
            // Specify the HTML file name and location of external resources.
            // {0} is replaced with the resource name.
            HtmlViewOptions viewOptions = HtmlViewOptions.ForExternalResources("output.html", "output/resource_{0}", "output/resource_{0}");
            viewer.View(viewOptions);
        }
    }
}
