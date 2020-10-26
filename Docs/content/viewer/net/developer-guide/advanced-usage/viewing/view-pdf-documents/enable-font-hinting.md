---
id: enable-font-hinting
url: viewer/net/enable-font-hinting
title: Enable font hinting
weight: 3
description: "This article explains how to enable font hinting when viewing PDF Documents with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
To adjust the display of an outline font ([learn more about font hinting](https://en.wikipedia.org/wiki/Font_hinting)) when rendering PDF documents into image GroupDocs.Viewer provides [PdfOptions.EnableFontHinting](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfoptions/properties/enablefonthinting) setting as shown below:

NOTE: this option is supported when rendering into PNG and JPG.

```csharp
using (Viewer viewer = new Viewer("sample.pdf"))
{
    PngViewOptions viewOptions = new PngViewOptions();
    viewOptions.PdfOptions.EnableFontHinting = true;

    viewer.View(viewOptions);
}
```

## More resources

### View PDF Documents Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View PDF files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/pdf)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)

