---
id: groupdocs-viewer-for-net-18-7-release-notes
url: viewer/net/groupdocs-viewer-for-net-18-7-release-notes
title: GroupDocs.Viewer for .NET 18.7 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 18.7.{{< /alert >}}

## Major Features

There are 9 features, improvements, and fixes in this regular monthly release. The most notable are:

*   Added ISFF-based DGN (V7) file format support
*   Improved output content for printable HTML
*   Extended DefaultFontName setting support for ODG, SVG and MetaFile Images

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1475 | Add ISFF-based DGN (V7) file format support | New Feature |
| VIEWERNET-1651 | Extend DefaultFontName setting support for ODG, SVG and MetaFile Images | Improvement |
| VIEWERNET-1637 | Improve output content for printable HTML | Improvement |
| VIEWERNET-1586 | Support empty string for ViewerConfig.PageNamePrefix property | Improvement |
| VIEWERNET-1567 | Improve compression for rendering into HTML with EnableMinification setting | Improvement |
| VIEWERNET-1657 | DOCX to HTML pages - all HTML pages use CSS class names from first page | Bug |
| VIEWERNET-1646 | API generates 5 pages with repeated content when rendering single page email message | Bug |
| VIEWERNET-1542 | Invalid styles when rendering presentation documents into HTML | Bug |
| VIEWERNET-1498 | Issues when printing printable Html or saving as PDF | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 18.7. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}{{< alert style="warning" >}}IMPORTANT: Please note that due to the change in the structure of GroupDocs.Viewer.Domain.AttachmentBase class, it is necessary to clear the cache after upgrading to the version 18.7 if you were using cache based rendering before and working with document attachments (that may exist in email and PDF document formats){{< /alert >}}

### List of Changes in v18.7

In the version 18.7 following public class members were added, marked as obsolete, removed or replaced:

#### GroupDocs.Viewer.Config.ViewerConfig

##### **Public string PageNamePrefix property accepts the empty string**

PageNamePrefix property is used for adding prefixes to output file names in the cache. The default implementation of CacheDataHandler is using "page" as the prefix. Output HTML files are named page1.html, page2.html and so on, resources folders are named page1, page2 and so on, output image files are named page1.png, page2.png and so on. Since the version 18.7, it is possible to set the empty string for PageNamePrefix property, then default CacheDataHandler will name this files and folder correspondingly 1.html, 2.html and so on, resource folder names 1, 2 and so on, output image files 1.png, 2.png and so on.

##### Public bool UseCache property compilation is set to fail

This property will be removed in version 18.8, please use EnableCaching property instead.

#### GroupDocs.Viewer.Domain.Attachment

##### Public Attachment(string sourceDocumentGuid, string attachmentID, string name, long size) new constructor has been added

This constructor is used to initialize attachments that have ID not matching with attachment name. Email documents can have attachments that have same file names and, in that case, ID of the attachment will be different from attachment name.

##### Public Attachment(string sourceDocumentGuid, string attachmentID, string name) new constructor has been added

This constructor is used to initialize attachments that have ID not matching with attachment name. Email documents can have attachments that have same file names, in that case, ID of the attachment will be different from attachment name.

#### GroupDocs.Viewer.Domain.AttachmentBase

##### Public string ID property has been added

This ID property is used to distinguish between email attachments, that have the same name. In cases when all attachments in email and PDF documents have unique names, ID is equal to Name property.

#### GroupDocs.Viewer.Exception.CacheFileNotFoundException

##### GroupDocs.Viewer.Exception.CacheFileNotFoundException class compilation set to fail

This exception is obsolete. GroupDocs.Viewer will start throwing System.IO.FileNotFoundException instead of CacheFileNotFoundException in version v18.7 and next versions.

#### GroupDocs.Viewer.Exception.GuidNotSpecifiedException

##### GroupDocs.Viewer.Exception.GuidNotSpecifiedException class compilation is set to fail

This exception is obsolete. GroupDocs.Viewer will start throwing System.ArgumentNullException instead of GuidNotSpecifiedException in version v18.7 and next versions.

#### GroupDocs.Viewer.Exception.StoragePathNotSpecifiedException

##### GroupDocs.Viewer.Exception.StoragePathNotSpecifiedException class compilation is set to fail

This exception is obsolete and will be removed in v18.8.

#### GroupDocs.Viewer.Handler.Cache.ICacheDataHandler

##### void ClearCache(TimeSpan olderThan) method compilation is set to fail

This method is obsolete and will be removed in v18.8

##### void ClearCache() method has been added

Use this method to clear all the data from cache.

#### GroupDocs.Viewer.Handler.ViewerHtmlHandler

##### public void ClearCache(TimeSpan olderThan) method compilation is set to fail 

Please use *public void ClearCache()* or *public void ClearCache(string guid)* methods instead.

#### GroupDocs.Viewer.Handler.ViewerImageHandler

##### public void ClearCache(TimeSpan olderThan) method compilation is set to fail 

Please use *public void ClearCache()* or *public void ClearCache(string guid)* methods instead.
