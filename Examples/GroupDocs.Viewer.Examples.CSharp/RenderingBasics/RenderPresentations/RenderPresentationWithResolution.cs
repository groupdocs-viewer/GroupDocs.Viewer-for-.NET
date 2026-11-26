namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPresentations;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPresentationWithResolution
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pptx"))
        {
            // Convert the presentation to PDF.
            var viewOptions = new PdfViewOptions("output.pdf");
            // Specify resolution.
            viewOptions.PresentationOptions.Resolution = Resolution.Dpi150;
            viewer.View(viewOptions);
        }
    }
}
