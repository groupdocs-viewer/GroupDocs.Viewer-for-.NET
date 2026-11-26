namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderArchives;

using System.IO;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderArchiveToImages
{
    public static void Run()
    {
        // ...

        string pngFolderPath = Directory.CreateDirectory("PNG").FullName;
        string jpegFolderPath = Directory.CreateDirectory("JPEG").FullName;

        PngViewOptions pngOptions = new PngViewOptions(Path.Combine(pngFolderPath, "page-{0}.png"));
        JpgViewOptions jpegOptions = new JpgViewOptions(Path.Combine(jpegFolderPath, "page-{0}.jpeg"));

        using (Viewer viewer = new Viewer("documents.zip"))
        {
            viewer.View(pngOptions);
            viewer.View(jpegOptions);
        }
    }
}
