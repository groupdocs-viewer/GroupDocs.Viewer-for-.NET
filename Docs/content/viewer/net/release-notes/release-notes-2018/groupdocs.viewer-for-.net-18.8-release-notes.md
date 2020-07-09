---
id: groupdocs-viewer-for-net-18-8-release-notes
url: viewer/net/groupdocs-viewer-for-net-18-8-release-notes
title: GroupDocs.Viewer for .NET 18.8 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 18.8.{{< /alert >}}

## Major Features

There are 15 features, improvements, and fixes in this regular monthly release. The most notable are:

*   Reduce count of calls to storage
*   Extend DefaultFontName setting support for MS Project documents
*   Time interval option for rendering MS Project documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1447 | Time interval option for rendering MS Project documents | New feature |
| VIEWERNET-1698 | Security improvements | Improvement |
| VIEWERNET-1685 | Rendering comments from Presentation documents into images when ExtractText option is enabled | Improvement |
| VIEWERNET-1670 | Retrieve list of resources only when loading page from cache | Improvement |
| VIEWERNET-1669 | Reduce count of calls to storage methods | Improvement |
| VIEWERNET-1664 | Extend support for DefaultFontName option for MS Project documents rendering to image and HTML | Improvement |
| VIEWERNET-1658 | Add ForcePasswordValidation configuration via configs | Improvement |
| VIEWERNET-1594 | Extend support for rendering comments from ODP document format | Improvement |
| VIEWERNET-1697 | Deadlock when rendering documents in multiple processes | Bug |
| VIEWERNET-1687 | An exception raises while retrieving HTML pages from the source document | Bug |
| VIEWERNET-1684 | Relative and absolute resource paths in the same HTML page | Bug |
| VIEWERNET-1682 | Exception when the file name contains curly braces | Bug |
| VIEWERNET-1465 | Legend is shifted and incorrect formatting when rendering PPTX as HTML | Bug |
| VIEWERNET-1462 | Incorrect font when rendering PPTX as HTML | Bug |
| VIEWERNET-935 | Incorrect character position in HTML mode in Safari for iOS | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 18.8. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Rendering part of the MS Project with the specified time interval

Since the version 18.8, GroupDocs.Viewer API allows rendering part of MS Project document according to specified StartDate and EndDate properties of ProjectOptions class as shown in examples below. When only one of these properties is set, rendering starts from the project's start date or ends on the project's end date correspondingly.

**Setting time interval for rendering part of MS Project document (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.mpp";
  
// Set Project options to render tasks from year 2018 only.
ImageOptions options = new ImageOptions();
options.ProjectOptions.StartDate = new DateTime(2018, 01, 01);
options.ProjectOptions.EndDate = new DateTime(2018, 12, 31);
 
// Get pages 
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
     Console.WriteLine("Page number: {0}", page.PageNumber); 
     Stream imageContent = page.Stream;
}
```

**Get PDF representation of MS Project documents with specified start and end dates (C#)**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.mpp";
  
// Set Project options to render tasks from year 2018 only.
PdfFileOptions options = new PdfFileOptions();
options.ProjectOptions.StartDate = new DateTime(2018, 01, 01);
options.ProjectOptions.EndDate = new DateTime(2018, 12, 31);
 
// Get PDF file 
FileContainer fileContainer = imageHandler.GetPdfFile(guid, options);
 
// Access PDF file stream.
Stream pdfFileStream = fileContainer.Stream;
```

### Changes in sample configuration files 

Since the version 18.8, it is possible to set ForcePasswordValidation property of the ViewerConfig class using app.config / web.config configuration files. UseCache property of the ViewerConfig class became  obsolete and has been removed, therefore <useCache value="bool"/> element is no longer valid. Due to recent changes, valid app.config / web.config is as below:

**Sample app.config with correct GroupDocs.Viewer configurations**

```csharp
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <configSections>
      <section name="groupdocs.viewer" type="GroupDocs.Viewer.Config.GroupDocsViewerSection, GroupDocs.Viewer"/>
    </configSections>
    <startup>         
      <supportedRuntime version="v2.0.50727"/>
    </startup>
    <groupdocs.viewer>
      <storagePath value="C:\storage"/>
      <cacheFolderName value="cachefolder"/>
      <cachePath value="C:\cache"/>
      <enableCaching value="true"/>
      <localesPath value="C:\locales"/>
      <pageNamePrefix value="prefix"/>
      <forcePasswordValidation value="true"/>
      <fontDirectories>
        <add path="C:\fonts" />
        <add path="C:\more_fonts" />
      </fontDirectories>
    </groupdocs.viewer>
</configuration>
```

### List of Changes in v18.8

In the version 18.8, following public class members were added, marked as obsolete, removed or replaced:

#### GroupDocs.Viewer.Config.ViewerConfig

##### Public bool UseCache property compilation is set to fail

This property has been removed, please use EnableCaching property instead.

#### GroupDocs.Viewer.Converter.Options.ProjectOptions

##### Public DateTime StartDate property added

Use this property to set starting date from which the rendering should begin.

##### Public DateTime EndDate property added

Use this property to set end date from which the rendering should end.

#### GroupDocs.Viewer.Exception.CacheFileNotFoundException

##### GroupDocs.Viewer.Exception.CacheFileNotFoundException class has been removed

This exception is obsolete and has been removed. GroupDocs.Viewer is throwing System.IO.FileNotFoundException instead of CacheFileNotFoundException since version v18.7 and next versions.

#### GroupDocs.Viewer.Exception.GuidNotSpecifiedException

##### GroupDocs.Viewer.Exception.GuidNotSpecifiedException class has been removed

This exception is obsolete and has been removed. GroupDocs.Viewer will is throwing System.ArgumentNullException instead of GuidNotSpecifiedException since version v18.7 and next versions.

#### GroupDocs.Viewer.Exception.StoragePathNotSpecifiedException

##### GroupDocs.Viewer.Exception.StoragePathNotSpecifiedException class has been removed

This exception is obsolete and has been removed.

#### GroupDocs.Viewer.Handler.Cache.ICacheDataHandler

##### void ClearCache(TimeSpan olderThan) method has been removed

This method is obsolete and has been removed.

#### GroupDocs.Viewer.Handler.Input.IInputDataHandler

##### DateTime GetLastModificationDate(string guid) method marked as obsolete

This method is obsolete and will be removed after v18.10. GroupDocs.Viewer will rely on LastModificationDate field in FileDescription object returned by GetFileDescription method.

#### GroupDocs.Viewer.Handler.ViewerHtmlHandler

##### public void ClearCache(TimeSpan olderThan) method has been removed

Please use *public void ClearCache()* or *public void ClearCache(string guid) * methods instead.

#### GroupDocs.Viewer.Handler.ViewerImageHandler

##### public void ClearCache(TimeSpan olderThan) method has been removed

Please use *public void ClearCache()* or *public void ClearCache(string guid) * methods instead.
