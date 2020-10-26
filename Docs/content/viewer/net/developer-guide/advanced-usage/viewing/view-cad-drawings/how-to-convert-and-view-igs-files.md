---
id: how-to-convert-and-view-igs-files
url: viewer/net/how-to-convert-and-view-igs-files
title: How to convert and view IGS files
weight: 3
description: "This article demonstrates how to convert and view IGS files with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
IGS is a 2D/3D vector format file based on the Initial Graphics Exchange Specification (IGES). It consists of text instructions and all lines are fixed 80 bytes length with 72 bytes of data.

It can be opened with desktop applications like e.g. Autodesk AutoCAD.

In case you need to view an IGS file in a browser or in a standard image or PDF viewer application, you can convert it to HTML, JPEG, PNG  PDF format with GroupDocs.Viewer for .NET.

## How to convert IGS files

### Convert IGS to HTML

To convert IGS files to HTML with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.igs"))
{
    HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("output.html");
    viewer.View(options);
}
```

The following screenshot shows the output HTML file opened in a browser.

![](viewer/net/images/how-to-convert-and-view-igs-files.png)

### Convert IGS to JPG

To convert IGS files to JPG with GroupDocs.Viewer for .NET use following code: 

```csharp
using (Viewer viewer = new Viewer("sample.igs"))
{
       JpgViewOptions options = new JpgViewOptions("output.jpg");
	viewer.View(options);
}
```

The following screenshot shows the output JPG file opened in a Windows Photo Viewer application.

![](viewer/net/images/how-to-convert-and-view-igs-files_1.png)

### Convert IGS to PNG

To convert IGS files to PNG with GroupDocs.Viewer for .NET use following code: 

```csharp
using (Viewer viewer = new Viewer("sample.igs"))
{
       PngViewOptions options = new PngViewOptions("output.png");
       viewer.View(options);
}
```

The following screenshot shows the output PNG file opened in a Windows Photo Viewer application.

![](viewer/net/images/how-to-convert-and-view-igs-files_2.png)

### Convert IGS to PDF

To convert IGS files to PDF with GroupDocs.Viewer for .NET use following code: 

```csharp
using (Viewer viewer = new Viewer("sample.igs"))
{
       PdfViewOptions options = new PdfViewOptions("output.pdf");
       viewer.View(options);
}
```

The following screenshot shows the output PDF file opened in an Acrobat Reader.

![](viewer/net/images/how-to-convert-and-view-igs-files_3.png)

## More resources

### View CAD Drawings Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View DXF, DWG, and DWF files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/cad)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)
