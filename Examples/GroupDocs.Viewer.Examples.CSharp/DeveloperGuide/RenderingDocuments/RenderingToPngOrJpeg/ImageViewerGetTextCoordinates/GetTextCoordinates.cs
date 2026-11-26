namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPngOrJpeg.ImageViewerGetTextCoordinates;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class GetTextCoordinates
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            // Get the file information and extract it text.
            bool extractText = true;
            ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForPngView(extractText);
            ViewInfo viewInfo = viewer.GetViewInfo(viewInfoOptions);

            // Display the file information and text.
            foreach (Page page in viewInfo.Pages)
            {
                Console.WriteLine($"Page: {page.Number}");
                Console.WriteLine("Text lines/words/characters:");

                foreach (Line line in page.Lines)
                {
                    Console.WriteLine(line);
                    foreach (Word word in line.Words)
                    {
                        Console.WriteLine($"\t{word}");
                        foreach (Character character in word.Characters)
                        {
                            Console.WriteLine($"\t\t{character}");
                        }
                    }
                }
            }
        }
    }
}
