namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderPdfDocuments;

using GroupDocs.Viewer.Fonts;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderOfdDocument
{
    public static void Run()
    {
        // ...

        //Put a SimSun.ttf to folder
        string SimSunFolderPath = "full-valid-path\folder-with-SimSun-inside";
        FolderFontSource fontSource = new FolderFontSource(SimSunFolderPath, SearchOption.TopFolderOnly);
        FontSettings.SetFontSources(fontSource);

        using (Viewer viewer = new Viewer("input.ofd"))
        {
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources("render-ofd-document_{0}.html");
            viewer.View(viewOptions);
        }
    }
}
