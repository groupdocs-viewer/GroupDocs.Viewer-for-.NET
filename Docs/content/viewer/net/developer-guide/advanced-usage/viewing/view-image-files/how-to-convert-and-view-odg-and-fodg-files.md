---
id: how-to-convert-and-view-odg-and-fodg-files
url: viewer/net/how-to-convert-and-view-odg-and-fodg-files
title: How to convert and view ODG and FODG files
weight: 1
description: "This article explains how to convert and view ODG and FODG files with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
FODG and ODG are OpenDocument Graphics formats. ODG consists from archive with set of files (e.g. styles and content in XML files) and [manifest file](https://en.wikipedia.org/wiki/Manifest_file). FODG is Flat OpenDocument Graphics format in uncompessed XML.

These files can be opened with LibreOffice(OpenOffice) draw.

In case you need to view a ODG(FODG) file in a browser or in a standard image or PDF viewer application, you can convert it to HTML, JPEG, PNG  PDF format with GroupDocs.Viewer for .NET. 

![](viewer/net/images/how-to-convert-and-view-odg-and-fodg-files.png)

## How to convert FODG files

### Convert FODG to HTML

To convert FODG files to HTML with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.fodg"))
{
       HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("output.html");

       viewer.View(options);
}
```

The following screenshot shows the output HTML file opened in a browser.

![](viewer/net/images/how-to-convert-and-view-odg-and-fodg-files_1.png)

### Convert FODG to JPG

To convert FODG files to JPG with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.fodg"))
{
       JpgViewOptions options = new JpgViewOptions("output.jpg");

       viewer.View(options);
}
```

The following screenshot shows the output JPG file opened in a Windows Photo Viewer application.

![](viewer/net/images/how-to-convert-and-view-odg-and-fodg-files_2.png)

### Convert FODG to PNG

To convert PLT/HPG files to PNG with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.fodg"))
{
       PngViewOptions options = new PngViewOptions("output.png");

       viewer.View(options);
}
```

The following screenshot shows the output PNG file opened in a Windows Photo Viewer application.

![](viewer/net/images/how-to-convert-and-view-odg-and-fodg-files_3.png)

### Convert FODG to PDF

To convert FODG files to PDF with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.fodg"))
{
       PdfViewOptions options = new PdfViewOptions("output.pdf");

       viewer.View(options);
}
```

The following screenshot shows the output PDF file opened in an Acrobat Reader.

![](viewer/net/images/how-to-convert-and-view-odg-and-fodg-files_4.png)

## More resources

### View FODG/ODG files Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View FODG and ODG files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/image)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)
