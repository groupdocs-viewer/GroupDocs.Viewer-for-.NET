---
id: groupdocs-viewer-for-net-20-12-release-notes
url: viewer/net/groupdocs-viewer-for-net-20-12-release-notes
title: GroupDocs.Viewer for .NET 20.12 Release Notes
weight: 47
description: "Features, improvements, and bugs-fixes that are shipped in GroupDocs.Viewer for .NET 20.12"
keywords: release notes, groupdocs.viewer, .net, 20.12
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 20.12{{< /alert >}}

## Major Features  

There are 34 features, improvements, and bug-fixes in this release, most notable are:

* Improved default font support when converting PowerPoint files to PNG/JPG
* RenderSinglePage option is now supported by GetViewInfo method

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
|VIEWERNET-2459|Improve default font support when converting PowerPoint files to PNG/JPG|Feature|
|VIEWERNET-2933|Add support of RenderSinglePage option by GetViewInfo method |Improvement|
|VIEWERNET-2748|Evaluation watermark appears in licensed mode when viewing NSF|Bug|
|VIEWERNET-2820|"Failed to open presentation with error: Input string was not in a correct format." exception when rendering ODP file"|Bug|
|VIEWERNET-2821|"Could not load file. File is corrupted or damaged." exception when rendering DWF file"|Bug|
|VIEWERNET-2829|"Failed to open presentation with error: Object reference not set to an instance of an object." exception when rendering PPTX file"|Bug|
|VIEWERNET-2903|Rendering an EML file doesn't show attachment details |Bug|
|VIEWERNET-2911|"Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')" exception when rendering MPP file"|Bug|
|VIEWERNET-2914|"Could not load file. File is corrupted or damaged." exception when rendering DWF file"|Bug|
|VIEWERNET-2923|"Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')" exception when rendering MPP file"|Bug|
|VIEWERNET-2927|"Index was outside the bounds of the array." exception when rendering MPP file"|Bug|
|VIEWERNET-2935|"Could not load file. File is corrupted or damaged." exception when rendering DOCX file"|Bug|
|VIEWERNET-2937|"Failed to open presentation with error: All column's widths must be greater than zero." exception when rendering PPTX file"|Bug|
|VIEWERNET-2978|Level index must lay in 0..8 interval exception when rendering FODP file|Bug|
|VIEWERNET-2981|PPTX to HTML has a title on page top that is not in the original document |Bug|
|VIEWERNET-1808|Wrong rendering of the PCL file|Bug|
|VIEWERNET-2486|"Index was out of range" exception when rendering VSDX file"|Bug|
|VIEWERNET-2579|"File is corrupted or damaged" exception is thrown when rendring DWG file"|Bug|
|VIEWERNET-2630|Issue in rendering DNG file|Bug|
|VIEWERNET-2648|Can't view vss file|Bug|
|VIEWERNET-2664|SVGZ result image damaged in PDF conversion and other conversions|Bug|
|VIEWERNET-2711|File is corrupted or damaged exception was thrown when rendering TIFF document|Bug|
|VIEWERNET-2717|HTML Rendering of PDF Files is including wrong CSS|Bug|
|VIEWERNET-2830|"Parameter is not valid." exception when rendering ODS file"|Bug|
|VIEWERNET-2849|Value cannot be null. Parameter name: source|Bug|
|VIEWERNET-2857|File is damaged for MHT file|Bug|
|VIEWERNET-2861|"Object reference not set to an instance of an object." exception when rendering VSS file"|Bug|
|VIEWERNET-2881|GroupDocs products conflict|Bug|
|VIEWERNET-2925|"Object reference not set to an instance of an object." exception when rendering VSSX file"|Bug|
|VIEWERNET-2932|Destination array is not long enough to copy all the items in the collection. Check array index and length.|Bug|
|VIEWERNET-2939|The column index should not be inside the pivottable report|Bug|
|VIEWERNET-2943|Cannot render RAR to PNG|Bug|
|VIEWERNET-2951|Rendering XLSM to HTML takes a lot of time|Bug|
|VIEWERNET-2955|Links are rendered incorrectly when rendering Markdown file |Bug|

## Public API and Backward Incompatible Changes

### Public API Changes

Removed two public methods that has internal purpose listed below from [VisioRenderingOptions](<https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/visiorenderingoptions>) class.

```csharp
/// <summary>
/// Check that options are changed
/// </summary>
/// <param name="otherObj">Object options for compare</param>
/// <returns>Options are changed</returns>
public bool OptionsAreChanged(VisioRenderingOptions otherObj)

/// <summary>
/// Clone Options object to remember original options
/// </summary>
/// <returns></returns>
public VisioRenderingOptions Clone()
```

### Behavior changes

In this version we've improved viewing of archives - when you use HtmlViewOptions with RenderSinglePage = true and calling the GetViewInfo method you get 1 page in result info:

```csharp

 using (Viewer viewer = new Viewer("sample.zip"))
 {
     HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
     viewOptions.RenderSinglePage = true;

     ViewInfoOptions viewInfoOptions = ViewInfoOptions.FromHtmlViewOptions(viewOptions);
     ViewInfo viewInfo = viewer.GetViewInfo(viewInfoOptions);

     // will print "Zipped File (.zip) with 1 page(s)"
     Console.WriteLine(viewInfo);

     // will produce single page
     viewer.View(viewOptions);
 }

```
