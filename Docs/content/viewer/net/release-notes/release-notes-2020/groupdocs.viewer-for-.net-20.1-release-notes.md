---
id: groupdocs-viewer-for-net-20-1-release-notes
url: viewer/net/groupdocs-viewer-for-net-20-1-release-notes
title: GroupDocs.Viewer for .NET 20.1 Release Notes
weight: 100
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 20.1{{< /alert >}}

## Major Features

  
There are 5 features, improvements, and bug-fixes in this release, most notable are:

*   Added OpenDocument Graphic Template (.otg) file-format support
*   Improved rendering presentations to responsive HTML
*   Removed legacy API

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-2045 | Add OpenDocument Graphic Template (.otg) file format support | Feature |
| VIEWERNET-2240 | Improve rendering presentations to responsive HTML  | Improvement |
| VIEWERNET-2276 | MSI package is not signed | Bug |
| VIEWERNET-2277 | Resource loading timeout is not working for some files | Bug |
| VIEWERNET-2282 | Parameter is not valid exception when resizing image | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="danger" >}}Starting from this version the Legacy API (GroupDocs.Viewer.Legacy) is not available.{{< /alert >}}

### Public API Changes

In version 20.1 following public class members were added, marked as obsolete, removed or replaced:

#### GroupDocs.Viewer.Legacy

We have removed all public types form GroupDocs.Viewer.Legacy namespace.

#### GroupDocs.Viewer.Options.LoadOptions

#### public LoadOptions(FileType fileType, string password) constructor has been removed

Please use the default parameterless constructor instead.

#### public LoadOptions(FileType fileType, string password, Encoding encoding) constructor has been removed

Please use the default parameterless constructor instead.
