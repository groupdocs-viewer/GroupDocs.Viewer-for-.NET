using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace GroupDocs.Viewer.Live.Demos.UI.Config
{
    public class BaseUserControl : UserControl
    {
        private GroupDocsAppsContext _atcContext;

        /// <summary>
        /// Main context object to access all the dcContent specific context info
        /// </summary>
        public GroupDocsAppsContext GroupDocsAppsContext
        {
            get
            {
                if (_atcContext == null) _atcContext = new GroupDocsAppsContext(HttpContext.Current);
                return _atcContext;
            }
        }

        private Dictionary<string, string> _resources;

        /// <summary>
        /// key/value pair containing all the error messages defined in resources.xml file
        /// </summary>
        public Dictionary<string, string> Resources
        {
            get
            {
                if (_resources == null) _resources = GroupDocsAppsContext.Resources;
                return _resources;
            }
        }

        protected override void OnLoad(EventArgs e)
        {

            GroupDocsAppsContext.atcc = GroupDocsAppsContext;
        }
    }
}