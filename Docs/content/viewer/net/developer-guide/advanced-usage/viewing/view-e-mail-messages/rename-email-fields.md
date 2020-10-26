---
id: rename-email-fields
url: viewer/net/rename-email-fields
title: Rename email fields
weight: 2
description: "This article explains how to translate fields when viewing E-Mail Messages with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
When rendering email messages, by default the API uses the English language to render field labels such as *From, To, Subject* etc. There might be the case when you want to change the label of the fields in email message's header.  
GroupDocs.Viewer is flexible enough to allow you to use the custom field labels for email header. The API provides a new property [FieldTextMap](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/emailoptions/properties/fieldtextmap) in [EmailOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/emailoptions) class to change the field labels.  
  
Following code sample shows how to use custom field labels.

```csharp
using (Viewer viewer = new Viewer("sample.msg"))
{
    HtmlViewOptions viewOptions = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
    viewOptions.EmailOptions.FieldTextMap[Field.From] = "Sender";
    viewOptions.EmailOptions.FieldTextMap[Field.To] = "Receiver";
    viewOptions.EmailOptions.FieldTextMap[Field.Sent] = "Date";
    viewOptions.EmailOptions.FieldTextMap[Field.Subject] = "Topic";
    viewer.View(viewOptions);
}
```

## More resources

### View eMail Messages Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View MSG and EML files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/email)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)
