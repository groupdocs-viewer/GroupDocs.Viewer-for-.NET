---
id: navigation-in-archive-files
url: viewer/net/navigation-in-archive-files
title: Folder navigation in archive files
weight: 2
description: "This article describes folder navigation in the archive with GroupDocs.Viewer within your .NET applications."
keywords: folder windows explorer navigation
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
When rendering contents of the archive to single-page HTML, Windows Explorer style like navigation is implemented, to use this you should set RenderSinglePage option to true:

```csharp
using (Viewer viewer = new Viewer("sample.zip"))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewOptions.RenderSinglePage = true;

    viewer.View(viewOptions);
}
```

To see the contents of a particular folder, just click on it. To get back in-depth, click on the required folder in the header near the archive name.

![Windows explorer navigation style](viewer/net/images/navigation-in-archive-files/navigation.gif)

## More resources

### View Archive Files Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View ZIP and TAR files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/archive)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)
