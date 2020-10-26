---
id: render-hidden-columns-and-rows
url: viewer/net/render-hidden-columns-and-rows
title: Render hidden columns and rows
weight: 4
description: "This article explains how to show hidden rows and cells when viewing Spreadsheets with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
Sometimes Excel document may contain hidden columns and rows (as shown in the image below). GroupDocs.Viewer doesn't render hidden columns and rows by default. However, there may be the case when you want to control the inclusion of hidden content in the rendering results. 

![](viewer/net/images/render-hidden-columns-and-rows.png)

## The Solution

GroupDocs.Viewer provides [RenderHiddenRows](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/spreadsheetoptions/properties/renderhiddenrows) and [RenderHiddenColumns](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/spreadsheetoptions/properties/renderhiddencolumns)options in [SpreadsheetOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/spreadsheetoptions) class which enables rendering hidden rows and columns as shown in the following code samples. 

```csharp
using (Viewer viewer = new Viewer("sample.xlsx"))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewOptions.SpreadsheetOptions.RenderHiddenColumns = true;
    viewOptions.SpreadsheetOptions.RenderHiddenRows = true;
    viewer.View(viewOptions);
}
```

## More resources

### View Excel Files Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View Excel XLS, XLSX, and XLSB files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/excel)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)
