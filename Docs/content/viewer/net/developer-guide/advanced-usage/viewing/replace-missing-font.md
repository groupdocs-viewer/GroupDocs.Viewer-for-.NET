---
id: replace-missing-font
url: viewer/net/replace-missing-font
title: Replace missing font
weight: 4
description: "This article explains how to replace missing font when viewing documents with GroupDocs.Viewer within your .NET applications."
keywords: Replace missing font with GroupDocs.Viewer for .NET API
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer enables you to set default font name which may be useful in following cases:

1.  You want to generally specify the default font to fall back on if a particular font in a document cannot be found during rendering;
2.  The document uses a font that contains non-English characters and the you want to make sure that any missing font is replaced with one which has the same character set available.

Following code snippet shows how to set default font name.

```csharp
using (Viewer viewer = new Viewer(@"sample.pptx"))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewOptions.DefaultFontName = "Courier New";
    viewer.View(viewOptions);
}          
```

.

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