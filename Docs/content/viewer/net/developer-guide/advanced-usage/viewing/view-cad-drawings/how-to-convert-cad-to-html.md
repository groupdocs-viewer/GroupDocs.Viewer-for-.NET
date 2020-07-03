---
id: how-to-convert-cad-to-html
url: viewer/net/how-to-convert-cad-to-html
title: How to convert CAD to HTML
weight: 5
description: "This article demonstrates how to convert CAD drawings to HTML with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
## Introduction

[CAD drawings](https://wiki.fileformat.com/cad/) are vector format images that contain points with x,y, z coordinates, and associated lines definitions. CAD drawings also may contain layers and layouts. 

## Background

If you convert your CAD drawings to HTML it's better to leave them in vector format rather rasterization to get better viewing and zooming. While converting your CAD drawings to HTML GroupDocs.Viewer converts a drawing to [SVG (Scalable Vector Graphics format)](https://wiki.fileformat.com/page-description-language/svg/) and embeds it to [HTML](https://wiki.fileformat.com/web/html/).

![](viewer/net/images/how-to-convert-cad-to-html.png)

## How to convert CAD drawings to HTML

There are two ways: HTML with external resources and HTML with embedded resources.

To render to HTML with external resources use following code:

```csharp
using (Viewer viewer = new Viewer("document.dwg"))
{
     HtmlViewOptions viewOptions = 
	 HtmlViewOptions.ForExternalResources("page_{0}.html","page_{0}/resource_{1}","page_{0}/resources");
	
    viewer.View(viewOptions);
}
```

Result:

![](viewer/net/images/how-to-convert-cad-to-html_1.png)

![](viewer/net/images/how-to-convert-cad-to-html_2.png)

Output SVG and HTML styles are located in the separate resources folder.

To render to HTML with embedded resources use following code:

```csharp
using (Viewer viewer = new Viewer("document.dwg"))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources("page_{0}.html");
	
    viewer.View(viewOptions);
}
```

Result:

![](viewer/net/images/how-to-convert-cad-to-html_3.png)

HTML content, SVG and HTML styles are located in one HTML file.

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