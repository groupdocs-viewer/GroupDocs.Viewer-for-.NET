---
id: loading-documents-from-different-sources
url: viewer/net/loading-documents-from-different-sources
title: Loading documents from different sources
weight: 4
description: "This article contains document loading use-cases with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer also enables you to render of remotely located documents. The rendering of the document would be similar to [Load document from Stream]({{< ref "viewer/net/developer-guide/advanced-usage/loading/loading-documents-from-different-sources/load-document-from-stream.md" >}}). In order to render a remotely located document, below steps can be followed.

* Specify the method to obtain remotely located document stream;
* Pass method's name to [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) class constructor.

```csharp
public static void LoadDocument()
{
   Stream stream = GetFileStream();
   
   using (Viewer viewer = new Viewer(stream))
   {
       HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
       viewer.View(viewOptions);
   }
}

private static Stream GetFileStream()
{
    //TODO: return the stream
};
```
