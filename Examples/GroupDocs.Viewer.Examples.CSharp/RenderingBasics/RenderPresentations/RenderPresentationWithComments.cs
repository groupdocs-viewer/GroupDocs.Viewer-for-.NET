namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPresentations;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPresentationWithComments
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("with_comments.pptx"))
        {
            // Convert the presentation to PDF.
            var viewOptions = new PdfViewOptions("render-presentation-with-comments.pdf");
            // Enable comments rendering.
            viewOptions.RenderComments = true;
            viewer.View(viewOptions);
        }
    }
}
