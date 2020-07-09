---
id: groupdocs-viewer-for-net-20-2-release-notes
url: viewer/net/groupdocs-viewer-for-net-20-2-release-notes
title: GroupDocs.Viewer for .NET 20.2 Release Notes
weight: 90
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 20.2{{< /alert >}}

## Major Features

There are 14 features, improvements, and bug-fixes in this release, most notable are:

*   Added support of retrieving an attachment file type
*   Display folder name in the header when viewing archives

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-2318 | Support retrieving an attachment file type | Feature |
| VIEWERNET-2323 | Include folder name when rendering archive folders | Feature |
| VIEWERNET-2324 | Recreate output files and resources instead of writing over | Improvement |
| VIEWERNET-8 | Overlapping Characters in Safari for iOS | Bug |
| VIEWERNET-226 | Files being created in Windows temp folder | Bug |
| VIEWERNET-257 | Incorrect rendering of DWG file as image | Bug |
| VIEWERNET-1202 | Invalid characters while viewing rendered HTML in IE | Bug |
| VIEWERNET-2175 | STL file is rendered into blank HTML or image | Bug |
| VIEWERNET-2306 | Issue in rendering/converting email attachments | Bug |
| VIEWERNET-2315 | Getting evaluation message on second server even license is applied  | Bug |
| VIEWERNET-2319 | Archive file name is missing when passing file stream | Bug |
| VIEWERNET-2320 | GetViewInfo hangs indefinitely  | Bug |
| VIEWERNET-2321 | ArchiveViewInfo shows that current folder is sub-folder of itself | Bug |
| VIEWERNET-2343 | Document viewer size discrepancy  | Bug |

## Public API and Backward Incompatible Changes

In version 20.2 following public class members were added:

*   Added new property to **[GroupDocs.Viewer.Options.PdfOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfoptions)** class

```csharp
/// <summary>
/// When this option enabled the output pages will have the same size
/// in pixels as page size in a source PDF document.
/// By default GroupDocs.Viewer calculates output image page size for better rendering quality.
/// </summary>
/// <remarks>
/// This option is supported when rendering into PNG or JPG formats.
/// </remarks>
public bool RenderOriginalPageSize { get; set; }
```

*   Added two fields and one method to **[GroupDocs.Viewer.FileType](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/filetype)** class

```csharp
/// <summary>
/// Gnu Zipped File (.gz)
/// </summary>
public static readonly FileType GZ = new FileType("Gnu Zipped File", ".gz");

/// <summary>
/// Gnu Zipped File (.gzip)
/// </summary>
public static readonly FileType GZIP = new FileType("Gnu Zipped File", ".gzip");
 
/// <summary>
/// Maps file media type to file type e.g. 'application/pdf' will be mapped to <see cref="FileType.PDF"/>.
/// </summary>
/// <param name="mediaType">File media type e.g. application/pdf.</param>
/// <exception cref="T:System.ArgumentException">Thrown when <paramref name="mediaType"/> is null or empty string.</exception>
/// <returns>Returns corresponding media type when found, otherwise returns default <see cref="Unknown"/> file type.</returns>
public static FileType FromMediaType(string mediaType)
```
