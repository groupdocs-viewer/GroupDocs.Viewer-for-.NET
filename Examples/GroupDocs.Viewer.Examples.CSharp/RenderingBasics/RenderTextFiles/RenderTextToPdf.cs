namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderTextFiles;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderTextToPdf
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("terms_of_service.txt"))
        {
            // Convert the text file to PDF.
            var viewOptions = new PdfViewOptions("output.pdf");
            viewer.View(viewOptions);
        }
    }
}
