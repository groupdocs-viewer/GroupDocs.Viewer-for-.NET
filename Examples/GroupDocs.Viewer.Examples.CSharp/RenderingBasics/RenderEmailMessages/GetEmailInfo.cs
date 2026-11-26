namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderEmailMessages;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer.Results;
using GroupDocs.Viewer;

public static class GetEmailInfo
{
    public static void Run()
    {
        // ...

        using (Viewer viewer = new Viewer("sample.eml"))
        {
            ViewInfo generalInfo = viewer.GetViewInfo(ViewInfoOptions.ForHtmlView());
            // explicit casting
            MailMessageViewInfo mailMessageInfo = (MailMessageViewInfo)generalInfo;
            Console.WriteLine("From: {0}; Subject: {1}; Sent: {2}.", mailMessageInfo.From, mailMessageInfo.Subject, mailMessageInfo.Sent);

            // Render to any output format if needed
            viewer.View(HtmlViewOptions.ForEmbeddedResources());
        }
    }
}
