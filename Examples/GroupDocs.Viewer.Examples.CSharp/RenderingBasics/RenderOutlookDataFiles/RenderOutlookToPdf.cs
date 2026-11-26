namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderOutlookDataFiles;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderOutlookToPdf
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.pst"))
        {
            // Create a PDF file.
            var viewOptions = new PdfViewOptions("output.pdf");
            viewer.View(viewOptions);
        }
    }
}
