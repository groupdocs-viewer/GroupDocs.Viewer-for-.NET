---
id: groupdocs-viewer-for-net-20-9-release-notes
url: viewer/net/groupdocs-viewer-for-net-20-9-release-notes
title: GroupDocs.Viewer for .NET 20.9 Release Notes
weight: 49
description: "Features, improvements, and bugs-fixes that are shipped in GroupDocs.Viewer for .NET 20.9"
keywords: release notes, groupdocs.viewer, .net, 20.9
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 20.9{{< /alert >}}

## Major Features  

There are 10 features, improvements, and bug-fixes in this release, most notable are:

* Added Adobe Photoshop Large Document Format (.psb) file format support
* [Added feature to render only figures without scheme for Visio files]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-visio-documents/how-to-render-visio-files-figures.md">}})

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
|VIEWERNET-2033|Add Adobe Photoshop Large Document Format (.psb) file format support|Feature|
|VIEWERNET-2547|Add feature to render only figures without scheme for Visio files|Feature|
|VIEWERNET-2548|VSS figures are rendered with small size|Bug|
|VIEWERNET-2690|PDF when rendered to HTML doesn't show drawing |Bug|
|VIEWERNET-2706|VDW, VSS, VST rendering to IMAGE/HTML works incorrectly|Bug|
|VIEWERNET-2707|Row number or column number cannot be zero|Bug|
|VIEWERNET-2710|Object reference not set to an instance of an object exception thrown when rendering DNG file|Bug|
|VIEWERNET-2721|Wrong error message for not supported dgn version|Bug|
|VIEWERNET-2744|Specified argument was out of the range of valid values|Bug|
|VIEWERNET-2746|Сontent breaks on 5 page when converting to PDF|Bug|

## Public API and Backward Incompatible Changes

### Behavior changes

* In this version we've improved viewing of Visio documents - now you can choose what to render: Visio figures or Visio scheme(diagram), also Visio figures will be rendered automatically if Visio document does not contain scheme pages.

### Changes in the public API

#### GroupDocs.Viewer.FileType

Field was added to [GroupDocs.Viewer.FileType](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/filetype>) class that reflects new file formats that we're supporting starting from v20.9.

```csharp
/// <summary>
/// Photoshop Large Document Format (.psb) represents Photoshop Large Document Format used for graphics designing and development.
/// Learn more about this file format <a href="https://wiki.fileformat.com/image/psb">here</a>.
/// </summary>
public static readonly FileType PSB = new FileType("Photoshop Large Document Format", ".psb");
```

#### GroupDocs.Viewer.Options.VisioRenderingOptions

public class [VisioRenderingOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/visiorenderingoptions>) class added to GroupDocs.Viewer.Options namespace. This class provides options for rendering Lotus Notes data files.

```csharp
/// <summary>
/// The Visio files processing documents view options.
/// </summary>
public class VisioRenderingOptions
{
    /// <summary>
    /// Render only Visio figures, not a diagram
    /// </summary>
    public bool RenderFiguresOnly { get; set; }

    /// <summary>
    /// Figure width, height will be calculated automatically
    /// </summary>
    public int FigureWidth { get; set; } = 100;

    /// <summary>
    /// Check that options are changed
    /// </summary>
    /// <param name="otherObj">Object options for compare</param>
    /// <returns>Options are changed</returns>
    public bool OptionsAreChanged(VisioRenderingOptions otherObj);

    /// <summary>
    /// Clone Options object to remember original options
    /// </summary>
    /// <returns></returns>
    public VisioRenderingOptions Clone();
}
```
