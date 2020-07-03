---
id: show-document-notes
url: viewer/net/show-document-notes
title: Show document notes
weight: 7
description: "This article explains how to show notes when viewing documents with GroupDocs.Viewer within your .NET applications."
keywords: Show notes when viewer documents with GroupDocs.Viewer .NET API
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer does not include notes in the rendering results. However, you can choose between to show or hide the notes in the output. If you want to see notes in your rendering result, use [RenderNotes](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/baseviewoptions/properties/rendernotes) property of the [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) (or [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions), or [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions), or [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions)) class and pass it to [Viewer 's](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) object [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method. 

![](viewer/net/images/show-document-notes.png)

The following are the steps to include the notes in the rendering result.

*   Initialize the object of [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions)
*   Set [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) object[RenderNotes](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/baseviewoptions/properties/rendernotes) property to *true*
*   Pass [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) object to [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method

The following code sample renders Presentation with notes.

```csharp
using (Viewer viewer = new Viewer("sample.pptx"))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewOptions.RenderNotes = true;
    viewer.View(viewOptions);
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