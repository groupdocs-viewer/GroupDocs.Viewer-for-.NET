using System;
using System.IO;
using GroupDocs.Viewer.Fonts;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.CommonRenderingOptions
{
    /// <summary>
    /// This example demonstrates how to add custom fonts to use when rendering documents.
    /// </summary>
    class RenderWithCustomFonts
    {
        public static void Run()
        {            
            FontSettings.SetFontSources(
                new FolderFontSource(Constants.FontsPath, Fonts.SearchOption.TopFolderOnly));                       
            
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(Constants.MISSING_FONT_ODG))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
