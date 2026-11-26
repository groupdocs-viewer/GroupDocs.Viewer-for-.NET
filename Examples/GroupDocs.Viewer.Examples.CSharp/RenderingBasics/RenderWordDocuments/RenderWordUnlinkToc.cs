namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWordDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWordUnlinkToc
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("handbook.docx"))
        {
            // Convert the document to HTML.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources();
            // Unlink table of contents.
            viewOptions.WordProcessingOptions.UnlinkTableOfContents = true;
            viewer.View(viewOptions);
        }
    }
}
