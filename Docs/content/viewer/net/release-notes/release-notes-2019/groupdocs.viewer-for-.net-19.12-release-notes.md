---
id: groupdocs-viewer-for-net-19-12-release-notes
url: viewer/net/groupdocs-viewer-for-net-19-12-release-notes
title: GroupDocs.Viewer for .NET 19.12 Release Notes
weight: 1
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 19.12{{< /alert >}}

## Major Features

There are 8 features, improvements, and bug-fixes in this release, most notable are:

*   Added AutoCAD Drawing Template (.dwt) file-format support
*   Improved performance when rendering documents in chunks
*   Improved rendering MS Project documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-127 | Add AutoCAD Drawing Template (.dwt) file-format support | Feature |
| VIEWERNET-2257 | Timeout when loading external resources contained by text documents | Feature |
| VIEWERNET-1993 | Reduce the number of resources created when rendering MS Project documents | Improvement |
| VIEWERNET-2174 | Improve performance when rendering document in chunks | Improvement |
| VIEWERNET-2250 | Support rendering CAD drawings in 32-bit process | Improvement |
| VIEWERNET-2258 | Simplify Viewer constructors that accept file path | Improvement |
| VIEWERNET-2133 | Incorrect font when rendering PDF to HTML | Bug |
| VIEWERNET-2251 | Empty folder list for ZIP archive created in Windows | Bug |

## Public API and Backward Incompatible Changes

following public class members were added, marked as obsolete, removed or replaced:

### GroupDocs.Viewer.Viewer

#### public Viewer(String filePath, Common.Func<LoadOptions> getLoadOptions) constructor has been set as obsolete 

This constructor is obsolete and will be available till March 2020 (v20.3). Please switch to constructor that accepts LoadOptions object instead of factory method.

#### Viewer(String filePath, Common.Func<LoadOptions> getLoadOptions, ViewerSettings settings) constructor has been set as obsolete 

This constructor is obsolete and will be available till March 2020 (v20.3). Please switch to constructor that accepts LoadOptions object instead of factory method.

#### public Viewer(String filePath, LoadOptions loadOptions) constructor has been added

```csharp
/// <summary>
/// Initializes new instance of <see cref="Viewer"/> class.
/// </summary>
/// <param name="filePath">The path to the file to render.</param>
/// <param name="loadOptions">The options that used to open the file.</param>
/// <exception cref="System.ArgumentException">Thrown when <paramref name="filePath"/> is null or empty.</exception>
/// <exception cref="System.ArgumentNullException">Thrown when <paramref name="loadOptions"/> is null.</exception>
public Viewer(String filePath, LoadOptions loadOptions)
```

#### public Viewer(String filePath, LoadOptions loadOptions, ViewerSettings settings) constructor has been added

```csharp
/// <summary>
/// Initializes new instance of <see cref="Viewer"/> class.
/// </summary>
/// <param name="filePath">The path to the file to render.</param>
/// <param name="loadOptions">The options that used to open the file.</param>
/// <param name="settings">The Viewer settings.</param>
/// <exception cref="System.ArgumentException">Thrown when <paramref name="filePath"/> is null or empty.</exception>
/// <exception cref="System.ArgumentNullException">Thrown when <paramref name="loadOptions"/> is null.</exception>
/// <exception cref="System.ArgumentNullException">Thrown when <paramref name="settings"/> is null.</exception>
public Viewer(String filePath, LoadOptions loadOptions, ViewerSettings settings)
```
