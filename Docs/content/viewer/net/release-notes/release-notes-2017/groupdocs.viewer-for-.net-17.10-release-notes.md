---
id: groupdocs-viewer-for-net-17-10-release-notes
url: viewer/net/groupdocs-viewer-for-net-17-10-release-notes
title: GroupDocs.Viewer for .NET 17.10 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 17.10{{< /alert >}}

## Major Features

There are 3 new features and 11 improvements and fixes in this regular monthly release. The most notable are:

*   Added setting to show/hide hidden pages
*   Added support of STL and IFC (CAD) file formats
*   Implemented rendering from stream as HTML with external resources

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1350 | Implement a setting to show/hide hidden pages | New Feature |
| VIEWERNET-1317 | Add STL file format support | New Feature |
| VIEWERNET-965 | Support of IFC file format | New Feature |
| VIEWERNET-1403 | Extend support of CountRowsPerPage option when rendering Spreadsheet documents as PDF and image with enabled text extraction | Improvement |
| VIEWERNET-1349 | Rendering documents into HTML from stream does not create external resources | Improvement |
| WEB-1350 | Gray rectangles instead of image parts | Bug |
| VIEWERNET-1402 | Empty space between text is lost when rendering Email documents | Bug |
| VIEWERNET-1399 | The parameter 'address' cannot be an empty string exception when rendering MSG document | Bug |
| VIEWERNET-1372 | Some rows/records are missing when rendering Excel document to HTML | Bug |
| VIEWERNET-1371 | Parameter is not valid exception when rendering Excel document to image | Bug |
| VIEWERNET-1367 | The output image gets cut when rendering PowerPoint presentation | Bug |
| VIEWERNET-1313 | All pages are same when rendering Microsoft Project document into an image | Bug |
| VIEWERNET-1243 | Incorrect rendering of PDF document into HTML | Bug |
| VIEWERNET-1139 | Exception when rendering CAD file into image | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 17.10. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### How to enable rendering hidden sheets, slides or pages

Microsoft Excel, PowerPoint and Visio documents may contain hidden pages (slides or sheets). By default, hidden pages are not rendered. In order to include them into the rendering set **ShowHiddenPages** property of the **RenderOptions** (ImageOptions or HtmlOptions) class as true as shown in the example below. This new setting has replaced obsolete **CellsOptions.ShowHiddenSheets** and **DiagramOptions.ShowHiddenPages** properties in **RenderOptions** class.

**Show hidden pages for Visio files in image representation**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "sample.vsdx";
  
// Set image options to show hidden pages
ImageOptions options = new ImageOptions();
options.ShowHiddenPages = true;
  
DocumentInfoContainer container = imageHandler.GetDocumentInfo(guid);
  
foreach (PageData page in container.Pages)
   Console.WriteLine("Page number: {0}, Page Name: {1}, IsVisible: {2}", page.Number, page.Name, page.IsVisible);
  
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
   Console.WriteLine("Page number: {0}", page.PageNumber);
  
   // Page image stream
   Stream imageContent = page.Stream;
}
```

**Show hidden pages for Visio files in HTML representation**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "sample.vsdx";
  
// Set html options to show grid lines
HtmlOptions options = new HtmlOptions();
options.ShowHiddenPages = true;
  
DocumentInfoContainer container = htmlHandler.GetDocumentInfo(guid);
  
foreach (PageData page in container.Pages)
   Console.WriteLine("Page number: {0}, Page Name: {1}, IsVisible: {2}", page.Number, page.Name, page.IsVisible);
  
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
  
foreach (PageHtml page in pages)
{
   Console.WriteLine("Page number: {0}", page.PageNumber);
   //Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

### Rendering worksheets by dividing into pages

{{< alert style="info" >}}This feature is supported starting from 17.10 for rendering the document as PDF and as image with enabled text extraction.{{< /alert >}}

  
GroupDocs.Viewer provides two options which allow controlling worksheets dividing: **CellsOptions.OnePagePerSheet** and **CellsOptions.CountRowsPerPage**. By default **CellsOptions.OnePagePerSheet** is set to true so Viewer will render the whole worksheet into single HTML/Image page or into a single page in PDF document. To enable dividing worksheet into pages **CellsOptions.OnePagePerSheet** should be disabled. In the next code snippet, it is shown how to render document which contains one sheet with 1000 rows into 10 pages.

**Rendering worksheets by dividing into pages**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image or html handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.xlsx";
  
// Set Cells options to divide worksheets into pages
ImageOptions options = new ImageOptions();
options.ExtractText = true;
options.CellsOptions.OnePagePerSheet = false; // default value is true
// Set count rows which should be rendered into single page
options.CellsOptions.CountRowsPerPage = 100; // default value is 50
 
// Get pages 
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    //Save image by accessing page.Stream
}
```

### List of changes in GroupDocs.Viewer for .NET 17.10

#### GroupDocs.Viewer.Converter.Options.CellsOptions

##### Public bool ShowHiddenSheets is set obsolete

This property will be removed in the version 17.12, please use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead as shown in the example below.

**Show hidden sheets for Excel files in image representation (since v17.10 C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.xlsx";
  
// Set image options to show grid lines
ImageOptions options = new ImageOptions();
options.ShowHiddenPages = true;
  
DocumentInfoContainer container = imageHandler.GetDocumentInfo(new DocumentInfoOptions(guid));
  
foreach (PageData page in container.Pages)
    Console.WriteLine("Page number: {0}, Page Name: {1}, IsVisible: {2}", page.Number, page.Name, page.IsVisible);
  
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
  
    // Page image stream
    Stream imageContent = page.Stream;
}
```

**Before v17.10 C#**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.xlsx";
  
// Set image options to show grid lines
ImageOptions options = new ImageOptions();
options.CellsOptions.ShowHiddenSheets = true;
  
DocumentInfoContainer container = imageHandler.GetDocumentInfo(new DocumentInfoOptions(guid));
  
foreach (PageData page in container.Pages)
    Console.WriteLine("Page number: {0}, Page Name: {1}, IsVisible: {2}", page.Number, page.Name, page.IsVisible);
  
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
  
    // Page image stream
    Stream imageContent = page.Stream;
}
```

#### GroupDocs.Viewer.Converter.Options.DiagramOptions

##### Public DiagramOptions class is set obsolete

This property will be removed in version 17.12. To enable rendering hidden pages use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead.

#### GroupDocs.Viewer.Converter.Options.HtmlOptions

##### Public bool IgnoreResourcePrefixForCss property compilation is set to fail

This property will be removed in the version 17.11.0, please use IgnorePrefixInResources property instead, as shown in the example below.

**In this example HtmlResourcePrefix option will be applied to resources inside HTML content, but will not be applied inside resources like SVG and CSS.**

```csharp
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.HtmlResourcePrefix = "http://contoso.com/api/getResource?name="
htmlOptions.IgnorePrefixInResources = true;
```

#### GroupDocs.Viewer.Converter.Options.RenderOptions

##### Public bool ShowHiddenPages property is added

This property enables rendering hidden pages, sheets or slides in Microsoft Excel, PowerPoint and Visio documents. It replaces obsolete CellsOptions.ShowHiddenSheets and DiagramOptions.ShowHiddenPages  properties in RenderOptions class.

##### Public DiagramOptions DiagramOptions is set obsolete

This will be removed in version 17.12. To enable rendering hidden pages use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead.

#### GroupDocs.Viewer.Domain.CachedDocumentDescription

##### Public DiagramOptions DiagramOptions is set obsolete

This will  be removed in version 17.12. To enable rendering hidden pages use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead.

#### GroupDocs.Viewer.Domain.CachedPageDescription

##### Public DiagramOptions DiagramOptions is set obsolete

This property will be removed in version 17.12. To enable rendering hidden pages use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead.

#### GroupDocs.Viewer.Domain.Html.HtmlResource

##### Public DiagramOptions DiagramOptions is set obsolete

This property will be removed in version 17.12. 

#### GroupDocs.Viewer.Domain.Options.DocumentInfoOptions

##### Public bool ShowHiddenPages property is added

This property enables rendering hidden pages, sheets or slides in Microsoft Excel, PowerPoint and Visio documents. It replaces obsolete CellsOptions.ShowHiddenSheets and DiagramOptions.ShowHiddenPages  properties in RenderOptions class.

##### Public DiagramOptions DiagramOptions is set obsolete

This will be removed in version 17.12. To enable rendering hidden pages use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead.

#### GroupDocs.Viewer.Domain.Options.PdfFileOptions

##### Public bool ShowHiddenPages property is added

This property enables rendering hidden pages, sheets or slides in Microsoft Excel, PowerPoint and Visio documents. It replaces obsolete CellsOptions.ShowHiddenSheets and DiagramOptions.ShowHiddenPages  properties in RenderOptions class.

##### Public DiagramOptions DiagramOptions is set obsolete

This property will be removed in version 17.12. To enable rendering hidden pages use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead.

#### GroupDocs.Viewer.Handler.IInputDataHandler

##### Public GroupDocs.Viewer.Handler.IInputDataHandler interface AddFile(string guid, Stream content) method has been removed

This method is obsolete and has been removed in the current version.

#### GroupDocs.Viewer.Handler.ViewerHtmlHandler

##### Public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, IFileDataStore fileDataStore) constructor compilation is set to fail.

This constructor is obsolete and will be removed after 17.11.0. Please use overload without 'fileDataStore' parameter.

##### Public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, IFileDataStore fileDataStore, CultureInfo cultureInfo) constructor compilation is set to fail.

This constructor is obsolete and will be removed after 17.11.0. Please use overload without 'fileDataStore' parameter.

#### GroupDocs.Viewer.Handler.ViewerImageHandler

##### Public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, IFileDataStore fileDataStore) constructor compilation is set to fail.

This constructor is obsolete and will be removed after 17.11.0. Please use overload without 'fileDataStore' parameter.

##### Public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, IFileDataStore fileDataStore, CultureInfo cultureInfo) constructor compilation is set to fail.

This constructor is obsolete and will be removed after 17.11.0. Please use overload without 'fileDataStore' parameter.

#### GroupDocs.Viewer.Helper.IFileDataStore

##### Public interface IFileDataStore interface compilation is set to fail.

This interface is obsolete and will be removed after 17.11.0.

{{< alert style="info" >}}Rendering documents into HTML from stream does not create external resourcesIn order to save HTML resources (styles, images, and fonts) in separate files with HtmlOptions.IsResourcesEmbedded property set to false, document name should be passed. In the case when we are rendering from the stream, and do not provide document name, before the version 17.10, API was suppressing saving resources separately and has been embedding resources into HTML regardless of IsResourcesEmbedded setting. Since the version 17.10, when document name is not provided, API tries to generate document name from the stream, when that stream is rendered again, API will generate the same name. Try to avoid not passing document name, in cases when document name is known, because API does not guarantee that document type can be detected and that document name will be unique for the stream(in some case, API may generate the same name for two different streams).{{< /alert >}}
