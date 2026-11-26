namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderEmailMessages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderEmailWithPageSize
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.eml"))
        {
            // Create a PDF file.
            var viewOptions = new PdfViewOptions("output.pdf");
            // Specify the page size.
            viewOptions.EmailOptions.PageSize = PageSize.A4;
            viewer.View(viewOptions);
        }
    }
}
