# Document Viewer .NET API

This powerful .NET document processing API supports rendering of [170+ format formats](https://docs.groupdocs.com/viewer/net/supported-document-formats/) to HTML5, image, and PDF formats, with more than 130 formats supported for auto-detection.

<p align="center">
  <a title="Download complete GroupDocs.Viewer for .NET source code" href="https://github.com/groupdocsviewer/GroupDocs_Viewer_NET/archive/master.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Demos](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/tree/master/Demos)  | Contains demo projects that demonstrate product features.
[Examples](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/tree/master/Examples)  | C# examples and sample files that will help you learn how to use product features.
[Plugins](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/tree/master/Plugins)  | Contains Visual Studio plugins related to GroupDocs.Viewer.

## Features

- Viewing documents by rendering as HTML5, images, or PDF.
- Rendering documents as self-contained HTML pages with embedded resources.
- Rendering files in lossless PNG format or lossy JPG compressed format.
- Rotating or reordering pages when rendering.
- Getting information about document and rendering results, such as file type and number of pages on the output.
- Getting a list of folders in an archive.
- Getting a list of layers and layouts in a CAD drawing.
- Getting a list of folders in an Outlook data file.
- Getting information about the limitations of PDF documents.
- Getting project start and end dates from an MS Project file.
- Minifying HTML and CSS.
- Rendering to responsive HTML.
- Adding text watermarks on output pages.
- Rendering documents with comments and notes.
- Rendering documents using custom fonts.
- Replacing missing fonts when rendering.

## Supported formats

**Microsoft Word®:** DOC, DOCM, DOCX, DOT, DOTM, DOTX\
**Microsoft Excel®:** XLS, XLSB, XLSM, XLSX, XLT, XLTX, XLAM\
**Microsoft PowerPoint®:** PPT, PPTX, PPTM, PPS, PPSX, PPSM, POT, POTM, POTX\
**Microsoft Visio®:** VDW, VDX, VSD, VSDM, VSDX, VSS, VSSM, VSSX, VST, VSTM, VSTX, VSX, VTX\
**Microsoft Project®:** MPP, MPT, MPX\
**Microsoft OneNote®:** ONE\
**OpenOffice®:** ODG, OTG, OXPS, ODP, OTP, ODS, OTS, ODT, OTT, OXPS\
**AutoCAD®:** DGN, DWF, DWT, DWG, DXF\
**CorelDraw®:** CDR\
**Adobe Photoshop®:** PSD, PSB\
**IBM Notes:** NSF\
**Source code:** CS, VB, AS, AS3, and other\
**Image:** GIF, ICO, JP2, JPF, JPX, JPM, J2C, J2K, JPC, JPG, JPEG, SVG, TIF, TIFF\
**Markup:** HTML, MHT, MHTML, MD\
**Portable:** PDF\
**Archive:** TAR, ZIP, BZ2, RAR, GZ\
**Email:** EML, EMLX, MSG, OST, PST\
**Metafile:** CGM, EMF, WMF, WMZ, EMZ, CMX\
**Other:** IFC, STL, PS, XPS, TEX, SXC, DJVU, DNG, DIB, EPS

## Platform independence

GroupDocs.Viewer for .NET does not require any external software or third-party tools and supports any 32-bit or 64-bit operating system with .NET Framework, .NET Core, or .NET installed. The supported operating systems and platforms are listed below:

**Windows:** Microsoft Windows Server 2003 and later, Microsoft Windows XP, Vista, 7, 8, 8.1, 10, 11\
**Mac:** Mac OS X\
**Linux:** Linux (Ubuntu, OpenSUSE, CentOS and others)\
**Development Environments:** Microsoft Visual Studio, Microsoft Visual Studio for Mac, Rider from JetBrains\
**Supported Frameworks:** .NET Framework, .NET Core, and .NET

## Get started

To fetch and reference the `GroupDocs.Viewer` assembly in your project, execute `Install-Package GroupDocs.Viewer` from the Package Manager Console in Visual Studio. To update the GroupDocs.Viewer for .NET, please execute `Update-Package GroupDocs.Viewer` to get the latest version.

Please check the [GitHub Repository](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET) for other common usage scenarios.

## C# code to render XLSX file to HTML

```csharp
using (Viewer viewer = new Viewer("invoice.xlsx"))
{
   HtmlViewOptions options = 
       HtmlViewOptions.ForEmbeddedResources();

   viewer.View(options);
}
```

[Product Page](https://products.groupdocs.com/viewer/net/) | [Docs](https://docs.groupdocs.com/viewer/net/) | [Demos](https://products.groupdocs.app/viewer/family) | [API Reference](https://reference.groupdocs.com/viewer/net/) | [Examples](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET) | [Blog](https://blog.groupdocs.com/category/viewer/) | [Search](https://search.groupdocs.com/) | [Free Support](https://forum.groupdocs.com/c/viewer) | [Temporary License](https://purchase.groupdocs.com/temporary-license/)