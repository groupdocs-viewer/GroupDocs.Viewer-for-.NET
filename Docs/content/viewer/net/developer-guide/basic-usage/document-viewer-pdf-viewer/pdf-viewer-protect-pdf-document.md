---
id: pdf-viewer-protect-pdf-document
url: viewer/net/pdf-viewer-protect-pdf-document
title: PDF Viewer - Protect PDF document
weight: 2
description: "Check this guide and learn how to view protected PDF documents inside your .NET application using PDF Viewer by GroupDocs."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer enables you to protect PDF document by setting permissions, password for opening and password for changing permissions.

The following steps are to be followed in order to set PDF document permissions.

*   Create a new instance of the [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) class and pass the source document path as a constructor parameter.
*   Initialize the instance of [Security](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/security) class;
*   Set [DocumentOpenPassword](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/security/properties/documentopenpassword) property if password is required to open PDF document;
*   Set [PermissionsPassword](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/security/properties/permissionspassword) property if it is required to change restrictions applied to PDF document; 
*   Set [Permissions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/permissions) property to specify exact permissions that should be applied to document;
*   Instantiate the [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions) object and specify saving path format for rendered document.
*   Initialize [Security](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions/properties/security) property of [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions) with object created at previous steps;
*   Pass [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions) object to [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method of [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) class.

Following example demonstrates how to protect output PDF document.

```csharp
 			using (Viewer viewer = new Viewer("sample.docx"))
            {
                Security security = new Security();
                security.DocumentOpenPassword = "o123";
                security.PermissionsPassword = "p123";
                security.Permissions = Permissions.AllowAll ^ Permissions.DenyPrinting;
                
                PdfViewOptions viewOptions = new PdfViewOptions(filePath);
                viewOptions.Security = security;
                                
                viewer.View(viewOptions);
            }
```

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
