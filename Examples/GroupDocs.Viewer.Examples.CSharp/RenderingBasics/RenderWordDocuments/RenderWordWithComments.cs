namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWordDocuments;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWordWithComments
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("with_comment.docx"))
        {
            // Convert the document to PDF.
            var viewOptions = new PdfViewOptions("render-word-with-comments.pdf");
            // Enable comments rendering.
            viewOptions.RenderComments = true;
            viewer.View(viewOptions);
        }
    }
}
