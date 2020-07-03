---
id: adjust-time-unit
url: viewer/net/adjust-time-unit
title: Adjust time unit
weight: 1
description: "This article explains how to adjust a time unit when viewing MS Project Documents with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
When rendering MS Project documents GroupDocs.Viewer tries to find optimal output size and time unit depending on the project's overall length. In case you need to set your own page size or time unit, you can set [ProjectManagementOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/projectmanagementoptions) class properties of corresponding [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) (or [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions), or [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions), or [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions)) class as shown in code samples below. Time unit refers to the smallest unit (days, third of a month or month) used in timescale bar. When the *TimeUnit.Days* is selected, you will get the most detailed view of your tasks. Whereas, when *TimeUnit.Month* is selected, you will get the more general representation of tasks.

The [TimeUnit](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/timeunit) enumeration contains the following members:

*   *Unknown* - The unknown, unspecified time scale
*   *Days* - The one day interval
*   *ThirdsOfMonths* - The one third of the month
*   *Months* - The one month interval

The following are the steps to be followed to set time interval:

*   Create [HtmlViewOption](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) / [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions) / [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions) / [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions) object;
*   Set [ProjectManagementOptions.TimeUnit](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/projectmanagementoptions/properties/timeunit) property;
*   Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method.

The following code samples show how to render MS Project document by time intervals.

```csharp
            using (Viewer viewer = new Viewer("sample.mpp"))
            {
                HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
                viewOptions.ProjectManagementOptions.TimeUnit = TimeUnit.Days;
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