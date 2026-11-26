namespace GroupDocs.Viewer.Examples.CSharp.GettingStarted.LicensingAndSubscription;

using System.IO;
using GroupDocs.Viewer;

public static class ApplyLicenseFromStream
{
    public static void Run()
    {
        // ...

        string licensePath = "GroupDocs.Viewer.lic";
        using (FileStream fileStream = File.OpenRead(licensePath))
        {
            License license = new License();
            license.SetLicense(fileStream);
        }
    }
}
