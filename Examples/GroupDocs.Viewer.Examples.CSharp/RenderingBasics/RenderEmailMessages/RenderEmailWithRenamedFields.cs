namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderEmailMessages;

using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderEmailWithRenamedFields
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.eml"))
        {
            // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("output.html");
            // Specify custom field labels.
            viewOptions.EmailOptions.FieldTextMap[Field.From] = "Sender";
            viewOptions.EmailOptions.FieldTextMap[Field.To] = "Recipient";
            viewOptions.EmailOptions.FieldTextMap[Field.Sent] = "Date";
            viewOptions.EmailOptions.FieldTextMap[Field.Subject] = "Email subject";
            viewer.View(viewOptions);
        }
    }
}
