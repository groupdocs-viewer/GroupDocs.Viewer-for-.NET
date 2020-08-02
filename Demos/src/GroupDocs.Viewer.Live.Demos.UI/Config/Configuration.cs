using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for Configuration
/// </summary>
namespace GroupDocs.Viewer.Live.Demos.UI.Config
{
	public static class Configuration
	{
        private static string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6); // + "\\GroupDocs.Total.lic";

        private static string _assetPath = path + ConfigurationManager.AppSettings["ASSETPATH"].ToString();
		private static string _appName = ConfigurationManager.AppSettings["AppName"].ToString();
		private static string _GroupDocsAppsAPIBasePath = ConfigurationManager.AppSettings["GroupDocsToolAPIBasePath"].ToString();
		private static int _smtpPort = int.Parse(ConfigurationManager.AppSettings["MailServerPort"].ToString());
		private static string _smtpServer = ConfigurationManager.AppSettings["MailServer"];
		private static string _fromEmailAddress = ConfigurationManager.AppSettings["FromAddress"];
		private static string _mailServerUserId = ConfigurationManager.AppSettings["MailServerUserId"];
		private static string _mailServerUserPassword = ConfigurationManager.AppSettings["MailServerPassword"];
		private static int _mailServerTimeOut = int.Parse(ConfigurationManager.AppSettings["SmtpTimeOut"].ToString());
		private static string _fileDownloadLink = ConfigurationManager.AppSettings["FileDownloadLink"];
		private static string _productsGroupDocsAppsURL = ConfigurationManager.AppSettings["ProductsGroupDocsAppsURL"];
		private static string _fileViewLink = ConfigurationManager.AppSettings["FileViewLink"];
        private static int _threadAbortSeconds = int.Parse(ConfigurationManager.AppSettings["ThreadAbortSeconds"].ToString());

        public static string ProductsGroupDocsAppsURL
		{
			get { return _productsGroupDocsAppsURL; }
		}
		public static string FileDownloadLink
		{
			get { return _fileDownloadLink; }
            set { _fileDownloadLink = value; }
        }
		public static int MailServerTimeOut
		{
			get { return _mailServerTimeOut; }
		}
		public static string AssetPath
		{
			get { return _assetPath; }
		}
		public static string AppName
		{
			get { return _appName; }
		}
		public static string GroupDocsAppsAPIBasePath
		{
			get { return _GroupDocsAppsAPIBasePath; }
            set { _GroupDocsAppsAPIBasePath = value; }
        }
		public static int MailServerPort
		{
			get { return _smtpPort; }
		}
		public static string MailServer
		{
			get { return _smtpServer; }
		}
		public static string FromEmailAddress
		{
			get { return _fromEmailAddress; }
		}
		public static string MailServerUserId
		{
			get { return _mailServerUserId; }
		}
		public static string MailServerUserPassword
		{
			get { return _mailServerUserPassword; }
		}
		public static string FileViewLink
		{
			get { return _fileViewLink; }
		}
        public static int ThreadAbortSeconds
        {
            get { return _threadAbortSeconds; }
        }
    }
}