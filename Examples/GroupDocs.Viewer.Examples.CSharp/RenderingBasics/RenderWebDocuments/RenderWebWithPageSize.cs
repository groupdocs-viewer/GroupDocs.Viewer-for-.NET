namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWebDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWebWithPageSize
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("groupdocs-documentation.mhtml"))
        {
            // Convert the document to PDF.
            var viewOptions = new PdfViewOptions("output.pdf");
            // Specify the page size.
            viewOptions.WebDocumentOptions.PageSize = PageSize.A3;
            viewer.View(viewOptions);
        }
    }
}
