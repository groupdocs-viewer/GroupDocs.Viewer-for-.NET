---
id: groupdocs-viewer-for-net-17-1-0-release-notes
url: viewer/net/groupdocs-viewer-for-net-17-1-0-release-notes
title: GroupDocs.Viewer for .NET 17.1.0 Release Notes
weight: 12
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 17.1.0.{{< /alert >}}

## Major Features

There are 4 new features and 11 improvements and fixes in this regular monthly release. The most notable are:

*   Added possibility to configure ViewerConfig class via app.config or web.config files
*   Implemented partial rendering of large Excel sheets when rendering to Html
*   Improved rendering Email documents in Html mode
*   Improved rendering Pdf documents in Html mode

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1043 | Implement setting to prevent glyphs grouping when rendering pdf documents | New Feature |
| VIEWERNET-1036 | Partial rendering of large Excel sheets in HTML mode | New Feature |
| VIEWERNET-1034 | Implement parameterless ViewerHtmlHandler and ViewerImageHandler constructors | New Feature |
| VIEWERNET-308 | Add possibility to configure ViewerConfig class via app.config or web.config file | New Feature |
| VIEWERNET-1052 | Implement setting to configure content ordering in resultant HTML document | Improvement |
| VIEWERNET-1040 | Improve Email documents rendering | Improvement |
| WEB-2422 | Printing Radio Buttons from HTML page | Bug |
| WEB-1092 | Links are converted into plain text when converting PDF to HTML | Bug |
| VIEWERNET-1023 | Merged cells in xlsx are not displayed as merged in HTML | Bug |
| VIEWERNET-1004 | Alignment of radio button text and checkbox text is not proper | Bug |
| VIEWERNET-994 | Jumbling words when rendering PDF document to HTML | Bug |
| VIEWERNET-975 | Creates only one page in text(txt) document | Bug |
| VIEWERNET-974 | Radio buttons are not showing as 'selected' or 'checked' when converting to fixed HTML | Bug |
| VIEWERNET-972 | Radio buttons are not showing as 'selected' or 'checked' | Bug |
| VIEWERNET-581 | Missing characters, invalid formating when saving to HTML | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 17.1.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Implement setting to prevent glyphs grouping when rendering pdf documents

When pdf documents are rendered into html, glyphs and characters are groupped into words and string groupes, this sometimes may produce undesirable result. To prevent grouping in such situations we should set PdfOptions.PreventGlyphsGrouping value of RenderOption object to true as shown in example. This mode allows to keep maximum precision during positioning of glyphs on the page and it can be used for conversion of documents with music notes or glyphs, that should be placed separately to each other.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";

// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.pdf";

// Set pdf options to render content without glyphs grouping
HtmlOptions options = new HtmlOptions();
options.PdfOptions.PreventGlyphsGrouping = true; // Default value is false

// Get pages
List<PageHtml> pages = htmlHandler.GetPages(guid, options);

foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}

```

### Partial rendering of large Excel sheets in HTML mode



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = "c:\\storage";

// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.xlsx";

// Set OnePagePerSheet = false to render multiple pages per sheet
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.CellsOptions.OnePagePerSheet = false;
// Set count rows to render into one page. Default value is 50.
htmlOptions.CellsOptions.CountRowsPerPage = 50;

// Get pages
List<PageHtml> pages = htmlHandler.GetPages(guid, htmlOptions);

```

### Implement parameterless ViewerHtmlHandler and ViewerImageHandler constructors

In version 17.1.0 ViewerHtmlHandler and ViewerImageHandler objects can be initialized by parameterless constructors.



```csharp
ViewerHtmlHandler handler = new ViewerHtmlHandler();

```

Initializing handlers this way, in combination with setting all neccesary properties for ViewerConfig in configuration file as decribed in below section, will let to reduce amount of code greatly.

### Add possibility to configurate ViewerConfig class via app.config or web.config file

Public properties of ViewerConfig class, could be configurated via app.config or web.config files, depending on the type of application.

To configurate ViewerConfig class public properties you will have to follow this steps:

1.  Add <section> element into <configSections> inside <configuration> section, with the name "groupdocs.viewer" and type "GroupDocs.Viewer.Config.GroupDocsViewerSection, GroupDocs.Viewer".
2.  Add `<groupdocs.viewer>` section inside <configuration> section.
3.  For each public property, which you want to be set, add an element inside `<groupdocs.viewer>` section, with the name equal to the property name and required value attribute.
4.  If you want to add font directory to FontDirectories collection property, create <fontDirectories> section inside `<groupdocs.viewer>` and append an <add> configuration element with the required path attribute for each font directory.
5.  Initialize ViewerConfig object using parameterless constructor.

{{< alert style="info" >}}Please note that configuration files are using camel case (lower camel case), so section names, element names and key names should obey this rule. Therefore, element name for the StoragePath property of ViewerConfig class should be storagePath.{{< /alert >}}{{< alert style="info" >}}Please also note that in the app.config or web.config file, <configSections> must be the first thing to appear in the <configuration> section, otherwise an error will be thrown at runtime.{{< /alert >}}

**XML**

```csharp
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <configSections>
      <section name="groupdocs.viewer" type="GroupDocs.Viewer.Config.GroupDocsViewerSection, GroupDocs.Viewer"/>
    </configSections>
    <startup>
      <supportedRuntime version="v2.0.50727"/>
    </startup>
    <groupdocs.viewer>
      <storagePath value="C:\storage"/>
      <cacheFolderName value="cachefolder"/>
      <cachePath value="C:\cache"/>
      <useCache value="true"/>
      <usePdf value="false"/>
      <localesPath value="C:\locales"/>
      <pageNamePrefix value="prefix"/>
      <defaultFontName value="Times New Roman"/>
      <fontDirectories>
        <add path="C:\fonts" />
        <add path="C:\more_fonts" />
      </fontDirectories>
    </groupdocs.viewer>
</configuration>

```

### Implement setting to configure content ordering in resultant html document



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = "c:\\storage";

// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.xlsx";

// Set OnePagePerSheet = false to render multiple pages per sheet
HtmlOptions htmlOptions = new HtmlOptions();
htmlOptions.CellsOptions.OnePagePerSheet = false;
// Set count rows to render into one page. Default value is 50.
htmlOptions.CellsOptions.CountRowsPerPage = 50;

// Get pages
List<PageHtml> pages = htmlHandler.GetPages(guid, htmlOptions);

```
