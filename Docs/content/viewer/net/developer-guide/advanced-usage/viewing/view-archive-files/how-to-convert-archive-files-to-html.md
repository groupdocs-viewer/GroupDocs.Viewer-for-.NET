---
id:  how-to-convert-archive-files-to-html
url: viewer/net/how-to-convert-archive-files-to-html
title: How to convert archive files to HTML
weight: 2
description: "In this article we show how to convert and view archive files with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
## Introduction

Archive file formats are related to files compression. There various archive formats:
Mostly used in Windows: ZIP, RAR
Mostly used in Linux (Unix): TAR, BZIP2 (BZ2), GZIP

ZIP archives can be opened with Windows explorer,
RAR, TAR, BZIP2, GZIP formats can be opened with WinRar,

![Archive in windows explorer](viewer/net/images/how-to-convert-archive-files-to-html/zip-in-explorer.png)

If you convert archive files to HTML, you can choose beetween multiple and single pages conversion.

## How to convert archive files to HTML

### Convert archive files to multiple pages HTML

If property RenderSinglePage is set to false (by default), you can set ItemsPerPage property - the number of items per page (default is 16), it is for rendering to HTML only.
To convert archive files to multiple pages HTML with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.zip"))
{
       HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("output_page_{0}.html");
       options.ArchiveOptions.ItemsPerPage = 10;

       viewer.View(options);
}
```

The following screenshot shows the output HTML file opened in a browser.

![Multiple pages HTML converted archive](viewer/net/images/how-to-convert-archive-files-to-html/zip-to-multiple-html.png)

### Convert archive files to single HTML

To convert archive files to single page HTML with GroupDocs.Viewer for .NET use following code:

```csharp
using (Viewer viewer = new Viewer("sample.zip"))
{
       HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("output.html");
       options.RenderSinglePage = true;
       viewer.View(options);
}
```

The following screenshot shows the output HTML file opened in a browser.

![Single page HTML converted zip](viewer/net/images/how-to-convert-archive-files-to-html/zip-to-single-html.png)

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
