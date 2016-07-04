﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GroupDocs.Viewer.WebForm.FrontEnd._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>GroupDocs.Viewer for .NET Sample</title>
   
    <script src="/Scripts/jquery-1.9.1.min.js"></script>
    <script src="/Scripts/jquery-ui-1.10.3.min.js"></script>
    <script src="/Scripts/knockout-3.2.0.js"></script>


    <script src="/Scripts/turn.min.js"></script>
    <script src="/Scripts/modernizr.2.6.2.Transform2d.min.js"></script>
    <script src="/Scripts/installableViewer.js"></script>

     <script type='text/javascript'> $.ui.groupdocsViewer.prototype.applicationPath = '/default.aspx';</script>
    <script type='text/javascript'> $.ui.groupdocsViewer.prototype.useHttpHandlers = false;</script>
    <script src="/Scripts/GroupdocsViewer.all.js"></script>
    
    <link href="~/Content/CSS/bootstrap.css" rel="stylesheet" />
    <link href="~/Content/CSS/groupdocsViewer.all.css" rel="stylesheet" />
    <link href="~/Content/CSS/dialog.css" rel="stylesheet" />
</head>
<body>
    <h2 style="text-align: center">GroupDocs.Viewer for .NET Sample</h2>

<table style="width:100%">
    <%--<tr>
        <td style="text-align: center">
            <h4>View document</h4>
        </td>
      
     </tr>--%>
    <tr style="width:100%">
        <td >
           
            <div id="viewerHtmlDiv" style="width:100%"></div>
        </td>
       
    </tr>
</table>

   


</body>
     <script>
         // For Html Representation

         $(function () {
             var viewerSyle = {
                 ScrollView: 1,
                 DoublePageFlip: 2,
                 OnePageInRow: 3,
                 TwoPagesInRow: 4,
                 CoverThenTwoPagesInRow: 5
             };
             var ImgextArr = ["jpg", "png", "bmp"];
             var FilePath = "test1.jpg";
             var isImage = $.inArray((FilePath.substr((FilePath.lastIndexOf('.') + 1))), ImgextArr) > -1 ? true : false;
             $('#viewerHtmlDiv').groupdocsViewer({
                 //filePath: 'http://groupdocs.com/images/banner/carousel2/signature.png',
                 filePath: FilePath,
                 zoomToFitWidth: true,
                 //zoomToFitHeight: true,
                 showFolderBrowser: true,
                 showHeader: true,
                 showPaging: true,
                 showThumbnails: true,
                 showZoom: true,
                 width: 650,
                 height: 900,
                 isResourcesEmbedded:true,
                 useHtmlBasedEngine: true,
                 showDownload: true,
                 downloadPdfFile: true,
                 showPrint: true,
                 preloadPagesCount: 1,
                 usePdfPrinting: true,
                 useEmScaling: isImage, 
                 //supportPageRotation: true
                 
             });
         });
         //For Image Representation
       /*  $(function () {
             $('#viewerImageDiv').groupdocsViewer({
                 filePath: 'demo.docx',
                 zoomToFitWidth: true,
                 showFolderBrowser: true,
                 showThumbnails: true,
                 showZoom: true,
                 showHeader: true,
                 showPaging: true,
                 width: 650,
                 height: 900,
                 watermarkPosition: 'Diagonal',
                 watermarkText: '全角',
                 watermarkWidth: 10,
                 useHtmlBasedEngine: false,
                 showDownload: true,
                 downloadPdfFile: false,
                 showPrint: true,
                 usePdfPrinting: false
             });
         });*/
    </script>
</html>
