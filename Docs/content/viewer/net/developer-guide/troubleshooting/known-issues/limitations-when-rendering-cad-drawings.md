---
id: limitations-when-rendering-cad-drawings
url: viewer/net/limitations-when-rendering-cad-drawings
title: Limitations when rendering CAD drawings
weight: 2
description: "This article is about the limitations of GroupDocs.Viewer of rendering CAD Drawings."
keywords: 
productName: GroupDocs.Viewer for .NET
hideChildren: False
---
{{< alert style="success" >}}This limitation has been eliminated in v20.7. Do not set assembly binding redirect in case you're using the v20.7 and higher.{{< /alert >}}

## Rendering CAD drawings requires adding assembly binding redirect

When rendering CAD drawings using **GroupDocs.Viewer** it is required to add the following [assembly binding redirect](https://docs.microsoft.com/en-us/dotnet/framework/configure-apps/redirect-assembly-versions) to your project **app.config** or **web.config** files. The next example shows the required assembly binding redirect when rendering CAD drawings with GroupDocs.Viewer for .NET 20.6.1.

```csharp
<configuration>
    <!--...-->
    <runtime>
        <!--...-->
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
            <!--...-->
            <dependentAssembly>
                <assemblyIdentity name="Aspose.PDF" publicKeyToken="716fcc553a201e56" culture="neutral"/>
                <bindingRedirect oldVersion="0.0.0.0-20.5.0.0" newVersion="20.5.0.0"/>
                <publisherPolicy apply="no"/>
            </dependentAssembly>
        </assemblyBinding>
    </runtime>
</configuration>
```

## More resources

### GitHub Examples

You may easily run the code above and see the feature in action in our GitHub examples:

* [GroupDocs.Viewer for .NET examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET)
* [GroupDocs.Viewer for Java examples, plugins, and showcase](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java)
* [Document Viewer for .NET MVC UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-MVC)
* [Document Viewer for .NET App WebForms UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-.NET-WebForms)
* [Document Viewer for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Dropwizard)
* [Document Viewer for Java Spring UI Example](https://github.com/groupdocs-viewer/GroupDocs.Viewer-for-Java-Spring)

### Free Online App

Along with full-featured .NET library we provide simple but powerful free Apps.
You are welcome to view Word, PDF, Excel, PowerPoint documents with free to use online **[GroupDocs Viewer App](https://products.groupdocs.app/viewer)**.
