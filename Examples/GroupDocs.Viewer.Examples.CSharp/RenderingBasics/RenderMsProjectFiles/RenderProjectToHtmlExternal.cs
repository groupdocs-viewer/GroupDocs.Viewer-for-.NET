namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderMsProjectFiles;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderProjectToHtmlExternal
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.mpp"))
        {
            // Render the project's active view as HTML.
            // Specify the HTML file names and location of external resources.
            // {0} and {1} are replaced with the page number and resource name, respectively.
            var viewOptions = HtmlViewOptions.ForExternalResources("render-project-to-html-external_{0}.html", "page_{0}/resource_{0}_{1}", "page_{0}/resource_{0}_{1}");
            viewer.View(viewOptions);
        }
    }
}
