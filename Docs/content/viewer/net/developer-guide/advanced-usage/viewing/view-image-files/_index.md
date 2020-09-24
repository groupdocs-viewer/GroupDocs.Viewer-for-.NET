---
id: view-image-files
url: viewer/net/view-image-files
title: View Image Files
weight: 16
description: "This article contains use-cases of viewing image files with GroupDocs.Viewer within your .NET applications."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
## Overview

For today there a lot of image files formats that contain pixel bit map with color(or black and white) values, some of them you can find in cameras (like JPEG, CR2) or in FAXes/scanners (TIF, TIFF). Some formats use image compression (like JPEG), for some formats use it optional (TIF/TIFF).

## Supported Image Formats

The following image formats are supported by the GroupDocs.Viewer for .NET.

Auto Detection means that GroupDocs.Viewer for .NET can determine the type of the image file by reading the information in the file header.

| File Extension | File Type | Auto Detection |
| --- | --- | --- |
| [.BMP](https://wiki.fileformat.com/image/bmp) | [Bitmap Picture (BMP)](https://wiki.fileformat.com/image/bmp) | Yes |
| [.CGM](https://wiki.fileformat.com/page-description-language/cgm) | [Computer Graphics Metafile](https://wiki.fileformat.com/page-description-language/cgm) | Yes |
| [.CDR](https://wiki.fileformat.com/image/cdr) | [CorelDraw Vector Graphic Drawing (CDR)](https://wiki.fileformat.com/image/cdr)[](https://wiki.fileformat.com/image/cdr/) | Yes |
| [.DCM](https://wiki.fileformat.com/image/dcm) | [Digital Imaging and Communications in Medicine (DICOM)](https://wiki.fileformat.com/image/dicom) | Yes |
| [.DJVU](https://wiki.fileformat.com/image/djvu) | [Deja Vu (DjVu)](https://wiki.fileformat.com/image/djvu) | Yes |
| [.DNG](https://wiki.fileformat.com/image/dng) | [Digital Negative Specification](https://wiki.fileformat.com/image/dng) | Yes |
| [.DIB](https://wiki.fileformat.com/image/dib) | [Device-independent bitmap](https://wiki.fileformat.com/image/dib) | Yes |
| [.EPS](https://wiki.fileformat.com/page-description-language/eps) | [Encapsulated PostScript](https://wiki.fileformat.com/page-description-language/eps) | Yes |
| [.GIF](https://wiki.fileformat.com/image/gif) | [Graphics Interchange Format (GIF)](https://wiki.fileformat.com/image/gif) | Yes |
| [.ICO](https://wiki.fileformat.com/image/ico) | [Windows Icon](https://wiki.fileformat.com/image/ico) | Yes |
| [.JP2](https://wiki.fileformat.com/image/jp2) | [JPEG 2000 Core Image File](https://wiki.fileformat.com/image/jp2) | Yes |
| .JPF | JPEG 2000 Image File | Yes |
| [.JPX](https://wiki.fileformat.com/image/jp2) | [JPEG 2000 Image File](https://wiki.fileformat.com/image/jp2) | Yes |
| .JPM | JPEG 2000 Image File | Yes |
| .J2C | JPEG 2000 Code Stream | Yes |
| [.J2K](https://wiki.fileformat.com/image/jp2) | [JPEG 2000 Code Stream](https://wiki.fileformat.com/image/jp2) | Yes |
| [.JPC](https://wiki.fileformat.com/image/jp2) | [JPEG 2000 Code Stream](https://wiki.fileformat.com/image/jp2) | Yes |
| [.JPG, .JPEG](https://wiki.fileformat.com/image/jpeg) | [Joint Photographic Experts Group (JPEG)](https://wiki.fileformat.com/image/jpeg) | Yes |
| [.ODG](https://wiki.fileformat.com/image/odg) | [Open Document Graphic (ODG)](https://wiki.fileformat.com/image/odg) | Yes |
| .FODG | Flat XML ODF Template | Yes |
| [.PCL](https://wiki.fileformat.com/page-description-language/pcl) | [Printer Command Language (PCL)](https://wiki.fileformat.com/page-description-language/pcl) | Yes |
| [.PNG](https://wiki.fileformat.com/image/png) | [Portable Network Graphics (PNG)](https://wiki.fileformat.com/image/png) | Yes |
| [.PS](https://wiki.fileformat.com/page-description-language/ps) | [PostScript (PS)](https://wiki.fileformat.com/page-description-language/ps) | Yes |
| [.PSD](https://wiki.fileformat.com/image/psd) | [Adobe Photoshop Document (PSD)](https://wiki.fileformat.com/image/psd) | Yes |
| [.PSB](https://wiki.fileformat.com/image/psb) | [Photoshop Large Document Format (PSB)](https://wiki.fileformat.com/image/psb) | Yes |
| [.SVG](https://wiki.fileformat.com/page-description-language/svg) | [Scalable Vector Graphics (SVG)](https://wiki.fileformat.com/page-description-language/svg) | Yes |
| [.SVGZ](https://fileinfo.com/extension/svgz) | [Scalable Vector Graphics gZipped (SVGZ)](https://fileinfo.com/extension/svgz) | Yes |
| [.TIF, .TIFF](https://wiki.fileformat.com/image/tiff) | [Tagged Image File Format (TIFF)](https://wiki.fileformat.com/image/tiff) | Yes |
| [.WEBP](https://wiki.fileformat.com/image/webp) | [WebP Image](https://wiki.fileformat.com/image/webp) | Yes |
| [.EMF](https://wiki.fileformat.com/image/emf) | [Windows Enhanced Metafile (EMF)](https://wiki.fileformat.com/image/emf)  | Yes |
| [.WMF](https://wiki.fileformat.com/image/wmf) | [Windows Metafile (WMF)](https://wiki.fileformat.com/image/wmf) | Yes |

## In this section

The articles given in this section describes the usage of GroupDocs.Viewer to convert Image formats with different available options.
