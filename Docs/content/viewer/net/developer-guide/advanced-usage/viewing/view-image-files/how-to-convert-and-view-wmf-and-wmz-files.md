---
id: how-to-convert-and-view-wmf-and-wmz-files
url: viewer/net/how-to-convert-and-view-wmf-and-wmz-files
title: How to convert and view WMF and WMZ files
weight: 1
description: "This article explains how to convert and view WMF and WMZ files with GroupDocs.Viewer within your .NET applications."
keywords: WMF WMZ convert rendering
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
WMF and WMZ are Windows Metafile graphics formats developed by Microsoft. These formats may contain both vector and raster images, but they are primarily used for vector images.
WMF is Windows MetaFile Format - it contains Windows MetaFile binary data.
WMZ is Windows Metafile Zipped format - it also contains Windows MetaFile binary data but compressed with GZIP.

WMF files can be opened with Microsoft Paint, Adobe Illustrator, InkScape.
WMZ files can be opened with the same applications but should be unpacked before open.

These file formats are part of a series of Windows Metafile formats:

Windows Metafile formats:
WMF - Windows Metafile Format
WMZ - Windows Metafile Compressed (GZipped) Format

Windows Metafile Enhanced formats:
EMF - Windows Metafile Enhanced Format
EMZ - Windows Metafile Enhanced Compressed (GZipped) Format
See [How to convert and view EMF and EMZ files]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-image-files/how-to-convert-and-view-emf-and-emz-files.md" >}})

In case you need to view a WMF(WMZ) file in a browser or a standard image or PDF viewer application, you can convert it to HTML, JPEG, PNG  PDF format with GroupDocs.Viewer for .NET.

![WMF and WMZ](viewer/net/images/how-to-convert-and-view-wmf-and-wmz-files/sample.jpg)

## How to convert WMZ files

### Convert WMZ to HTML

To convert WMZ files to HTML with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.WMZ"))
{
       HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("output.html");

       viewer.View(options);
}
```

\
The following screenshot shows the output HTML file opened in a browser.

![WMF/WMZ in HTML](viewer/net/images/how-to-convert-and-view-wmf-and-wmz-files/html.jpg)

### Convert WMZ to JPG

To convert WMZ files to JPG with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.WMZ"))
{
       JpgViewOptions options = new JpgViewOptions("output.jpg");

       viewer.View(options);
}
```

\
The following screenshot shows the output JPG file opened in a Windows Photo Viewer application.

![WMF/WMZ in JPG](viewer/net/images/how-to-convert-and-view-wmf-and-wmz-files/jpg.jpg)

### Convert WMZ to PNG

To convert PLT/HPG files to PNG with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.WMZ"))
{
       PngViewOptions options = new PngViewOptions("output.png");

       viewer.View(options);
}
```

\
The following screenshot shows the output PNG file opened in a Windows Photo Viewer application.

![WMF/WMZ in PNG](viewer/net/images/how-to-convert-and-view-wmf-and-wmz-files/png.jpg)

### Convert WMZ to PDF

To convert WMZ files to PDF with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.WMZ"))
{
       PdfViewOptions options = new PdfViewOptions("output.pdf");

       viewer.View(options);
}
```

\
The following screenshot shows the output PDF file opened in an Acrobat Reader.

![WMF/WMZ in PDF](viewer/net/images/how-to-convert-and-view-wmf-and-wmz-files/pdf.jpg)

## More resources

### View WMF/WMZ files Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View WMF and WMZ files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/image)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)
