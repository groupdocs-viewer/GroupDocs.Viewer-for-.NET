---
id:  how-to-convert-and-view-apple-numbers-files
url: viewer/net/how-to-convert-and-view-apple-numbers-files
title: How to convert and view Apple numbers files
weight: 2
description: "In this article we show how to convert and view Apple numbers files with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
Numbers is Apple spreadsheet document format. It can be opened on Mac with Numbers application.

![numbers in Mac](viewer/net/images/how-to-convert-and-view-apple-numbers-files/numbers-in-mac.png)

## How to convert Apple numbers files

### Convert Apple numbers to HTML

To convert Apple numbers files to HTML with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.numbers"))
{
       HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("output.html");
       viewer.View(options);
}
```

The following screenshot shows the output HTML file opened in a browser.

![HTML converted numbers](viewer/net/images/how-to-convert-and-view-apple-numbers-files/numbers-in-html.png)

### Convert Apple numbers to JPG

To convert Apple numbers files to JPG with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.numbers"))
{
       JpgViewOptions options = new JpgViewOptions("output.jpg");
       viewer.View(options);
}
```

The following screenshot shows the output JPG file opened in a Windows Photo Viewer application.

![JPEG converted numbers](viewer/net/images/how-to-convert-and-view-apple-numbers-files/numbers-in-jpg.png)

### Convert Apple numbers to PNG

To convert Apple numbers files to PNG with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.numbers"))
{
       PngViewOptions options = new PngViewOptions("output.png");
       viewer.View(options);
}
```

The following screenshot shows the output PNG file opened in a Windows Photo Viewer application.

![PNG converted numbers](viewer/net/images/how-to-convert-and-view-apple-numbers-files/numbers-in-png.png)

### Convert Apple numbers to PDF

To convert Apple numbersfiles to PDF with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.numbers"))
{
       PdfViewOptions options = new PdfViewOptions("output.pdf");
       viewer.View(options);
}
```

The following screenshot shows the output PDF file opened in an Acrobat Reader.

![PDF converted numbers](viewer/net/images/how-to-convert-and-view-apple-numbers-files/numbers-in-pdf.png)

## More resources

### View Excel Files Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View Excel XLS, XLSX, and XLSB files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/excel)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)
