namespace GroupDocs.Viewer.Examples.CSharp.Showcases.HowToIntegrateGroupdocsViewerInAspNetCoreWebApp;

public static class AspnetCoreAuthorization
{
    public static void Run()
    {
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapGroupDocsViewerUI(options =>
        {
            options.UIPath = "/viewer";
            options.ApiEndpoint = "/viewer-api";
        }).RequireAuthorization();

        app.MapGroupDocsViewerApi(options =>
        {
            options.ApiPath = "/viewer-api";
        }).RequireAuthorization();
    }
}
