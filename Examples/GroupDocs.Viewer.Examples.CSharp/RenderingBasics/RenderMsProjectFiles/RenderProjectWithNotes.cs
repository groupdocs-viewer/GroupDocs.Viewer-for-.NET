namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderMsProjectFiles;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderProjectWithNotes
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.mpp"))
        {
            // Convert the document to PDF.
            var viewOptions = new PdfViewOptions("output.pdf");
            // Enable notes rendering.
            viewOptions.RenderNotes = true;
            viewer.View(viewOptions);
        }
    }
}
