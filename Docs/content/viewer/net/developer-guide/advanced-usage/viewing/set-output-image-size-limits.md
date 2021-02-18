---
id: set-output-image-size-limits
url: viewer/net/set-output-image-size-limits
title: Set output image size limits
weight: 10
description: "This article explains how to set output image size limits for PNG/JPG output when rendering documents with GroupDocs.Viewer within your .NET applications."
keywords: limit max size width height
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer also provides the feature to set limits for width/height for the output image. Follow the below steps to achieve this functionality.
If you set MaxWidth/MaxHeight options, if the image exceeds one of these limits - it will be resized proportionally.

* Instantiate the [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) object;
* Instantiate the  [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions) or [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions);
* Set MaxWidth and/or MaxHeight values;

* Call [View](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/view) method.
* The following code sample shows how to set the output image size limits when rendering the document.

```csharp
using (Viewer viewer = new Viewer("sample.jpg"))
{
    JpgViewOptions viewOptions = new JpgViewOptions("result_{0}.jpg");
    //PngViewOptions viewOptions = new PngViewOptions("result_{0}.png");
    
    viewOptions.MaxWidth = 800;
    viewOptions.MaxHeight = 600;

    viewer.View(viewOptions);
}
```

[PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions) and [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions) implement special interface [IMaxSizeOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/imaxsizeoptions), which contain properties for size limits.

```csharp
/// <summary>
/// Limits of image size options interface. 
/// </summary>
public interface IMaxSizeOptions
{
    /// <summary>
    /// Max width of an output image in pixels.
    /// </summary>
    int MaxWidth { get; set; }

    /// <summary>
    /// Max height of an output image in pixels.
    /// </summary>
    int MaxHeight { get; set; }
}
```

Note: If you set Width/Height in options, MaxWidth/MaxHeight options will be ignored.

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
