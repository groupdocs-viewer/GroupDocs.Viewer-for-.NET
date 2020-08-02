using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for Configuration
/// </summary>
namespace GroupDocs.Viewer.Live.Demos.UI
{
	public static class AppSettings
	{
        private static string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6); // + "\\GroupDocs.Total.lic";

        private static string _outputDirectory = path + ConfigurationManager.AppSettings["OutputDirectory"].ToString();
		private static string _workingDirectory = path + ConfigurationManager.AppSettings["WorkingDirectory"].ToString();
		private static string _storageDirectory = path + ConfigurationManager.AppSettings["StorageDirectory"].ToString();
		private static string _filesBaseDirectory = path + ConfigurationManager.AppSettings["FilesBaseDirectory"].ToString();

		public static string OutputDirectory
		{
			get { return _outputDirectory; }
		}

		public static string WorkingDirectory
		{
			get { return _workingDirectory; }
		}

		public static string StorageDirectory
		{
			get { return _storageDirectory; }
		}

		public static string FilesBaseDirectory
		{
			get { return _filesBaseDirectory.ToLower(); }
		}
	}
}