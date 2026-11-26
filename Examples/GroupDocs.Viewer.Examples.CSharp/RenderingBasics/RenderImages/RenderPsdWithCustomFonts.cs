namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderImages;

using System.IO;
using System;
using GroupDocs.Viewer.Fonts;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderPsdWithCustomFonts
{
    public static void Run()
    {
        // ...

        // Specify a folder that stores custom fonts used in a PSD file.
        System.IO.Directory.CreateDirectory("custom_fonts_folder");
        // SearchOption is named in full: System.IO, which .NET 6+ projects import by default, has one too.
        var fontSource = new FolderFontSource("custom_fonts_folder", GroupDocs.Viewer.Fonts.SearchOption.AllFolders);
        FontSettings.SetFontSources(fontSource);

        using (var viewer = new Viewer("sample.psd"))
        {
            // Convert a PSD file to PNG.
            var viewOptions = new PngViewOptions("output.png");
            // Specify the default font that should be used to replace missing fonts.
            viewOptions.DefaultFontName = "Arial";
            viewer.View(viewOptions);
        }
    }
}
