---
id: image-viewer-get-text-coordinates
url: viewer/net/image-viewer-get-text-coordinates
title: Image Viewer - Get text coordinates
weight: 4
description: "Learn how to obtain text coordinates when viewing your documents with Image Viewer by GroupDocs and place text over rendered document page image."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
GroupDocs.Viewer provides the feature of getting text coordinates. This feature is useful if you want to add selectable text over the image or implement a text search in image-based rendering. 

The [ExtractText](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/viewinfooptions/properties/extracttext) property of [ViewInfoOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/viewinfooptions) class enables you to get the text contained in a source document with coordinates.

Following code sample shows how to retrieve and print out text ([lines](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.results/page/properties/lines) / [words](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.results/line/properties/words) / [characters](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.results/word/properties/characters)) of each document [page](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.results/page) with coordinates.

```csharp
using (Viewer viewer = new Viewer("sample.docx"))
{
    ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForPngView(true);
    ViewInfo viewInfo = viewer.GetViewInfo(viewInfoOptions);

    foreach(Page page in viewInfo.Pages)
    {
        Console.WriteLine($"Page: {page.Number}");
        Console.WriteLine("Text lines/words/characters:");
                            
        foreach (Line line in page.Lines)
        {
            Console.WriteLine(line);
            foreach (Word word in line.Words)
            {
                Console.WriteLine($"\t{word}");
                foreach (Character character in word.Characters)
                {
                    Console.WriteLine($"\t\t{character}");
                }
            }
        }
    }
}
```

## More resources

### Advanced Usage Topics

To learn more about document viewing features, please refer to the [advanced usage section]({{< ref "viewer/net/developer-guide/advanced-usage/_index.md" >}}).

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
