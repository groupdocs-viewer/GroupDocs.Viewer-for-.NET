---
id: render-layers
url: viewer/net/render-layers
title: Render layers
weight: 11
description: "This article explains how to view CAD drawing layers with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer renders all layers of the CAD drawing by default. To render specific layers you can set the layers that you want to render by adding them into the [CadOptions.Layers](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/cadoptions/properties/layers) property of [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) (or [PngView](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions)[Options](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions), or [JpgView](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions)[Options](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions), or[PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions)) class. 

The following code sample shows how to render a specific layer of a CAD drawing.

```csharp
using (Viewer viewer = new Viewer("sample.dwg"))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewOptions.CadOptions.Layers = new List<Layer>
    {
        new Layer("TRIANGLE"),
        new Layer("QUADRANT")
    };
    viewer.View(viewOptions);
}
```

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
