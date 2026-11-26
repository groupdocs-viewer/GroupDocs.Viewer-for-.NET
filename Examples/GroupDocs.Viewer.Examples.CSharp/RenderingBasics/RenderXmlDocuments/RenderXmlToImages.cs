namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderXmlDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderXmlToImages
{
    public static void Run()
    {
        PngViewOptions pngOptions = new PngViewOptions("page-{0}.png");
        JpgViewOptions jpegOptions = new JpgViewOptions("page-{0}.jpeg");
        jpegOptions.Quality = 80; // setting output JPEG quality explicitly

        string inputXmlDocument = "sample.xml";
        using (Viewer viewer = new Viewer(inputXmlDocument))
        {
            viewer.View(pngOptions);
            viewer.View(jpegOptions);
        }
    }
}
