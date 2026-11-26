namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.RenderingDocuments.RenderingToPdf.ProtectPdfDocument;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class ProtectPdfDocument
{
    public static void Run()
    {
        // ...

        using(Viewer viewer = new Viewer("sample.docx"))
        {
            // Specify the security settings.
            Security security = new Security();
            security.DocumentOpenPassword = "o123";
            security.PermissionsPassword = "p123";
            security.Permissions = Permissions.AllowAll ^ Permissions.DenyPrinting;

            // Create a PDF file.
            PdfViewOptions viewOptions = new PdfViewOptions();

            // Apply the security settings
            viewOptions.Security = security;
            viewer.View(viewOptions);
        }
    }
}
