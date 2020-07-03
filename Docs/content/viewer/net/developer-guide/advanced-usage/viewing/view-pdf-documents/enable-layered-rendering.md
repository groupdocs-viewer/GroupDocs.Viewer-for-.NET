---
id: enable-layered-rendering
url: viewer/net/enable-layered-rendering
title: Enable layered rendering
weight: 4
description: "This article explains how to enable layered rendering when viewing PDF Documents with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
When rendering into HTML GroupDocs.Viewer renders text and graphics as a single layer that improves performance and reduces HTML document size. To improve content positioning wen rendering multi-layered PDF document GroupDocs.Viewer provides [EnableLayeredRendering](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfoptions/properties/enablelayeredrendering) option that enables rendering of text and graphics according to z-order in original PDF document when rendering into HTML.

{{< alert style="info" >}}This option is supported when rendering to HTML only.{{< /alert >}}

Following code sample demonstrates how to enable layered rendering.

```csharp
            using (Viewer viewer = new Viewer("sample.pdf"))
            {
                HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
                viewOptions.PdfOptions.EnableLayeredRendering = true;
                
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