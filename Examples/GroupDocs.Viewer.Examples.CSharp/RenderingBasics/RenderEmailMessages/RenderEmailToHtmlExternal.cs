namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderEmailMessages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderEmailToHtmlExternal
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.eml"))
        {
            // Specify the HTML file name and location of external resources.
            // {0} is replaced with the page number, {1} with the resource name.
            var viewOptions = HtmlViewOptions.ForExternalResources("page_{0}.html", "page_{0}/resource_{0}_{1}", "page_{0}/resource_{0}_{1}");
            viewer.View(viewOptions);
        }
    }
}
