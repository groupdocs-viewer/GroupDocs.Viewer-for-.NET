---
id: image-viewer-adjust-image-size
url: viewer/net/image-viewer-adjust-image-size
title: Image Viewer - Adjust image size
weight: 2
description: "Check this guide to learn how to adjust PNG and JPG images size when viewing documents with Image Viewer by GroupDocs for .NET."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
Image Viewer allows you to set custom output image size in pixels through [Width](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions/properties/width) and [Height](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions/properties/height) properties in [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions) and [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions) classes.

Keep in mind that aspect ratio is automatically applied when you set [Width](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions/properties/width) or [Height](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions/properties/height) only.

This example demonstrates how to set output image size

```csharp
using (Viewer viewer = new Viewer("sample.docx"))
{
    JpgViewOptions viewOptions = new JpgViewOptions();
    viewOptions.Width = 600;
    viewOptions.Height = 800;
    
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
