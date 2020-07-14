---
id: how-to-check-if-file-is-encrypted
url: viewer/net/how-to-check-if-file-is-encrypted
title: How to check if file is encrypted
weight: 5
description: "This article explains how to check if a file is encrypted using .NET / C# with GroupDocs.Viewer for .NET."
keywords: check, file, encrypted, C#, .NET
productName: GroupDocs.Viewer for .NET
hideChildren: False
---

The encryption is used to protect the file, so the only people with encryption key (such as a password) can open and view a file.
In case you wan't to check if file is encrypted you can use _GetFileInfo()_ method that returns file type and flag that indicates if the file is encrypted as it shown in the next example ([this example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/blob/master/Examples/GroupDocs.Viewer.Examples.CSharp/BasicUsage/CheckFileIsEncrypted.cs) can be found in our examples at GitHub.)

```csharp
using (Viewer viewer = new Viewer("encrypted.pdf"))
{
    FileInfo fileInfo = viewer.GetFileInfo();

    Console.WriteLine("File type is: " + fileInfo.FileType);
    Console.WriteLine("File encrypted: " + fileInfo.Encrypted);
}
```

After running the code abowe you will see an output like this:

```bash
File type is: Portable Document Format File (.pdf)
File encrypted: True
```

To learn how to open encrypted file please reffer to [Load password-protected document]({{< ref "load-password-protected-document.md" >}}) documentation article.

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
