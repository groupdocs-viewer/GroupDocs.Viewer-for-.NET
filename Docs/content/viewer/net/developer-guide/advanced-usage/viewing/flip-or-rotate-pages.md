---
id: flip-or-rotate-pages
url: viewer/net/flip-or-rotate-pages
title: Flip or rotate pages
weight: 2
description: "This article explains how to flip or rotate pages when viewing documents with GroupDocs.Viewer within your .NET applications."
keywords: Flip rotate pages with GroupDocs.Viewer for .NET API
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
![](viewer/net/images/flip-or-rotate-pages.png)

The GroupDocs.Viewer enables you to rotate individual pages when viewing documents in HTML/PDF/JPG/PNG formats. To flip/rotate pages use the [RotatePage](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/viewoptions/methods/rotatepage) method of [ViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/viewoptions) class.  The method accepts page number as the first parameter and rotation angle as the second parameter. There are three options that you can pass as the second parameter into [RotatePage](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/viewoptions/methods/rotatepage) method:

* [Rotation.On90Degree](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/rotation) - instructs to rotate page on 90-degree clockwise; 
* [Rotation.On180Degree](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/rotation) - instructs to rotate page on 180-degree clockwise;
* [Rotation.On270Degree](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/rotation) - instructs to rotate page on 270-degree clockwise;

The following code snippet shows how to rotate output pages when viewing a document as PDF (t[his example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/blob/master/Examples/GroupDocs.Viewer.Examples.CSharp/AdvancedUsage/Rendering/CommonRenderingOptions/FlipRotatePages.cs) can be also found in our public [GitHub repository](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET).)

```csharp
using (Viewer viewer = new Viewer("sample.docx"))
{
    PdfViewOptions viewOptions = new PdfViewOptions();
    viewOptions.RotatePage(1, Rotation.On90Degree);

    viewer.View(viewOptions);
}
```

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
