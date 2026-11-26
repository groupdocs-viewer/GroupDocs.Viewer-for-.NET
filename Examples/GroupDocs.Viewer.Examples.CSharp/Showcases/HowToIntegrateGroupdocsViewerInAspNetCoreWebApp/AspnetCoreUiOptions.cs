namespace GroupDocs.Viewer.Examples.CSharp.Showcases.HowToIntegrateGroupdocsViewerInAspNetCoreWebApp;

public static class AspnetCoreUiOptions
{
    public static void Run()
    {
        builder.Services
            .AddGroupDocsViewerUI(config =>
            {
                config.EnableRotate = false;
                config.EnableThemeSwitcher = false;
            });
    }
}
