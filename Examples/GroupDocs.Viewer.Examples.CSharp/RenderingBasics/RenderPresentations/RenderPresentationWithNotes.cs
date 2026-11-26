namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPresentations;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPresentationWithNotes
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pptx"))
        {
            // Convert the presentation to PDF.
            var viewOptions = new PdfViewOptions("render-presentation-with-notes.pdf");
            // Enable speaker notes rendering.
            viewOptions.RenderNotes = true;
            viewer.View(viewOptions);
        }
    }
}
