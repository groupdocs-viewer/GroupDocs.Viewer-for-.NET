---
id: how-to-view-dwf-file-layers
url: viewer/net/how-to-view-dwf-file-layers
title: How to view DWF file layers
weight: 8
description: "This article explains how to view a specific DWF file layers with GroupDocs.Viewer within your .NET / C# applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
Design Web Format File (.dwf) consists of various user layers. Layers represent various parts of the entire drawing, for example, this drawing describes a plan of a building and it's parts like stairs, walls, doors located in different layers.

![](viewer/net/images/how-to-view-dwf-file-layers.png)

## Background

Let's take a sample DWF described above and then we'll process with GroupDocs.Viewer and compare results.

By default GroupDocs.Viewer renders all layers:

![](viewer/net/images/how-to-view-dwf-file-layers_1.png)

## How to view only specific layers

If you want to view only specific layers you can set [CadOptions.Layers](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/cadoptions/properties/layers) property of [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) (or [PngView](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions)[Options](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions), or  [JpgView](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions)[Options](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions), or[PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions)) class. 

Let's view only "Doors", "Stairs", "Walls" layers, to do that use following code, 

```csharp
using (Viewer viewer = new Viewer("sample.dwf"))
{
    PngViewOptions viewOptions = new PngViewOptions();

    options.CadOptions.Layers.Add(new Results.Layer("Stairs"));
    options.CadOptions.Layers.Add(new Results.Layer("Walls"));
    options.CadOptions.Layers.Add(new Results.Layer("Doors"));

    viewer.View(viewOptions);
}
```

Now GroupDocs.Viewer will render only these layers:

![](viewer/net/images/how-to-view-dwf-file-layers_2.png)

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