---
id: net-standard-2-0-api-limitations
url: viewer/net/net-standard-2-0-api-limitations
title: .NET Standard 2.0 API Limitations
weight: 1
description: "This article is about the limitations of .NET Standard 2.0 compared to .NET API or GroupDocs.Viewer."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
## Limitations of .NET Standard 2.0 compared to .NET API

This article is about the limitations of .NET Standard 2.0 compared to .NET API or GroupDocs.Viewer.

## Limitations

1.  Because of the lack of Windows fonts in target OS (Android, macOS, Linux, etc), fonts used in documents are substituted with available fonts, this might lead to inaccurate document layout when rendering the document to PNG, JPG, and PDF.
2.  If GroupDocs.Viewer for .NET Standard is intended to be used in a Linux environment, an additional NuGet package should be referenced to make it work correctly with graphics: [SkiaSharp.NativeAssets.Linux](https://www.nuget.org/packages/SkiaSharp.NativeAssets.Linux) for Ubuntu (it also should work on most Debian-based Linux distributions) or [Goelze.SkiaSharp.NativeAssets.AlpineLinux](https://www.nuget.org/packages/Goelze.SkiaSharp.NativeAssets.AlpineLinux) for Alpine Linux.

## Recommendations 

When using GroupDocs.Viewer in a non-Windows environment in order to improve rendering results we do recommend installing the following packages :

1.  libgdiplus - is the Mono library that provides a GDI+-compatible API on non-Windows operating systems.
2.  libc6-dev - package contains the symlinks, headers, and object files needed to compile and link programs which use the standard C library.
3.  ttf-mscorefonts-installer - package with Microsoft compatible fonts.

To install packages on Debian-based Linux distributions use [apt-get](https://wiki.debian.org/apt-get)utility:

1.  sudo apt-get install libgdiplus
2.  sudo apt-get install libc6-dev
3.  sudo apt-get install ttf-mscorefonts-installer

## More resources
### GitHub Examples
You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)    
*   [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)    
*   [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)     
*   [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)    
*   [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)    
*   [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)

### Free Online App
Along with full-featured .NET library we provide simple but powerful free Apps.
You are welcome to view Word, PDF, Excel, PowerPoint documents with free to use online **[GroupDocs Viewer App](https://products.groupdocs.app/viewer)**.