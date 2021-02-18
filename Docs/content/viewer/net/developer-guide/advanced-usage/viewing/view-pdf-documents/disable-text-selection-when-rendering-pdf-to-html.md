---
id: disable-text-selection-when-rendering-pdf-to-html
url: viewer/net/disable-text-selection-when-rendering-pdf-to-html
title: Disable text selection when rendering PDF to HTML
weight: 9
description: "This article explains how to disable text selection by rendering text as image when viewing PDF Documents with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
When rendering PDF documents to HTML with GroupDocs.Viewer you can disable text selection by rendering text as an image. When rendering text as an image the output HTML will look close to the source PDF document. To disable text selection set `ViewOptions.PdfOptions.RenderTextAsImage = true`.

## Example

To let's take [one-page-text.pdf](viewer/net/sample-files/disable-text-selection/one-page-text.pdf), convert it to HTML with default options and check output HTML document source. To convert PDF to HTML we'll be running the following code:

```csharp
using (Viewer viewer = new Viewer("one-page-text.pdf"))
{
    HtmlViewOptions viewOptions = 
        HtmlViewOptions.ForEmbeddedResources("default-options.html");

    viewer.View(viewOptions);
}
```

As a result, Viewer will produce a single HTML document [default-options.html](viewer/net/sample-files/disable-text-selection/default-options.html). If we open this document in a browser we'll be able to select the text as is shown on the screenshot below:

![Output HTML document and it's source when rendering with default options](viewer/net/images/disable-text-selection/default-options.png)

As you can see we can select the text because it is actually a text inside `span` element.

Let's now run the following code and check the output, the differences here are the new line `viewOptions.PdfOptions.RenderTextAsImage = true` and output file name `text-as-images.html`:

```csharp
using (Viewer viewer = new Viewer("one-page-text.pdf"))
{
    HtmlViewOptions viewOptions = 
        HtmlViewOptions.ForEmbeddedResources("text-as-images.html");
    viewOptions.PdfOptions.RenderTextAsImage = true;

    viewer.View(viewOptions);
}
```

We'll get [text-as-images.html](viewer/net/sample-files/disable-text-selection/text-as-images.html) on the output that will look similar to the previous result, but as you can see the text is replaced with an image that makes it impossible to select the text and copy it.

![Output HTML document and it's source when rendering with RenderTextAsImage set to true](viewer/net/images/disable-text-selection/text-as-images.png)

## More resources

### View PDF Documents Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View PDF files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/pdf)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)

