using System;
using System.Web;
using System.Text;
using System.Collections.Generic;
using System.Threading;

namespace GroupDocs.Viewer.Live.Demos.UI.Config
{
	/// <summary>
	/// Wrapper class for Words GroupDocs Apps context access to Pages and controls
	/// </summary>
	public class GroupDocsAppsContext : Context
	{
		/// <summary>
		/// The context data is directly picked up from the Application Thread's data slots, this is required to share the context between
		/// independent threads working for this application, e.g. AsyncHttpRequestHandlers and other assemblies as well, this will also 
		/// eliminate the need for extra copies and object cloning b/w assemblies
		/// </summary>
		/// <param name="hc"></param>
		internal GroupDocsAppsContext(HttpContext hc) : base(hc) { Thread.SetData(Thread.GetNamedDataSlot("GroupDocsApps" + hc.Request.Url.Host.Trim().Replace(".", "") + "ContextSlot"), hc); }
		private static GroupDocsAppsContext atc;
		/// <summary>
		///  Use for internal syncing of the context
		/// </summary>
		internal static GroupDocsAppsContext atcc { set { atc = value; } }
		internal static GroupDocsAppsContext Current
		{
			get { return atc; }
		}

		internal new Dictionary<string, string> Resources
		{
			get { return base.Resources; }
		}
	}
}