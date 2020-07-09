---
id: load-document-from-stream
url: viewer/net/load-document-from-stream
title: Load document from Stream
weight: 5
description: "This article explains how to load a document from a Stream with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
There might be the case when your document is not physically located on the disk. Instead, you have the document in the form of a stream. In this case, to avoid the overhead of saving stream as a file on disk, GroupDocs.Viewer enables you to render the file streams directly.

The following are the steps to be followed:

*   Specify the method to obtain document stream; 
*   Pass method's name to [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) class constructor.

Following code snippet serves this purpose.

```csharp
public static void LoadDocumentFromStream()
{
   using (Viewer viewer = new Viewer(GetFileStream)) 
    {
    	HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
        viewer.View(viewOptions);
	}         
}

private static Stream GetFileStream() => return File.OpenRead("sample.docx");
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