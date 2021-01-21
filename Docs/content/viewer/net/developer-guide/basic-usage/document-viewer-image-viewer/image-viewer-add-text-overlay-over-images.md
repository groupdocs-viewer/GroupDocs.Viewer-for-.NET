---
id: image-viewer-add-text-overlay-over-images
url: viewer/net/image-viewer-add-text-overlay-over-images
title: Image Viewer - Add text overlay over images
weight: 1
description: "Implement selectable text and text search features by adding text overlay over document page images with GroupDocs.Viewer component."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer provides feature that allows to add text overlays over images. This feature is useful if you want to add selectable text over the image or implement a text search in image-based rendering.

**Please note** that due to Image Viewer's architecture rendering results with text extraction enabled and disabled are different.

The [ExtractText](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions/properties/extracttext) property of [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions) (or [ExtractText ](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions/properties/extracttext) property of [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions)) class enables you to render document to display with text.

This example demonstrates how to render document for display with text.

```csharp
using (Viewer viewer = new Viewer("sample.docx"))
{
    PngViewOptions viewOptions = new PngViewOptions();
    viewOptions.ExtractText = true;
    viewer.View(viewOptions);
}
```

## More resources

### Advanced Usage Topics

To learn more about document viewing features, please refer to the [advanced usage section]({{< ref "viewer/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:
* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)

### Free Online App

Along with full-featured .NET library we provide simple but powerful free Apps.
You are welcome to view Word, PDF, Excel, PowerPoint documents with free to use online **[GroupDocs Viewer App](https://products.groupdocs.app/viewer)**.
