---
id: groupdocs-viewer-for-net-17-12-release-notes
url: viewer/net/groupdocs-viewer-for-net-17-12-release-notes
title: GroupDocs.Viewer for .NET 17.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 17.12.{{< /alert >}}

## Major Features

There 10 improvements, fixes, and new features in this regular monthly release. The most notable are:

*   Added support of CSS and HTML minification
*   Added method to remove cache files of a specific document
*   Added support of rendering MS Project documents by time intervals

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1454 | Add ODG (OpenDocument Graphics) file format support | New Feature |
| VIEWERNET-1445 | Removing cache files of a specific document | New Feature |
| VIEWERNET-1433 | Improve rendering Jpeg images into HTML | New Feature |
| VIEWERNET-1353 | Implement a setting for minifying CSS resources and HTML content | New Feature |
| VIEWERNET-1352 | Implement an option to split MS Project documents by time intervals | New Feature |
| VIEWERNET-1364 | Add code examples for Slides rendering options | Improvement |
| VIEWERNET-1452 | Index was out of range exception when rendering XLSX as PDF | Bug |
| VIEWERNET-1415 | Blank output when rendering PDF document as HTML | Bug |
| VIEWERNET-1342 | CAD document layouts with the size different than model are not rendered correctly | Bug |
| VIEWERNET-1004 | Alignment of radio button text and checkbox text is not proper | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 17.12. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### ODG (OpenDocument Graphics) file format support

Since version 17.12, ODG file format is also supported.   

### Removing cache files of a specific document

A new overload of the ViewerHandler.ClearCache method with guid parameter has been added to remove the cache files of a specific document.



```csharp
//Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
 
// Init viewer image or html handler
ViewerImageHandler viewerImageHandler = new ViewerImageHandler(viewerConfig);
 
// Set the guid of the document you want to clear.
string guid = "document.docx";
//Clear files from cache related to specified document. 
viewerImageHandler.ClearCache(guid);
```

### Setting for minifying CSS resources and HTML content

Since the version 17.12 GroupDocs.Viewer API provides a new **EnableMinification** property of the **HtmlOptions** class, that lets you get output content minified. Minification removes comments, extra white-spaces, and other unneeded characters without breaking the content structure. As a result, the page becomes smaller in size and loads faster. The following example demonstrates how to minify output content when rendering MS Word document into HTML.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.docx";
 
HtmlOptions options = new HtmlOptions();
options.EnableMinification = true;
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
 
 
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

{{< alert style="info" >}}Please note that currently minification is not applied to CSS, this future will be added in coming releases.{{< /alert >}}

While these settings will not compress the content as significantly as this might be achieved using Gzip compression (that should be enabled and configured from your web server), however, still it might be valuable and can be used as an additional optimization in combination with Gzip compression.

#### Details behind minification

The process of minification almost in all cases provides the output that looks identically with original content in all browsers but minified HTML content does not pass strict HTML validation. Here is the list of technics that lay behind minification process:

HTML minification:  

*   Comments (except when they contain IE conditional statements) are completely removed
*   Conditional comments are compressed
*   Spaces and line breaks inside the tags and between the tags are removed
*   Document type declaration is simplified to `<!DOCTYPE html>`, and all HTML tag properties are removed
*   Protocol declarations like http:, https: and javascript: from path values are removed
*   Multiple spaces between words (except when they occur inside the pre or textarea tag) are replaced with single space
*   Quotes around tag property values (except inline events) are removed
*   Default attributes for "script", "style" and "link" tags are removed
*   Boolean attributes are simplified, therefore `<input type="text" disabled="disabled">` becomes `<input type=text disabled>`

### Option to split MS Project documents by time intervals

#### Adjusting Page Size and Time Unit

When you are rendering MS Project documents into an image, HTML or PDF, GroupDocs.Viewer API tries to find optimal output size and time unit, depending on the projects overall length. In case you need to set your own page size or time unit, you can set **ProjectOptions** class properties of corresponding **RenderOptions** (**HtmlOptions** or **ImageOptions**) or **PdfFileOptions** class for rendering into PDF,  as shown in examples below. Time unit refers to smallest unit (days, third of a month or month) used in timescale bar. When the *TimeUnit.Days* is selected you will get the most detailed view of your tasks and when *TimeUni*t.*Month* is selected you will get a more general representation of tasks.

**Setting page size and time unit when rendering MS Project documents (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.mpp";
  
// Set Project options to render content with a specified size and time unit.
ImageOptions options = new ImageOptions();
options.ProjectOptions.PageSize = PageSize.A2;
options.ProjectOptions.TimeUnit = TimeUnit.Days;
 
// Get pages 
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
     Console.WriteLine("Page number: {0}", page.PageNumber); 
     Stream imageContent = page.Stream;
}
```

**Get PDF representation of MS Project documents with specified page size and time unit (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.mpp";
  
// Set Project options to render content with a specified size and time unit.
PdfFileOptions options = new PdfFileOptions();
options.ProjectOptions.PageSize = PageSize.A2;
options.ProjectOptions.TimeUnit = TimeUnit.Days;
 
// Get PDF file 
FileContainer fileContainer = imageHandler.GetPdfFile(guid, options);
 
// Access PDF file stream.
Stream pdfFileStream = fileContainer.Stream;
```

### List of changes in GroupDocs.Viewer for .NET 17.12

#### GroupDocs.Viewer.Handler.Cache.ICacheDataHandler

##### void ClearCache(string guid) overload has been added.

A new overload of ClearCache method aims to clear cache related to the specific document, indicated by guid parameter. Please implement this new overload if you are supplying your custom implementation for the cache data handler. 

#### GroupDocs.Viewer.Handler.ViewerHandler<T>

##### public void ClearCache(string guid) overload of the ClearCache method has been added.

This overload of the ClearCache method clears cache for the specified document. As the new overload has been added in the base abstract class, it applies to both, ViewerImageHandler and ViewerHtmlHandler classes.
