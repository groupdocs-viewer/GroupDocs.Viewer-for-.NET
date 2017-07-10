<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ViewerModernWebPart.Layouts.ViewerModernWebPart.Home" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
    <title>GroupDocs.Viewer for .NET SharePoint Web-Part</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/angular_material/1.1.0/angular-material.min.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons|Roboto+Condensed:400,700">
    <link href="Content/style.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.1/angular.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.1/angular-animate.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.1/angular-aria.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.1/angular-resource.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angular_material/1.1.0/angular-material.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
     <script src="Content/app.js"></script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
     <div ng-app="GroupDocsViewer" ng-cloak flex layout="column" style="height: 100%;">
        <md-toolbar ng-controller="ToolbarController" layout="row" hide-print md-whiteframe="4"
                    class="md-toolbar-tools md-scroll-shrink">
            <md-button class="md-icon-button" ng-click="toggleLeft()">
                <md-icon>menu</md-icon>
            </md-button>
            <h1 hide-xs>GroupDocs.Viewer for .NET</h1>
            <span flex></span>
            <md-button ng-href="DownloadOriginal.aspx?file={{ selectedFile }}"
                       class="md-icon-button"
                       ng-disabled="!selectedFile">
                <md-icon>file_download</md-icon>
                <md-tooltip>Download</md-tooltip>
            </md-button>
            <md-button ng-href="DownloadPdf.aspx?file={{ selectedFile }}"
                       target="_blank"
                       class="md-icon-button"
                       ng-disabled="!selectedFile">
                <md-icon>picture_as_pdf</md-icon>
                <md-tooltip>Download as pdf</md-tooltip>
            </md-button>
            <div ng-controller="AvailableFilesController">
                <md-select ng-model="selectedFile" placeholder="Please select a file"
                           md-on-open="onOpen()"
                           ng-change="onChange($event)">
                    <md-optgroup label="Available files">
                        <md-option ng-value="item" ng-repeat="item in list.d">{{ item }}</md-option>
                    </md-optgroup>
                </md-select>
            </div>
            <md-button class="md-icon-button">
                <md-icon>more_vert</md-icon>
            </md-button>
        </md-toolbar>
        <md-content flex layout="row" md-scroll-y>
            <md-content flex id="content" class="md-padding" role="main">
                <div ng-controller="PagesController">
                    <md-card ng-repeat="item in docInfo.pages.d">
                        <a name="page-view-{{ item.number }}"></a>
                        <iframe ng-src="{{ createPageUrl(selectedFile, item.number) }}"
                                width="100%"
                                frameborder="0"></iframe>
                    </md-card>
                     <div ng-repeat="attachment in docInfo.attachments.d">
                        <md-card ng-repeat="number in attachment.count">
                            <a name="page-view-{{attachment.name}}-{{number}}"></a>
                            <iframe ng-src="{{ createAttachmentPageUrl(selectedFile,attachment.name,number) }}"
                                    width="100%"
                                    frameborder="0"></iframe>
                        </md-card>
                    </div>
                </div>
            </md-content>
            <md-sidenav md-component-id="left" hide-print md-whiteframe="4" class="md-sidenav-left">
                <md-tabs md-dynamic-height md-border-bottom>
                    <md-tab label="Thumbnails">
                        <md-content role="navigation">
                            <div ng-controller="ThumbnailsController">
                                <md-card ng-repeat="item in docInfo.pages.d">
                                    <img ng-src="{{ createThumbnailUrl(selectedFile, item.number) }}"
                                         ng-click="onThumbnailClick($event, item)"
                                         class="md-card-image page-thumbnail" />
                                </md-card>
                                 <div ng-repeat="attachment in docInfo.attachments.d">
                                    <md-card ng-repeat="number in  attachment.count">
                                        <img ng-src="{{  createAttachmentThumbnailPageUrl(selectedFile,attachment.name,number) }}"
                                             ng-click="onAttachmentThumbnailClick($event,attachment.name,number)"
                                             class="md-card-image page-thumbnail" />
                                    </md-card>
                                </div>
                            </div>
                        </md-content>
                    </md-tab>
                </md-tabs>
            </md-sidenav>
        </md-content>
    </div>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">

</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
GroupDocs.Viewer for .NET SharePoint Web-Part
</asp:Content>
