---
id: how-to-convert-and-view-cdr-files
url: viewer/net/how-to-convert-and-view-cdr-files
title: How to convert and view CDR files
weight: 1
description: "This article explains how to convert and view CDR files with GroupDocs.Viewer within your .NET applications."
keywords: corel coreldraw corel draw cdr convert rendering
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
CDR is a Corel Image File format developed by Corel. This format contains vector image data.

CDR files can be opened with Corel Draw, Corel PaintShop, Adobe Illustrator, InkScape. CDR files may contain multiple images, you can set what images to render (see examples).

In case you need to view a CDR file in a browser or a standard image or PDF viewer application, you can convert it to HTML, JPEG, PNG  PDF format with GroupDocs.Viewer for .NET.

![CDR](viewer/net/images/how-to-convert-and-view-cdr-files/sample.jpg)

## How to convert CDR files

### Convert CDR to HTML

To convert CDR files to HTML with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.cdr"))
{
       HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("output_{0}.html");

       viewer.View(options);

       // To render 2nd image, just specify
       //viewer.View(options,2);
}
```

\
The following screenshot shows the output HTML file opened in a browser.

![CDR in HTML](viewer/net/images/how-to-convert-and-view-cdr-files/html.jpg)

### Convert CDR to JPG

To convert CDR files to JPG with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.cdr"))
{
       JpgViewOptions options = new JpgViewOptions("output_{0}.jpg");

       viewer.View(options);

       // To render 2nd image, just specify
       //viewer.View(options,2);
}
```

\
The following screenshot shows the output JPG file opened in a Windows Photo Viewer application.

![CDR in JPG](viewer/net/images/how-to-convert-and-view-cdr-files/jpg.jpg)

### Convert CDR to PNG

To convert PLT/HPG files to PNG with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.cdr"))
{
       PngViewOptions options = new PngViewOptions("output_{0}.png");

       viewer.View(options);

       // To render 2nd image, just specify
       //viewer.View(options,2);
}
```

\
The following screenshot shows the output PNG file opened in a Windows Photo Viewer application.

![CDR in PNG](viewer/net/images/how-to-convert-and-view-cdr-files/png.jpg)

### Convert CDR to PDF

To convert CDR files to PDF with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.cdr"))
{
       PdfViewOptions options = new PdfViewOptions("output.pdf");

       viewer.View(options);

       // By default all images will be rendered in output.pdf, to render only 2nd image in output PDF
       //viewer.View(options,2);
}
```

\
The following screenshot shows the output PDF file opened in an Acrobat Reader.

![CDR in PDF](viewer/net/images/how-to-convert-and-view-cdr-files/pdf.jpg)

## More resources

### View CDR files Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View CDR files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/cdr)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)
