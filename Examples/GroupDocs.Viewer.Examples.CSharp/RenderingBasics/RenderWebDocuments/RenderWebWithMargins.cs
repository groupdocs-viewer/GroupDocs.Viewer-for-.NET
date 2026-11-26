namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWebDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWebWithMargins
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("groupdocs-documentation.mhtml"))
        {
            // Convert the document to PDF.
            var viewOptions = new PdfViewOptions("output.pdf");
            // Specify the size of page margins in points.
            viewOptions.WebDocumentOptions.LeftMargin = 40;
            viewOptions.WebDocumentOptions.RightMargin = 40;
            viewOptions.WebDocumentOptions.TopMargin = 40;
            viewOptions.WebDocumentOptions.BottomMargin = 40;
            viewer.View(viewOptions);
        }
    }
}
