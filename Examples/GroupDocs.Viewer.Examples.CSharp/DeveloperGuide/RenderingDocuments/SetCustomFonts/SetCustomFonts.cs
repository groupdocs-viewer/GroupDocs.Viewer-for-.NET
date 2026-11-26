namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.SetCustomFonts;

using GroupDocs.Viewer.Fonts;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class SetCustomFonts
{
    public static void Run()
    {
        // ...

        // Specify the font source: the custom_fonts folder holds Lobster-Regular.ttf.
        // SearchOption is named in full: System.IO, which .NET 6+ projects import by default, has one too.
        FolderFontSource fontSource =
            new FolderFontSource("custom_fonts", GroupDocs.Viewer.Fonts.SearchOption.TopFolderOnly);
        FontSettings.SetFontSources(fontSource);

        using (Viewer viewer = new Viewer("harvest-launch.pptx"))
        {
            // Create an HTML file.
            HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
            viewer.View(viewOptions);
        }
    }
}
