---
id: groupdocs-viewer-for-net-19-6-release-notes
url: viewer/net/groupdocs-viewer-for-net-19-6-release-notes
title: GroupDocs.Viewer for .NET 19.6 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 19.6{{< /alert >}}

## Major Features

There are 7 features, improvements and fixes in this regular monthly release. The most notable are:

*   Added support of file formats:
    *   Microsoft Excel 97-2003 Template (.xlt)
    *   Microsoft Excel Macro-Enabled Template (.xltm)
    *   Microsoft Excel Template (.xltx)
    *   JPEG 2000 Code Stream (.jpc)
    *   Programming languages file formats (rendered as plain text without highlight, highlight will be added in future versions)
        *   ActionScript File (.as)
        *   ActionScript File (.as3)
        *   Assembly Language Source Code File (.asm)
        *   DOS Batch File (.bat)
        *   C/C++ Source Code File (.c)
        *   C++ Source Code File (.cc)
        *   CMake File (.cmake)
        *   C++ Source Code File (.cpp)
        *   Cascading Style Sheet (.css)
        *   C++ Source Code File (.cxx)
        *   Patch File (.diff)
        *   Ruby ERB Script (.erb)
        *   Groovy Source Code File (.groovy)
        *   C/C++/Objective-C Header File (.h)
        *   Haml Source Code File (.haml)
        *   C++ Header File (.hh)
        *   Java Source Code File (.java)
        *   JavaScript File (.js)
        *   JavaScript Object Notation File (.json)
        *   LESS Style Sheet (.less)
        *   Log File (.log)
        *   Objective-C Implementation File (.m)
        *   Xcode Makefile Script (.make)
        *   Markdown Documentation File (.md)
        *   ML Source Code File (.ml)
        *   Objective-C++ Source File (.mm)
        *   PHP Source Code File (.php)
        *   Perl Script (.pl)
        *   Java Properties File (.properties)
        *   Python Script (.py)
        *   Ruby Source Code (.rb)
        *   reStructuredText File (.rst)
        *   Syntactically Awesome StyleSheets File (.sass)
        *   Scala Source Code File (.scala)
        *   Scheme Source Code File (.scm)
        *   Generic Script File (.script)
        *   Bash Shell Script (.sh)
        *   Standard ML Source Code File (.sml)
        *   Structured Query Language Data File (.sql)
        *   Vim Settings File (.vim)
        *   YAML Document (.yaml)

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1898 | Add Microsoft Excel 97-2003 Template (.xlt) file format support | Feature |
| VIEWERNET-1899 | Add Microsoft Excel Macro-Enabled Template (.xltm) file format support | Feature |
| VIEWERNET-1900 | Add Microsoft Excel Template (.xltx) file format support | Feature |
| VIEWERNET-1979 | Add programming languages file formats support | Feature |
| VIEWERNET-2050 | Add JPEG 2000 Code Stream (.jpc) file format support | Feature |
| VIEWERNET-2075 | Credit based billing for Metered license | Feature |
| VIEWERNET-2052 | Excel document loses formatting when rendering into multiple pages per sheet | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 19.6. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### public static decimal GetConsumptionCredit() method added

This method returns count of credits which were consumed in case of Metered licensing is used.

```csharp
/// <summary>
/// Retrieves count of credits consumed.
/// </summary>
/// <example>
/// Following example demonstrates how to retrieve count of credits consumed.
/// <code lang="C#">
/// string publicKey = "Public Key";
/// string privateKey = "Private Key";
/// 
/// Metered metered = new Metered();
/// metered.SetMeteredKey(publicKey, privateKey);
///
/// decimal creditsConsumed = Metered.GetConsumptionCredit();
/// </code>
/// </example>
[Obfuscation(Feature = "virtualization", Exclude = false)]
public static decimal GetConsumptionCredit()
```
