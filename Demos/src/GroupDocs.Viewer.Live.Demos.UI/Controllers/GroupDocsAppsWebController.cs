using GroupDocs.Viewer.Live.Demos.UI.Models;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace GroupDocs.Viewer.Live.Demos.UI.Controllers
{

	public class GroupDocsAppsWebController : ApiController
	{
		/// <summary>
		///Download converted file
		/// </summary>
		/// <param name="string outFile">file name</param>
		/// <returns>HttpResponseMessage</returns>
		[HttpGet]
		[ActionName("DownloadFile")]
		public HttpResponseMessage DownloadFile([FromUri]string outFile)
		{
			string downloadPath = AppSettings.OutputDirectory;

			outFile = outFile.Replace("../", "").Replace("//", "");
			var fileName = string.Format("{0}{1}", downloadPath, outFile);

			var response = Request.CreateResponse();
			string parentFolder = Directory.GetParent(System.IO.Path.Combine(fileName, @"..\..")).ToString();
			if (outFile.ToLower().EndsWith(".zip"))
				parentFolder = AppSettings.FilesBaseDirectory;

			if (!Path.GetFullPath(parentFolder).ToLower().Equals(Path.GetFullPath(AppSettings.FilesBaseDirectory)) || !System.IO.File.Exists(fileName))
			{
				response.StatusCode = HttpStatusCode.NotFound;
				response.ReasonPhrase = string.Format("The file [{0}] does not exist.", outFile);
				throw new HttpResponseException(response);
			}

			response.Content = new PushStreamContent(async (outputStream, httpContent, transportContext) =>
			{
				try
				{
					var buffer = new byte[65536];

					using (var file = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
					{
						var length = (int)file.Length;
						var bytesRead = 1;

						while (length > 0 && bytesRead > 0)
						{
							bytesRead = file.Read(buffer, 0, Math.Min(length, buffer.Length));
							await outputStream.WriteAsync(buffer, 0, bytesRead);
							length -= bytesRead;
						}
					}

				}
				finally
				{
					outputStream.Close();
				}

			});

			response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
			response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
			{
				FileName = outFile
			};

			return response;
		}
		/// <summary>
		///Returns a Json string of the settings
		/// </summary>
		/// <returns>String</returns>
		
		[MimeMultipart]
		[HttpPost]
		[ActionName("UploadFile")]
		public async Task<FileUploadResult> UploadFile(string userEmail)
		{
			string _localFileName = "";
			string folderName = "";
			try
			{
				folderName = Guid.NewGuid().ToString();
				// Prepare a path in which the result file will be
				string uploadPath = AppSettings.WorkingDirectory + "/" + folderName;
				// Check directroy already exist or not
				if (!Directory.Exists(uploadPath))
					Directory.CreateDirectory(uploadPath);

				var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);

				// Read the MIME multipart asynchronously 
				await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

				_localFileName = multipartFormDataStreamProvider
					.FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();
			}
			catch (Exception)
			{
				
			}

			// Create response
			return new FileUploadResult
			{
				LocalFilePath = _localFileName,

				FileName = Path.GetFileName(_localFileName),

				FileLength = new FileInfo(_localFileName).Length,

				FolderId = folderName
			};
		}

		[MimeMultipart]
		[HttpPost]
		[ActionName("UploadFileToFolder")]
		public async Task<FileUploadResult> UploadFileToFolder(string userEmail, string folder)
		{
			string _localFileName = "";
			string folderName = folder;
			try
			{
				// Prepare a path in which the result file will be
				string uploadPath = AppSettings.WorkingDirectory + "/" + folderName;
				// Check directroy already exist or not
				if (!Directory.Exists(uploadPath))
					Directory.CreateDirectory(uploadPath);

				var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);

				// Read the MIME multipart asynchronously 
				await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

				_localFileName = multipartFormDataStreamProvider
					.FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();
			}
			catch (Exception) 
			{
				
			}

			// Create response
			return new FileUploadResult
			{
				LocalFilePath = _localFileName,

				FileName = Path.GetFileName(_localFileName),

				FileLength = new FileInfo(_localFileName).Length,

				FolderId = folderName
			};
		}
	}
}
