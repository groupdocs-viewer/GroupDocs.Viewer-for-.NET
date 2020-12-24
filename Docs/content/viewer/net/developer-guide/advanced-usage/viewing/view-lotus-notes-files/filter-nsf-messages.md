---
id: filter-nsf-messages
url: viewer/net/filter-nsf-messages
title: How to filter Lotus Notes database messages
weight: 1
description: "This article explains how to filter messages when viewing Lotus Notes Files with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
 Lotus Notes allows filtering messages inside folders by some text value from message content and by part of the sender's or recipient's address.

![Filter NSF messages](viewer/net/images/filter-nsf-messages/filter-nsf-messages.jpg)

GroupDocs.Viewer also allows filtering the rendered messages using the following filters:

* Filter by subject and content using [LotusNotesOptions.TextFilter](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/lotusnotesoptions/properties/textfilter)*;*
* Filter by the sender's and recipient's email addresses using [LotusNotesOptions.](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/lotusnotesoptions/properties/addressfilter)[AddressFilter](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/lotusnotesoptions/properties/addressfilter)*;*

As an example, when setting [LotusNotesOptions.TextFilter](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/lotusnotesoptions/properties/textfilter)as 'Microsoft'  the API will render all messages that contain the text 'Microsoft' in the message's subject or body. Whereas, setting [LotusNotesOptions.](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/lotusnotesoptions/properties/addressfilter)[AddressFilter](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/lotusnotesoptions/properties/addressfilter)as 'susan' will filter messages that contain 'susan' as a part of the sender's or recipient's address. The following code samples show how to filter the messages.

```csharp
            using (Viewer viewer = new Viewer("sample.nsf"))
            {
                HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources();
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                options.LotusNotesOptions.TextFilter = "April 2015";
                options.LotusNotesOptions.AddressFilter = "test@test.com";
                viewer.View(viewOptions);
            }
```

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
