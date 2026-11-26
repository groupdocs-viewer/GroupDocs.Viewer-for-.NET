namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderMsProjectFiles;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderProjectToHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.mpp"))
        {
            // Render the project's active view as HTML.
            // {0} is replaced with the current page number in the output file names.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("render-project-to-html_{0}.html");
            viewer.View(viewOptions);
        }
    }
}
