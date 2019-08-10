using System;

namespace GroupDocs.Viewer.Examples.CSharp.QuickStart
{
    /// <summary>
    /// This example demonstrates how to set Metered license.
    /// Learn more about Metered license at https://purchase.groupdocs.com/faqs/licensing/metered.
    /// </summary>
    class SetMeteredLicense
    {
        public static void Run()
        {
            string publicKey = "*****";
            string privateKey = "*****";

            Metered metered = new Metered();
            metered.SetMeteredKey(publicKey, privateKey);

            Console.WriteLine("License set successfully.");
        }
    }
}
