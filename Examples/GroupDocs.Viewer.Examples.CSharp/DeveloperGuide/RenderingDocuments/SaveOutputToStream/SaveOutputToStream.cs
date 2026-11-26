namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.SaveOutputToStream;

using System.Collections.Generic;
using System.IO;
using GroupDocs.Viewer.Interfaces;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

internal class MemoryPageStreamFactory : IPageStreamFactory
{
    private readonly List<MemoryStream> _pages;

    public MemoryPageStreamFactory(List<MemoryStream> pages)
    {
        _pages = pages;
    }

    public Stream CreatePageStream(int pageNumber)
    {
        MemoryStream pageStream = new MemoryStream();
        _pages.Add(pageStream);
        return pageStream;
    }

    public void ReleasePageStream(int pageNumber, Stream pageStream)
    {
        //Do not release page stream as we'll need to keep the stream open
    }
}

public static class SaveOutputToStream
{
    public static void Run()
    {
        // ...

        // Create the list to store output pages
        List<MemoryStream> pages = new List<MemoryStream>();

        using (Viewer viewer = new Viewer("sample.docx"))
        {
            MemoryPageStreamFactory pageStreamFactory = new MemoryPageStreamFactory(pages);
            ViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources(pageStreamFactory);
            viewer.View(viewOptions);
        }
    }
}
