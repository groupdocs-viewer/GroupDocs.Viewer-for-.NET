namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.SpecifyRenderingOptions;

using System;
using GroupDocs.Viewer.Drawing;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SetBackgroundColor
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.dwg"))
        {
            // Convert the document to PDF.
            var viewOptions = new PdfViewOptions("set-background-color.pdf");

            // Specify the background color.
            viewOptions.CadOptions.BackgroundColor = Argb32Color.Transparent;
            viewer.View(viewOptions);
        }
    }
}
