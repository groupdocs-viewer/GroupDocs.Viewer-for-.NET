---
id: groupdocs-viewer-for-net-20-5-release-notes
url: viewer/net/groupdocs-viewer-for-net-20-5-release-notes
title: GroupDocs.Viewer for .NET 20.5 Release Notes
weight: 60
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 20.5{{< /alert >}}

## Major Features

There are 13 features, improvements, and bug-fixes in this release, most notable are:

*   When converting CAD drawings to HTML, CAD drawings are converted to SVG instead of PNG   
*Related article* *[How to convert CAD to HTML]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-cad-drawings/how-to-convert-cad-to-html.md" >}})*
*   Added Flat XML ODF Template (.fodg) file format support  
*Related article [How to convert and view ODG and FODG files]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-image-files/how-to-convert-and-view-odg-and-fodg-files.md" >}})*
*   Added IGES Drawing File (.igs) file format support  
*Related article [How to convert and view IGS files]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-cad-drawings/how-to-convert-and-view-igs-files.md" >}})*
*   Added Common File Format File (.cf2) file-format support  
*Related article [How to convert and view CFF2 and CF2 files]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-cad-drawings/how-to-convert-and-view-cff2-and-cf2-files.md" >}})*
*   Added Wavefront 3D Object File (.obj) file-format support  
*Related article [How to convert and view OBJ files]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-cad-drawings/how-to-convert-and-view-obj-files.md" >}})*
*   Added support viewing MS Project documents with notes  
*Related article [How to convert and view MS Project documents with notes]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-ms-project-files/how-to-convert-and-view-ms-project-documents-with-notes.md" >}})*
*   Added support viewing OpenDocument Flat XML Presentation (.fodp) files  
*Related article [How to convert and view FODP and ODP files]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-powerpoint-presentations/how-to-convert-and-view-fodp-and-odp-files.md" >}})*
*   Improved default font support when converting PowerPoint files to HTML and PDF  
*Related article [How to substitute missing font when converting presentations]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-powerpoint-presentations/how-to-substitute-missing-font-when-converting-presentations.md" >}})*

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-125 | Support viewing MS Project documents with notes | Feature |
| VIEWERNET-2034 | Add OpenDocument Flat XML Presentation (.fodp) file format support | Feature |
| VIEWERNET-2046 | Add Flat XML ODF Template (.fodg) file format support | Feature |
| VIEWERNET-2057 | Convert CAD drawings to SVG | Feature |
| VIEWERNET-2059 | Add IGES Drawing File (.igs) file format support | Feature |
| VIEWERNET-2243 | Add Common File Format File (.cf2) file-format support | Feature |
| VIEWERNET-2311 | Add Wavefront 3D Object File (.obj) file-format support | Feature |
| VIEWERNET-2433 | Improve default font support when converting PowerPoint files | Improvement |
| VIEWERNET-258 | Exception when rendering DWG file as image | Bug |
| VIEWERNET-2125 | Same result when rendering presentation without and with excluded font | Bug |
| VIEWERNET-2285 | Link represented as span when rendering PDF into HTML | Bug |
| VIEWERNET-2424 | File is corrupted or damaged exception when converting MPX file | Bug |
| VIEWERNET-2458 | Unable to load shared library 'gdi32.dll' or one of its dependencies exception when processing TEX files on Linux | Bug |

## Public API and Backward Incompatible Changes

### Behavior changes

*   Starting from 20.5 the CAD drawings are converted to SVG instead of PNG for better quality please refer to [How to convert CAD to HTML]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-cad-drawings/how-to-convert-cad-to-html.md" >}}) article for more details.
