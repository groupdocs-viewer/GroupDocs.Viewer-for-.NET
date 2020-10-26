---
id: how-to-convert-and-view-fodp-and-odp-files
url: viewer/net/how-to-convert-and-view-fodp-and-odp-files
title: How to convert and view FODP and ODP files
weight: 2
description: "In this article we show how to convert and view FODP and ODP files with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
FODP is Flat Open Document Presentation in XML format for presentations. It can be opened with LibreOffice (OpenOffice) Impress.

ODP is Open Document Presentation too, but it formatted using the OASIS XML-based OpenDocument standard and consists of an archive with a set of files and a [manifest](https://en.wikipedia.org/wiki/Manifest_file) file. 

![](viewer/net/images/how-to-convert-and-view-fodp-and-odp-files.png)

## How to convert FODP(ODP) files

### Convert FODP(ODP) to HTML

To convert FODP(ODP) files to HTML with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.fodp"))
{
       HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("output.html");
       viewer.View(options);
}
```

The following screenshot shows the output HTML file opened in a browser.

![](viewer/net/images/how-to-convert-and-view-fodp-and-odp-files_1.png)

### Convert FODP(ODP) to JPG

To convert FODP(ODP) files to JPG with GroupDocs.Viewer for .NET use following code: 

```csharp
using (Viewer viewer = new Viewer("sample.fodp"))
{
       JpgViewOptions options = new JpgViewOptions("output.jpg");
       viewer.View(options);
}
```

The following screenshot shows the output JPG file opened in a Windows Photo Viewer application.

![](viewer/net/images/how-to-convert-and-view-fodp-and-odp-files_2.png)

### Convert FODP(ODP) to PNG

To convert FODP(ODP) files to PNG with GroupDocs.Viewer for .NET use following code: 

```csharp
using (Viewer viewer = new Viewer("sample.fodp"))
{
       PngViewOptions options = new PngViewOptions("output.png");
       viewer.View(options);
}
```

The following screenshot shows the output PNG file opened in a Windows Photo Viewer application.

![](viewer/net/images/how-to-convert-and-view-fodp-and-odp-files_3.png)

### Convert FODP(ODP) to PDF

To convert FODP(ODP) files to PDF with GroupDocs.Viewer for .NET use following code: 

```csharp
using (Viewer viewer = new Viewer("sample.fodp"))
{
       PdfViewOptions options = new PdfViewOptions("output.pdf");
       viewer.View(options);
}
```

The following screenshot shows the output PDF file opened in an Acrobat Reader.

![](viewer/net/images/how-to-convert-and-view-fodp-and-odp-files_4.png)

## More resources

### View PowerPoint Files Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View PPT, PPTX, and ODP presentations online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/powerpoint)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)