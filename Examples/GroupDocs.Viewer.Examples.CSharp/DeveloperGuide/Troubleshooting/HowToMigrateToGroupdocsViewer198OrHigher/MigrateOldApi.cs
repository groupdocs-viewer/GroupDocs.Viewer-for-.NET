namespace GroupDocs.Viewer.Examples.CSharp.DeveloperGuide.Troubleshooting.HowToMigrateToGroupdocsViewer198OrHigher;

using System.Collections.Generic;
using System;
using GroupDocs.Viewer.Options;

public static class MigrateOldApi
{
    public static void Run()
    {
        //Get Configurations
        ViewerConfig config = Utilities.GetConfigurations();

        // Create html handler
        ViewerHtmlHandler htmlHandler = new ViewerHtmlHandler(config);

        // Guid implies that unique document name 
        string guid = "sample.docx";

        //Instantiate the HtmlOptions object
        HtmlOptions options = new HtmlOptions();

        //to get html representations of pages with embedded resources
        options.IsResourcesEmbedded = true;

        // Set password if document is password protected. 
        if(!String.IsNullOrEmpty(DocumentPassword))
           options.Password = DocumentPassword;

        //Get document pages in html form
        List<PageHtml> pages = htmlHandler.GetPages(guid, options);

        foreach (PageHtml page in pages)
        {
            //Save each page at disk
            Utilities.SaveAsHtml(page.PageNumber + "_" + DocumentName, page.HtmlContent);
        }
    }
}
