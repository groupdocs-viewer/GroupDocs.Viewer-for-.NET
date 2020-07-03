---
id: split-worksheets-into-pages
url: viewer/net/split-worksheets-into-pages
title: Split worksheets into pages
weight: 8
description: "This article explains how to split worksheets into pages when viewing Spreadsheets with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
There might be the case when you do not want to render the whole Spreadsheet on a single page and limit the number of rows that would be rendered on each output page. In this situation, the GroupDocs.Viewer allows you to specify the number of rows in an Spreadsheet to be rendered on each page.

The following steps are required for partial rendering of large Excel sheets.

*   Instantiate the [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) (or [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions), or [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions), or [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions)) object
*   Instantiate [SpreadsheetOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/spreadsheetoptions) object by calling [SpreadsheetOptions.ForSplitSheetIntoPages](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/spreadsheetoptions/methods/forsplitsheetintopages) method and specifying desired *countRowsPerPage* parameter.
*   Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method.

```csharp
            using (Viewer viewer = new Viewer("sample.xlsx"))
            {
                HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
                viewOptions.SpreadsheetOptions = SpreadsheetOptions.ForSplitSheetIntoPages(45);
                viewer.View(viewOptions);
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