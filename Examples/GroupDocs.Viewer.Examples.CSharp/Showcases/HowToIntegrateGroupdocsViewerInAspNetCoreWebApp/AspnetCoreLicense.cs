namespace GroupDocs.Viewer.Examples.CSharp.Showcases.HowToIntegrateGroupdocsViewerInAspNetCoreWebApp;

using GroupDocs.Viewer;

public static class AspnetCoreLicense
{
    public static void Run()
    {
        builder.Services
            .AddControllers()
            .AddGroupDocsViewerSelfHostApi(config =>
            {
                config.SetLicensePath("GroupDocs.Viewer.lic");
            })
            .AddLocalStorage("./Files")
            .AddLocalCache("./Cache");
    }
}
