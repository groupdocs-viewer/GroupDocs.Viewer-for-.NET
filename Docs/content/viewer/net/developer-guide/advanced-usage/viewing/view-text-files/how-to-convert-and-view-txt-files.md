---
id: how-to-convert-and-view-txt-files
url: viewer/net/how-to-convert-and-view-txt-files
title: How to convert and view TXT files
weight: 1
description: "This article explains how to convert and view Text files with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
TXT documents are simple text documents, without additional (font size, paragraphs/text styling) formatting.
These files can be opened with windows notepad, or Microsoft office/OpenOffice desktop applications.
In case you need to view a text files in a browser or in a standard image or PDF viewer application, you can convert it to HTML, JPEG, PNG  PDF format with GroupDocs.Viewer for .NET.

![Text file opened in notepad](viewer/net/images/how-to-convert-and-view-txt-files.png)

## How to convert Text files

### Convert TXT to HTML

To convert TXT files to multiple pages HTML with GroupDocs.Viewer for .NET use following code:

```csharp

using (Viewer viewer = new Viewer("sample.txt"))
{
       HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("output_{0}.html");

       viewer.View(options);
}
```

\
To convert TXT files to single HTML with GroupDocs.Viewer for .NET use following code:

```csharp

using (Viewer viewer = new Viewer("sample.txt"))
{
       HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("output.html");
       options.RenderSinglePage = true;

       viewer.View(options);
}
```

The following screenshot shows the output HTML file opened in a browser.

![](viewer/net/images/how-to-convert-and-view-txt-files_1.png)

### Convert TXT to JPG

To convert TXT files to JPG with GroupDocs.Viewer for .NET use following code: 

```csharp
using (Viewer viewer = new Viewer("sample.txt"))
{
       JpgViewOptions options = new JpgViewOptions("output.jpg");

       viewer.View(options);
}
```

The following screenshot shows the output JPG file opened in a Windows Photo Viewer application.

![](viewer/net/images/how-to-convert-and-view-txt-files_2.png)

### Convert TXT to PNG

To convert PLT/HPG files to PNG with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.txt"))
{
       PngViewOptions options = new PngViewOptions("output.png");

       viewer.View(options);
}
```

The following screenshot shows the output PNG file opened in a Windows Photo Viewer application.

![](viewer/net/images/how-to-convert-and-view-txt-files_3.png)

### Convert TXT to PDF

To convert TXT files to PDF with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.txt"))
{
       PdfViewOptions options = new PdfViewOptions("output.pdf");

       viewer.View(options);
}
```

The following screenshot shows the output PDF file opened in an Acrobat Reader.

![](viewer/net/images/how-to-convert-and-view-txt-files_4.png)

## More resources

### View TXT Files Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View TXT files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/txt)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)
