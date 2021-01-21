---
id: features-overview
url: viewer/net/features-overview
title: Features Overview
weight: 1
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
  
## Document viewer

GroupDocs.Viewer main feature is an ability to view documents by rendering them into an HTML, Image or PDF using [ViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/viewoptions) class, so that documents of different types can be easily displayed inside your application without any additional software installed, such as Microsoft Office, Apache Open Office, Adobe Acrobat Reader, etc.

Choosing the most appropriate [ViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/viewoptions)depends on your application type, specifics and requirements.

Let’s review in detail what are the differences between [ViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/viewoptions) and how to choose the most suitable for your case.  

### Document viewer - HTML Viewer

HTML viewer will suit the best with following specifications and requirements:

* You are writing a web-based application;
* Document content should be displayed inside web-browser;
* You need an ability to interact with rendered document text - select, copy or search;
* You want to view document pages separately;
* Zooming in a document without quality loss for most cases;
* You want to rotate, reorder pages or add watermarks.

HTML viewer provide two resources management options for CSS, fonts, images, etc.:

* Render to **HTML with external resources** - stores page resources near to HTML which allows to reuse common resources across separate pages and dramatically reduce page size and loading speed.    
* Render to **HTML with embedded resources** - integrates page resources into HTML and makes each document page self-sufficient. The drawback is that page size and loading speed may increase.

### Document viewer - Image Viewer

Image viewer will suit the best with following specifications and requirements:

* You are writing any type of application;
* You don’t need to render textual content or want to restrict interaction with rendered document text. For example: prevent text copying. There is still an ability for you to extract document text if you want to add selectable text layer over the page image (described below).
* You want to view document pages separately;
* You want to rotate, reorder pages or add watermarks.

Image viewer support document rendering into JPG and PNG formats.

Following is a brief description of both image formats which may help you to choose the most suitable for your case.  

* **PNG** **format** is a lossless raster graphics file format that works with full-color images and supports transparency. There is no ability to adjust the quality of saved PNG image. PNG is a good choice for storing line drawings, text, and iconic graphics at small file sizes.
* **JPG** **format** is a lossy compressed file format which allows to adjust the quality of the saved image — when it is reduced, the details are removed and noise is added to the image, but the size becomes more compact. JPG is optimal for images with a large number of colors (for example, for photos).  It’s is a common choice to use JPG on the Web because of its compression.

### Document viewer - PDF Viewer

PDF viewer will suit the best with following specifications and requirements:

* You are going to print documents;
* You want to send documents via email.
* You don’t want to view document pages separately. All pages of a source document are rendered as a single PDF document.

### Viewing options and output customizations

GroupDocs.Viewer for .NET provides a set of options to apply different document page transformations:

* Page Rotation - applies page rotation when rendering a document to HTML or Image formats.
* Watermarking - applies the specified text as watermark to all document pages when rendering document to HTML or Image formats.
* Page Reorder - changes the page order when rendering a document to HTML or Image formats.

## Caching results

GroupDocs.Viewer for .NET provides a document viewer API that supports caching in order to boost document loading speed and optimize application performance.

Documents cache is saved to a local disk by default. However, document viewer API also provides document cache interfaces that can be implemented for 3rd party storage support - FTP, Amazon S3, Dropbox, Google Drive, Windows Azure, Redis or any other.
  
## Document text extraction

When using Image Viewer with [PngViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/pngviewoptions) or [JpgViewOptions](https://apireference.groupdocs.com/net/viewer/groupdocs.viewer.options/jpgviewoptions), document text can be extracted along with separate words coordinates.

This may be helpful when you want to add selectable text layer over the page image.
  
## Document information extraction

GroupDocs.Viewer for .NET allows to obtain basic information about source documents such as file type, pages count, text with coordinates, etc.

For the following document formats additional information can also be extracted:

* Archive – list of folders contained in archive;
* CAD - list of layers and layouts in a CAD document;
* Email – list of folders contained in an Outlook data file document;
* PDF – information about document printing restrictions;
* Project Management – project start and end dates.
