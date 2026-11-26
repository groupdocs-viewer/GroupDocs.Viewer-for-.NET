namespace GroupDocs.Viewer.Examples.CSharp.GettingStarted.LicensingAndSubscription;

using GroupDocs.Viewer;

public static class ApplyLicenseFromEmbeddedResource
{
    public static void Run()
    {
        // ...

        License license = new License();
        license.SetLicense("GroupDocs.Viewer.lic");
    }
}
