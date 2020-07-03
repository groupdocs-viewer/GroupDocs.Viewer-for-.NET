---
id: groupdocs-viewer-for-net-18-12-release-notes
url: viewer/net/groupdocs-viewer-for-net-18-12-release-notes
title: GroupDocs.Viewer for .NET 18.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 18.12.{{< /alert >}}

## Major Features

There are 9 features, improvements, and fixes in this regular monthly release. The most notable are:

*   Ability to obtain the list of folders contained in Outlook Data Files
*   Setting for specifying the folder to render from Outlook Data Files
*   Improved rendering of CAD and Outlook Data File documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1779 | Obtaining the list of folders contained in OST/PST formats  | Feature |
| VIEWERNET-1780 | Setting for rendering specific folder from OST/PST formats | Feature |
| VIEWERNET-1811 | Ignore empty columns when rendering spreadsheet documents | Feature |
| VIEWERNET-1220 | Ignore empty string when it passed as path to directory with fonts | Improvement |
| VIEWERNET-1820 | Improve rendering into HTML for Outlook Data Files with subfolders and empty folders  | Improvement |
| VIEWERNET-1824 | Set exception localization feature as obsolete | Improvement |
| VIEWERNET-1828 | Prevent rendering frozen and invisible CAD layers by default | Improvement |
| VIEWERNET-150 | PDF contains blank page when rendering XPS to PDF | Bug |
| VIEWERNET-1226 | Issue with the image source when rendering Excel to HTML with embedded resources | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 18.12. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Retrieving the list of Outlook folders

Outlook Data File documents (PST/OST formats) contain folders like Inbox, Sent Items, Deleted Items and so on. These folders, in turn, may contain other folders (subfolders). Since the version 18.12 Groupdocs.Viewer API allows retrieving the list of containing folders. The following examples below show how to retrieve the list of containing folders including subfolders.

**Retrieving the list of root folders from Outlook Data File documents (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create HTML handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "sample.pst";
  
// Get outlook document info
OutlookDocumentInfoContainer documentInfoContainer = htmlHandler.GetDocumentInfo(guid) as OutlookDocumentInfoContainer;
  
foreach (string folderName in documentInfoContainer.Folders)
 Console.WriteLine("Folder name: {0}", folderName);  
```

**Retrieving the list of sub folders from specified folder within Outlook Data File documents (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create HTML handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "sample.pst";
  
// Create option object with specified folder name
DocumentInfoOptions options = new DocumentInfoOptions();
options.OutlookOptions.FolderName = "Inbox";
// Get outlook document info
OutlookDocumentInfoContainer documentInfoContainer = htmlHandler.GetDocumentInfo(guid, options) as OutlookDocumentInfoContainer;
  
foreach (string folderName in documentInfoContainer.Folders)
 Console.WriteLine("Folder name: {0}", folderName); 
```

### Rendering messages from specified folder only

By default, messages from all folders (including nested folders) are rendered. When you need to render items form specific folder, set *FolderName* property of the *OutlookOptions* class as shown in example below. This option is available since version 18.12. Please note that you should use the following convention for naming folders and subfolders to specify it in *FolderName* option: **{Parent folder name}\\\\{Sub folder name}**. Thus, if you need to render items from Inbox folder just specify `FolderName = "Inbox";` when you need to render subfolder named "Orion" that resides in a folder named "Urgent" that in turn resides in Inbox set: `FolderName = "Inbox\\Urgent\\Orion".` The following example shows how to use this option for rendering into HTML, image, and PDF:

**Rendering specified folder into image (or HTML) (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler or use ViewerHtmlHandler to render into HTML
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "sample.pst";
  
// Create image options with specified folder name (use HtmlOptions to render into HTML)
ImageOptions options = new ImageOptions();
options.OutlookOptions.FolderName = "Inbox\\Sub Folder 1";
 
// Render document into image (List<PageHtml> is returned when rendering into HTML)
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
    // use page.Stream to work with rendering result
}
```

**Rendering specified folder into PDF (C#)**

```csharp
 // Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "sample.pst";
  
// Create pdf options with specified folder name
PdfFileOptions options = new PdfFileOptions();
options.OutlookOptions.FolderName = "Inbox";
 
// Get pdf document
FileContainer fileContainer = imageHandler.GetPdfFile(guid, options);
  
// Access result PDF document using fileContainer.Stream property
```

### Ignoring empty columns when rendering Spreadsheet documents

Since version 18.12, along with the option for ignoring empty rows (that exists since the version 17.8.0), Groupdocs.Viewer API supports skipping the rendering for the empty columns. Use this option as shown in the example below:

**Ignoring empty columns when rendering Cells documents. (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create HTML or image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.xlsx";
  
// Set image or html options to skip the rendering for empty columns
ImageOptions options = new ImageOptions();
options.CellsOptions.IgnoreEmptyColumns = true; // default value is false
 
// Get pages 
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
    // Use page.Stream for image or page.HtmlContent for HTML to manipulate the rendering results
}
```

### List of Changes in v18.12

In version 18.12, following public class members were added, marked as obsolete, removed or replaced.

#### GroupDocs.Viewer.Converter.Options.ImageOptions

##### public string FileExtension { get; } property has been set obsolete

Use System.IO.Path.GetExtension(string path) method instead.

#### GroupDocs.Viewer.Converter.Options.OutlookOptions

##### public string FolderName property has been added

Use this option to specify Outlook folders.

#### GroupDocs.Viewer.Domain.Containers.DocumentInfoContainer

##### string DocumentType { get; } property has been removed

This property is obsolete, use FileFormat property instead.

##### string FileType { get; } property has been removed

This property is obsolete, use FileFormat property instead.

##### string DocumentTypeFormat { get; } property has been removed

This property is obsolete, use FileFormat property instead.

#### GroupDocs.Viewer.Domain.FileDescription

##### string BaseName { get; } property has been removed

This property is obsolete, to get base name use following code: System.IO.Path.GetFileNameWithoutExtension(fileDescription.Name).

##### string DocumentType { get; } property has been removed

This property is obsolete, use FileFormat property instead.

##### string FileType { get; } property has been removed

This property is obsolete, use FileFormat property instead.

##### string DocumentTypeFormat { get; } property has been removed

This property is obsolete, use FileFormat property instead.

#### GroupDocs.Viewer.Handler.ViewerHtmlHandler

##### public ViewerHtmlHandler(ViewerConfig viewerConfig, CultureInfo cultureInfo) constructor marked as obsolete

This constructor is obsolete and will be removed after version 19.2.

##### public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, CultureInfo cultureInfo) constructor marked as obsolete

This constructor is obsolete and will be removed after version 19.2.

##### public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, CultureInfo cultureInfo) constructor marked as obsolete

This constructor is obsolete and will be removed after version 19.2.

##### public ViewerHtmlHandler(IFileStorage fileStorage, CultureInfo cultureInfo) constructor marked as obsolete

This constructor is obsolete and will be removed after version 19.2.

##### public ViewerHtmlHandler(ViewerConfig viewerConfig, IFileStorage fileStorage, CultureInfo cultureInfo) constructor marked as obsolete

This constructor is obsolete and will be removed after version 19.2.

#### GroupDocs.Viewer.Handler.ViewerImageHandler

##### public ViewerImageHandler(ViewerConfig viewerConfig, CultureInfo cultureInfo) constructor marked as obsolete

This constructor is obsolete and will be removed after version 19.2.

##### public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, CultureInfo cultureInfo) constructor marked as obsolete

This constructor is obsolete and will be removed after version 19.2.

##### public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, CultureInfo cultureInfo) constructor marked as obsolete

This constructor is obsolete and will be removed after version 19.2.

##### public ViewerImageHandler(IFileStorage fileStorage, CultureInfo cultureInfo) constructor marked as obsolete

This constructor is obsolete and will be removed after version 19.2.

##### public ViewerImageHandler(ViewerConfig viewerConfig, IFileStorage fileStorage, CultureInfo cultureInfo) constructor marked as obsolete

This constructor is obsolete and will be removed after version 19.2.

#### GroupDocs.Viewer.Localization.ILocalizationHandler

##### public interface ILocalizationHandler marked as obsolete

This interface is obsolete and will be removed after version 19.2.

##### string GetString(string key) method marked as obsolete

This method is obsolete and will be removed after version 19.2.

#### GroupDocs.Viewer.Localization.LocalizedStringKeys

##### public static class LocalizedStringKeys marked as obsolete

This class and all of it constants are obsolete and will be removed after version 19.2.
