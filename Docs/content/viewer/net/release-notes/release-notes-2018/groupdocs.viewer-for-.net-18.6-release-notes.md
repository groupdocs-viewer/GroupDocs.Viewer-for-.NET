---
id: groupdocs-viewer-for-net-18-6-release-notes
url: viewer/net/groupdocs-viewer-for-net-18-6-release-notes
title: GroupDocs.Viewer for .NET 18.6 Release Notes
weight: 9
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 18.6.{{< /alert >}}

## Major Features

There are 17 features, improvements, and fixes in this regular monthly release. The most notable are:

*   Added DWF file format support
*   Rendering CAD documents by specifying coordinates
*   New option to force password validation each time the document is processed

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1601 | Add new option which allows checking password each time document processed | New Feature |
| VIEWERNET-1218 | Add DWF file format support | New Feature |
| VIEWERNET-915 | Render CAD documents by specifying coordinates | New Feature |
| VIEWERNET-1621 | Extend support for DefaultFontName setting to PDF documents when rendering into PDF | Improvement |
| VIEWERNET-1588 | Add new property EmbedResources which will replace IsResourcesEmbedded property in HtmlOptions class | Improvement |
| VIEWERNET-1585 | Support empty string for ViewerConfig.CacheFolderName property | Improvement |
| VIEWERNET-1564 | Eliminate the gap between list of tasks and footer when rendering MS Project documents | Improvement |
| VIEWERNET-1157 | Extend support for DefaultFontName option for CAD documents | Improvement |
| VIEWERNET-1626 | Access to the path 'c:\\windows\\system32\\inetsrv\\vs.bin' is denied. | Bug |
| VIEWERNET-1617 | Can't set different default fonts when rendering PDF document | Bug |
| VIEWERNET-1615 | Incorrect rendering of items with background color in Visio document | Bug |
| VIEWERNET-1614 | GetFileList throws "Guid for file should contain extension" when file has no extension | Bug |
| VIEWERNET-1613 | Some STL files are not supported | Bug |
| VIEWERNET-1553 | Text color is incorrect when rendering PDF | Bug |
| VIEWERNET-1545 | Content of the cell is hidden when rendering Excel to HTML | Bug |
| VIEWERNET-1543 | Unable to render Presentation documents, after ViewerConfig.FontDirectories are added | Bug |
| VIEWERNET-1470 | Wrong number of layouts in DXF | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 18.6. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Force password validation

When password protected documents are rendered with the caching enabled, document password is validated only on the first call, all subsequent renderings will provide output without checking the document password. In order to alter this behavior and let the API to validate document password on each rendering, set ForcePasswordValidation property of the ViewerConfig object as shown in the example below.

**How to force password validation each time document is rendered**

```csharp
//Init viewer config
ViewerConfig viewerConfig = new ViewerConfig();
viewerConfig.StoragePath = "c:\\storage";
 
//Set the password to be validated on every call
viewerConfig.ForcePasswordValidation = true;
// Init viewer html handler
ViewerHtmlHandler viewerHtmlHandler = new ViewerHtmlHandler(viewerConfig);
  
// Set the guid of the document you want to render
string guid = "with-images.pdf";
  
//Set document password
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.Password = "documentpassword";
 
//Render document with specified options
List<PageHtml> pages = viewerHtmlHandler.GetPages(guid, htmlOptions);
  
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

### Rendering by coordinates or Tiled rendering

Tiled rendering or (rendering by coordinates) is the process of rendering CAD documents (into an image, HTML or PDF) by dividing into square parts and rendering each part (or tile), separately. The advantage to this is that the amount of memory involved is reduced as compared to rendering the entire document at once. Since the version 18.6, tiled rendering is available for rendering into an image and HTML for DWG file format. Generally, DWG documents are divided into pages by Model and Layouts, but when the tiled rendering is enabled, only the Model is rendered, and every tile composes a separate page. You can add as many tiles as you need. The following example demonstrates how to render DWG drawing into an image by dividing into four equal parts. 

**Rendering by coordinates (C#)**

```csharp
 // Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.dwg";
  
// Get document width and height
DocumentInfoContainer docInfo = imageHandler.GetDocumentInfo(guid);
int width = docInfo.Pages[0].Width;
int height = docInfo.Pages[0].Height;
 
// Set tile width and height as a half of image total width
int tileWidth = width / 2;
int tileHeight = height / 2;
 
int pointX = 0;
int pointY = 0;
//Create image options and add four tiles, one for each quarter
ImageOptions options = new ImageOptions();
Tile tile = new Tile(pointX, pointY, tileWidth, tileHeight);
options.CadOptions.Tiles.Add(tile);
pointX += tileWidth;
tile = new Tile(pointX, pointY, tileWidth, tileHeight);
options.CadOptions.Tiles.Add(tile);
 
pointX = 0;
pointY += tileHeight;
tile = new Tile(pointX, pointY, tileWidth, tileHeight);
options.CadOptions.Tiles.Add(tile);
 
pointX += tileWidth;
tile = new Tile(pointX, pointY, tileWidth, tileHeight);
options.CadOptions.Tiles.Add(tile);
// The pages list will contain four images, one for each quarter
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
     Console.WriteLine("Page number: {0}", page.PageNumber); 
     Stream imageContent = page.Stream;
}
```

#### How tiled rendering works with other CAD options

When the tiled rendering is enabled, (i.e CadOptions.Tiles list is not empty) RenderLayouts and LayoutName properties of CadOptions class are ignored (only the Model is rendered). If you are setting the size of the document manually, using CadOptions.ScaleFactor or CadOptions.Width and CadOptions.Height properties, please pass the same parameters to the GetDocumentInfo method to get correct document overall size as shown in the example below.

**Rendering by coordinates when setting output size manually (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.dwg";
 
 //Set same ScaleFactor or Width and Height properties as used for GetPages method
DocumentInfoOptions docInfoOptions =  new DocumentInfoOptions();
docInfoOptions.CadOptions.ScaleFactor = 100;
// Get width and height
DocumentInfoContainer docInfo = imageHandler.GetDocumentInfo(guid, docInfoOptions);
int width = docInfo.Pages[0].Width;
int height = docInfo.Pages[0].Height;
 
// Set tile width and height as a half of image total width
int tileWidth = width / 2;
int tileHeight = height / 2;
 
int pointX = 0;
int pointY = 0;
//Create image options and add tile
ImageOptions options = new ImageOptions();
options.CadOptions.ScaleFactor = 100;
Tile tile = new Tile(pointX, pointY, tileWidth, tileHeight);
options.CadOptions.Tiles.Add(tile);
 
// The pages list will contain four images, one for each quarter
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
     Console.WriteLine("Page number: {0}", page.PageNumber); 
     Stream imageContent = page.Stream;
}
```

### Known issues with rendering CAD documents

#### Running .Net 4.5 executables (and higher)  as 32-bit process

When you are rendering CAD documents using GroupDocs.Viewer from your .Net application that has a framework 4.5 and higher on 64-bit windows systems, and you have "Preffer 32-bit" option turned on (checked) in your project options in Visual Studio, rendering may continue without termination. To resolve the issue switch "Preffer 32-bit" option off (uncheck)  from your project options in Visual Studio.

The same issue appears when you are running Web Application from IIS Express 32-bit version, using Visual Studio. To resolve the issue, set "Use 64 bit version of IIS Express for websites and projects" option on (check) in Web Projects subsection of the Project and Solutions section in Visual Studio options.

This issue is reproducible since the version 18.6.

### Managing text overflow when rendering Cells documents to HTML

Since the version 18.6, rendering into HTML with TextOverflowMode.Overlay has been improved. Before version 18.6 text from both cells (that is overlaying and that is overlayed) was visible. Since the version 18.6 only text from overlaying cell is visible and text that is overlayed is hidden.

### List of Changes in v18.6

#### GroupDocs.Viewer.Config.ViewerConfig

##### **Public string CacheFolderName property accepts an empty string**

CacheFolderName property sets the folder inside StoragePath directory, that will be used for keeping cache files. This property is ignored when CachePath property value is set.

Since the version 18.6, it is possible to set the empty string for CacheFolderName property of the ViewerConfig object. Previously, property setter (mutator) was replacing empty string value with the string "temp". 

##### **Public bool ForcePasswordValidation property has been added.**

Use this property to force password validation for protected documents each time document is rendered. The default value for the option is false.

#### GroupDocs.Viewer.Converter.Options.HtmlOptions

##### public bool IsResourcesEmbedded is set obsolete

This property will be removed in version 18.9, please use EmbedResources property instead.

##### public bool EmbedResources property added

Use this property as a replacement for IsResourceEmbedded property, for indicating whether to embed resources (fonts, images and CSS) into HTML or save them as separate resource files.

**Setting resources to be saved as separate files (C#) (since the v18.6)**

```csharp
string guid = "document.docx";
 
// Setup GroupDocs.Viewer config with cache enabled
ViewerConfig config = new ViewerConfig();
config.EnableCaching = true; 
 
// Pass configurations to ViewerHandler and get output pages
ViewerImageHandler handler = new ViewerImageHandler(config); 
 
// Initialize HtmlOptions object and set resources not to be embedded
HtmlOptions options = new HtmlOptions();
options.EmbedResources = false;
 
// Pass HtmlOptions object to GetPages method of the ViewerHandler
List<PageImage> pages = handler.GetPages(guid, options); 
```

**(C#) (before v18.6)**

```csharp
string guid = "document.docx";
  
// Setup GroupDocs.Viewer config with cache enabled
ViewerConfig config = new ViewerConfig();
config.EnableCaching = true; 
 
// Pass configurations to ViewerHandler and get output pages
ViewerImageHandler handler = new ViewerImageHandler(config); 
 
 
// Initialize HtmlOptions object and set resources not to be embedded
HtmlOptions options = new HtmlOptions();
options.IsResourcesEmbedded = false;
 
 
// Pass HtmlOptions object to GetPages method of the ViewerHandler
List<PageImage> pages = handler.GetPages(guid, options); 
```
