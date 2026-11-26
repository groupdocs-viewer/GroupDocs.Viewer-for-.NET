namespace GroupDocs.Viewer.Examples.CSharp.GettingStarted.LicensingAndSubscription;

using GroupDocs.Viewer;

public static class ApplyLicenseFromFile
{
    public static void Run()
    {
        // ...

        string licensePath = "GroupDocs.Viewer.lic";
        License license = new License();
        license.SetLicense(licensePath);
    }
}
