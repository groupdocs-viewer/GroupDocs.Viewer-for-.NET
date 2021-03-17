---
id: groupdocs-viewer-for-net-21-3-release-notes
url: viewer/net/groupdocs-viewer-for-net-21-3-release-notes
title: GroupDocs.Viewer for .NET 21.3 Release Notes
weight: 118
description: "Features, improvements, and bugs-fixes that are shipped in GroupDocs.Viewer for .NET 21.3"
keywords: release notes, groupdocs.viewer, .net, 21.3
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 21.3{{< /alert >}}

## Major Features

There are 21 features, improvements, and bug-fixes in this release, most notable are:

* Support quality setting when rendering OneNote files
* Support Width/Height/MaxWidth/MaxHeight params by GetViewInfo method

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
|VIEWERNET-2314|Support quality setting when rendering OneNote files|Feature|
|VIEWERNET-3094|Support Width/Height/MaxWidth/MaxHeight params by GetViewInfo method|Feature|
|VIEWERNET-3132|Add FilePath parameter to Attachment class|Feature|
|VIEWERNET-3049|Improve error message when loading unsupported Numbers file|Improvement|
|VIEWERNET-2979|Specified Font is not embedded in an output HTML document.|Bug|
|VIEWERNET-2988|"Could not load file. File is corrupted or damaged." exception when rendering DXF file"|Bug|
|VIEWERNET-2991|"Failed to open presentation with error: Error reading adjustment value: connsiteX0 = "*/ 0 w 8286" exception when rendering PPTX file"|Bug|
|VIEWERNET-2993|"Failed to open presentation with error: Object reference not set to an instance of an object." exception when rendering PPTX file"|Bug|
|VIEWERNET-2995|"Image export failed." exception when rendering WMF file"|Bug|
|VIEWERNET-2997|"Could not load file. File is corrupted or damaged." exception when rendering DWF file"|Bug|
|VIEWERNET-3000|"Failed to render CAD document into PDF." exception when rendering DXF file"|Bug|
|VIEWERNET-3059|"Could not load file. File is corrupted or damaged" exception when rendering DXF file"|Bug|
|VIEWERNET-3061|"Failed to render CAD document into PDF." exception when rendering DXF file"|Bug|
|VIEWERNET-3090|Not all layers are rendered in specific CAD file|Bug|
|VIEWERNET-3096|The number greater than zero is expected. (Parameter 'width') exception when calling GetViewInfo for VSS file|Bug|
|VIEWERNET-3097|"Could not load file. File is corrupted or damaged." exception when rendering DXF file"|Bug|
|VIEWERNET-3101|Html markup broken for specific VSD file|Bug|
|VIEWERNET-3108|Search is not working for Excel and PowerPoint files in jQuery Viewer|Bug|
|VIEWERNET-3128|Shifted drawing when converting to PNG in Linux|Bug|
|VIEWERNET-3129|EML document takes too long time to render to HTML|Bug|
|VIEWERNET-3130|Incorrect headings when rendering spreadsheets by page breaks|Bug|

## Public API and Backward Incompatible Changes

### Public API Changes

#### GroupDocs.Viewer.Results.Attachment

The *FilePath* field has been added to [GroupDocs.Viewer.Results.Attachment](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.results/attachment>) class. It is used to keep a relative attachment path or attachment filename.

```csharp
/// <summary>
/// Attachment relative path e.g. <example>folder/file.docx</example> or filename when the file is located in the root of an archive, in e-mail message or data file.
/// </summary>
public string FilePath { get; }
```

In addition, all three *Attachment* class constructors have been updated to accept the *FilePath* parameter.

#### GroupDocs.Viewer.Options.ViewInfoOptions

New fields have been added to [GroupDocs.Viewer.Options.ViewInfoOptions](<https://apireference.groupdocs.com/viewer/net/groupDocs.viewer.options/viewinfooptions>) class. It is used to keep a relative attachment path or attachment filename.

```csharp
/// <summary>
/// Max width of output image (for PNG/JPG output only)
/// </summary>
public int MaxWidth { get; set; }

/// <summary>
/// Max height of output image (for PNG/JPG output only)
/// </summary>
public int MaxHeight { get; set; }

/// <summary>
/// Image width (for PNG/JPG output only)
/// </summary>
public int Width { get; set; }

/// <summary>
/// Image Height (for PNG/JPG output only)
/// </summary>
public int Height { get; set; }
```

#### Behavior changes

You can set output JPEG quality when converting OneNote files using the following code:

```csharp
 using (Viewer viewer = new Viewer("document.one"))
 {
      JpgViewOptions options = new JpgViewOptions("result_{0}.jpg");
      options.Quality = 50;

      viewer.View(options);
 }
```
