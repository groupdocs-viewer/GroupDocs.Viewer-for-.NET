---
id: groupdocs-viewer-for-net-19-2-release-notes
url: viewer/net/groupdocs-viewer-for-net-19-2-release-notes
title: GroupDocs.Viewer for .NET 19.2 Release Notes
weight: 11
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 19.2.{{< /alert >}}

## Major Features

There are 11 features, improvements and fixes in this regular monthly release. The most notable are:

*   Added Zip and Tar file formats support
*   Extended support for **CellsOptions.TextOverflowMode** option for rendering into image and PDF
*   Resolved watermarking issues when rendering into HTML

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1883 | Add tar file format support | Feature |
| VIEWERNET-1854 | Add zip file format support | Feature |
| VIEWERNET-1852 | Improve performance for rendering PSD image format into PDF | Improvement |
| VIEWERNET-1853 | Improve rendering Dicom, Dng and WebP formats into PDF | Improvement |
| VIEWERNET-1867 | Extend support for CellsOptions.TextOverflowMode option for rendering into image | Improvement |
| VIEWERNET-1868 | Extend support for CellsOptions.TextOverflowMode option for rendering into PDF | Improvement |
| VIEWERNET-1830 | Output extension is empty when saving HTML page into cache | Bug |
| VIEWERNET-1855 | Object null reference exception when rendering DWG document | Bug |
| VIEWERNET-1886 | Watermark opacity set twice when rendering as HTML | Bug |
| VIEWERNET-1887 | Separator is wrong for the opacity value | Bug |
| VIEWERNET-166 | Unable to render .xls file | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 19.2. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### GroupDocs.Viewer.Config.ViewerConfig

#### public string LocalesPath property compilation set to fail

This property is obsolete and will be removed after version 19.2. GroupDocs.Viewer no longer provides localization supports.

### GroupDocs.Viewer.Converter.Options.ImageOptions

#### public string FileExtension property compilation set to fail

This property is obsolete and will be removed after version 19.2.

### GroupDocs.Viewer.Handler.ViewerHtmlHandler

#### public ViewerHtmlHandler(ViewerConfig viewerConfig, CultureInfo cultureInfo) constructor has been set as obsolete

This constructor is obsolete and will be removed after version 19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, CultureInfo cultureInfo) constructor has been set as obsolete

This constructor is obsolete and will be removed after version 19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerHtmlHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, CultureInfo cultureInfo) constructor has been set as obsolete

This constructor is obsolete and will be removed after version 19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerHtmlHandler(IFileStorage fileStorage, CultureInfo cultureInfo) constructor has been set as obsolete

This constructor is obsolete and will be removed after version 19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerHtmlHandler(ViewerConfig viewerConfig, IFileStorage fileStorage, CultureInfo cultureInfo) constructor has been set as obsolete

This constructor is obsolete and will be removed after version 19.3. Please, instead, use the constructors that do not have CultureInfo argument.

### GroupDocs.Viewer.Handler.ViewerImageHandler

#### public ViewerImageHandler(ViewerConfig viewerConfig, CultureInfo cultureInfo) constructor has been set obsolete

This constructor is obsolete and will be removed after version 19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, CultureInfo cultureInfo) constructor has been set obsolete

This constructor is obsolete and will be removed after version 19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerImageHandler(ViewerConfig viewerConfig, IInputDataHandler inputDataHandler, ICacheDataHandler cacheDataHandler, CultureInfo cultureInfo) constructor has been set obsolete

This constructor is obsolete and will be removed after version 19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerImageHandler(IFileStorage fileStorage, CultureInfo cultureInfo) constructor has been set obsolete

This constructor is obsolete and will be removed after version 19.3. Please, instead, use the constructors that do not have CultureInfo argument.

#### public ViewerImageHandler(ViewerConfig viewerConfig, IFileStorage fileStorage, CultureInfo cultureInfo) constructor has been set obsolete

This constructor is obsolete and will be removed after version 19.3. Please, instead, use the constructors that do not have CultureInfo argument.

### GroupDocs.Viewer.Localization.ILocalizationHandler

#### public interface ILocalizationHandler compilation is set to fail

This interface is obsolete and will be removed after version 19.2. The exception localization feature no longer provided.

### GroupDocs.Viewer.Localization.LocalizedStringKeys

#### public static class LocalizedStringKeys and all its members have been set obsolete

This class and its members are obsolete and will be removed after version 19.2. The exception localization feature no longer provided.
