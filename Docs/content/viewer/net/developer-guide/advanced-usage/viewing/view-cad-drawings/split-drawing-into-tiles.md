---
id: split-drawing-into-tiles
url: viewer/net/split-drawing-into-tiles
title: Split drawing into tiles
weight: 13
description: "This article explains how to split CAD drawing into tiles with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
Tiled rendering or (rendering by coordinates) is the process of rendering CAD drawings (into an image, HTML or PDF) by dividing into square parts and rendering each part (or tile) separately. The advantage of this process is that the amount of memory involved is reduced as compared to rendering the entire document at once. Generally, DWG documents are divided into pages by Model and Layouts, but when the tiled rendering is enabled, only the Model is rendered and every tile composes a separate page. 

![](viewer/net/images/split-drawing-into-tiles.jpg)

## Rendering by Coordinates

Before you start rendering by coordinates, you should obtain the overall width and height of the document using the [GetViewtInfo](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer/methods/getviewinfo) method of [Viewer](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer/viewer) object as shown in the code sample below. After you know the width and height, determine the starting point (X and Y coordinates) and the width and the height of the tile (region you want to render). Add the tiles to [CadOptions.Tiles](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/cadoptions/properties/tiles) list as shown in the sample below. The coordinates start from the bottom left corner of the drawing and have only positive values as shown in the sample picture below. 

Overall size of the document is 650px height and 750px width. The selected tile starts at coordinate X: 250 and Y: 100 and has a width 150px, height: 200px

![](viewer/net/images/split-drawing-into-tiles_1.jpg)

You can add as many tiles as you need.  
The following code sample demonstrates how to render DWG drawing into an image by dividing into four equal parts.

```csharp
using (Viewer viewer = new Viewer("sample.dwg"))
{
    ViewInfoOptions viewInfoOptions = ViewInfoOptions.ForPngView(false);
    ViewInfo viewInfo = viewer.GetViewInfo(viewInfoOptions);

    // Get width and height
    int width = viewInfo.Pages[0].Width;
    int height = viewInfo.Pages[0].Height;

    // Set tile width and height as a half of image total width
    int tileWidth = width / 2;
    int tileHeight = height / 2;
    int pointX = 0;
    int pointY = 0;

    //Create image options and add four tiles, one for each quarter
    PngViewOptions viewOptions = new PngViewOptions(pageFilePathFormat);
    Tile tile = new Tile(pointX, pointY, tileWidth, tileHeight);
    viewOptions.CadOptions.Tiles.Add(tile);
    pointX += tileWidth;
    tile = new Tile(pointX, pointY, tileWidth, tileHeight);
    viewOptions.CadOptions.Tiles.Add(tile);
    pointX = 0;
    pointY += tileHeight;
    tile = new Tile(pointX, pointY, tileWidth, tileHeight);
    viewOptions.CadOptions.Tiles.Add(tile);
    pointX += tileWidth;
    tile = new Tile(pointX, pointY, tileWidth, tileHeight);
    viewOptions.CadOptions.Tiles.Add(tile);

    viewer.View(viewOptions);
}
```

## More resources

### View CAD Drawings Online

Along with full-featured .NET library we provide simple but powerful free online Apps.
View DXF, DWG, and DWF files online with **[GroupDocs Viewer App](https://products.groupdocs.app/viewer/cad)**.

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)
