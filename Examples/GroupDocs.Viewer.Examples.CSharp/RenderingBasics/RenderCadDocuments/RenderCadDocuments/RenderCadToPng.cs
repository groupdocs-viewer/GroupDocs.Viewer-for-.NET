namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.RenderCadDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderCadToPng
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.dwg"))
        {
            // Create a PNG image for the drawing.
            PngViewOptions viewOptions = new PngViewOptions("output.png");
            // Set width and height.
            viewOptions.Width = 1500;
            viewOptions.Height = 1000;
            viewer.View(viewOptions);
        }
    }
}
