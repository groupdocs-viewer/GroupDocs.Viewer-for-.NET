---
id: render-single-layout
url: viewer/net/render-single-layout
title: Render single layout
weight: 12
description: "This article explains how to view a single layout of CAD drawing with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer renders *Model* layout of CAD drawing by default. To render specific layout from a CAD drawing the API provides[CadOptions.LayoutName](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/cadoptions/properties/layoutname) property of [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) (or [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions), or [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions), or [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions)) class. When this property is set, [CadOptions.RenderLayouts](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/cadoptions/properties/renderlayouts) property will be ignored.

Following are the steps to render specific layout in CAD drawing.

* Create [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) object.
* Set [CadOptions.LayoutName](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/cadoptions/properties/layoutname) of [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions). 
* Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method.

The following code sample shows how to render a specific layout.

```csharp
using (Viewer viewer = new Viewer("sample.dwg"))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewOptions.CadOptions.LayoutName = "Model";
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
