namespace GroupDocs.Viewer.Examples.CSharp.GettingStarted.LicensingAndSubscription;

using System;
using GroupDocs.Viewer;

public static class ApplyMeteredLicense
{
    public static void Run()
    {
        // ...

        string publicKey = ""; // Your public license key
        string privateKey = ""; // Your private license key

        Metered metered = new Metered();
        metered.SetMeteredKey(publicKey, privateKey);

        // Get amount (MB) consumed
        decimal amountConsumed = GroupDocs.Viewer.Metered.GetConsumptionQuantity();
        Console.WriteLine("Amount (MB) consumed: " + amountConsumed);

        // Get count of credits consumed
        decimal creditsConsumed = GroupDocs.Viewer.Metered.GetConsumptionCredit();
        Console.WriteLine("Credits consumed: " + creditsConsumed);
    }
}
