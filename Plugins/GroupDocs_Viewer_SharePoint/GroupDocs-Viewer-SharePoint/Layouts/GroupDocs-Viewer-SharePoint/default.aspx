<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GroupDocs_Viewer_SharePoint.Layouts.GroupDocs_Viewer_SharePoint.default" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
     <title>GroupDocs.Viewer for .NET SharePoint Sample</title>
         
        <script type ="text/jscript" src="Scripts/jquery-1.9.1.min.js"></script>
        <script type ="text/jscript" src="Scripts/jquery-ui-1.10.3.min.js"></script>
        <script type ="text/jscript" src="Scripts/knockout-3.2.0.js"></script>


        <script type ="text/javascript" src="Scripts/turn.min.js"></script>
        <script type ="text/jscript" src="Scripts/modernizr.2.6.2.Transform2d.min.js"></script>
        <script type ="text/jscript" src="Scripts/installableViewer.js"></script>

        <script type='text/javascript'> $.ui.groupdocsViewer.prototype.applicationPath = 'http://win-50lbl4alcmn:6281/_layouts/15/GroupDocs-Viewer-SharePoint/default.aspx';</script>
        <script type='text/javascript'> $.ui.groupdocsViewer.prototype.useHttpHandlers = false;</script>
        <script type ="text/jscript" src="Scripts/GroupdocsViewer.all.js"></script>

        <link href="Content/CSS/bootstrap.css" rel="stylesheet" />
        <link href="Content/CSS/groupdocsViewer.all.css" rel="stylesheet" />
        <link href=" Content/CSS/dialog.css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
     <h2 style="text-align: center">GroupDocs.Viewer for .NET SharePoint Sample</h2>

        <table style="width: 100%">
            <tr>
                <td style="text-align: center">
                    <h4>View document</h4>
                </td>

            </tr>
            <tr>
                <td style="text-align: center">

                    <div id="viewerHtmlDiv"></div>
                </td>

            </tr>
        </table>

    <script>
        // For Html Representation
        $(function () {
            $('#viewerHtmlDiv').groupdocsViewer({
                //filePath: 'http://groupdocs.com/images/banner/carousel2/signature.png',
                filePath: 'demo.docx',
                zoomToFitWidth: true,
                showFolderBrowser: true,
                showHeader: true,
                showPaging: true,
                showThumbnails: true,
                showZoom: true,
                useHtmlThumbnails: true,
                width: 800,
                height: 900,
                useHtmlBasedEngine: true,
                showDownload: true,
                downloadPdfFile: true,
                showPrint: true,
                usePdfPrinting: true,
                supportPageRotation: true

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

</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
GroupDocs.Viewer for .Net SharePoint Sample
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
GroupDocs.Viewer for .Net SharePoint Sample
</asp:Content>
