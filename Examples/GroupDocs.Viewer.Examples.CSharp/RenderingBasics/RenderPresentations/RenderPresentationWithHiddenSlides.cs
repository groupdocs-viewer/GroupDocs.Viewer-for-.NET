namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPresentations;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPresentationWithHiddenSlides
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pptx"))
        {
            // Convert the presentation to PDF.
            var viewOptions = new PdfViewOptions("render-presentation-with-hidden-slides.pdf");
            // Enable hidden slides rendering.
            viewOptions.RenderHiddenPages = true;
            viewer.View(viewOptions);
        }
    }
}
