namespace GroupDocs.Viewer.Examples.CSharp.RenderingBasics.RenderEmailMessages;

using System;
using GroupDocs.Viewer.Options;
using GroupDocs.Viewer;

public static class RenderEmailWithDatetimeFormat
{
    public static void Run()
    {
        // ...

        using (var viewer = new Viewer("sample.eml"))
        {
            // Create an HTML file.
            var viewOptions = HtmlViewOptions.ForEmbeddedResources("output.html");
            // Apply a custom format to the date in the email message header.
            viewOptions.EmailOptions.DateTimeFormat = "MMMM dd, yyyy H:mm:ss zzz";
            // Specify the time zone offset. 
            viewOptions.EmailOptions.TimeZoneOffset = new TimeSpan(-7, 0, 0);
            viewer.View(viewOptions);
        }
    }
}
