---
id: add-text-watermark
url: viewer/net/add-text-watermark
title: Add text watermark
weight: 1
description: "This article explains how to add text watermark when viewing documents with GroupDocs.Viewer within your .NET applications."
keywords: Add watermark with GroupDocs.Viewer for .NET API
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer enables you to add a watermark the output HTML/JPG/PNG/PDF.

Here is the recipe:

* Create instance of [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) class (or [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions), or [JpgViewOption](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions), or [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions));
* Create a [Watermark](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/watermark) object and populate its properties;
* Assign [Watermark](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/watermark) object to [HtmlViewOptions.Watermark](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/viewoptions/properties/watermark) (or [PngViewOptions.Watermark](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/viewoptions/properties/watermark), or [JpgViewOptions.](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/viewoptions/properties/watermark)[Watermark](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions), or [PdfViewOptions.Watermark](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/viewoptions/properties/watermark)) property;
* Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method.

The following code sample shows how to apply the watermark to the output pages.

```csharp
using (Viewer viewer = new Viewer("sample.docx"))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewOptions.Watermark = new Watermark("This is a watermark");
                
    viewer.View(viewOptions);
}
```

## More resources

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
