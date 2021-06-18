<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viewer.aspx.cs" Inherits="GroupDocs.Viewer.WebForms.Viewer" %>

<%
    GroupDocs.Viewer.WebForms.Products.Common.Config.GlobalConfiguration config = new GroupDocs.Viewer.WebForms.Products.Common.Config.GlobalConfiguration();
%>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1" />
    <title>Viewer for .NET Web Forms</title>
    <link rel="icon" type="image/x-icon" href="resources/viewer/favicon.ico" />
</head>
<body>
    <client-root></client-root>
    <script src="/viewer/resources/viewer/runtime-es2015.js" type="module"></script>
    <script src="/viewer/resources/viewer/runtime-es5.js" nomodule></script>
    <script src="/viewer/resources/viewer/polyfills-es2015.js" type="module"></script>
    <script src="/viewer/resources/viewer/polyfills-es5.js" nomodule></script>
    <script src="/viewer/resources/viewer/styles-es2015.js" type="module"></script>
    <script src="/viewer/resources/viewer/styles-es5.js" nomodule></script>
    <script src="/viewer/resources/viewer/vendor-es2015.js" type="module"></script>
    <script src="/viewer/resources/viewer/vendor-es5.js" nomodule></script>
    <script src="/viewer/resources/viewer/main-es2015.js" type="module"></script>
    <script src="/viewer/resources/viewer/main-es5.js" nomodule></script>
</body>
</html>