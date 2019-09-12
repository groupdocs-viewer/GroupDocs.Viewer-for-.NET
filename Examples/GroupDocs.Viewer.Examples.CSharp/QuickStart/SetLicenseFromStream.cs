using System;
using System.IO;

namespace GroupDocs.Viewer.Examples.CSharp.QuickStart
{
    /// <summary>
    /// This example demonstrates how to set license from stream.
    /// </summary>
    class SetLicenseFromStream
    {
        public static void Run()
        {
            if (File.Exists(Utils.LicensePath))
            {
                using (FileStream stream = File.OpenRead(Utils.LicensePath))
                {
                    License license = new License();
                    license.SetLicense(stream);
                }

                Console.WriteLine("License set successfully.");
            }
            else
            {
                Console.WriteLine("\nWe do not ship any license with this example. " +
                                  "\nVisit the GroupDocs site to obtain either a temporary or permanent license. " +
                                  "\nLearn more about licensing at https://purchase.groupdocs.com/faqs/licensing. " +
                                  "\nLear how to request temporary license at https://purchase.groupdocs.com/temporary-license.");
            }
        }
    }
}
