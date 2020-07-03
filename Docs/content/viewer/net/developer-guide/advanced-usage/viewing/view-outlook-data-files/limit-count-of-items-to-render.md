---
id: limit-count-of-items-to-render
url: viewer/net/limit-count-of-items-to-render
title: Limit count of items to render
weight: 3
description: "This article explains how to set a limit for items to view of Outlook Data Files with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer allows rendering the items in Outlook Data Files (OST/PST). [OutlookOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/outlookoptions) is used to set rendering options for OST and PST formats. The following steps are to be followed when rendering the items in Outlook Data Files.

*   Create [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) object;
*   Create [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) (or [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions), or [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions), or [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions)) object;
*   Set Outlook options i.e. [HtmlViewOptions.OutlookOptions.MaxItemsInFolder](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/outlookoptions/properties/maxitemsinfolder)*;*
*   Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method.

The following code samples show how to render the items in an Outlook Data File by setting a maximum limit.

```csharp
            using (Viewer viewer = new Viewer("sample.ost"))
            {
                HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
                viewOptions.OutlookOptions.MaxItemsInFolder = 1000;
                viewer.View(viewOptions);
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