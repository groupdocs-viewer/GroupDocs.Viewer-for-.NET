namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWordDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWordWithTrackedChanges
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("with_tracked_changes.docx"))
        {
            // Convert the document to PDF.
            var viewOptions = new PdfViewOptions("render-word-with-tracked-changes.pdf");
            // Enable tracked changes rendering.
            viewOptions.WordProcessingOptions.RenderTrackedChanges = true;
            viewer.View(viewOptions);
        }
    }
}
