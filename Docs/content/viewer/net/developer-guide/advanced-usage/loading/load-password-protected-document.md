---
id: load-password-protected-document
url: viewer/net/load-password-protected-document
title: Load password-protected document
weight: 2
description: "This article explains how to load password-protected document with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---

The encryption is used to protect data and allow only authorized persons to open the file. When a file is encrypted the passwords must be specified to open the file. To learn how to check if the file is encrypted please refer to [How to check if file is encrypted]({{< ref "how-to-check-if-file-is-encrypted.md" >}}) documentation article.

The following are the steps to convert encrypted documents:

* Instantiate the [HtmlViewOptions](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/htmlviewoptions) (or [PngViewOptions](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/pngviewoptions), or [JpgViewOptions](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/jpgviewoptions), or [PdfViewOptions](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/pdfviewoptions)) object;
* Set password in [LoadOptions.Password](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.options/loadoptions/properties/password) property;
* Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method.

The following code sample shows how to convert encrypted documents:

```csharp
LoadOptions loadOptions = new LoadOptions();
loadOptions.Password = "123456";

using (Viewer viewer = new Viewer("encrypted.docx", loadOptions))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewer.View(viewOptions);
}
```

{{< alert style="info" >}}
In case the password is not specified GroupDocs.Viewer will throw [PasswordRequiredException](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.exceptions/passwordrequiredexception).
{{< /alert >}}

## More resources

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