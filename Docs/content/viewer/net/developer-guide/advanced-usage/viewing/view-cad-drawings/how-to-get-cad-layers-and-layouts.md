---
id: how-to-get-cad-layers-and-layouts
url: viewer/net/how-to-get-cad-layers-and-layouts
title: How to get CAD layers and layouts
weight: 6
description: "This article explains how to retrieve information about CAD drawings with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
## Retrieving layers and layouts

GroupDocs.Viewer provides additional information about CAD drawings such as list of layouts and layers when calling [GetViewInfo](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/getviewinfo) method. To retrieve view information for CAD drawing call [GetViewInfo](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/getviewinfo) method and cast output result to [CadViewInfo](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.results/cadviewinfo) type.

Following example demonstrates how to retrieve view information for CAD drawing.

```csharp
using (Viewer viewer = new Viewer("sample.dwg"))
{
    ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForHtmlView();
    CadViewInfo viewInfo = viewer.GetViewInfo(viewInfoOptions) as CadViewInfo;
 
    Console.WriteLine("File type: " + viewInfo.FileType);
    Console.WriteLine("Pages count: " + viewInfo.Pages.Count);
     
    foreach (Layout layout in viewInfo.Layouts)
        Console.WriteLine(layout);
 
    foreach (Layer layer in viewInfo.Layers)
        Console.WriteLine(layer);
}    
      

```

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