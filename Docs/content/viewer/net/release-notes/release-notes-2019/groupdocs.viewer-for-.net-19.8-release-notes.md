---
id: groupdocs-viewer-for-net-19-8-release-notes
url: viewer/net/groupdocs-viewer-for-net-19-8-release-notes
title: GroupDocs.Viewer for .NET 19.8 Release Notes
weight: 5
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 19.8{{< /alert >}}

## Major Features

{{< alert style="danger" >}}In this version we're introducing new public API which was designed to be simple and easy to use. For more details about new API please check Public Docs section. The legacy API have been moved into Legacy namespace so after update to this version it is required to make project-wide replacement of namespace usages from GroupDocs.Viewer. to GroupDocs.Viewer.Legacy. to resolve build issues.{{< /alert >}}

  
Other notable features:

*   Added support of rendering custom folders from Outlook Data Files
*   Added support of file formats:
    *   Microsoft Excel Add-in (.xlam) 
    *   Microsoft Project Exchange File (.mpx)

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-2038 | Add Microsoft Excel Add-in (.xlam) file format support | Feature |
| VIEWERNET-2039 | Add Microsoft Project Exchange File (.mpx) file format support | Feature |
| VIEWERNET-2076 | New public API | Feature |
| VIEWERNET-1998 | Rendering custom folders from Outlook Data Files | Improvement |
| VIEWERNET-2079 | SVG files are always embedded into resulting HTML | Bug |

## Public API and Backward Incompatible Changes

### All public types from GroupDocs.Viewer namespace are moved and marked as obsolete

#### All public types from GroupDocs.Viewer namespace 

1.  Have been moved into **GroupDocs.Viewer.Legacy** namespace
2.  Marked as **Obsolete** with message: *This interface/class/enumeration is obsolete and will be available till January 2020 (v20.1).*

#### Full list of types that have been moved and marked as obsolete:
1.  GroupDocs.Viewer.Storage.FileInfo => GroupDocs.Viewer.Legacy.Storage.FileInfo    
2.  GroupDocs.Viewer.Storage.IFileInfo => GroupDocs.Viewer.Legacy.Storage.IFileInfo    
3.  GroupDocs.Viewer.Storage.IFileStorage => GroupDocs.Viewer.Legacy.Storage.IFileStorage    
4.  GroupDocs.Viewer.Storage.LocalFileStorage => GroupDocs.Viewer.Legacy.Storage.LocalFileStorage    
5.  GroupDocs.Viewer.Handler.ViewerHandler<T> => GroupDocs.Viewer.Legacy.Handler.ViewerHandler<T>    
6.  GroupDocs.Viewer.Handler.ViewerHtmlHandler => GroupDocs.Viewer.Legacy.Handler.ViewerHtmlHandler    
7.  GroupDocs.Viewer.Handler.ViewerImageHandler => GroupDocs.Viewer.Legacy.Handler.ViewerImageHandler    
8.  GroupDocs.Viewer.Handler.Input.IInputDataHandler => GroupDocs.Viewer.Legacy.Handler.Input.IInputDataHandler    
9.  GroupDocs.Viewer.Handler.Cache.ICacheDataHandler => GroupDocs.Viewer.Legacy.Handler.Cache.ICacheDataHandler    
10.  GroupDocs.Viewer.Exception.GroupDocsViewerException => GroupDocs.Viewer.Legacy.Exception.GroupDocsViewerException    
11.  GroupDocs.Viewer.Exception.TransformationFailedPageNotExistException => GroupDocs.Viewer.Legacy.Exception.TransformationFailedPageNotExistException    
12.  GroupDocs.Viewer.Exception.InvalidPasswordException => GroupDocs.Viewer.Legacy.Exception.InvalidPasswordException    
13.  GroupDocs.Viewer.Exception.CorruptedOrDamagedFileException => GroupDocs.Viewer.Legacy.Exception.CorruptedOrDamagedFileException    
14.  GroupDocs.Viewer.Exception.FileTypeNotSupportedException => GroupDocs.Viewer.Legacy.Exception.FileTypeNotSupportedException    
15.  GroupDocs.Viewer.Exception.PasswordProtectedFileException => GroupDocs.Viewer.Legacy.Exception.PasswordProtectedFileException    
16.  GroupDocs.Viewer.Domain.ArchiveFileData => GroupDocs.Viewer.Legacy.Domain.ArchiveFileData    
17.  GroupDocs.Viewer.Domain.CadLayer => GroupDocs.Viewer.Legacy.Domain.CadLayer    
18.  GroupDocs.Viewer.Domain.PdfFileData => GroupDocs.Viewer.Legacy.Domain.PdfFileData    
19.  GroupDocs.Viewer.Domain.OutlookFileData => GroupDocs.Viewer.Legacy.Domain.OutlookFileData    
20.  GroupDocs.Viewer.Domain.ProjectFileData => GroupDocs.Viewer.Legacy.Domain.ProjectFileData    
21.  GroupDocs.Viewer.Domain.Attachment => GroupDocs.Viewer.Legacy.Domain.Attachment    
22.  GroupDocs.Viewer.Domain.AttachmentBase => GroupDocs.Viewer.Legacy.Domain.AttachmentBase    
23.  GroupDocs.Viewer.Domain.CadFileData => GroupDocs.Viewer.Legacy.Domain.CadFileData    
24.  GroupDocs.Viewer.Domain.DocumentTypeName => GroupDocs.Viewer.Legacy.Domain.DocumentTypeName    
25.  GroupDocs.Viewer.Domain.FileFormat => GroupDocs.Viewer.Legacy.Domain.FileFormat    
26.  GroupDocs.Viewer.Domain.FileData => GroupDocs.Viewer.Legacy.Domain.FileData    
27.  GroupDocs.Viewer.Domain.Page => GroupDocs.Viewer.Legacy.Domain.Page    
28.  GroupDocs.Viewer.Domain.PageData => GroupDocs.Viewer.Legacy.Domain.PageData    
29.  GroupDocs.Viewer.Domain.RowData => GroupDocs.Viewer.Legacy.Domain.RowData    
30.  GroupDocs.Viewer.Domain.Transformation => GroupDocs.Viewer.Legacy.Domain.Transformation    
31.  GroupDocs.Viewer.Domain.Watermark => GroupDocs.Viewer.Legacy.Domain.Watermark    
32.  GroupDocs.Viewer.Domain.WatermarkPosition => GroupDocs.Viewer.Legacy.Domain.WatermarkPosition    
33.  GroupDocs.Viewer.Domain.WindowsAuthenticationCredential => GroupDocs.Viewer.Legacy.Domain.WindowsAuthenticationCredential    
34.  GroupDocs.Viewer.Domain.FileDescription => GroupDocs.Viewer.Legacy.Domain.FileDescription    
35.  GroupDocs.Viewer.Domain.Image.PageImage => GroupDocs.Viewer.Legacy.Domain.Image.PageImage    
36.  GroupDocs.Viewer.Domain.Html.HtmlResource => GroupDocs.Viewer.Legacy.Domain.Html.HtmlResource    
37.  GroupDocs.Viewer.Domain.Html.HtmlResourceType => GroupDocs.Viewer.Legacy.Domain.Html.HtmlResourceType    
38.  GroupDocs.Viewer.Domain.Html.PageHtml => GroupDocs.Viewer.Legacy.Domain.Html.PageHtml    
39.  GroupDocs.Viewer.Domain.Cache.CachedDocumentDescription => GroupDocs.Viewer.Legacy.Domain.Cache.CachedDocumentDescription    
40.  GroupDocs.Viewer.Domain.Cache.CachedAttachmentDescription => GroupDocs.Viewer.Legacy.Domain.Cache.CachedAttachmentDescription    
41.  GroupDocs.Viewer.Domain.Cache.CacheFileDescription => GroupDocs.Viewer.Legacy.Domain.Cache.CacheFileDescription    
42.  GroupDocs.Viewer.Domain.Cache.CacheFileType => GroupDocs.Viewer.Legacy.Domain.Cache.CacheFileType    
43.  GroupDocs.Viewer.Domain.Cache.CachedPageResourceDescription => GroupDocs.Viewer.Legacy.Domain.Cache.CachedPageResourceDescription    
44.  GroupDocs.Viewer.Domain.Cache.CachedPageDescription => GroupDocs.Viewer.Legacy.Domain.Cache.CachedPageDescription    
45.  GroupDocs.Viewer.Domain.Options.PdfFilePermissions => GroupDocs.Viewer.Legacy.Domain.Options.PdfFilePermissions    
46.  GroupDocs.Viewer.Domain.Options.PdfFileSecurity => GroupDocs.Viewer.Legacy.Domain.Options.PdfFileSecurity    
47.  GroupDocs.Viewer.Domain.Options.FileListOptions => GroupDocs.Viewer.Legacy.Domain.Options.FileListOptions    
48.  GroupDocs.Viewer.Domain.Options.DocumentInfoOptions => GroupDocs.Viewer.Legacy.Domain.Options.DocumentInfoOptions    
49.  GroupDocs.Viewer.Domain.Options.PdfFileOptions => GroupDocs.Viewer.Legacy.Domain.Options.PdfFileOptions    
50.  GroupDocs.Viewer.Domain.Options.PrintableHtmlOptions => GroupDocs.Viewer.Legacy.Domain.Options.PrintableHtmlOptions    
51.  GroupDocs.Viewer.Domain.Options.ReorderPageOptions => GroupDocs.Viewer.Legacy.Domain.Options.ReorderPageOptions    
52.  GroupDocs.Viewer.Domain.Options.RotatePageOptions => GroupDocs.Viewer.Legacy.Domain.Options.RotatePageOptions    
53.  GroupDocs.Viewer.Domain.Containers.ArchiveDocumentInfoContainer => GroupDocs.Viewer.Legacy.Domain.Containers.ArchiveDocumentInfoContainer    
54.  GroupDocs.Viewer.Domain.Containers.PdfDocumentInfoContainer => GroupDocs.Viewer.Legacy.Domain.Containers.PdfDocumentInfoContainer    
55.  GroupDocs.Viewer.Domain.Containers.OutlookDocumentInfoContainer => GroupDocs.Viewer.Legacy.Domain.Containers.OutlookDocumentInfoContainer    
56.  GroupDocs.Viewer.Domain.Containers.ProjectDocumentInfoContainer => GroupDocs.Viewer.Legacy.Domain.Containers.ProjectDocumentInfoContainer    
57.  GroupDocs.Viewer.Domain.Containers.CadDocumentInfoContainer => GroupDocs.Viewer.Legacy.Domain.Containers.CadDocumentInfoContainer    
58.  GroupDocs.Viewer.Domain.Containers.DocumentFormatsContainer => GroupDocs.Viewer.Legacy.Domain.Containers.DocumentFormatsContainer    
59.  GroupDocs.Viewer.Domain.Containers.DocumentInfoContainer => GroupDocs.Viewer.Legacy.Domain.Containers.DocumentInfoContainer    
60.  GroupDocs.Viewer.Domain.Containers.FileContainer => GroupDocs.Viewer.Legacy.Domain.Containers.FileContainer    
61.  GroupDocs.Viewer.Domain.Containers.PrintableHtmlContainer => GroupDocs.Viewer.Legacy.Domain.Containers.PrintableHtmlContainer    
62.  GroupDocs.Viewer.Domain.Containers.FileListContainer => GroupDocs.Viewer.Legacy.Domain.Containers.FileListContainer    
63.  GroupDocs.Viewer.Converter.Options.ArchiveOptions => GroupDocs.Viewer.Legacy.Converter.Options.ArchiveOptions    
64.  GroupDocs.Viewer.Converter.Options.OutlookOptions => GroupDocs.Viewer.Legacy.Converter.Options.OutlookOptions    
65.  GroupDocs.Viewer.Converter.Options.EmailField => GroupDocs.Viewer.Legacy.Converter.Options.EmailField    
66.  GroupDocs.Viewer.Converter.Options.ImageQuality => GroupDocs.Viewer.Legacy.Converter.Options.ImageQuality    
67.  GroupDocs.Viewer.Converter.Options.PageSize => GroupDocs.Viewer.Legacy.Converter.Options.PageSize    
68.  GroupDocs.Viewer.Converter.Options.ProjectOptions => GroupDocs.Viewer.Legacy.Converter.Options.ProjectOptions    
69.  GroupDocs.Viewer.Converter.Options.SlidesOptions => GroupDocs.Viewer.Legacy.Converter.Options.SlidesOptions    
70.  GroupDocs.Viewer.Converter.Options.CadOptions => GroupDocs.Viewer.Legacy.Converter.Options.CadOptions    
71.  GroupDocs.Viewer.Converter.Options.TextOverflowMode => GroupDocs.Viewer.Legacy.Converter.Options.TextOverflowMode    
72.  GroupDocs.Viewer.Converter.Options.EmailOptions => GroupDocs.Viewer.Legacy.Converter.Options.EmailOptions    
73.  GroupDocs.Viewer.Converter.Options.TimeUnit => GroupDocs.Viewer.Legacy.Converter.Options.TimeUnit    
74.  GroupDocs.Viewer.Converter.Options.Tile => GroupDocs.Viewer.Legacy.Converter.Options.Tile    
75.  GroupDocs.Viewer.Converter.Options.WordsOptions => GroupDocs.Viewer.Legacy.Converter.Options.WordsOptions    
76.  GroupDocs.Viewer.Converter.Options.CellsOptions => GroupDocs.Viewer.Legacy.Converter.Options.CellsOptions    
77.  GroupDocs.Viewer.Converter.Options.ConvertImageFileType => GroupDocs.Viewer.Legacy.Converter.Options.PdfOptions    
78.  GroupDocs.Viewer.Converter.Options.HtmlOptions => GroupDocs.Viewer.Legacy.Converter.Options.HtmlOptions    
79.  GroupDocs.Viewer.Converter.Options.ImageOptions => GroupDocs.Viewer.Legacy.Converter.Options.ImageOptions    
80.  GroupDocs.Viewer.Converter.Options.RenderOptions => GroupDocs.Viewer.Legacy.Converter.Options.RenderOptions    
81.  GroupDocs.Viewer.Config.ViewerConfig => GroupDocs.Viewer.Legacy.Config.ViewerConfig