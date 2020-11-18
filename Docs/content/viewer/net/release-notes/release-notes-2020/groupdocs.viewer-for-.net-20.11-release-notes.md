---
id: groupdocs-viewer-for-net-20-11-release-notes
url: viewer/net/groupdocs-viewer-for-net-20-11-release-notes
title: GroupDocs.Viewer for .NET 20.11 Release Notes
weight: 48
description: "Features, improvements, and bugs-fixes that are shipped in GroupDocs.Viewer for .NET 20.11"
keywords: release notes, groupdocs.viewer, .net, 20.11
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 20.11{{< /alert >}}

## Major Features  

There are 21 features, improvements, and bug-fixes in this release, most notable are:

* [Rendering archives in HTML with Windows explorer behavior]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-archive-files/_index.md">}})
* Automatically recalculating CAD drawing size when it is required
* Fixed images and text positioning when rendering Excel as HTML/image/PDF in Linux

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
|VIEWERNET-2839|Update CAD document size only when it needs|Improvement|
|VIEWERNET-2826|Make detailed description for unsupported numbers file|Improvement|
|VIEWERNET-2598|Rendering archives in HTML with Windows explorer behavior|Improvement|
|VIEWERNET-2907|Stream does not support reading exception when rendering MPP/MPX/MPT files to JPG/PNG|Bug|
|VIEWERNET-2880|Rendering NSF to JPG/PNG/PDF takes too much time|Bug|
|VIEWERNET-2879|Images are missing, text positioning wrong when rendering Excel as HTML/image/PDF in Linux|Bug|
|VIEWERNET-2877|File is damaged exception when rendering BMP file|Bug|
|VIEWERNET-2873|Replacing the default font doesn't work on Linux|Bug|
|VIEWERNET-2872|"Key cannot be null. (Parameter 'key')" exception when rendering ODS file"|Bug|
|VIEWERNET-2850|"Object reference not set to an instance of an object" when rendering specific XLTX file|Bug|
|VIEWERNET-2844|Wrong exception|Bug|
|VIEWERNET-2842|"Key cannot be null. (Parameter 'key')" exception when rendering ODS file"|Bug|
|VIEWERNET-2831|"Input string was not in a correct format." exception when rendering XLSX file"|Bug|
|VIEWERNET-2817|Parameter is not valid.|Bug|
|VIEWERNET-2813|An attempt was made to move the file pointer before the beginning of the file.|Bug|
|VIEWERNET-2788|Shape with 3-D effect has incorrect background color|Bug|
|VIEWERNET-2776|Out of memory exception thrown Linux when rendering specific VSD file to PNG in Linux|Bug|
|VIEWERNET-2720|Exception has been thrown by the target of an invocation.|Bug|
|VIEWERNET-2702|Image export failed|Bug|
|VIEWERNET-2688|Can't open ppsm file|Bug|
|VIEWERNET-2488|Exception is thrown when rendering DNG file|Bug|

## Public API and Backward Incompatible Changes

### Behavior changes

In this version we've improved viewing of archives - now you can navigate between archive folder with Windows explorer behavior:

![Windows explorer navigation style](viewer/net/images/navigation-in-archive-files/navigation.gif)

For more details and code snippets check [Rendering archives in HTML with Windows explorer behavior]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-archive-files/_index.md">}}) documentation article.
