---
id: rendering-pages-to-the-same-size-as-the-size-of-pages-in-a-source-document
url: viewer/net/rendering-pages-to-the-same-size-as-the-size-of-pages-in-a-source-document
title: Rendering pages to the same size as the size of pages in a source document
weight: 6
description: "This article explains how to set the output image size to be the same as the page size of a PDF Document with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This option is supported when rendering to JPG and PNG only.{{< /alert >}}

![](viewer/net/images/rendering-pages-to-the-same-size-as-the-size-of-pages-in-a-source-document.png)

When viewing PDF documents in JPG and PNG formats by default GroupDocs.Viewer calculates output image size for better viewing quality. In case you want to make output JPG and PNG images to be the same size in pixels as the size of pages in a source PDF document GropDocs.Viewer provides a new option called [RenderOriginalPageSize](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfoptions/properties/renderoriginalpagesize) of the [PdfOptions ](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfoptions) class. 

The following code snippet shows how to convert pages to the same size as the size of pages in a source document ([This example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/blob/master/Examples/GroupDocs.Viewer.Examples.CSharp/AdvancedUsage/Rendering/RenderingOptionsByDocumentType/RenderingPdfDocuments/RenderOriginalPageSize.cs) can be also found in our public [GitHub repository](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET).)

```csharp
using (Viewer viewer = new Viewer("sample.pdf"))
{
    PngViewOptions viewOptions = new PngViewOptions();
    viewOptions.PdfOptions.RenderOriginalPageSize = true;

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
