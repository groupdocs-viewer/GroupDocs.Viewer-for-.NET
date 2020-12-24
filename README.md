[![Build Status](https://travis-ci.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET.svg?branch=master)](https://travis-ci.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)

# Document Viewer .NET API

GroupDocs.Viewer for .NET is a powerful [Document Viewer API](https://products.groupdocs.com/viewer/net) which [supports over 160 file formats](https://docs.groupdocs.com/viewer/net/supported-document-formats/) to view documents in HTML5, Image or PDF modes with fast and high quality rendering. The Viewer Library allows to customize the rendering strategy by processing document page-by-page, entire document at once or a custom pages range. Developers may also customize document appearance via additional rendering options by adding watermarks, rotation and reordering pages, extracting document text with coordinates and much more.

<p align="center">
  <a title="Download complete GroupDocs.Viewer for .NET source code" href="https://github.com/groupdocsviewer/GroupDocs_Viewer_NET/archive/master.zip">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Docs](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/tree/master/Docs)  | Product documentation containing the Developer's Guide, Release Notes and more.
[Examples](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/tree/master/Examples)  | C# examples and sample files that will help you learn how to use product features. 
[Showcases](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/tree/master/Showcases)  | The open source UI that can help integrate GroupDocs.Viewer for .NET API in front end applications. 
[Plugins](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET/tree/master/Plugins)  | Contains Visual Studio plugins related to GroupDocs.Viewer.

## Render & Display Documents via .NET

- View documents by rendering in HTML, image or PDF format.
- Reuse common resources across several HTML pages.
- Make each HTML page self=sufficient by rendering it with embedded resources.
- Render files in the lossless PNG file format or lossy JPG compressed image format.
- Apply page rotation or change page order when rendering a document to HTML or image formats.
- Apply the specified text as watermark to all pages while being rendered into HTML or image.
- Boost document loading speed to optimize application performance via caching.
- Perform document text extract for PNG and JPG formats.
- Fetch basic information about source documents.
- Extract information about PDF document printing restrictions.
- Fetch start and end dates of a project from MS Project file.
- Minify HTML & CSS to improve the rendering process.
- [Apply watermark](https://docs.groupdocs.com/viewer/net/add-text-watermark/) on the output pages of HTML, image or PDF files.
- Render documents with comments, notes, and custom fonts.
- Replace missing fonts while rendering.

## Supported Formats for HTML, Image, PDF Rendering

**Microsoft Word:** DOC, DOCM, DOCX, DOT, DOTM, DOTX\
**Microsoft Excel:** XLS, XLSB, XLSM, XLSX, XLT, XLTX, XLAM\
**Microsoft PowerPoint:** PPT, PPTX, PPTM, PPS, PPSX, PPSM, POT, POTM, POTX\
**Microsoft Visio:** VDW, VDX, VSD, VSDM, VSDX, VSS, VSSM, VSSX, VST, VSTM, VSTX, VSX, VTX\
**Microsoft Project:** MPP, MPT, MPX\
**Microsoft OneNote:** ONE\
**OpenOffice:** ODG, FODG, OTG, OXPS, ODP, OTP, FODS, ODS, OTS, ODT, OTT, OXPS\
**AutoCAD:** DGN, DWF, DWT, DWG, DXF\
**CorelDraw:** CDR\
**Adobe Photoshop:** PSD, PSB\
**Programming:** CS, VB, AS, AS3, ASM, BAT, C, CC, CMAKE, CPP, CSS, CXX, ERB, GROOVY, H, HAML, HH, JAVA, JS, JSON, LESS, LOG, M, MAKE, MD, ML, MM, PHP, PL, PROPERTIES, PY, RB, RST, SASS, SCALA, SCM, SCRIPT, SH, SML, SQL, VIM, YAML\
**Image:** GIF, ICO, JP2, JPF, JPX, JPM, J2C, J2K, JPC, JPG, JPEG, SVG, SVGZ, TIF, TIFF\
**Markup:** HTML, MHT, MHTML, MD\
**Portable:** PDF\
**Archive:** TAR, ZIP, BZ2, RAR\
**Email:** EML, EMLX, MSG, OST, PST, NSF\
**Metafile:** CGM, EMF, WMF\
**Other:** IFC, STL, PS, XPS, TEX, SXC, DJVU, DNG, DIB, EPS, HPG, PLT, IGS, CF2, OBJ

## Develop & Deploy GroupDocs.Viewer for .NET Anywhere

**Microsoft Windows:** Microsoft Windows Desktop & Server (x86, x64), Windows Azure\
**macOS:** Mac OS X\
**Linux:** Ubuntu, OpenSUSE, CentOS, and others\
**Development Environments:** Microsoft Visual Studio, Xamarin.Android, Xamarin.IOS, Xamarin.Mac, MonoDevelop\
**Supported Frameworks:** .NET Framework 2.0 or higher, Mono Framework 1.2 or higher, .NET Standard 2.0, .NET Core 2.0 & 2.1

## Get Started with GroupDocs.Viewer for .NET

Are you ready to give GroupDocs.Viewer for .NET a try? Simply execute `Install-Package GroupDocs.Viewer` from Package Manager Console in Visual Studio to fetch & reference GroupDocs.Viewer assembly in your project. If you already have GroupDocs.Viewer for .Net and want to upgrade it, please execute `Update-Package GroupDocs.Viewer` to get the latest version.

## Render Layouts of a DWG CAD Drawing as HTML

```csharp
string outputDirectory = @"C:\output\RenderAllLayouts";
string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");
using (Viewer viewer = new Viewer("with_layers_and_layouts.dwg"))
{
   HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
   options.CadOptions.RenderLayouts = true;
   viewer.View(options);
}
```

## Load & View DOCX as PDF while Applying Password to PDF 

```csharp
string outputDirectory = @"C:\output\ProtectPdfDocument";
string filePath = Path.Combine(outputDirectory, "output.pdf");
using (Viewer viewer = new Viewer("sample.docx"))
{
    // set PDF file security
    Security security = new Security();
    security.DocumentOpenPassword = "o123";
    security.PermissionsPassword = "p123";
    security.Permissions = Permissions.AllowAll ^ Permissions.DenyPrinting;

    PdfViewOptions options = new PdfViewOptions(filePath);
    options.Security = security;

    viewer.View(options);
}
```

[Home](https://www.groupdocs.com/) | [Product Page](https://products.groupdocs.com/viewer/net) | [Documentation](https://docs.groupdocs.com/viewer/net/) | [Demo](https://products.groupdocs.app/viewer/family) | [API Reference](https://apireference.groupdocs.com/net/viewer) | [Examples](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET) | [Blog](https://blog.groupdocs.com/category/viewer/) | [Free Support](https://forum.groupdocs.com/c/viewer) | [Temporary License](https://purchase.groupdocs.com/temporary-license)
