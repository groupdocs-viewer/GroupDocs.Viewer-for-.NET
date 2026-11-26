namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.RenderCadDocuments;

using System.Collections.Generic;
using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class RenderSpecificLayers
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.dwg"))
        {
            // Convert the document to PDF.
            PdfViewOptions viewOptions = new PdfViewOptions("render-specific-layers.pdf");
            // Specify a list of layers to display.
            viewOptions.CadOptions.Layers = new List<Layer>
            {
                new Layer("WALLS"),
                new Layer("RACKS")
            };
            viewer.View(viewOptions);
        }
    }
}
