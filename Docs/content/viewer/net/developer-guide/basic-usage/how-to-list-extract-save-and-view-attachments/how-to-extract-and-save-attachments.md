---
id: how-to-extract-and-save-attachments
url: viewer/net/how-to-extract-and-save-attachments
title: How to extract and save attachments
weight: 2
description: "This article will help you learn how to save attachments from PDF document, Outlook data file or email with file viewer by GroupDocs."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
You can save/export attachments from Email documents, Outlook data files, Archives and PDF documents with only a few lines of code using GroupDocs.Viewer for .NET API.

Follow these steps to get and save (export) attachments:

* Instantiate [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) object  for the file that contains attachment(s);
* Call [GetAttachments](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/getattachments) method which will return document attachments collection;
* Iterate through attachments collection and save attachment by calling [SaveAttachment](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/saveattachment) method.

Following example demonstrates on how to get and save attachments from MSG files.

```csharp
string outputPath = @"C:\output";
using (Viewer viewer = new Viewer("with_attachments.msg"))
{
    IList<Attachment> attachments = viewer.GetAttachments();
    foreach(Attachment attachment in attachments)
    {
        string filePath = Path.Combine(outputPath, attachment.FileName);  
        viewer.SaveAttachment(attachment, File.OpenWrite(filePath)); 
    }
}          
```

{{< alert style="info" >}}NOTE: provided code example is actual for all document types that support attachments - Email documents, Outlook data files, Archives and PDF documents.{{< /alert >}}

## More resources

### Advanced Usage Topics

To learn more about document viewing features, please refer to the [advanced usage section]({{< ref "viewer/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)

### Free Online App

Along with full-featured .NET library we provide simple but powerful free Apps.
You are welcome to view Word, PDF, Excel, PowerPoint documents with free to use online **[GroupDocs Viewer App](https://products.groupdocs.app/viewer)**.