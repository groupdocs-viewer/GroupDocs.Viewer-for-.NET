---
id: groupdocs-viewer-for-net-18-3-release-notes
url: viewer/net/groupdocs-viewer-for-net-18-3-release-notes
title: GroupDocs.Viewer for .NET 18.3 Release Notes
weight: 12
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 18.3.{{< /alert >}}

## Major Features

There are 15 new features, improvements, and fixes in this regular monthly release. The most notable are:

*   Added support for following file formats:  
    *   XLTM (Excel Open XML Macro-Enabled Spreadsheet) 
    *   XLTX (Excel Open XML Spreadsheet Template)
*   Added support of HtmlOptions.ExcludeFonts for Text (Microsoft Word) document
*   Improved rendering Microsoft OneNote documents as HTML
*   Added support for ShowHiddenSlides option for Open Document Presentation documents
*   Added option which allows to specify image quality when rendering PDF documents as HTML

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1530 | Specify image quality when rendering PDF documents as HTML | New Feature |
| VIEWERNET-1451 | Add XLTM file format support | New Feature |
| VIEWERNET-1450 | Add XLTX file format support | New Feature |
| VIEWERNET-1512 | Extend support of HtmlOptions.ExcludeFonts option for Text documents | Improvement |
| VIEWERNET-1510 | Improve rendering MS OneNote documents into HTML by providing pure HTML and SVG | Improvement |
| VIEWERNET-1497 | Exporting contained images when rendering SVG to HTML | Improvement |
| VIEWERNET-1480 | Extend support for ShowHiddenSlides option to Open Document Presentation | Improvement |
| VIEWERNET-1283 | Improve rendering metafile images into HTML | Improvement |
| WEB-1740 | Text is garbled in an Arabic PDF | Bug |
| VIEWERNET-1508 | Blur output when rendering PDF as Html | Bug |
| VIEWERNET-1500 | Printable Html gets messy when adding watermark | Bug |
| VIEWERNET-1499 | Content minification prevents styles loading | Bug |
| VIEWERNET-1493 | Access to the path "/Path/to/file/fd.xml" is denied | Bug |
| VIEWERNET-1435 | ViewerConfig.FontDirectories property not working for Presentation documents | Bug |
| VIEWERNET-1528 | Converting DNG image into JPG provides output with light spots | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 18.3. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Image quality when rendering PDF documents as HTML

When rendering PDF documents as HTML, GroupDocs.Viewer creates single image resource which contains all the images from the PDF document page and uses created image as the background for HTML document. Starting from v18.3, new option added to **PdfOptions** class called **ImageQuality** which allows you to control image resource quality. Supported values are **Low*, *Medium** and **High**. Please note that with **Low** value you'll have the best performance and with **High** value, you'll have the best quality but it will slow down rendering. 

**How to render PDF document with image quality option**

```csharp
//Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
  
// Init viewer html handler
ViewerHtmlHandler viewerHtmlHandler = new ViewerHtmlHandler(viewerConfig);
  
// Set the guid of the document you want to render
string guid = "with-images.pdf";
  
//Set desired image quality in the output HTML document
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.PdfOptions.ImageQuality = ImageQuality.High;
 
//Render document with specified options
List<PageHtml> pages = viewerHtmlHandler.GetPages(guid, htmlOptions);
  
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

### List of Changes in v18.3

#### GroupDocs.Viewer.Converter.Options.PdfOptions

##### public ImageQuality ImageQuality { get; set; } property has been added

This property allows specifying image quality when rendering PDF documents as HTML. Supported values are Low, Medium and High. The default value is Low.

**How to render document with desired image quality**

```csharp
//Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
 
// Init viewer html handler
ViewerHtmlHandler viewerHtmlHandler = new ViewerHtmlHandler(viewerConfig);
 
// Set the guid of the document you want to render
string guid = "with-images.pdf";
 
//Set desired image quality in the output HTML document
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.PdfOptions.ImageQuality = ImageQuality.High;
//Render document with specified options
List<PageHtml> pages = viewerHtmlHandler.GetPages(guid, htmlOptions);
```
