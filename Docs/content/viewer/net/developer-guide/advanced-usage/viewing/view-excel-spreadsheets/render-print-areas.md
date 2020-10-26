---
id: render-print-areas
url: viewer/net/render-print-areas
title: Render print areas
weight: 5
description: "This article explains how to view Spreadsheet print areas with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
Spreadsheet document allows to set a print area if you want to print a specific section on a worksheet. There can be the case when you want to render only the print area of the worksheet using GroupDocs.Viewer. 

![](viewer/net/images/render-print-areas.png)

## The Solution

GroupDocs.Viewerprovides an option to render sections of the worksheet(s) defined as the "print area". It renders each print area in a worksheet as a separate page. The following code samples show how to render only the print areas from worksheets.

```csharp
using (Viewer viewer = new Viewer("sample.xlsx"))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewOptions.SpreadsheetOptions = SpreadsheetOptions.ForRenderingPrintArea();
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
