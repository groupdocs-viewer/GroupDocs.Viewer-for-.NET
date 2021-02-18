---
id: render-spreadsheets-by-page-breaks
url: viewer/net/render-spreadsheets-by-page-breaks
title: Render spreadsheets by page breaks
weight: 9
description: "This article explains how to render Spreadsheet by page breaks with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
When printing spreadsheets with a lot of data sheets are automatically broken into pages to fit the paper size and keep printed content readable. To preview the page breaks in Excel navigate to _View_ and click _Page Break Preview_ as it shown on the screenshot.

![Page break preview in Excel](viewer/net/images/render-spreadsheets-by-page-breaks/page-break-preview-in-excel.png)

In case you print the workbook by clicking at _File > Print_ and there would be two pages in the print preview.

![Printing spreadsheet in Excel](viewer/net/images/render-spreadsheets-by-page-breaks/printing-spreadsheet-in-excel.png)

To perform the same action programmatically with GroupDocs.Viewer set _SpreadsheetOptions_ to _SpreadsheetOptions.ForRenderingByPageBreaks()_ and call _View_ method. Let's take [page-breaks.xlsx](viewer/net/sample-files/render-spreadsheets-by-page-breaks/page-breaks.xlsx) and render it to PDF by running the following code.

```csharp
using (Viewer viewer = new Viewer("page-breaks.xlsx"))
{
    PdfViewOptions viewOptions = new PdfViewOptions();
    viewOptions.SpreadsheetOptions = SpreadsheetOptions.ForRenderingByPageBreaks();

    // Enable rendering gird lines and headings to check that proper areas are rendered
    viewOptions.SpreadsheetOptions.RenderGridLines = true;
    viewOptions.SpreadsheetOptions.RenderHeadings = true;

    viewer.View(viewOptions);
}
```

We'll got one PDF file with two pages that are corresponds to pages highlighted by Excel on the first screenshot.

![PDF rendered by page breaks](viewer/net/images/render-spreadsheets-by-page-breaks/rendered-by-page-breaks.png)

The same applies when rendering to HTML, JPEG, and PNG formats.

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
