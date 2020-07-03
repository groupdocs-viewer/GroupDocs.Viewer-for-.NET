---
id: adjust-image-quality
url: viewer/net/adjust-image-quality
title: Adjust image quality
weight: 1
description: "This article explains how to adjust image quality when viewing PDF Documents with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer enables you to adjust quality of output images contained by the source PDF document. To adjust image quality use [PdfOptions.ImageQuality](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfoptions/properties/imagequality)option of [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) class.

[PdfOptions.ImageQuality](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfoptions/properties/imagequality) can be set to:

*   *Low* - The acceptable quality, best performance and least size of the output image.
*   *Medium* - Better quality and slower performance.
*   *High* - Best quality but slow performance.

NOTE: this option is supported when rendering to HTML only.

Following code snippet shows how to adjust image quality when rendering to HTML.

```csharp
            using (Viewer viewer = new Viewer("sample.docx"))
            {
                HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
                viewOptions.PdfOptions.ImageQuality = ImageQuality.Medium;
                               
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