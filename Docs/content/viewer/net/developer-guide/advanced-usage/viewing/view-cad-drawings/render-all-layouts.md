---
id: render-all-layouts
url: viewer/net/render-all-layouts
title: Render all layouts
weight: 10
description: "This article explains how to view all CAD drawing layouts with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
![](viewer/net/images/render-all-layouts.jpg)

When GroupDocs.Viewer renders CAD drawings we get only Model representation. In order to render Model and all non-empty Layouts within CAD drawing, the property [CadOptions.RenderLayouts](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/cadoptions/properties/renderlayouts) of [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) class (or [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions), or [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions), or [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions)) is used.

Following are the steps to render all the non-empty layouts along with the Model.

* Create [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) object.
* Set [CadOptions.RenderLayouts](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/cadoptions/properties/renderlayouts) of [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) to *true*
* Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method

The following code sample shows how to render layouts along with the Model of a CAD drawing.

```csharp
using (Viewer viewer = new Viewer("sample.dwg"))
{
   HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
   viewOptions.CadOptions.RenderLayouts = true;
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