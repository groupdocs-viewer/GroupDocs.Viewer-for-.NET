---
id: how-to-get-file-type-and-pages-count
url: viewer/net/how-to-get-file-type-and-pages-count
title: How to get file type and pages count
weight: 4
description: "This article explains how to get file type and pages count using .NET / C# with GroupDocs.Viewer for .NET."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
## Introduction

GroupDocs.Viewer for .NET API enables you to get file type and pages count with [GetViewInfo](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer/viewer/methods/getviewinfo) method that returns a [ViewInfo](https://apireference.groupdocs.com/viewer/net/groupdocs.viewer.results/viewinfo) object.

For the following document types GroupDocs.Viewer provides additional information:

*   Archive files - a collection of folders inside the archive (see [How to list archive folders]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-archive-files/how-to-list-archive-folders.md" >}}));
*   CAD drawings - a collection of layouts and layers (see [How to get CAD layers and layouts]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-cad-drawings/how-to-get-cad-layers-and-layouts.md" >}}));
*   Outlook Data files - a collection of folders inside Outlook Data file (see [How to get Outlook Data file folders]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-outlook-data-files/how-to-get-outlook-data-file-folders.md" >}}));
*   PDF documents - a flag that indicates whether document printing is allowed or not (see [How to check that PDF printing not allowed]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-pdf-documents/how-to-check-that-pdf-printing-not-allowed.md" >}}));
*   MS Project documents - project start/end dates (see [How to get MS Project start and end dates]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/view-ms-project-files/how-to-get-ms-project-start-and-end-dates.md" >}})).

## Get file type and pages count from file 

```csharp
using (Viewer viewer = new Viewer("sample.pdf"))
{
	ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForHtmlView();
	ViewInfo viewInfo = viewer.GetViewInfo(viewInfoOptions);
 
    Console.WriteLine("Document type is: " + viewInfo.FileType);
    Console.WriteLine("Pages count: " + viewInfo.Pages.Count);
}
```

## Get file type and pages count from stream

```csharp
using (Viewer viewer = new Viewer(() => File.OpenRead("sample.pdf")))
{
	ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForHtmlView();
	ViewInfo viewInfo = viewer.GetViewInfo(viewInfoOptions);
 
    Console.WriteLine("Document type is: " + viewInfo.FileType);
    Console.WriteLine("Pages count: " + viewInfo.Pages.Count);
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