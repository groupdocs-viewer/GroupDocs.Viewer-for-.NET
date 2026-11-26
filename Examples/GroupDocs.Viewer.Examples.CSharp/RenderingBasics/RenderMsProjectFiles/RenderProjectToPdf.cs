namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderMsProjectFiles;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderProjectToPdf
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.mpp"))
        {
            // Create a PDF file for the project's active view.
            var viewOptions = new PdfViewOptions("output.pdf");
            viewer.View(viewOptions);
        }
    }
}
