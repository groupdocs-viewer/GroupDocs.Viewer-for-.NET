using System;
using System.Web;
using System.Web.UI;
using GroupDocs.Viewer.Live.Demos.UI.Models;
using GroupDocs.Viewer.Live.Demos.UI.Config;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GroupDocs.Viewer.Live.Demos.UI.ViewerApp
{
	public partial class ViewerFileApp : BasePage
	{
		public string howto = "";
		public string fileFormat = "";
		public string metatitle = "";
		public string metadescription = "";
		public string metakeywords = "";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string validationExpression = "";
				string validFileExtensions = validationExpression;// GetValidFileExtensions(validationExpression);
				string validformats = "PDF, PS, EPS, PCL, DOC, DOCX, DOCM, DOT, DOTX, DOTM, MOBI, XLS, XLSX, XLSM, XLTX, XLTM, XLSB, PPT, PPTX, PPS, PPSX, POTM, PPSM, POTX, PPTM, VSD, VDX, VSS, VSX, VST, VTX, VSDX, VDW, VSSX, VSTX, VSTM, VSDM, VSSM, MPP, MPT, MSG, EML, OST, PST, ONE, EMLX, ODT, OTT, ODS, ODP, OTP, OTS, ODG, RTF, TXT, TEX, CSV, TSV, HTML, MHT, XML, XPS, DXF, DWG, DWF, IFC, STL, DGN, BMP, GIF, JPG, JPEG, PNG, TIFF, DJVU, SVG, WEBP, DNG, JP2, J2C, J2K, JPF, JPX, JPM, DCM, EPUB, ICO, WMF, EMF, PSD, CGM";

				metatitle = "Free Online Document Viewer";
				metadescription = "Free online document viewer. 100% free online document viewer, secure and easy to use. free online document viewer for " + validformats;
				metakeywords = "Free online document viewer, 100% free online document viewer, free online document viewer, ";
				hdescription.InnerHtml = "Fast and Secure Viewer for more than 90 types of documents, from any device with a modern browser like Chrome, Opera and Firefox.";

				foreach (string str in validformats.Replace(" ", "").Split(','))
				{
					metakeywords += str + " viewer, ";
				}
				metakeywords += "GroupDocs";
				howto = " document files";

				dvAllFormats.Visible = true;

				if (Page.RouteData.Values["fileformat"] != null)
				{
					if (!Page.RouteData.Values["fileformat"].ToString().ToLower().Equals("total"))
						validformats = Page.RouteData.Values["fileformat"].ToString().ToUpper();
				}
				//Response response = GroupDocsViewerApiHelper.GetAllViewerSupportedFormats();
				string supportedFileExtensions = "";
				//if (response == null)
				//{
				//	throw new Exception(Resources["APIResponseTime"]);
				//}
				//else if (response.StatusCode == 200)
				//{
				//	if (response.OutputType.Length > 0)
				//	{
				validationExpression = "." + validformats.Replace(", ", "|.").ToLower();
				validFileExtensions = validformats;
				supportedFileExtensions = validformats;
				//	}
				//}

				ValidateFileType.ValidationExpression = @"(.*?)(" + validationExpression.ToLower() + "|" + validationExpression.ToUpper() + ")$";

				int index = supportedFileExtensions.LastIndexOf(",");
				if (index != -1)
				{
					string substr = supportedFileExtensions.Substring(index);
					string str = substr.Replace(",", " or");
					supportedFileExtensions = supportedFileExtensions.Replace(substr, str);
				}

				ValidateFileType.ErrorMessage = Resources["InvalidFileExtension"] + " " + supportedFileExtensions;

				aPoweredBy.InnerText = "GroupDocs.Viewer";
				aPoweredBy.HRef = "https://products.GroupDocs.com/viewer";

				hFeatureTitle.InnerText = "GroupDocs Viewer App";
				hPageTitle.InnerHtml = "View your file online from anywhere";

				hdnAllowedFileTypes.Value = validFileExtensions.ToLower();

				btnView.Text = Resources["btnViewNow"];
				rfvFile.ErrorMessage = Resources["SelectorDropFileMessage"];
				h4para.InnerText = string.Format(Resources["ViewerFeature1Description"], "");

				if (Page.RouteData.Values["fileformat"] != null)
				{
					if (!Page.RouteData.Values["fileformat"].ToString().ToLower().Equals("total"))
					{
						howto = " " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " file";
						metatitle = "Free Online  " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " Viewer";
						metadescription = "Free online document viewer. 100% free online document viewer, secure and easy to use. free online document viewer for " + validformats;
						metakeywords = "Free online " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " viewer, 100% free online " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " viewer, free online " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " viewer, ";

						foreach (string str in validformats.Replace(" ", "").Split(','))
						{
							metakeywords += str + " viewer, ";
						}
						metakeywords += "GroupDocs";

						hheading.InnerHtml = metatitle;
						hdescription.InnerHtml = "View " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " documents online from any device, with a modern browser like Chrome, Opera and Firefox.";
						hfToFormat.Value = Page.RouteData.Values["fileformat"].ToString();

						fileFormat = Page.RouteData.Values["fileformat"].ToString().ToUpper() + " ";
					}
				}
			}

			Page.Title = metatitle;
			Page.MetaDescription = metadescription;
		}

		private string GetValidFileExtensions(string validationExpression)
		{
			string validFileExtensions = validationExpression.Replace(".", "").Replace("|", ", ").ToUpper();

			int index = validFileExtensions.LastIndexOf(",");
			if (index != -1)
			{
				string substr = validFileExtensions.Substring(index);
				string str = substr.Replace(",", " or");
				validFileExtensions = validFileExtensions.Replace(substr, str);
			}

			return validFileExtensions;
		}

		private string TitleCase(string value)
		{
			return new CultureInfo("en-US", false).TextInfo.ToTitleCase(value);
		}

		protected void btnView_Click(object sender, EventArgs e)
		{
			if (IsValid)
			{
                Configuration.GroupDocsAppsAPIBasePath = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                Configuration.FileDownloadLink = Configuration.GroupDocsAppsAPIBasePath + "DownloadFile.aspx";

                // Access the File using the Name of HTML INPUT File.
                HttpPostedFile postedFile = Request.Files["ctl00$MainContent$FileUpload1"];

				pMessage.Attributes.Remove("class");
				pMessage.InnerHtml = "";

				// Check if File is available.                

				if (postedFile != null && postedFile.ContentLength > 0)
				{
					// remove any invalid character from the filename.
					string fn = Regex.Replace(System.IO.Path.GetFileName(postedFile.FileName).Trim(), @"\A(?!(?:COM[0-9]|CON|LPT[0-9]|NUL|PRN|AUX|com[0-9]|con|lpt[0-9]|nul|prn|aux)|[\s\.])[^\\\/:*"" ?<>|]{ 1,254}\z", "");
					fn = fn.Replace(" ", String.Empty);

					string SaveLocation = Configuration.AssetPath + fn;
					SaveLocation = SaveLocation.Replace("'", "");

					try
					{
						postedFile.SaveAs(SaveLocation);
						var isFileUploaded = FileManager.UploadFile(SaveLocation, "emailTo.Value");

						if ((isFileUploaded != null) && (isFileUploaded.FileName.Trim() != ""))
						{
							if (Page.RouteData.Values["fileformat"] != null)
							{
								Response.Redirect("/viewer/" + Page.RouteData.Values["fileformat"].ToString() + "/" + isFileUploaded.FolderId + "/" + HttpUtility.UrlEncode(isFileUploaded.FileName.Trim()) + "/");
							}
							else
							{
								Response.Redirect("/viewer/" + isFileUploaded.FolderId + "/" + HttpUtility.UrlEncode(isFileUploaded.FileName.Trim()) + "/");
							}
						}
					}
					catch (Exception ex)
					{
						pMessage.InnerHtml = "Error: " + ex.Message;
						pMessage.Attributes.Add("class", "alert alert-danger");
					}
				}
			}
		}
	}
}