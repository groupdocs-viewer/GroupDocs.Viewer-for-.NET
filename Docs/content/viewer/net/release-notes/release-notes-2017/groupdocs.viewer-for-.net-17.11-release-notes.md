---
id: groupdocs-viewer-for-net-17-11-release-notes
url: viewer/net/groupdocs-viewer-for-net-17-11-release-notes
title: GroupDocs.Viewer for .NET 17.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 17.11.{{< /alert >}}

## Major Features

There are 15 improvements and fixes in this regular monthly release. The most notable are:

*   Added new overload for RotatePage and ReorderPage methods with ability to specify RenderOptions
*   Improved MHT documents rendering performance
*   Improved styles generation when rendering into HTML with embedded resources

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1424 | New overload for RotatePage and ReorderPage methods with ability to specify RenderOptions | Improvement |
| VIEWERNET-1417 | Improve MHT documents rendering performance | Improvement |
| VIEWERNET-1405 | Drop support of caching based on render options | Improvement |
| VIEWERNET-1363 | Add code examples for CAD rendering options | Improvement |
| VIEWERNET-1362 | Load custom fonts on demand | Improvement |
| VIEWERNET-1351 | Improve styles generation when rendering into HTML with embedded resources | Improvement |
| VIEWERNET-1347 | Watermark is not over the content when rendering into HTML | Improvement |
| VIEWERNET-560 | DWG+DFX (2007,2010) support is required. | Improvement |
| VIEWERNET-1434 | ViewerConfig.FontDirectories property not working for Text documents | Bug |
| VIEWERNET-1425 | Exception when rendering Excel document into HTML and image | Bug |
| VIEWERNET-1423 | Index out of range exception when rendering CAD document | Bug |
| VIEWERNET-1418 | Content is missing when rendering interactive PDF document | Bug |
| VIEWERNET-1414 | Columns are missing when rendering Excel document to PDF and HTML | Bug |
| VIEWERNET-1376 | Missing words and characters when rendering PDF to HTML | Bug |
| VIEWERNET-1132 | Incorrect Positioning of Characters When Rendering PDF to HTML | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 17.11. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Specifying Render Options while Rotating Documents

Since the version 17.11, there is a new overload for RotatePage method of the ViewerHandler class, that allows specifying render options while rotating the document. We might need this overload when we are setting options that influence the resulting page count. For example, when we are rendering MS PowerPoint document with two visible and one hidden slide, by default we get only visible pages rendered, when we set ShowHiddenPages property of the RenderOptions class, as a result, we will get three pages rendered. In order to be able to rotate this third page, we should use this new overload as shown in the example below.

**Rotate 3rd hidden page of the document by 90 deg (C#)**

```csharp
 // Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 config.UseCache = true;
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.pptx"; 
 
// Set rotation angle 90 for page number 3
RotatePageOptions rotateOptions = new RotatePageOptions(3, 90);
 
// Set html options to include hidden pages
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.ShowHiddenPages = true;
 
// Perform page rotation
htmlHandler.RotatePage(guid, rotateOptions, htmlOptions);
 
// Set html options to include rotated pages
htmlOptions.Transformations = Transformation.Rotate;
  
// Get html representation of all document pages, including rotated pages. 
List<PageHtml> pages = htmlHandler.GetPages(guid, htmlOptions);
```

### Specifying Render Options while Reordering Documents

Since the version 17.11, there is a new overload for ReorderPage method of the ViewerHandler class, that allows specifying render options while reordering the document. We might need this overload when we are setting options that influence the resulting page count. For example, when we are rendering MS PowerPoint document with two visible and one hidden slide, by default we get only visible pages rendered, when we set ShowHiddenPages property of the RenderOptions class, as a result, we will get three pages rendered. In order to be able to reorder this third page, we should use this new overload as shown in the example below.

**Reorder 3rd hidden page of the document with 2nd page (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 config.UseCache = true;
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.pptx"; 
 
int pageNumber = 2;
int newPosition = 3;
  
// Set reorder options
ReorderPageOptions options = new ReorderPageOptions(pageNumber, newPosition);
 
// Set html options to include hidden pages
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.ShowHiddenPages = true;
 
// Perform page reordering
htmlHandler.ReorderPage(guid, options, htmlOptions);
 
// Set html options to include reordered pages
htmlOptions.Transformations = Transformation.Rotate;
  
// Get html representation of all document pages, including reordered pages. 
List<PageHtml> pages = htmlHandler.GetPages(guid, htmlOptions);
```

### List of Changes in GroupDocs.Viewer for .NET 17.11

#### GroupDocs.Viewer.Converter.Options.CellsOptions

##### Public bool ShowHiddenSheets property compilation is set to fail

This property is no longer active and will be removed in the version 17.12, please use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead.

#### GroupDocs.Viewer.Converter.Options.DiagramOptions

##### Public DiagramOptions class compilation is set to fail

This class will be removed in version 17.12. To enable rendering hidden pages use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead.

#### GroupDocs.Viewer.Converter.Options.HtmlOptions

##### Public bool IgnoreResourcePrefixForCss property has been removed

This property has been removed, please use IgnorePrefixInResources property instead.

#### GroupDocs.Viewer.Converter.Options.PdfOptions

##### Public bool DeleteAnnotations property compilation is set to fail

This property is no longer active and will be removed in version 17.12. Please use RenderComments property of the HtmlOptions or ImageOptions class instead.

#### GroupDocs.Viewer.Converter.Options.RenderOptions

##### Public DiagramOptions.ShowHiddenPages property compilation is set to fail

This property is no longer active and will be removed in version 17.12. To enable rendering hidden pages use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead.

#### GroupDocs.Viewer.Domain.CachedDocumentDescription

##### Public DiagramOptions.ShowHiddenPages property compilation is set to fail

This property is no longer active and will be removed in version 17.12. To enable rendering hidden pages use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead.

#### GroupDocs.Viewer.Domain.CachedPageDescription

##### Public DiagramOptions.ShowHiddenPages property compilation is set to fail

This property is no longer active and will be removed in version 17.12. To enable rendering hidden pages use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead.

#### GroupDocs.Viewer.Domain.Html.HtmlResource

##### Public DiagramOptions.ShowHiddenPages property compilation is set to fail

This property is no longer active and will be removed in version 17.12. 

#### GroupDocs.Viewer.Domain.Options.DocumentInfoOptions

##### Public DiagramOptions.ShowHiddenPages property compilation is set to fail

This property is no longer active and will be removed in version 17.12. To enable rendering hidden pages use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead.

#### GroupDocs.Viewer.Domain.Options.PdfFileOptions

#### Public DiagramOptions.ShowHiddenPages property compilation is set to fail

This property is no longer active and will be removed in version 17.12. To enable rendering hidden pages use ShowHiddenPages property of the RenderOptions (ImageOptions, HtmlOptions or PdfFileOptions) class instead.

#### GroupDocs.Viewer.Handler.ViewerHandler

##### Public void RotatePage(string guid, RotatePageOptions rotatePageOptions, RenderOptions renderOptions) overload has been added

##### Public void ReorderPage(string guid, ReorderPageOptions reorderPageOptions, RenderOptions renderOptions) overload has been added

#### GroupDocs.Viewer.Handler.ViewerHtmlHandler

##### Public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, IFileDataStore fileDataStore) constructor has been removed

Please use overload without 'fileDataStore' parameter.

##### Public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, IFileDataStore fileDataStore, CultureInfo cultureInfo) constructor has been removed

Please use overload without 'fileDataStore' parameter.

#### GroupDocs.Viewer.Handler.ViewerImageHandler

##### Public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, IFileDataStore fileDataStore) constructor has been removed

This constructor is obsolete and has been removed. Please use overload without 'fileDataStore' parameter.

##### Public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, IFileDataStore fileDataStore, CultureInfo cultureInfo) constructor has been removed

This constructor is obsolete and has been removed. Please use overload without 'fileDataStore' parameter.

#### GroupDocs.Viewer.Helper.IFileDataStore

##### Public interface IFileDataStore interface has been removed

This interface has been removed. If you need your own implementation for storing file data, please refer to the documentation and implement the ICacheDataHandler interface instead.

{{< alert style="info" >}}Starting from 17.11 caching based on render options feature was disabled. It is recommended to clear your cache folder after update to 17.11 in the case when default implementation of ICacheDataHandler shipped with GroupDocs.Viewer for .NET is used. {{< /alert >}}
