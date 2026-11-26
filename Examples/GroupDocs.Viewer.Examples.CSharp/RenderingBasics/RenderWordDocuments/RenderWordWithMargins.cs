namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWordDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWordWithMargins
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.docx"))
        {
            // Create an HTML file for each document page.
            // {0} is replaced with the current page number in the file name.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("render-word-with-margins_{0}.html");
            // Specify the size of page margins in points.
            viewOptions.WordProcessingOptions.TopMargin = 72;
            viewOptions.WordProcessingOptions.BottomMargin = 72;
            viewOptions.WordProcessingOptions.LeftMargin = 54;
            viewOptions.WordProcessingOptions.RightMargin = 54;
            viewer.View(viewOptions);
        }
    }
}
