namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.ProcessingAttachments.HowToConvertAndViewAttachments;

using System.IO;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class ConvertAndViewAttachments
{
    public static void Run()
    {
        // ...

        // Specify attachment.
        Attachment attachment = new Attachment("delivery-note-0912.xlsx", "delivery-note-0912.xlsx");

        // Create a stream for attachment.
        MemoryStream attachmentStream = new MemoryStream();

        //Save attachment
        using (Viewer viewer = new Viewer("sample.msg"))
        {
            viewer.SaveAttachment(attachment, attachmentStream);
        }

        // Render attachment
        using (Viewer viewer = new Viewer(attachmentStream))
        {
            HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources();
            viewer.View(options);
        }
    }
}
