---
id: how-to-convert-and-view-svg-and-svgz-files
url: viewer/net/how-to-convert-and-view-svg-and-svgz-files
title: How to convert and view SVG and SVGZ files
weight: 1
description: "This article explains how to convert and view SVG and SVGZ files with GroupDocs.Viewer within your .NET applications."
keywords: svg svgz convert and view SVG and SVGZ with GroupDocs.Viewer .NET API
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
SVG and SVGZ are Scalable Vector Graphics formats. SVG is a Flat Scalable Vector Graphics format in uncompressed XML.
SVGZ consists of a GZIPped archive with one traditional SVG file.

These files can be opened with Adobe Illustrator, Corel PaintShop Pro, Serif DrawPlus, and Inkscape.

In case you need to view an SVG(SVGZ) file in a browser or in a standard image or PDF viewer application, you can convert it to HTML, JPEG, PNG PDF format with GroupDocs.Viewer for .NET.

![Image in desktop program](viewer/net/images/how-to-convert-and-view-svg-and-svgz-files/main.jpg)

## How to convert SVG/SVGZ files

### Convert SVG/SVGZ to HTML

To convert SVG/SVGZ files to HTML with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.svgz"))
{
       HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("output.html");

       viewer.View(options);
}
```

The following screenshot shows the output HTML file opened in a browser.

![Result in browser](viewer/net/images/how-to-convert-and-view-svg-and-svgz-files/result-in-browser.jpg)

### Convert SVG/SVGZ to JPG

To convert SVG/SVGZ files to JPG with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.svgz"))
{
       JpgViewOptions options = new JpgViewOptions("output.jpg");

       viewer.View(options);
}
```

The following screenshot shows the output JPG file opened in a Windows Photo Viewer application.

![Result in JPG](viewer/net/images/how-to-convert-and-view-svg-and-svgz-files/result-jpg.jpg)

### Convert SVG/SVGZ to PNG

To convert PLT/HPG files to PNG with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.svgz"))
{
       PngViewOptions options = new PngViewOptions("output.png");

       viewer.View(options);
}
```

The following screenshot shows the output PNG file opened in a Windows Photo Viewer application.

![Result in PNG](viewer/net/images/how-to-convert-and-view-svg-and-svgz-files/result-png.jpg)

### Convert SVG/SVGZ to PDF

To convert SVGZ files to PDF with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.svgz"))
{
       PdfViewOptions options = new PdfViewOptions("output.pdf");

       viewer.View(options);
}
```

The following screenshot shows the output PDF file opened in an Acrobat Reader.

![Result in PDF](viewer/net/images/how-to-convert-and-view-svg-and-svgz-files/result-pdf.jpg)

## More resources

### View SVG/SVGZ files Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View SVG and SVGZ files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/image)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)