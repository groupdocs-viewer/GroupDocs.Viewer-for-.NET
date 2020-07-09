---
id: document-viewer-html-viewer
url: viewer/net/document-viewer-html-viewer
title: Document viewer - HTML Viewer
weight: 1
description: "HTML Viewer component by GroupDocs allows to render and display documents of PDF, Word, Excel, PowerPoint and many other file formats within .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: True
---
Document viewer can operate in different rendering modes, HTML, Image and PDF (see [Document viewer - HTML Viewer]({{< ref "viewer/net/developer-guide/basic-usage/document-viewer-html-viewer/_index.md" >}}) for more information). This article will describe on how to view documents in HTML mode with HTML Viewer.

In HTML rendering mode all pages of the source documents are rendered as separate HTML pages. 

For HTML rendering mode following [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) are available:
*   [HtmlViewOptions.ForEmbeddedResources](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions/methods/forembeddedresources) - all resources such as styles, fonts, and graphics are integrated into an HTML pages.    
    *   Pros: No external files which makes more convenient to save result to a stream.        
    *   Cons: Larger page size and as a result slower loading and rendering of an HTML document in a browser.        
*   [HtmlViewOptions.ForExternalResources](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions/methods/forexternalresources) - all the resources, such as styles, fonts, and graphics are external.    
    *   Pros: Smaller page size as a page includes only markup and links to external resources. Faster HTML document loading and rendering in a browser as browsers can load multiple external resources simultaneously.        
    *   Cons: External files, since all resources will be stored next to an HTML page or in a specific directory.  

With GroupDocs.Viewer for .NET API HTML rendering became simple and intuitive. Just follow these steps:
*   Create a new instance of the [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) class and pass the source document path as a constructor parameter.    
*   Instantiate the [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) object according to your requirements (for embedded or external HTML resources) and specify saving path format for rendered document pages.    
*   Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method of [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) class instance and pass [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions) to it.
    

## Document viewer - HTML Viewer (embedded resources)

The following code shows how to render document to HTML with embedded resources.  

```csharp
using (Viewer viewer = new Viewer("sample.docx"))
{
   HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
   viewer.View(viewOptions);
}
```


## Document viewer - HTML Viewer (external resources)

The following code shows how to render document to HTML with external resources.  

```csharp
using (Viewer viewer = new Viewer("sample.docx"))
{
	HtmlViewOptions viewOptions = HtmlViewOptions.ForExternalResources();
	viewer.View(viewOptions);
}
```

{{< alert style="info" >}}GroupDocs.Viewer also provides an ability to customize rendering to HTML by setting additional options. To learn more about caching customization please refer to the following guides:HTML Viewer - Exclude fontsHTML Viewer - Minify HTMLHTML Viewer - Responsive layout{{< /alert >}}

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