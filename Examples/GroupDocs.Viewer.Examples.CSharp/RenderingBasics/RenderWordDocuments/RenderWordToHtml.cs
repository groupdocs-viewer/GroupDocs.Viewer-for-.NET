namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWordDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWordToHtml
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.docx"))
        {
            // Create an HTML file for each document page.
            // {0} is replaced with the current page number in the file name.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("page_{0}.html");
            viewer.View(viewOptions);
        }
    }
}
