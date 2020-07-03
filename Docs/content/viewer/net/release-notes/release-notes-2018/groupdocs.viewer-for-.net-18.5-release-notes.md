---
id: groupdocs-viewer-for-net-18-5-release-notes
url: viewer/net/groupdocs-viewer-for-net-18-5-release-notes
title: GroupDocs.Viewer for .NET 18.5 Release Notes
weight: 10
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 18.5.{{< /alert >}}

## Major Features

There are 14 features, improvements, and fixes in this regular monthly release. The most notable are:

*   Changing language for Email document headers
*   Setting page size when rendering Email documents
*   Support for rendering password protected ODT and OTT formats

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1591 | Setting page size when rendering Email documents as PDF and image | New Feature |
| VIEWERNET-1571 | Changing language for header of emails | New Feature |
| VIEWERNET-1587 | Add new property EnableCaching which will replace UseCache property in ViewerConfig class | Improvement |
| VIEWERNET-1580 | Add support for rendering password protected ODT and OTT formats | Improvement |
| VIEWERNET-1573 | Support JpegQuality option when rendering OneNote documents into PDF | Improvement |
| VIEWERNET-1561 | Extend support for DefaultFontName option for MS Project documents when rendering into PDF | Improvement |
| VIEWERNET-1595 | The voluminous email is not fully rendered into image | Bug |
| VIEWERNET-1559 | Images and diagrams are missing when rendering OTS file | Bug |
| VIEWERNET-1532 | Text's shadow appears in the output HTML | Bug |
| VIEWERNET-1527 | Issues when rendering Excel document with vertical Japanese writing | Bug |
| VIEWERNET-1464 | Text overlaps when viewing HTML in Mozilla Firefox | Bug |
| VIEWERNET-1256 | Content is missing when rendering PDF document into HTML | Bug |
| VIEWERNET-1016 | Link with external URL in PDF document is not rendered as hyperlink | Bug |
| VIEWERNET-1599 | The output image is cropped when rendering HTML as image | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 18.5. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Setting page size when rendering Email documents as PDF and image

Since the version 18.5, it is possible to set output page size for rendering Email documents into PDF and images. To enable this feature, set the **PageSize** property of the **EmailOptions** class. Please note that for rendering into HTML the whole email message is rendered into one responsive HTML page and this new option will not influence the rendering. 

**Rendering as Image (C#)**

```csharp
string guid = "long-email.msg";
  
//Instantiate Viewer Hanlder 
ViewerImageHandler imageHandler = new ViewerImageHandler();
  
//Set page size  
ImageOptions imageOptions = new ImageOptions();
imageOptions.EmailOptions.PageSize = PageSize.A4;
 
//Render document with custom page size
List<PageImage> pages = imageHandler.GetPages(guid, imageOptions);
 
//Use Stream property of the PageImage class, to get output image.
foreach (PageImage page in pages)
{
    Console.WriteLine(page.Stream.Length);
}
```

**Rendering as PDF (C#)**

```csharp
string guid = "long-email.msg";
  
//Instantiate Viewer Hanlder 
ViewerImageHandler imageHandler = new ViewerImageHandler();
  
//Set page size  
PdfFileOptions pdfOptions = new PdfFileOptions();            
pdfOptions.EmailOptions.PageSize = PageSize.A4;
 
//Render document with custom page size
FileContainer pdfContainer = imageHandler.GetPdfFile(guid, pdfOptions);
 
//Use Stream property of the FileContainer class, to get the output PDF document.
Console.WriteLine(pdfContainer.Stream.Length);
```

### Changing language for the header of emails

When rendering email messages, by default the API uses the English language to render field labels such as (From, To, Subject etc.). To change field labels, the API provides a new property called **FieldLabels** in **EmailOptions** class.

**How to change field labels (C#)**

```csharp
 string guid = "email.msg";
  
//Instantiate Viewer Hanlder 
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler();
  
//Set field labels 
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.EmailOptions.FieldLabels[EmailField.From] = "Sender";
htmlOptions.EmailOptions.FieldLabels[EmailField.To] = "Receiver";
htmlOptions.EmailOptions.FieldLabels[EmailField.Sent] = "Date";
htmlOptions.EmailOptions.FieldLabels[EmailField.Subject] = "Topic";
 
//Render document with custom field labels
List<PageHtml> pages = htmlHandler.GetPages(guid, htmlOptions);
```

### List of Changes in v18.5

#### GroupDocs.Viewer.Config.ViewerConfig

##### Public bool UseCache property is set obsolete

This property will be removed in version 18.8, please use EnableCaching property instead.

##### Public bool EnableCaching property added

Use this property to enable caching as a replacement for UseCache property.

**Enabling cache (C#)**

```csharp
string guid = "document.docx";
 
// Setup GroupDocs.Viewer config with cache enabled
ViewerConfig config = new ViewerConfig();
config.EnableCaching = true; 
 
// Pass configurations to ViewerHandler and get output pages
ViewerImageHandler handler = new ViewerImageHandler(config); 
List<PageImage> pages = handler.GetPages(guid);
```

##### Public string DefaultFontName property has been removed

Please use DefaultFontName property of the ImageOptions, HtmlOptions, DocumentInfoOptions or PdfFileOptions class instead as show in example below.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
string guid = "document.docx";
ViewerImageHandler handler = new ViewerImageHandler(config);
 
//Initialize a new instance of an ImageOptions class and set its DefaultFontName property 
ImageOptions options = new ImageOptions();
options.DefaultFontName = "Calibri";
 
List<PageImage> pages = handler.GetPages(guid, options);
```

#### GroupDocs.Viewer.Converter.Options.EmailField

##### public static class EmailField added

This class contains supported Email document fields.

#### GroupDocs.Viewer.Converter.Options.EmailOptions

##### public Dictionary<string, string> FieldLabels property added

Use this property to specify custom labels for Email document fields.

**Set labels (C#)**

```csharp
string guid = "email.msg";
 
//Instantiate Viewer Hanlder 
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler();
 
//Set field labels 
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.EmailOptions.FieldLabels[EmailField.From] = "Sender";
htmlOptions.EmailOptions.FieldLabels[EmailField.To] = "Receiver";
htmlOptions.EmailOptions.FieldLabels[EmailField.Sent] = "Date";
htmlOptions.EmailOptions.FieldLabels[EmailField.Subject] = "Topic";
 
//Render document with custom field labels
List<PageHtml> pages = htmlHandler.GetPages(guid, htmlOptions);
```

##### public PageSize property added

Use this option to set the output page size for rendering into images and PDF.

**Render as image (C#)**

```csharp
string guid = "long-email.msg";
  
//Instantiate Viewer Hanlder 
ViewerImageHandler imageHandler = new ViewerImageHandler();
  
//Set page size  
ImageOptions imageOptions = new ImageOptions();
imageOptions.EmailOptions.PageSize = PageSize.A4;
 
//Render document with custom page size
List<PageImage> pages = imageHandler.GetPages(guid, imageOptions);
 
//Use Stream property of the PageImage class, to get output image.
foreach (PageImage page in pages)
{
    Console.WriteLine(page.Stream.Length);
}
```

**Render as PDF (C#)**

```csharp
string guid = "long-email.msg";
  
//Instantiate Viewer Hanlder 
ViewerImageHandler imageHandler = new ViewerImageHandler();
  
//Set page size  
PdfFileOptions pdfOptions = new PdfFileOptions();            
pdfOptions.EmailOptions.PageSize = PageSize.A4;
 
//Render document with custom page size
FileContainer pdfContainer = imageHandler.GetPdfFile(guid, pdfOptions);
 
//Use Stream property of the FileContainer class, to get the output PDF document.
Console.WriteLine(pdfContainer.Stream.Length);
```
