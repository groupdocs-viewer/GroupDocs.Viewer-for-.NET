---
id: skip-rendering-of-empty-columns
url: viewer/net/skip-rendering-of-empty-columns
title: Skip rendering of empty columns
weight: 6
description: "This article explains how to hide empty columns when viewing Spreadsheets with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
Sometimes Excel document contains information at the beginning of the worksheet and after that, it contains some count of empty (blank) columns. In case, if the number of empty columns is considerably huge, the rendering time increases and hence, it affects the performance. 

## The Solution

To skip rendering of empty columns GroupDocs.Viewerprovides [SkipEmptyColumns](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/spreadsheetoptions/properties/skipemptycolumns) property of [SpreadsheetOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/spreadsheetoptions) class, which allow omitting to render empty columns as shown in the sample below.

```csharp
using (Viewer viewer = new Viewer("sample.xlsx"))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewOptions.SpreadsheetOptions.SkipEmptyColumns = true;
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
