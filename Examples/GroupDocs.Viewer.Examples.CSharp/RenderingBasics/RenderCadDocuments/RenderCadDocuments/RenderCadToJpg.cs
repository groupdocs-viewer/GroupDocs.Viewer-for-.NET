namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.RenderCadDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderCadToJpg
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.dwg"))
        {
            // Create a JPG image for the drawing.
            JpgViewOptions viewOptions = new JpgViewOptions("output.jpg");
            // Set width and height.
            viewOptions.Width = 1500;
            viewOptions.Height = 1000;
            viewer.View(viewOptions);
        }
    }
}
