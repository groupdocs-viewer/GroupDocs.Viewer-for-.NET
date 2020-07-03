---
id: document-viewer-pdf-viewer
url: viewer/net/document-viewer-pdf-viewer
title: Document viewer - PDF Viewer
weight: 3
description: "Following this guide you will to learn how to display documents of more than 100 types in PDF format with PDF Viewer by GroupDocs."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: True
---  
Document viewer can operate in different rendering modes, HTML, Image and PDF (see [Features Overview]({{< ref "viewer/net/getting-started/features-overview.md" >}}) for more information).

This article will describe on how to view documents in PDF mode with PDF Viewer. When rendering to PDF format with GroupDocs.Viewer, it saves all pages of source document as a single target PDF document.  
Here are the steps for rendering to PDF with GroupDocs.Viewer:
*   Create new instance of [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) class and pass source document path as a constructor parameter.    
*   Instantiate the [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions) object and specify saving path format for rendered document.    
*   Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method of [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) class instance and pass [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions) to it.    

The following code sample shows how to get **PDF** representation of the document.

```csharp
using (Viewer viewer = new Viewer("sample.docx"))
{
   PdfViewOptions viewOptions = new PdfViewOptions();
   viewer.View(viewOptions);
}

```
{{< alert style="info" >}}GroupDocs.Viewer also provides an ability to customize rendering to PDF by setting additional options. To learn more about caching customization please refer to the following guides:PDF Viewer - Adjust quality for JPG imagesPDF Viewer - Protect PDF document{{< /alert >}}

## More resources
### Advanced Usage Topics
To learn more about document viewing features, please refer to the [advanced usage section]({{< ref "viewer/net/developer-guide/advanced-usage/_index.md" >}}).

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