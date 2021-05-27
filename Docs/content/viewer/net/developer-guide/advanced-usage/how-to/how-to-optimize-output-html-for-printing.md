---
id: how-to-optimize-output-html-for-printing
url: viewer/net/how-to-optimize-output-html-for-printing
title: How to optimize output HTML for printing
weight: 1
description: "This article explains how to optimize output HTML for printing."
keywords: document html print
productName: GroupDocs.Viewer for .NET
hideChildren: False
---

If you need to optimize HTML output for printing you should set ForPrinting option HtmlViewOptions.
This option implemented for:

* Presentation documents: PPT,PPS,PPTX,PPSX,ODP,FODP,OTP,POT,POTX,POTM,PPTM,PPSM
* Diagram documents: VSD,VSDX,VSS,VST,VSX,VTX,VDW,VDX,VSSX,VSTX,VSDM,VSSM,VSTM
* Meta file formats: WMF, WMZ, EMF, EMZ

```csharp
 using (Viewer viewer = new Viewer("some-document.doc"))
 {
      HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("result.html");
      //HtmlViewOptions options = HtmlViewOptions.ForExternalResources("p_{0}.html", "p_{0}_{1}", "p_{0}_{1}");
      
      options.ForPrinting = true;

      viewer.View(options);
 }
```

If ForPrinting option is enabled output HTML pages will be converted to vector SVG format for better quality for print and page layout.


## More resources

### GitHub Examples

You may easily run the code above and see the feature in action in on GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)

### Free Online App

Along with full-featured .NET library we provide simple but powerful free Apps.
You are welcome to view Word, PDF, Excel, PowerPoint documents with free to use online **[GroupDocs Viewer App](https://products.groupdocs.app/viewer)**.
