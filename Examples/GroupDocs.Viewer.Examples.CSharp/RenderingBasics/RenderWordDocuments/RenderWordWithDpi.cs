namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderWordDocuments;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderWordWithDpi
{
    public static void Run()
    {
        // ...

        PngViewOptions pngOpt = new PngViewOptions();
        pngOpt.WordProcessingOptions.HorizontalResolution = pngOpt.WordProcessingOptions.VerticalResolution = 192;

        JpgViewOptions jpegOpt = new JpgViewOptions();
        jpegOpt.WordProcessingOptions.VerticalResolution = 120;

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            viewer.View(pngOpt);
            viewer.View(jpegOpt);
        }
    }
}
