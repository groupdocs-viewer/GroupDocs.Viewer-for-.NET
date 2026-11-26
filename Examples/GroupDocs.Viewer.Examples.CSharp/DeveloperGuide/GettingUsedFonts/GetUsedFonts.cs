namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.GettingUsedFonts;

using System.IO;
using System;
using GroupDocs.Viewer.Fonts;
using GroupDocs.Viewer;

public static class GetUsedFonts
{
    public static void Run()
    {
        // ...

        const string filename = "sample.docx";
        string inputPath = Path.GetFullPath(filename);

        using (Viewer viewer = new Viewer(inputPath))
        {
            IFontInfo[] allFonts = viewer.GetAllFonts();
            Console.WriteLine("{0} fonts found in the '{1}' document", allFonts.Length, filename);
            foreach (IFontInfo font in allFonts)
            {
                Console.WriteLine("Font '{0}' of {1} style has {2} bytes and is of {3} format",
                    font.FamilyName,
                    font.Style,
                    font.Content.Length,
                    font.Format);
            }
        }
    }
}
