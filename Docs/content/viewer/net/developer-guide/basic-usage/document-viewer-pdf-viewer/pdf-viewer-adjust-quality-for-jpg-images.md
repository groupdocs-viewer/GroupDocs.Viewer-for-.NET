---
id: pdf-viewer-adjust-quality-for-jpg-images
url: viewer/net/pdf-viewer-adjust-quality-for-jpg-images
title: PDF Viewer - Adjust quality for JPG images
weight: 1
description: "Check this guide and learn how to adjust JPG images quality and size when displaying documents with PDF Viewer by GroupDocs."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
When rendering documents to PDF format that contains JPG images it may be reasonable to reduce size of the output file by adjusting quality of the JPG images. GroupDocs.Viewer enables you to adjust quality of images in the output PDF document with [JpgQuality](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions/properties/jpgquality) setting of [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions) class. The supported values range of [JpgQuality](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions/properties/jpgquality) is from 1 to 100. Default value is 90.

The following steps are to be followed in order to set image quality.

* Initialize the object of [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions);
* Set [PdfViewOptions.JpgQuality](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions/properties/jpgquality) value;
* Pass [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions) object to *View* function.

The following code sample shows how to adjust JPG image quality in the output PDF document.

```csharp
using (Viewer viewer = new Viewer("sample.docx"))
{               
    PdfViewOptions viewOptions = new PdfViewOptions();
    viewOptions.JpgQuality = 50;
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
