---
id: document-viewer-image-viewer
url: viewer/net/document-viewer-image-viewer
title: Document viewer - Image Viewer
weight: 2
description: "Image Viewer component by GroupDocs allows you to display 100+ file formats as PNG or JPG images in your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: True
---
Document viewer can operate in different rendering modes, HTML, Image and PDF (see [Features Overview]({{< ref "viewer/net/getting-started/features-overview.md" >}}) for more information). This article will describe on how to view documents in Image mode with Image Viewer.

Image Viewer provides [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions) and [JpgViewOptions ](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions) classes to set specific options for rendering the document into desired image format.

Here are the steps for rendering into image with GroupDocs.Viewer API:
*   Create new instance of [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) class and pass source document path as a constructor parameter.    
*   Instantiate the [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions) or [JpgViewOptions ](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions) object according to your requirements and specify saving path format for rendered document pages.    
*   Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method of [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) class instance and pass [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions) or [JpgViewOptions ](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions) to it.
    

## Document Viewer - Image Viewer (PNG)

This example shows how to render each document page into PNG image.

```csharp
using (Viewer viewer = new Viewer("sample.docx"))
{
    PngViewOptions viewOptions = new PngViewOptions();
    viewer.View(viewOptions);
}
```

## Document Viewer - Image Viewer (JPG)

This example shows how to render each document page into JPG image.

```csharp
using (Viewer viewer = new Viewer("sample.docx"))
{
    JpgViewOptions viewOptions= new JpgViewOptions();                  
    viewer.View(viewOptions);
}
```

{{< alert style="info" >}}GroupDocs.Viewer also provides an ability to customize rendering to image by setting additional options. To learn more about caching customization please refer to the following guides:Image Viewer - Add text overlay over imagesImage Viewer - Adjust image sizeImage Viewer - Adjust quality for JPGImage Viewer - Get text coordinates{{< /alert >}}

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