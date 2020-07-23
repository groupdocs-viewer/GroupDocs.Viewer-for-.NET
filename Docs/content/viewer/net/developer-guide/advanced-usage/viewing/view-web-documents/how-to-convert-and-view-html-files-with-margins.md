---
id:  how-to-convert-and-view-html-files-with-margins
url: viewer/net/how-to-convert-and-view-html-files-with-margins
title: How to convert and view HTML files with user defined margins
weight: 2
description: "In this article we show how set page margins while converting and viewing HTML files with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
## Introduction

When you are converting HTML files, you can ajdust top/bottom, left/right page margins in final document.
The units of margins are typography points.\
Default values are:\
Top/Bottom - 72\
Left/Right - 5

Final margin value is calculated as:\
Final margin value = [HTML page margin value] + [margin value in viewer ]

![Page in Internet Explorer](viewer/net/images/how-to-convert-and-view-html-files-with-margins/page-in-explorer.jpg)

## How to set margins values

### Setting margins values when converting to PNG

To set margins values when converting HTML files to PNG with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.htm"))
{
       PngViewOptions options = new PngViewOptions("result_page_{0}.png");
       options.WordProcessingOptions.LeftMargin = 40;
       options.WordProcessingOptions.RightMargin = 40;
       options.WordProcessingOptions.TopMargin = 40;
       options.WordProcessingOptions.BottomMargin = 40;

       viewer.View(options);
}
```

\
The following screenshot shows the output PNG file opened in a Windows Photo Viewer application.

![Output PNG result](viewer/net/images/how-to-convert-and-view-html-files-with-margins/png-result.jpg)

### Setting margins values when converting to JPG

To set margins values when converting HTML files to PNG with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.htm"))
{
       JpgViewOptions options = new JpgViewOptions("result_page_{0}.jpg");
       options.WordProcessingOptions.LeftMargin = 40;
       options.WordProcessingOptions.RightMargin = 40;
       options.WordProcessingOptions.TopMargin = 40;
       options.WordProcessingOptions.BottomMargin = 40;

       viewer.View(options);
}
```

\
The following screenshot shows the output JPEG file opened in a Windows Photo Viewer application.\
\
![Output JPEG result](viewer/net/images/how-to-convert-and-view-html-files-with-margins/jpg-result.jpg)

### Setting margins values when converting to PDF

To set margins values when converting HTML files to PDF with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.htm"))
{
       PdfViewOptions options = new PdfViewOptions("result.pdf");
       options.WordProcessingOptions.LeftMargin = 40;
       options.WordProcessingOptions.RightMargin = 40;
       options.WordProcessingOptions.TopMargin = 40;
       options.WordProcessingOptions.BottomMargin = 40;

       viewer.View(options);
}
```

\
The following screenshot shows the output PDF file opened in an Acrobat Reader.\
\
![Output PDF result](viewer/net/images/how-to-convert-and-view-html-files-with-margins/pdf-result.jpg)

## More resources

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
