namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.RenderCadDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderAllLayouts
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.dxf"))
        {
           // Convert the document to PDF.
           PdfViewOptions viewOptions = new PdfViewOptions("render-all-layouts.pdf");
           // Render the Model and all non-empty paper space layouts. 
           viewOptions.CadOptions.RenderLayouts = true;
           viewer.View(viewOptions);
        }
    }
}
