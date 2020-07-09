---
id: how-to-get-an-output-stream-when-viewing-a-document
url: viewer/net/how-to-get-an-output-stream-when-viewing-a-document
title: How to get an output stream when viewing a document
weight: 1
description: "This article explains how to get an output stream when viewing a document with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
By default GroupDocs.Viewer saves output results to the local disk but we also provide a way to save output results into a stream. 

There are three interfaces that we can utilize:

*   [IFileStreamFactory](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.interfaces/ifilestreamfactory) - defines the methods that are required for instantiating and releasing output file stream.
*   [IPageStreamFactory](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.interfaces/ipagestreamfactory) - defines the methods that are required for instantiating and releasing output page stream.
*   [IResourceStreamFactory](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.interfaces/iresourcestreamfactory) - defines the methods that are required for creating resource URL, instantiating and releasing output HTML resource stream.

Let's say that instead of saving rendering results to the local disk we want to have all the output file or output files in form of stream or list of streams.

What we need to do is to implement one or two of the interfaces listed above. 

*   When rendering into PDF we have to implement [IFileStreamFactory](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.interfaces/ifilestreamfactory) interface and pass implementation into [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions) constructor
*   When rendering into JPG/PNG or HTML with embedded resources we have to implement [IPageStreamFactory](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.interfaces/ipagestreamfactory) interface and pass implementation into [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions)/[PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions) constructor or [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) [ForEmbeddedResources](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options.htmlviewoptions/forembeddedresources/methods/3) factory method
*   When rendering into HTML with external resources we have to implement [IPageStreamFactory](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.interfaces/ipagestreamfactory) and [IResourceStreamFactory](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.interfaces/iresourcestreamfactory) interfaces and pass implementation into [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions)/[PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions) constructor or [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) [ForExternalResources](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options.htmlviewoptions/forexternalresources/methods/3) factory method

In this example, we'll render into HTML with embedded resources so we need to implement only [IPageStreamFactory](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.interfaces/ipagestreamfactory) interface.

```csharp
// Create the list to store output pages
List<MemoryStream> pages = new List<MemoryStream>();

using (Viewer viewer = new Viewer("sample.docx"))
{
    MemoryPageStreamFactory pageStreamFactory = new MemoryPageStreamFactory(pages);

    ViewOptions viewOptions =
        HtmlViewOptions.ForEmbeddedResources(pageStreamFactory);

    viewer.View(viewOptions);
}
 
// 
 
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
```

## More resources
### GitHub Examples
You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)    
*   [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)    
*   [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)     
*   [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)    
*   [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)    
*   [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)

### Free Online App
Along with full-featured .NET library we provide simple but powerful free Apps.
You are welcome to view Word, PDF, Excel, PowerPoint documents with free to use online **[GroupDocs Viewer App](https://products.groupdocs.app/viewer)**.
