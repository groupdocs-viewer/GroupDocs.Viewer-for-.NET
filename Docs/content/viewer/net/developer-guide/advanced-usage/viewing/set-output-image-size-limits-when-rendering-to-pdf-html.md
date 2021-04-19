---
id: set-output-image-size-limits-rendering-to-pdf-html
url: viewer/net/set-output-image-size-limits-when-rendering-to-pdf-html
title: Set output image size limits when rendering single image to PDF/HTML.
weight: 11
description: "This article explains how to set output image size limits for PDF/HTML output when rendering documents with GroupDocs.Viewer within your .NET applications."
keywords: limit max size width height pdf html
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer also provides the feature to set limits for width/height for the output image. Follow the below steps to achieve this functionality.
If you want to render single image in PDF/HTML you can set width/height for the output image.
If you set ImageMaxWidth/ImageMaxHeight options, if the image exceeds one of these limits - it will be resized proportionally.

* Instantiate the [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) object;
* Instantiate the  [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions) or [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions);
* Set ImageMaxWidth and/or ImageMaxHeight values;

* Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method.
* The following code sample shows how to set the output image size limits when rendering the document.

```csharp
using (Viewer viewer = new Viewer("sample.jpg"))
{
    PdfViewOptions viewOptions = new PdfViewOptions("result.pdf");
    //HtmlViewOptions viewOptions = new HtmlViewOptions.ForEmbeddedResources("result_{0}.html");
    //HtmlViewOptions viewOptions = new HtmlViewOptions.ForExternalResources("page_{0}.html", "page_{0}_{1}", "page_{0}_{1}");
    
    viewOptions.ImageMaxWidth = 800;
    viewOptions.ImageMaxHeight = 600;

    viewer.View(viewOptions);
}
```

In [PdfViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pdfviewoptions) and [HtmlViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/htmlviewoptions)
have following properties to set single image width/height in HTML.

```csharp
 /// <summary>
/// Max width of an output image in pixels. (When converting single image to HTML only)
/// </summary>
public int ImageMaxWidth { get; set; }

/// <summary>
/// Max height of an output image in pixels. (When converting single image to HTML only)
/// </summary>
public int ImageMaxHeight { get; set; }

/// <summary>
/// The width of the output image in pixels. (When converting single image to HTML only)
/// </summary>
public int ImageWidth { get; set; }

/// <summary>
/// The height of an output image in pixels. (When converting single image to HTML only)
/// </summary>
public int ImageHeight { get; set; }
```

Note: If you set Width/Height in options, MaxWidth/MaxHeight options will be ignored.

If you want to render single image to JPG/PNG, please refer to the [following article]({{< ref "viewer/net/developer-guide/advanced-usage/viewing/set-output-image-size-limits-when-rendering-to-png-jpg.md" >}}).

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
