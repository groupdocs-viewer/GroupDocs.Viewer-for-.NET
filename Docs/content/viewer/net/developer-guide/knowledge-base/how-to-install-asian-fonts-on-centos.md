---
id: how-to-install-asian-fonts-on-centos
url: viewer/net/how-to-install-asian-fonts-on-centos
title: How to install Asian Fonts on CentOS
weight: 1
description: "This article will guide you through the installation of Asian Fonts on CentOS 6 / 7 / 8."
keywords: CentOS, Asian Fonts
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
This article will guide you through the installation process of the Asian Fonts on CentOS 8 / 7 / 6 operating systems. We'll be installing groups of font packages with [yum group install](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/7/html/system_administrators_guide/sec-working_with_package_groups).

Let's see how to install Asian Fonts on:


## CentOS 7 / 8

The installation process is the same for CentOS 7 and CentOS 8.

We have to install a group of packages called Fonts that includes fonts for Asian languages.

Let's take CentOS 8 and run it in Docker container and install the fonts. 

![](viewer/net/images/how-to-install-asian-fonts-on-centos.png)

Type the following command to install a group of packages that includes Asian fonts.

```csharp
$ yum group install -y Fonts
```

  
![](viewer/net/images/how-to-install-asian-fonts-on-centos_1.png)

When installation will be completed you should see "Complete!" message.

![](viewer/net/images/how-to-install-asian-fonts-on-centos_2.png)

That's all, the fonts are installed.

## CentOS 6

For the CentOS 6 the installation process is quite different, so let's run it in Docker container and walk through all the steps.

![](viewer/net/images/how-to-install-asian-fonts-on-centos_3.png)

The fonts packages are separated into groups that we can list by typing the following command. 

```csharp
$ yum grouplist
```

![](viewer/net/images/how-to-install-asian-fonts-on-centos_4.png)

First, check what language packages that already installed under "Installed Language Packs" and then check the "Available Language Groups" section that lists the package bundles that can be installed.

Among others, you'll find the "Chinese Support \[zh\]" language group.

![](viewer/net/images/how-to-install-asian-fonts-on-centos_5.png)

Type the following command to install Chinese language support.

```csharp
$ yum groupinstall -y "Chinese Support"
```

![](viewer/net/images/how-to-install-asian-fonts-on-centos_6.png)

When the language will be installed you should see "Complete!" message.

![](viewer/net/images/how-to-install-asian-fonts-on-centos_7.png)

You can also install other Asian languages support by typing:

```csharp
$ yum groupinstall -y "Japanese Support"
$ yum groupinstall -y "Korean Support"
$ yum groupinstall -y "Hindi Support"
$ yum groupinstall -y "Kannada Support"
```
