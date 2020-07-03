---
id: how-to-get-outlook-data-file-folders
url: viewer/net/how-to-get-outlook-data-file-folders
title: How to get Outlook Data file folders
weight: 2
description: "This article explains how to retrieve information about Outlook Data File with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
## Retrieving folders

GroupDocs.Viewer provides additional information for Outlook Data Files when calling [GetViewInfo](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/getviewinfo) method. To retrieve view information for Outlook Data File call [GetViewInfo](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/getviewinfo) method and cast output result to [OutlookViewInfo](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.results/outlookviewinfo) type.

Following example demonstrates how to retrieve view information for Outlook Data File.

```csharp
using (Viewer viewer = new Viewer("sample.ost"))
{
    ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForHtmlView();
    OutlookViewInfo viewInfo = viewer.GetViewInfo(viewInfoOptions) as OutlookViewInfo;
 
    Console.WriteLine("File type is: " + viewInfo.FileType);
    Console.WriteLine("Pages count: " + viewInfo.Pages.Count);
    
    foreach (string folder in viewInfo.Folders)
        Console.WriteLine(folder);
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