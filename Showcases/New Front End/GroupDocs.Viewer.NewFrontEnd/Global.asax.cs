using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace GroupDocs.Viewer.NewFrontEnd
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["LicenseFile"].ToString()))
                GroupDocs.Viewer.Model.Utilities.ApplyLicense(System.Configuration.ConfigurationManager.AppSettings["LicenseFile"].ToString());
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}