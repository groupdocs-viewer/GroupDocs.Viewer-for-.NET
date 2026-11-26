namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderVisioDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderVisioShapesOnly
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("map.vsdx"))
        {
            // Convert the Visio file to PDF.
            var viewOptions = new PdfViewOptions("output.pdf");
            // Render the master shapes only.
            viewOptions.VisioRenderingOptions.RenderFiguresOnly = true;
            // Specify shape width in pixels.
            viewOptions.VisioRenderingOptions.FigureWidth = 200;
            viewer.View(viewOptions);
        }
    }
}
