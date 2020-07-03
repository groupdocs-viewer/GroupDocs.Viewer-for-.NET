---
id: groupdocs-viewer-for-net-19-4-release-notes
url: viewer/net/groupdocs-viewer-for-net-19-4-release-notes
title: GroupDocs.Viewer for .NET 19.4 Release Notes
weight: 8
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 19.4{{< /alert >}}

## Major Features

There are 14 features, improvements, and fixes in this regular monthly release. The most notable are:

*   Added cdr file formats support
*   Ability to render files contained in zip archives
*   Extended support for loading fonts from custom folders for vector image formats

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1940 | Add cdr file format support | Feature |
| VIEWERNET-1859 | Option for rendering content of the specified folder in the zip archive | Feature |
| VIEWERNET-1861 | Possibility to render files contained in zip archives as attachments | Feature |
| VIEWERNET-1846 | Extend support for ViewerConfig.FontDirectories setting to vector image formats | Improvement |
| VIEWERNET-1857 | Rending attachments from password protected zip archives | Improvement |
| VIEWERNET-23 | Exception: Value does not fall within the expected range | Bug |
| VIEWERNET-51 | Some characters are missing when rendering PDF as Html | Bug |
| VIEWERNET-203 | Invalid Printable HTML  for MS Project documents with several pages  | Bug |
| VIEWERNET-225 | Missing characters when rendering PDF document as HTML | Bug |
| VIEWERNET-1227 | License is not applied in Unit Test project | Bug |
| VIEWERNET-1939 | ArchiveDocumentInfoContainer.Folders doesn't return the list of folders | Bug |
| VIEWERNET-1977 |  Values in the form fields are missing when rendering PDF into HTML | Bug |
| VIEWERNET-1966 | First page of ODT documents is not rendering | Bug |
| VIEWERNET-1975 | Metered related exception when License is initialized with other GroupDocs products | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 19.4. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

Since the version19.4 files contained in archives (e.g. inside zip, tar formats) can be obtained through the *GetFile()* method as shown in examples below.

**C# (Obtaining attachment from document that is stored on the disk)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create image handler object
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
// Create attachment object 
Attachment attachment = new Attachment("attachment.zip", "foldername\document.docx", "document.docx");

// Get attachment original file and print out Stream length
using (FileContainer fileContainer = imageHandler.GetFile(attachment))
{
	Console.WriteLine("Attach stream lenght: {0}", fileContainer.Stream.Length);
}
```

**C# (Obtaining attachment from document's stream)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create image handler object
ViewerImageHandler imageHandler = new ViewerImageHandler(config);

// Create attachment object and print out its name and file type
Attachment attachment = new Attachment("attachment.zip", "foldername\document.docx", "document.docx");
Console.WriteLine("Attach name: {0}, Type: {1}", attachment.Name, attachment.FileType);

// Get attachment original file using document stream
using (FileStream fileStream = new FileStream("attachment.zip", FileMode.Open))
using (FileContainer fileContainer = imageHandler.GetFile(fileStream, attachment))
{
	Console.WriteLine("Attach stream lenght: {0}", fileContainer.Stream.Length);
}
```

### GroupDocs.Viewer.Handler.Cache.ICacheDataHandler

#### public DateTime? GetLastModificationDate method has been removed

This property has been removed. GroupDocs.Viewer will no longer rely on document last modification date while caching or retrieving render results from cache.

### GroupDocs.Viewer.Handler.ViewerHtmlHandler

#### public ViewerHtmlHandler(ViewerConfig viewerConfig, CultureInfo cultureInfo) constructor has been removed

This constructor has been removed. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, CultureInfo cultureInfo) constructor has been removed

This constructor has been removed. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, CultureInfo cultureInfo) constructor has been removed

This constructor has been removed. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerHtmlHandler(IFileStorage fileStorage, CultureInfo cultureInfo) constructor has been removed

This constructor has been removed. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerHtmlHandler(ViewerConfig viewerConfig, IFileStorage fileStorage, CultureInfo cultureInfo) constructor has been removed

This constructor has been removed. Please, instead, use the constructors that do not have CultureInfo argument.

### GroupDocs.Viewer.Handler.ViewerImageHandler

#### public ViewerImageHandler(ViewerConfig viewerConfig, CultureInfo cultureInfo) constructor has been removed

This constructor has been removed. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, CultureInfo cultureInfo) constructor has been removed

This constructor has been removed. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, CultureInfo cultureInfo) constructor has been removed

This constructor has been removed. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerImageHandler(IFileStorage fileStorage, CultureInfo cultureInfo) constructor has been removed

This constructor has been removed. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerImageHandler(ViewerConfig viewerConfig, IFileStorage fileStorage, CultureInfo cultureInfo) constructor has been removed

This constructor has been removed. Please, instead, use the constructors that do not have CultureInfo argument.

### GroupDocs.Viewer.Localization.ILocalizationHandler

#### public interface ILocalizationHandler has been removed

This interface is obsolete and has been removed. The exception localization feature no longer provided.

### GroupDocs.Viewer.Localization.LocalizedStringKeys

#### public static class LocalizedStringKeys and all its members have been removed

This class and its members are obsolete and have been removed. The exception localization feature no longer provided.
