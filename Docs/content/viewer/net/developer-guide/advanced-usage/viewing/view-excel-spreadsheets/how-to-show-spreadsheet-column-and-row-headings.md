---
id: how-to-show-spreadsheet-column-and-row-headings
url: viewer/net/how-to-show-spreadsheet-column-and-row-headings
title: How to show spreadsheet column and row headings
weight: 2
description: "This article explains how to adjust text-overflow in cells when viewing Spreadsheets with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
Excel worksheet columns and rows numeration are described by letters (A, B, C, etc.) for columns and by numbers (1, 2, 3, etc.) for rows, numeration is located in headings of Excel worksheet. The column headings are used to identify the column and row numbers are used to identify the row in the worksheet. The combination of the column letter and the row number (A1, D3, F7, etc.) is called cell reference and used to identify the cell in the worksheet.

The column and row headings are highlighted in the following screenshot.

![Row and column headings in Excel](viewer/net/images/how-to-show-spreadsheet-column-and-row-headings.png)

## Background

Let's take a sample workbook and open it with Excel. Then we'll process the same file with GroupDocs.Viewer and compare results.

The following screenshot shows the default spreadsheet view in Excel.

![Spreadsheet in Excel](viewer/net/images/how-to-show-spreadsheet-column-and-row-headings_1.png)

When processing spreadsheets with GroupDocs.Viewer the row and column headings are not shown by default.

The following screenshot shows the default spreadsheet HTML view in a browser.

![Spreadsheet without headings when viewing output HTML in a browser](viewer/net/images/how-to-show-spreadsheet-column-and-row-headings_2.png)

## Solution

To show of column and row headings in the output document you just need to set [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) (or [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions), or [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions), or [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions)) object [SpreadsheetOptions.RenderHeadings](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/spreadsheetoptions/properties/renderheadings) property to true

The following code sample shows how to enable rendering of column and row headings (this example can be also found in our [public examples repository](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/blob/master/Examples/GroupDocs.Viewer.Examples.CSharp/AdvancedUsage/Rendering/RenderingOptionsByDocumentType/RenderingSpreadsheets/RenderRowAndColumnHeadings.cs).)

```csharp
using (Viewer viewer = new Viewer("sample.xlsx"))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewOptions.SpreadsheetOptions.RenderHeadings = true;
    viewer.View(viewOptions);
}
```

When headings rendering is enabled, the spreadsheet HTML view in a browser will contain row and column headings as shown in the screenshot below.

![Spreadsheet headings when viewing output HTML in a browser](viewer/net/images/how-to-show-spreadsheet-column-and-row-headings_3.png)

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
