---
id: groupdocs-viewer-for-net-16-12-0-release-notes
url: viewer/net/groupdocs-viewer-for-net-16-12-0-release-notes
title: GroupDocs.Viewer For .NET 16.12.0 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 16.12.0.{{< /alert >}}

## Major Features

There are 2 new features and 9 improvements and fixes in this regular monthly release. The most notable are:

*   WebP (Image format) file format viewing support
*   OTS (OpenDocument Spreadsheet Template) file format viewing support
*   Current directory is used as storage path when storage path is not specified in ViewerConfig
*   Implemented responsive HTML output for Slides documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-996 | OTS format support | New Feature |
| VIEWERNET-971 | WebP file format support | New Feature |
| VIEWERNET-1020 | Use current directory when storage path is not specified | Improvement |
| VIEWERNET-934 | Implement responsive html output for Slides documents | Improvement |
| VIEWERNET-1027 | Different exception messages for password encrypted Word document | Bug |
| VIEWERNET-993 | Failed to load SAI image | Bug |
| VIEWERNET-976 | Large scrollbars when viewing pdf converted to html with embedded resources in IE Edge | Bug |
| VIEWERNET-962 | IE Edge displays large scrollbars for generated HTML | Bug |
| VIEWERNET-953 | Failed to load Tex file from stream | Bug |
| VIEWERNET-947 | Failed to load XCF file | Bug |
| VIEWERNET-941 | Position of graph lines is not correct in output HTML or image file | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 16.12.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### File Format Support

1.  OTS format
2.  WebP file format

### Investigate EMLX format support

###### Public API changes:

class *GroupDocs.Viewer.Domain.DocumentTypeFormat* new constant added *public const string APPLE\_MAIL = "Apple Mail";*
