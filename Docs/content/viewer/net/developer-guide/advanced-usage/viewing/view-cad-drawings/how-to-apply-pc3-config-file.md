---
id: how-to-apply-pc3-config-file
url: viewer/net/how-to-apply-pc3-config-file
title: How to apply PC3 config file when rendering CAD formats
weight: 9
description: "This article explains how to apply PC3 files with GroupDocs.Viewer within your .NET applications."
keywords: pc3 file plotter configuration
productName: GroupDocs.Viewer for .NET
hideChildren: False
---

From 21.2 version you can apply PC3 file configuration. PC3 file is "Plotter Configuration Version 3" – contains settings for a particular plotter, GroupDocs.Viewer can apply width/height of page from PC3 file.
To apply PC3 file, please use the following code:

```csharp
using (Viewer viewer = new Viewer("sample.dwg"))
{
       PngViewOptions options = new PngViewOPtions("result.png");
       options.CadOptions.Pc3File = "small_page.pc3";

       viewer.View(options);
}
```

## PC3 files location

By default, the PC3 files of an Autocad installation will be saved at: \
C:\\Users\\%User Name%\\AppData\\Roaming\\Autodesk\\AutoCAD [Version]\\[Version Code]\\[Language]\\Plotters
For example, for an English version of Autocad 2021 it would be:
C:\\Users\\%UserName%\\AppData\\Roaming\\Autodesk\\AutoCAD 2021\\R24.0\\enu\\Plotters

## More resources

### View CAD Drawings Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View DXF, DWG, and DWF files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/cad)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)
