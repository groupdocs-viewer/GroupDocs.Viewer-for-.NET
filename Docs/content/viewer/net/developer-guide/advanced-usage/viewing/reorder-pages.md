---
id: reorder-pages
url: viewer/net/reorder-pages
title: Reorder pages
weight: 3
description: "This article explains how to reorder pages when viewing documents with GroupDocs.Viewer within your .NET applications."
keywords: Reorder pages with GroupDocs.Viewer for .NET API
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer allows you to reorder the document pages. The order of the pages in the source document is never changed, instead, the API applies reordering to the resultant PDF document.

To reorder the pages:

*   Instantiate [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) object;
*   Create [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions);
*   Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method specifying desired page numbers order.

The following code snippet shows how to reorder pages. 

```csharp
using (Viewer viewer = new Viewer("sample.docx"))            
{     
	PdfViewOptions viewOptions = new PdfViewOptions();
 
    // Pass page numbers in the order you want to render them                                       
    viewer.View(viewOptions, 2, 1);
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