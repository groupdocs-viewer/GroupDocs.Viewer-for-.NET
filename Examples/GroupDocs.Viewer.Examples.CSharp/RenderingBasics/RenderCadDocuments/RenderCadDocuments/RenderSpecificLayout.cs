namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.RenderCadDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderSpecificLayout
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.dxf"))
        {
           // Convert the document to PDF.
           PdfViewOptions viewOptions = new PdfViewOptions("output.pdf");
           // Specify the name of the layout to render.
           // If the specified layout is not found,
           // an exception occurs.
           viewOptions.CadOptions.LayoutName = "Mezzanine";
           viewer.View(viewOptions);
        }
    }
}
