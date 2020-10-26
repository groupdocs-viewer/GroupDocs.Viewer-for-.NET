---
id: render-outlook-data-file-folder
url: viewer/net/render-outlook-data-file-folder
title: Render Outlook Data File Folder
weight: 4
description: "This article explains how to view a specific folder of Outlook Data File with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---

GroupDocs.Viewer renders messages from all folders (including nested folders) by default. When you need to render items from a specific folder, set [Folder](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/outlookoptions/properties/folder) property of the [OutlookOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/outlookoptions) class as shown in the example below. Please note that you should use the following convention for naming folders and subfolders to specify it in [FolderName](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/outlookoptions/properties/folder) option: **{Parent folder name}\\\\{Sub folder name}**. Thus, if you need to render items from Inbox folder just specify `Folder = "Inbox";` when you need to render subfolder named "Orion" that resides in a folder named "Urgent" that in turn resides in Inbox, set: `Folder = "Inbox\\Urgent\\Orion".` 

The following code samples show how to use this option for rendering:

```csharp
using (Viewer viewer = new Viewer("sample.ost"))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewOptions.OutlookOptions.Folder = "Inbox\\SubFolder\\SubFolder2";
    viewer.View(viewOptions);
}
```

## More resources

### View OST/PST Files Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View OST and PST files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/outlook)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)
