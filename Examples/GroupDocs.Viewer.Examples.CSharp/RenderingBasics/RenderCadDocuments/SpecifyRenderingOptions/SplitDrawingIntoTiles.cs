namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderCadDocuments.SpecifyRenderingOptions;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class SplitDrawingIntoTiles
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.dwg"))
        {
            var viewInfoOptions = ViewInfoOptions.ForHtmlView();
            var viewInfo = viewer.GetViewInfo(viewInfoOptions);

            // Get the width and height of the CAD drawing.
            int width = viewInfo.Pages[0].Width;
            int height = viewInfo.Pages[0].Height;

            // Specify the number of rows and columns to split the drawing into.
            int columns = 2;
            int rows = 2;

            // Calculate the width and height of each tile.
            int tileWidth = width / columns;
            int tileHeight = height / rows;
            int pointX = 0;
            int pointY = 0;

            // Split the drawing into tiles and convert them to HTML.
            // {0} is replaced with the tile number in the output file name.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("page_{0}.html");
            for (int i = 0; i < columns; i++)
                for (int j = 0; j < rows; j++)
                {
                    Tile tile = new Tile(pointX + tileWidth * i, pointY + tileHeight * j,
                        tileWidth, tileHeight);
                    viewOptions.CadOptions.Tiles.Add(tile);
                }
            viewer.View(viewOptions);
        }
    }
}
