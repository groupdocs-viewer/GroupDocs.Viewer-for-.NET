---
id: groupdocs-viewer-for-net-19-10-release-notes
url: viewer/net/groupdocs-viewer-for-net-19-10-release-notes
title: GroupDocs.Viewer for .NET 19.10 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 19.10{{< /alert >}}

## Major Features

There are 19 features, improvements and bug-fixes in this release, most notable are:

*   Starting from 19.10 GroupDocs.Viewer for .NET includes .NET Standard 2.0 version. It has full functionality of .NET Framework version with few limitations (see [.NET Standard 2.0 API Limitations]({{< ref "viewer/net/developer-guide/troubleshooting/known-issues/net-standard-2.0-api-limitations.md" >}}))
*   Added support of Gnu Zipped File (.gzip) file format 
*   Added support of StarOffice Calc Spreadsheet (.sxc) file format

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-2183 | Adjust page size when rendering email messages into HTML | Feature |
| VIEWERNET-2129 | Support excluding fonts when rendering PDF documents | Feature |
| VIEWERNET-2128 | Support rendering PDF documents without embedding or producing external font resources | Feature |
| VIEWERNET-2074 | Add Gnu Zipped File (.gzip) file format support | Feature |
| VIEWERNET-2037 | Add StarOffice Calc Spreadsheet (.sxc) file format support | Feature |
| VIEWERNET-1904 | Add .NET Standard 2.0 support | Feature |
| VIEWERNET-2122 | Improve rendering of Markdown Documentation File (\*.md) file format | Improvement |
| VIEWERNET-2022 | Fit content by width when rendering mail messages into PDF/JPG/PNG | Improvement |
| VIEWERNET-2178 | Tiff rendered incorrectly | Bug |
| VIEWERNET-2169 | Incorrect image URLs when rendering email as HTML | Bug |
| VIEWERNET-2168 | Blur image in when rendering slides as HTML | Bug |
| VIEWERNET-2159 | Rendering Word document is taking a long time | Bug |
| VIEWERNET-2157 | External resources failed to load when rendering Email messages | Bug |
| VIEWERNET-2156 | Styles are lost when rendering XLSX into HTML | Bug |
| VIEWERNET-2054 | The print preview of the rendered HTML is zoomed in | Bug |
| VIEWERNET-2051 | Exception when rendering Word document as HTML | Bug |
| VIEWERNET-1996 | Rendering Diagram document provides improper output colors | Bug |
| VIEWERNET-16 | A null reference or invalid value was found exception when rendering DWG as HTML | Bug |
| VIEWERNET-15 | DWG rendered empty | Bug |

## Public API and Backward Incompatible Changes

Following public class members were added, marked as obsolete, removed or replaced:

### GroupDocs.Viewer.Options.LoadOptions

#### public LoadOptions(FileType fileType) constructor has been set as obsolete 

This constructor is obsolete and will be available until January 2020 (v20.1). Please use the default parameterless constructor instead.

#### public LoadOptions(FileType fileType, string password) constructor has been set as obsolete 

This constructor is obsolete and will be available until January 2020 (v20.1). Please use the default parameterless constructor instead.

#### public LoadOptions(FileType fileType, string password, Encoding encoding) constructor has been set as obsolete 

This constructor is obsolete and will be available until January 2020 (v20.1). Please use the default parameterless constructor instead.

#### public LoadOptions() constructor has been added

```csharp
/// <summary>
/// Initializes new instance of <see cref="LoadOptions"/> class.
/// </summary>
public LoadOptions()
{
    FileType = FileType.Unknown;
    Encoding = Encoding.Default;
}
```

#### public FileType FileType { get; set; } public setter has been added

```csharp
/// <summary>
/// The type of the file to open.
/// </summary>
public FileType FileType { get; set; }
```

#### public string Password { get; set; } public setter has been added

```csharp
/// <summary>
/// The password for opening password-protected file.
/// </summary>
public string Password { get; set; }
```

#### public Encoding Encoding { get; set; } public setter has been added

```csharp
/// <summary>
/// The encoding used when opening text-based files or email messages such as <see cref="GroupDocs.Viewer.FileType.CSV"/>, <see cref="GroupDocs.Viewer.FileType.TXT"/>, and <see cref="GroupDocs.Viewer.FileType.MSG"/>.
/// Default value is <see cref="System.Text.Encoding.Default"/>.
/// </summary>
public Encoding Encoding { get; set; }
```
