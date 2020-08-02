using System;
using System.IO;
using System.Web.Http;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Drawing.Imaging;
using System.Net;
using GroupDocs.Viewer.Live.Demos.UI.Models;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Live.Demos.UI.Controllers
{
	public class GroupDocsViewerController : ApiControllerBase
	{
		[HttpGet]
		[ActionName("DocumentPages")]
		public List<string> DocumentPages(string file, string folderName, string userEmail, int currentPage)
		{
			string logMsg = "Product: Viewer File: " + folderName + "/" + file + " CurrentPage: " + currentPage;
			List<string> output;

			try
			{
				output = GetDocumentPages(file, folderName, userEmail, currentPage);				
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return output;
		}

		private List<string> GetDocumentPages(string file, string folderName, string userEmail, int currentPage)
		{
			List<string> lstOutput = new List<string>();
			string outfileName = "page_{0}";
			string outPath = AppSettings.OutputDirectory + folderName + "/" + outfileName;
            outPath = Path.GetFullPath(outPath).Replace('\\', '/');

            //currentPage = currentPage - 1;

            string imagePath = string.Format(outPath, currentPage) + ".png";

			if (!Directory.Exists(AppSettings.OutputDirectory + folderName))
			{
				Directory.CreateDirectory(AppSettings.OutputDirectory + folderName);
			}

			if (System.IO.File.Exists(imagePath) && currentPage > 1)
			{
				lstOutput.Add(imagePath);
				return lstOutput;
			}

			int i = currentPage;

			// check Words product family
			try
			{
				//GroupDocs.Apps.API.Models.License.SetGroupDocsViewerLicense();

				PngViewOptions options = new PngViewOptions(outPath + ".png");
				GroupDocs.Viewer.Viewer viewer = new GroupDocs.Viewer.Viewer(AppSettings.WorkingDirectory + folderName + "/" + file);

				if (currentPage <= 1)
				{
					lstOutput.Add(viewer.GetViewInfo(ViewInfoOptions.ForPngView(false)).Pages.Count.ToString());
				}

				viewer.View(options, new int[] { currentPage });
				lstOutput.Add(imagePath);

				return lstOutput;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpGet]
		[ActionName("DownloadDocument")]
		public HttpResponseMessage DownloadDocument(string file, string folderName, bool isImage)
		{
			file = file.Replace("../", "").Replace("//", "");
			folderName = folderName.Replace("../", "").Replace("//", "");
			string outfileName = Path.GetFileNameWithoutExtension(file) + "_Out.zip";
			string outPath = AppSettings.OutputDirectory + outfileName;

			string parentFolder = Directory.GetParent(System.IO.Path.Combine(AppSettings.WorkingDirectory + folderName + "/" + file, @"..\..")).ToString();

			if (!parentFolder.ToLower().Equals(AppSettings.FilesBaseDirectory))
			{
				throw new Exception("Invalid file path.");
			}

			if (!isImage)
			{
				outPath = AppSettings.WorkingDirectory + folderName + "/" + file;
			}
			else
			{
				if (System.IO.File.Exists(outPath))
					System.IO.File.Delete(outPath);

				List<string> lst = GetDocumentPages(file, folderName, "none", 1);

				if (lst.Count > 1)
				{
					int tmpPageCount = int.Parse(lst[0]);
					for (int i = 2; i <= tmpPageCount; i++)
					{
						GetDocumentPages(file, folderName, "none", i);
					}
				}

				if (System.IO.File.Exists(outPath))
					System.IO.File.Delete(outPath);

				ZipFile.CreateFromDirectory(AppSettings.OutputDirectory + folderName + "/", outPath);
			}

			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(outPath, FileMode.Open, FileAccess.Read);
			}
			catch (Exception x)
			{
				throw x;
			}

			using (var ms = new MemoryStream())
			{
				fileStream.CopyTo(ms);
				var result = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new ByteArrayContent(ms.ToArray())
				};
				result.Content.Headers.ContentDisposition =
					new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
					{
						FileName = (isImage ? outfileName : file)
					};
				result.Content.Headers.ContentType =
					new MediaTypeHeaderValue("application/octet-stream");

				return result;
			}
		}

		[HttpGet]
		[ActionName("PrintableHtml")]
		public String PrintableHtml(string file, string folderName)
		{
			string outPath = AppSettings.WorkingDirectory + folderName + "/" + file;

			//GroupDocs.Apps.API.Models.License.SetGroupDocsViewerLicense();
			HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources("page_{0}.html");
			options.Minify = true;

			GroupDocs.Viewer.Viewer viewer = new GroupDocs.Viewer.Viewer(AppSettings.WorkingDirectory + folderName + "/" + file);
			viewer.View(options);

			return "".Replace(".doc-page { position: absolute; }", ".doc-page { position: relative; }");
		}

		[HttpGet]
		[ActionName("DownloadPDFDocument")]
		public HttpResponseMessage DownloadPDFDocument(string file, string folderName)
		{
			file = file.Replace("../", "").Replace("//", "");
			folderName = folderName.Replace("../", "").Replace("//", "");
			string outPath = AppSettings.OutputDirectory + folderName + "/" + Path.GetFileNameWithoutExtension(file) + ".pdf";

			//GroupDocs.Apps.API.Models.License.SetGroupDocsViewerLicense();

			PdfViewOptions options = new PdfViewOptions(outPath);

			GroupDocs.Viewer.Viewer viewer = new GroupDocs.Viewer.Viewer(AppSettings.WorkingDirectory + folderName + "/" + file);
			viewer.View(options);

			FileStream fileStream = new FileStream(outPath, FileMode.Open, FileAccess.Read);

			using (var ms = new MemoryStream())
			{
				fileStream.CopyTo(ms);
				var result = new HttpResponseMessage(HttpStatusCode.OK)
				{
					Content = new ByteArrayContent(ms.ToArray())
				};
				result.Content.Headers.ContentDisposition =
					new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
					{
						FileName = Path.GetFileNameWithoutExtension(file) + ".pdf"
					};
				result.Content.Headers.ContentType =
					new MediaTypeHeaderValue("application/octet-stream");
				fileStream.Close();
				return result;
			}
		}

		[HttpGet]
		[ActionName("PageImage")]
		public HttpResponseMessage PageImage(string imagePath)
		{
			imagePath = imagePath.Replace("../", "").Replace("//", "");
			return GetImageFromPath(imagePath);
		}

		private HttpResponseMessage GetImageFromPath(string imagePath)
		{
			HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
			FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
			System.Drawing.Image image = System.Drawing.Image.FromStream(fileStream);
			MemoryStream memoryStream = new MemoryStream();


			image.Save(memoryStream, ImageFormat.Jpeg);
			result.Content = new ByteArrayContent(memoryStream.ToArray());
			result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
			fileStream.Close();

			return result;
		}

		[HttpGet]
		[ActionName("GetAllViewerSupportedFormats")]
		public async Task<Response> GetAllViewerSupportedFormats()
		{
			string logMsg = "ControllerName: GetDocumentSaveOptionsViewerController";
			try
			{

				//GroupDocs.Apps.API.Models.License.SetGroupDocsViewerLicense();

				// Get supported document formats
				var supportedDocumentFormats = GroupDocs.Viewer.FileType.GetSupportedFileTypes();
				string strFromExtensions = "";

				foreach (var name in supportedDocumentFormats)
				{
					strFromExtensions += name.Extension.ToUpper().Replace(".", "") + ", ";
				}

				strFromExtensions = strFromExtensions.Trim().Trim(',');

				return await Task.FromResult(new Response
				{
					OutputType = strFromExtensions,
					StatusCode = 200
				});
			}
			catch (Exception exc)
			{
				return new Response
				{
					Status = exc.Message,
					StatusCode = 500,
					Text = exc.ToString()
				};
			}
		}
	}
}
