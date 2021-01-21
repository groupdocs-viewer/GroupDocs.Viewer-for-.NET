---
id: installation
url: viewer/net/installation
title: Installation
weight: 4
description: ""
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
## Development Environment

GroupDocs.Viewer for .NET supported platforms are listed below.

| Platform | Description |
| --- | --- |
| .NET Standard 2.0 | Any type of  .NET Standard 2.0 application is supported (since Q4 2019). |
| .NET Framework | Any type of  .NET Framework version 2.0 (or later) application is supported - ASP.NET, Web Services, WinForms, WPF and others.  
Full support for 32-bit and 64-bit. |
| Windows Azure | Yes, GroupDocs.Viewer for .NET runs on Windows Azure. |
| Mono | You can use GroupDocs.Viewer for .NET to build applications with Mono. |

## Install from Nuget

NuGet is the easiest way to download and install GroupDocs.Viewer for .NET. There are ways to install it in your project.

### Install via Package Manager GUI

Follow these steps to reference GroupDocs.Viewer using Package Manager GUI:

* Open your solution/project in Visual Studio.
* Click **Tools** -> **NuGet Package Manager** -> **Manage NuGet Packages for Solution**. You can also access the same option through the Solution Explorer. Right-click the solution or project and select Manage NuGet Packages from the context menu
* Select **Browse tab** and type **"GroupDocs.Viewer"** in the search text box.
* Click the **Install** button to install the latest version of the API into your project as shown in the following screenshot.  

![](viewer/net/images/development-environment-installation-and-configuration.png)

#### Using Package Manager Console

You can follow the steps below to reference GroupDocs.Viewer for .NET using the Package Manager Console:
* Open your solution/project in Visual Studio.
* Select **Tools** -> **NuGet Package Manager** -> **Package Manager Console** from the menu to open package manager console.
* Type the command "Install-Package GroupDocs.Viewer" and press enter to install the latest release into your application.
* After successful installation, GroupDocs.Viewer will be referenced in your application.
![](viewer/net/images/development-environment-installation-and-configuration_1.png)

## Install from official GroupDocs website

You can follow the steps below to reference GroupDocs.Viewer for .NET downloaded from official website [Downloads section](https://downloads.groupdocs.com/viewer/net):

1. Unpack zip archive or follow MSI install wizard instructions.
2. In the Solution Explorer, expand the project node you want to add a reference to.
3. Right-click the **References** node for the project and select **Add Reference** from the menu.
4. In the Add Reference dialog box, select the **.NET** tab (it's usually selected by default).
5. If you have used MSI installer to install GroupDocs.Viewer, you will see GroupDocs.Viewer in the top pane. Select it and then click the **Select** button.
6. If you have downloaded and unpacked the DLL only, click the **Browse** button and locate the GroupDocs.Viewer.dll file.
    You have referenced GroupDocs.Viewer and it should appear in the **SelectedComponents** pane of the dialog box.
7. Click **OK**.
    GroupDocs.Viewer reference appears under the **References** node of the project.
