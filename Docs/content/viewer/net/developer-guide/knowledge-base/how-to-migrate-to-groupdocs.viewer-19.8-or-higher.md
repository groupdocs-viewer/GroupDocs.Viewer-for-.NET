---
id: how-to-migrate-to-groupdocs-viewer-19-8-or-higher
url: viewer/net/how-to-migrate-to-groupdocs-viewer-19-8-or-higher
title: How to migrate to GroupDocs.Viewer 19.8 or higher
weight: 3
description: "This article contains information about migration from the legacy API to GroupDocs.Viewer 19.8 or higher."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
This article contains information about migration from the legacy API to GroupDocs.Viewer 19.8 or higher.


## Why To Migrate

Here are the key reasons to use the new updated API provided by **GroupDocs.Viewer for .NET** since version **19.8**:
*   **Viewer** class introduced as a **single entry point** to manage the document rendering process to any supported file format (instead of **ViewerHtmlHander** / **ViewerImageHander** classes from previous versions).    
*   The overall **rendering speed improved** dramatically by saving rendered page as soon as it was rendered, not when all pages list were rendered.     
*   Product architecture was redesigned from scratch in order to **decreased memory usage** (from 10% to 400% approx. depending on document type).    
*   Document **viewing options simplified** so it’s easy to instantiate proper options class and control over document rendering and saving processes.       
    

## How To Migrate

Here is a brief comparison of how to display document into HTML form using old and new API.  

**Old coding style**

```csharp
//Get Configurations
ViewerConfig config = Utilities.GetConfigurations();

// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

// Guid implies that unique document name 
string guid = "sample.docx";

//Instantiate the HtmlOptions object
HtmlOptions options = new HtmlOptions();

//to get html representations of pages with embedded resources
options.IsResourcesEmbedded = true;

// Set password if document is password protected. 
if(!String.IsNullOrEmpty(DocumentPassword))
   options.Password = DocumentPassword;
            
//Get document pages in html form
List<PageHtml> pages = htmlHandler.GetPages(guid, options);

foreach (PageHtml page in pages)
{
    //Save each page at disk
    Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
}
```

**New coding style**

```csharp
using (Viewer viewer = new Viewer("sample.docx"))
{
   HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources();
   viewer.View(options);
}
```

## More resources
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
