using GroupDocs.Viewer.Fonts;
using GroupDocs.Viewer.Options;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Rendering.CommonRenderingOptions
{
    /// <summary>
    /// This example demonstrates how to add custom fonts to use when rendering documents.
    /// </summary>
    class RenderWithCustomFonts
    {
        public static void Run()
        {
            string fontsPath;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                fontsPath = Utils.FontsPath;
            }
            else
            {
                var assembly = System.Reflection.Assembly.GetEntryAssembly();
                var entryAssemblyDirectory = Path.GetDirectoryName(assembly.Location);
                fontsPath = Path.Combine(entryAssemblyDirectory, Utils.FontsPath);
            }

            FontSettings.SetFontSources(
                new FolderFontSource(fontsPath, Fonts.SearchOption.TopFolderOnly));

            string outputDirectory = Utils.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");

            using (Viewer viewer = new Viewer(TestFiles.MISSING_FONT_ODG))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
