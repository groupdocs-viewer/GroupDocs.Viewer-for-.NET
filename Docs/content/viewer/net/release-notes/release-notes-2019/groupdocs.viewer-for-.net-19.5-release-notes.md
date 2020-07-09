---
id: groupdocs-viewer-for-net-19-5-release-notes
url: viewer/net/groupdocs-viewer-for-net-19-5-release-notes
title: GroupDocs.Viewer for .NET 19.5 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
## Major Features

There are 12 features, improvements and fixes in this regular monthly release. The most notable are:

*   Added support of file formats:
    *   Device Independent Bitmap File (.dib)
    *   Microsoft PowerPoint Template (.pot) 
    *   Bzip2 Compressed File (.bz2)
*   Ability to obtain files (attachments) contained in password protected documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1896 | Add Device Independent Bitmap File (.dib) file format support | Feature |
| VIEWERNET-1897 | Add PowerPoint template (.pot) file format support | Feature |
| VIEWERNET-1987 | Implement obtaining contained files (attachments) from password protected documents | Feature |
| VIEWERNET-1999 | Add .vcard file format support | Feature |
| VIEWERNET-2004 | Add bz2 archive format support | Feature |
| VIEWERNET-1932 | Extend support for ViewerConfig.FontDirectories setting to SVG format | Improvement |
| VIEWERNET-1770 | Issue with rendering PCL documents | Bug |
| VIEWERNET-1834 | ViewerHtmlHandler.GetPages produces exception with custom fonts directory option | Bug |
| VIEWERNET-1849 | PDF to HTML rendering throws "Stack empty" exception | Bug |
| VIEWERNET-2002 | Pages are empty when rendering Archive documents with text extraction set on | Bug |
| VIEWERNET-2021 | The content of email gets cut in the output image and PDF | Bug |
| VIEWERNET-2025 | Pages are empty when rendering Outlook Data Files with text extraction set on | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 19.5. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### GroupDocs.Viewer.Handler.ViewerHtmlHandler

#### public FileContainer GetFile(Stream fileStream, AttachmentBase attachment, string password)

A new overload for GetFile method that accepts document password has been added.

This overload provides the ability to obtain contained files (attachments) from password protected documents.

#### public FileContainer GetFile(AttachmentBase attachment, string password)

A new overload for GetFile method that accepts document password has been added.

This overload provides the ability to obtain contained files (attachments) from password protected documents.

### GroupDocs.Viewer.Handler.ViewerImageHandler

#### public FileContainer GetFile(Stream fileStream, AttachmentBase attachment, string password)

A new overload for GetFile method that accepts document password has been added.

This overload provides the ability to obtain contained files (attachments) from password protected documents.

#### public FileContainer GetFile(AttachmentBase attachment, string password)

A new overload for GetFile method that accepts document password has been added.

This overload provides the ability to obtain contained files (attachments) from password protected documents.
