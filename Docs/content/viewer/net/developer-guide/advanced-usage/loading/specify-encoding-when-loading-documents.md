---
id: specify-encoding-when-loading-documents
url: viewer/net/specify-encoding-when-loading-documents
title: Specify encoding when loading documents
weight: 3
description: "This article explains how to set encoding when loading documents with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer enables users to pass encoding when rendering text documents or email messages.

This feature is supported for:

*   [Plain-text (.txt) files](https://wiki.fileformat.com/word-processing/txt/)
*   [Comma-separated values (.csv)](https://wiki.fileformat.com/spreadsheet/csv/) 
*   [Tab-separated values (.tsv)](https://wiki.fileformat.com/spreadsheet/tsv/)
*   [E-Mail Message (.eml)](https://wiki.fileformat.com/email/eml/)

Following code snippet sets the document encoding.

```csharp
LoadOptions loadOptions = new LoadOptions();
loadOptions.Encoding = Encoding.GetEncoding("shift_jis");

using (Viewer viewer = new Viewer("sample.txt", loadOptions))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
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