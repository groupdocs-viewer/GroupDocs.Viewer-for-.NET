---
id: html-viewer-minify-html
url: viewer/net/html-viewer-minify-html
title: HTML Viewer - Minify HTML
weight: 2
description: "Learn how to minify HTML markup and CSS when rendering of documents into HTML and make your HTML documents load faster with GroupDocs.Viewer."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
When you are looking for the ways to optimize the rendering of documents into HTML, one of the solutions you might want to use is the compression of the output content (HTML, CSS, and SVG). This solution is suitable in case you are providing your content from the web server over the internet. The lower the content user has to download, the faster he will see the rendered document.

![](viewer/net/images/html-viewer-minify-html.jpg)

## The Solution

GroupDocs.Viewer provides a new *Minify* property of the *HtmlViewOptions* class, that lets you get output content minified. Minification removes comments, extra white-spaces, and other unneeded characters without breaking the content structure. As a result, the page becomes smaller in size and loads faster. The following example demonstrates how to minify output content when rendering MS Word document into HTML.

The following code sample shows how to enable minification.

```csharp
using (Viewer viewer = new Viewer("sample.docx"))
{
	HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
    viewOptions.Minify = true;
    viewer.View(viewOptions);
}
```

{{< alert style="info" >}}This setting will not compress the content as significantly as this might be achieved using Gzip compression (that should be enabled and configured from your webserver). But it still might be valuable and can be used as additional optimization in combination with Gzip compression. {{< /alert >}}

## Details Behind Minification

The process of minification almost in all cases provides the output that looks identically with original content in all browsers, but minified HTML content does not pass strict HTML validation. Here is the list of technics that lay behind the minification process.

**HTML Minification**

*   Comments (except when they contain IE conditional statements) are completely removed
*   Conditional comments are compressed
*   Spaces and line breaks inside the tags and between the tags are removed
*   Document type declaration is simplified to `<!DOCTYPE html> `and all HTML tag properties are removed
*   Protocol declarations like http:, https: and javascript: are removed from path values
*   Multiple spaces between words (except when they occur inside the pre or textarea tag) are replaced with single space
*   Quotes around tag property values (except inline events) are removed
*   Default attributes for "script", "style" and "link" tags are removed
*   Boolean attributes are simplified, therefore `<input type="text" disabled="disabled">` becomes `<input type=text disabled>`

**CSS Minification**

The embedded CSS content is minified when the *Minify* setting is on.

*   Remove all insignificant white-space.
*   Remove all comments.
*   Remove all unnecessary semicolon separators.
*   Reduce color values.
*   Reduce integer representations by removing leading and trailing zeros.
*   Remove unit specifiers from numeric zero values.

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
