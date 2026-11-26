namespace GroupDocs.Viewer.Examples.CSharp.Showcases.HowToIntegrateGroupdocsViewerInAspNetCoreWebApp;

public static class AspnetCoreProgram
{
    public static void Run()
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddGroupDocsViewerUI();

        builder.Services
            .AddControllers()
            .AddGroupDocsViewerSelfHostApi()
            .AddLocalStorage("./Files")
            .AddLocalCache("./Cache");

        var app = builder.Build();

        app.UseRouting();

        app.MapGroupDocsViewerUI(options =>
        {
            options.UIPath = "/viewer";
            options.ApiEndpoint = "/viewer-api";
        });

        app.MapGroupDocsViewerApi(options =>
        {
            options.ApiPath = "/viewer-api";
        });

        app.Run();
    }
}
