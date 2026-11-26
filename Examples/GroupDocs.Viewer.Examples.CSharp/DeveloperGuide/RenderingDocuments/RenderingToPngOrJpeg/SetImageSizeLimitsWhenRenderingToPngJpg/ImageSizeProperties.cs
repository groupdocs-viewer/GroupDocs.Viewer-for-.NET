namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPngOrJpeg.SetImageSizeLimitsWhenRenderingToPngJpg;

using GroupDocs.Viewer.Options;

/// <summary>
/// Limits of image size options interface. 
/// </summary>
public interface IMaxSizeOptions
{
    /// <summary>
    /// Max width of an output image in pixels.
    /// </summary>
    int MaxWidth { get; set; }

    /// <summary>
    /// Max height of an output image in pixels.
    /// </summary>
    int MaxHeight { get; set; }
}

public static class ImageSizeProperties
{
    public static void Run()
    {
    }
}
