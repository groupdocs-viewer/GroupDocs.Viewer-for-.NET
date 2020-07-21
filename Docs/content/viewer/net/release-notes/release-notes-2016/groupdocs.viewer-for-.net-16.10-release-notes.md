---
id: groupdocs-viewer-for-net-16-10-release-notes
url: viewer/net/groupdocs-viewer-for-net-16-10-release-notes
title: GroupDocs.Viewer For .NET 16.10 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}
This page contains release notes for [GroupDocs.Viewer for .NET 16.10.0](http://downloads.groupdocs.com/viewer/net/new-releases/groupdocs.viewer-for-.net-16.10.0/).
{{< /alert >}}

## Major Features

There are 1 new feature and 8 improvements and fixes in this regular monthly release. The most notable are: 
*   Improved rendering Slides documents by removing embedded audios
*   Improved extracting document information
*   MOBI file format viewing support
*   Fixed rendering of DWG documents which were rendered into small image or into image with dots

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-888 | Mobi format support | New Feature |
| VIEWERNET-913 | Remove embedded audios from presentation | Improvement |
| VIEWERNET-942 | Invalid rendering of DWG file into Image or HTML | Bug |
| VIEWERNET-922 | GetDocumentInfo() method is throwing exception | Bug |
| VIEWERNET-918 | Failed to load XPS file in evaluation mode | Bug |
| VIEWERNET-910 | Dwg document is rendered into small image. | Bug |
| VIEWERNET-905 | Invalid rendering of DWG file into HTML and Image | Bug |
| VIEWERNET-798 | SheetRender.GetPageSize throws an exception when sheet is empty. | Bug |
| VIEWERNET-417 | FormattedText does not return TextWidth for Japanese characters. | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 16.10.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

1.  Rename classes which names start with AutoCad to Cad
    1.  Class *GroupDocs.Viewer.Domain.DocumentTypeFormat* constant *AUTOCAD\_DRAWING\_FILE\_FORMAT* **value changed** to *"CAD Drawing File Format"*
    2.  Class *GroupDocs.Viewer.Domain.DocumentTypeFormat* constant *AUTOCAD\_DRAWING\_FILE\_FORMAT* **name  changed** to *CAD\_DRAWING\_FILE\_FORMAT*
2.  Mobi format support
    1.  Class *GroupDocs.Viewer.Domain.DocumentTypeFormat* **constant added** *public const string MOBIPOCKET = "Mobipocket"*
