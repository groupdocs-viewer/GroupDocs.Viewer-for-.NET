---
id: how-to-convert-and-view-cff2-and-cf2-files
url: viewer/net/how-to-convert-and-view-cff2-and-cf2-files
title: How to convert and view CFF2 and CF2 files
weight: 2
description: "This article demonstrates how to convert and view CFF2 and CF2 files with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
CF2 (also CF2, CFF2) is a Common File Format File of revision 2. This file format is designed for exchange of cardboard boxes (goods packaging) drawings. It contains text instructions splitted by sections for the numerical control machine ([NC machine](https://en.wikipedia.org/wiki/Numerical_control)) tool.

## View CF2 files

The CF2 can be opened with desktop applications like e.g. PicView 8.

In case you need to view a CF2 file in a browser or in a standard image or PDF viewer application, you can convert it to HTML, JPEG, PNG  PDF format with GroupDocs.Viewer for .NET. 

![](viewer/net/images/how-to-convert-and-view-cff2-and-cf2-files.png)

### Convert CF2 to HTML

To convert CF2 files to HTML with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.cf2"))
{
       HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("output.html");
       //options.CadOptions = CadOptions.ForRenderingByScaleFactor(0.7f); // Render image and reduce it by 30%
       //options.CadOptions = CadOptions.ForRenderingByWidthAndHeight(400,400); // Render image and set output size to 400x400
       //options.CadOptions = CadOptions.ForRenderingByWidth(500); // Render image, fix width by 500 px and recalculate height
       //options.CadOptions = CadOptions.ForRenderingByHeight(500); // Render image, fix height by 500 px and recalculate width

       viewer.View(options);
}
```

The following screenshot shows the output HTML file opened in a browser.

![](viewer/net/images/how-to-convert-and-view-cff2-and-cf2-files_1.png)

### Convert CF2 to JPG

To convert CF2 files to JPG with GroupDocs.Viewer for .NET use following code: 

```csharp
using (Viewer viewer = new Viewer("sample.cf2"))
{
       JpgViewOptions options = new JpgViewOptions("output.jpg");
       //options.CadOptions = CadOptions.ForRenderingByScaleFactor(0.7f); // Render image and reduce it by 30%
       //options.CadOptions = CadOptions.ForRenderingByWidthAndHeight(400,400); // Render image and set output size to 400x400
       //options.CadOptions = CadOptions.ForRenderingByWidth(500); // Render image, fix width by 500 px and recalculate height
       //options.CadOptions = CadOptions.ForRenderingByHeight(500); // Render image, fix height by 500 px and recalculate width
       viewer.View(options);
}
```

The following screenshot shows the output JPG file opened in a Windows Photo Viewer application.

![](viewer/net/images/how-to-convert-and-view-cff2-and-cf2-files_2.png)

### Convert CF2 to PNG

To convert CF2 files to PNG with GroupDocs.Viewer for .NET use following code: 

```csharp
using (Viewer viewer = new Viewer("sample.cf2"))
{
       PngViewOptions options = new PngViewOptions("output.png");
       //options.CadOptions = CadOptions.ForRenderingByScaleFactor(0.7f); // Render image and reduce it by 30%
       //options.CadOptions = CadOptions.ForRenderingByWidthAndHeight(400,400); // Render image and set output size to 400x400
       //options.CadOptions = CadOptions.ForRenderingByWidth(500); // Render image, fix width by 500 px and recalculate height
       //options.CadOptions = CadOptions.ForRenderingByHeight(500); // Render image, fix height by 500 px and recalculate width
       viewer.View(options);
}
```

The following screenshot shows the output PNG file opened in a Windows Photo Viewer application.

![](viewer/net/images/how-to-convert-and-view-cff2-and-cf2-files_3.png)

### Convert CF2 to PDF

To convert CF2 files to PDF with GroupDocs.Viewer for .NET use following code: 

```csharp
using (Viewer viewer = new Viewer("sample.cf2"))
{
       PdfViewOptions options = new PdfViewOptions("output.pdf");
       //options.CadOptions = CadOptions.ForRenderingByScaleFactor(0.7f); // Render image and reduce it by 30%
       //options.CadOptions = CadOptions.ForRenderingByWidthAndHeight(400,400); // Render image and set output size to 400x400
       //options.CadOptions = CadOptions.ForRenderingByWidth(500); // Render image, fix width by 500 px and recalculate height
       //options.CadOptions = CadOptions.ForRenderingByHeight(500); // Render image, fix height by 500 px and recalculate width
       viewer.View(options);
}
```

The following screenshot shows the output PDF file opened in a browser.

![](viewer/net/images/how-to-convert-and-view-cff2-and-cf2-files_4.png)

## More resources

### View CF2 Drawings Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View CF2 files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/cf2)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)