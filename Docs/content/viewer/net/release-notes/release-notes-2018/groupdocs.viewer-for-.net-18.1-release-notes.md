---
id: groupdocs-viewer-for-net-18-1-release-notes
url: viewer/net/groupdocs-viewer-for-net-18-1-release-notes
title: GroupDocs.Viewer for .NET 18.1 Release Notes
weight: 13
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Viewer for .NET 18.1.{{< /alert >}}

## Major Features

There are 12 features, improvements, and fixes in this regular monthly release. The most notable are:

*   Added setting for specifying Layers when rendering CAD documents
*   Added Jpeg2000 (JP2, J2C, J2K, JPF, JPX, JPM) file formats support
*   Added PostScript (PS) file format support
*   Added Microsoft PowerPoint Macro-Enabled Template (POTM) and Microsoft PowerPoint Macro-Enabled Show (PPSM) file formats support
*   Added support of rendering notes for Presentation documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| VIEWERNET-1479 | Add POTM file format support | New Feature |
| VIEWERNET-1477 | Add PPSM file format support | New Feature |
| VIEWERNET-1430 | Add JPEG2000 file format support | New Feature |
| VIEWERNET-1222 | Support rendering notes for Presentation documents | New Feature |
| VIEWERNET-1156 | Implement setting for specifying Layers when rendering CAD documents | New Feature |
| VIEWERNET-872 | Add PS (PostScript) file format support | New Feature |
| VIEWERNET-1484 | Set output page height and width (for image and HTML) depending on the rendered DWF document page sizes | Improvement |
| VIEWERNET-1483 | Create single styles resource when rendering Text documents as HTML | Improvement |
| VIEWERNET-1457 | Improve exporting and embedding HTML resources when rendering SVG documents | Improvement |
| VIEWERNET-1242 | Improve exporting and embedding HTML resources when rendering Presentation documents | Improvement |
| VIEWERNET-1482 | Header contains error message when rendering Word document as PDF | Bug |
| VIEWERNET-1474 | API is not creating cache files in CachePath when rendering document from network path | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Viewer for .NET 18.1. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Viewer which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Support of file formats

GroupDocs.Viewer for .NET 18.1 includes the support of following file formats.

*   POTM 
*   PPSM 
*   JPEG2000 (JP2, J2C, J2K, JPF, JPX, JPM)
*   PS (PostScript)

### Rendering notes in Presentation documents 

Starting from version 18.1, rendering notes in the Presentation documents is also supported in HTML based rendering. 

{{< alert style="info" >}}Limitation: When rendering the document as the image, in case of notes do not fit into the single page, some of the trailing notes may be truncated.{{< /alert >}}

**Rendering document with notes**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.pptx";
  
// Set words options to render content with comments
ImageOptions options = new ImageOptions();
options.SlidesOptions.RenderNotes = true; // Default value is false
 
// Get pages 
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
   //...
}
```

### Working with CAD layers

Layers in CAD documents is a way of organizing objects in the drawing by associating them with a specific function or a purpose. For example, when we have a complex drawing of the building, all objects can be divided (associated) into several layers - e.g. electrical, water plumbing, furniture, walls and so on. According to your needs, you can temporarily hide or show some of the objects by turning off their layers. Since the version 18.1, GroupDocs.Viewer API allows you to get the list of layers from the drawing and supports rendering specified layers.

#### How to get the list of layers from the drawing

To get the list of layer names from the drawing, cast the DocumentInfoContainer object returned by GetDocumentInfo method of the ViewerHandler and use Layers property, as shown in the example below.

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
config.UseCache = true;
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "withLayers.dwg";
  
CadDocumentInfoContainer documentInfo = (CadDocumentInfoContainer) imageHandler.GetDocumentInfo(guid);
 
// Loop through all layers contained in the drawing 
foreach (string layer in documentInfo.Layers)
    Console.WriteLine("Layer name: {0}", layer); 
```

#### How to render specific layers

After you have got the list of layers, contained in the drawing, you can specify those that you want to render by adding layer names into the CadOptions.Layers property of corresponding RenderOptions(ImageOptions or HtmlOptions) as shown in example below. Please note, when you do not specify layers, all layers are rendered.

**Rendering certain Layers from CAD document**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.dwg";
  
// Set CAD options to render two Layers
ImageOptions options = new ImageOptions();
options.CadOptions.Layers.Add("electrical");
options.CadOptions.Layers.Add("walls");
 
// Get pages 
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
     Console.WriteLine("Page number: {0}", page.PageNumber); 
     Stream imageStream = page.Stream;
}
```

### Exclude/include fonts when rendering SVG and Presentation documents to HTML

When we are rendering documents into HTML, by default fonts that are used in the document are added to HTML content. This ensures fonts availability so that you can be pretty sure that the text from the original document will appear similar in HTML, regardless of whether fonts are installed on the viewer's device or not. Depending on **IsResourceEmbedded** option of **HtmlOptions** class the fonts are added inline as base64-encoded fonts or as external resources. Support for adding and preventing fonts into HTML added for Presentation documents and Scalable Vector Graphics since the version 18.1.

Embedded fonts increase the size of the rendering result. In order to prevent adding fonts into HTML, set **ExcludeFonts** property of **HtmlOptions** class as true as shown in the example below:

**Use ExcludeFonts = true to prevent adding fonts in HTML representations**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "word.doc";
 
HtmlOptions options = new HtmlOptions();
options.ExcludeFonts = true;
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
 
 
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

### List of changes in GroupDocs.Viewer for .NET 18.1

In the version 18.1 following public class members were added, marked as obsolete, removed or replaced.

#### GroupDocs.Viewer.Config.ViewerConfig

##### ViewerConfig class is no longer inheriting from FoundationConfig

All public members of the FoundationConfig class are moved directly to ViewerConfig class.

##### public string DefaultFontName property has been set as obsolete

Please use DefaultFontName property of the ImageOptions, HtmlOptions, DocumentInfoOptions or PdfFileOptions class instead as show in example below.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
string guid = "document.docx";
ViewerImageHandler handler = new ViewerImageHandler(config);
 
//Initialize a new instance of an ImageOptions class and set its DefaultFontName property 
ImageOptions options = new ImageOptions();
options.DefaultFontName = "Calibri";
 
List<PageImage> pages = handler.GetPages(guid, options);
```

#### GroupDocs.Viewer.Converter.Options.CadOptions

##### Public List<string> Layers property added

Use this property to set the list of layers that should be rendered. 

**Rendering certain Layers from CAD document**

```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create image handler
ViewerImageHandler imageHandler = new ViewerImageHandler(config);
string guid = "document.dwg";
  
// Set CAD options to render two Layers
ImageOptions options = new ImageOptions();
options.CadOptions.Layers.Add("electrical");
options.CadOptions.Layers.Add("walls");
 
// Get pages 
List<PageImage> pages = imageHandler.GetPages(guid, options);
  
foreach (PageImage page in pages)
{
     Console.WriteLine("Page number: {0}", page.PageNumber); 
     Stream imageStream = page.Stream;
}
```

#### GroupDocs.Viewer.Converter.Options.CellsOptions

##### Public bool ShowHiddenSheets property has been removed

Please use ShowHiddenPages property of the RenderOptions (ImageOptions or HtmlOptions) class instead.

#### GroupDocs.Viewer.Converter.Options.PdfOptions

##### Public bool DeleteAnnotations property has been removed

Please use RenderComments property of the HtmlOptions or ImageOptions class instead as shown in examples below.



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
  
// Create html handler
ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);
string guid = "document.pdf";
  
// Set options to render content with comments
HtmlOptions options = new HtmlOptions();
options.RenderComments = true; // Default value is false
 
// Get pages 
List<PageHtml> pages = htmlHandler.GetPages(guid, options);
  
foreach (PageHtml page in pages)
{
    Console.WriteLine("Page number: {0}", page.PageNumber);
    Console.WriteLine("Html content: {0}", page.HtmlContent);
}
```

#### GroupDocs.Viewer.Converter.Options.RenderOptions

##### Public string DefaultFontName property added

Use this property to set default font that should be used as a replacement for missing fonts while rendering into an image or HTML as shown in the example below:



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
string guid = "document.docx";
ViewerImageHandler handler = new ViewerImageHandler(config);
 
//Initialize a new instance of an ImageOptions class and set its DefaultFontName property 
ImageOptions options = new ImageOptions();
options.DefaultFontName = "Calibri";
 
List<PageImage> pages = handler.GetPages(guid, options);
```

#### GroupDocs.Viewer.Domain.CadFileData

##### A new CadFileData class added

This class represents file data for CAD documents. It inherits from FileData and extends it by providing **public List<string> Layers** property that contains the list of layer names contained in CAD document.

#### GroupDocs.Viewer.Domain.Containers.CadDocumentInfoContainer

##### A new CadDocumentInfoContainer class added

This class represents document information container for CAD documents. It inherits from DocumentInfoContainer and extends it by providing **public List<string> Layers** property that contains the list of layer names contained in CAD document.

#### GroupDocs.Viewer.Domain.Options.DocumentInfoOptions

##### Public string DefaultFontName property added

Use this property to set default font that should be used as a replacement for missing fonts while getting document information as shown in the example below:



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
string guid = "document.docx";
ViewerImageHandler handler = new ViewerImageHandler(config);
 
//Initialize a new instance of the DocumentInfoOptions class and set its DefaultFontName property 
DocumentInfoOptions options = new DocumentInfoOptions();
options.DefaultFontName = "Calibri";
 
DocumentInfoContainer documentInfo = handler.GetDocumentInfo(guid, options);
```

#### GroupDocs.Viewer.Domain.Options.PdfFileOptions

#### Public string DefaultFontName property added

Use this property to set default font that should be used as a replacement for missing fonts while rendering the document into PDF as shown in the example below:



```csharp
// Setup GroupDocs.Viewer config
ViewerConfig config = new ViewerConfig();
config.StoragePath = @"C:\storage";
 
string guid = "document.docx";
ViewerImageHandler handler = new ViewerImageHandler(config);
 
//Initialize a new instance of the DocumentInfoOptions class and set its DefaultFontName property 
PdfFileOptions options = new PdfFileOptions();
options.DefaultFontName = "Calibri";
 
FileContainer fileContainer = handler.GetPdfFile(guid, options);
```
