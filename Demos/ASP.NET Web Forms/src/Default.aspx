<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GroupDocs.Viewer.AspNetWebForms._Default" %>
<%@ Import Namespace="GroupDocs.Viewer.AspNetWebForms.Core" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>GroupDocs.Viewer for .NET ASP.NET Web Forms Demo</title>
</head>
<body>
<app-root></app-root>
<script type="text/javascript">
    var apiEndpoint = "<%: $"/{Constants.API_PATH}" %>";
    var uiSettingsPath = "<%: $"/{Constants.API_PATH}/{Constants.LOAD_CONFIG_ACTION_NAME}" %>";
</script>
<script src="/ClientApp/dist/runtime.js" type="module"></script>
<script src="/ClientApp/dist/polyfills.js" type="module"></script>
<script src="/ClientApp/dist/main.js" type="module"></script>
</body>
</html>