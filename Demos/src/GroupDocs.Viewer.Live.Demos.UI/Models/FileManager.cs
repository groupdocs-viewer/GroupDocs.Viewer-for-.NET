using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using System.Net.Http.Headers;
using GroupDocs.Viewer.Live.Demos.UI.Config;
using System.Threading;

namespace GroupDocs.Viewer.Live.Demos.UI.Models
{
	public static class FileManager
	{
		public static FileUploadResult UploadFile(string file, string userEmail)
		{
			FileUploadResult uploadResult = null;
			try
			{
				HttpClient httpClient = new HttpClient();
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				// Read the files                 
				var fileStream = File.Open(file, FileMode.Open);
				var fileInfo = new FileInfo(file);

				var content = new MultipartFormDataContent();
				content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileInfo.Name));

				System.Threading.Tasks.Task taskUpload = httpClient.PostAsync(Configuration.GroupDocsAppsAPIBasePath + "api/GroupDocsAppsweb/UploadFile" + "?userEmail=" + userEmail, content).ContinueWith(task =>
				{
					if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
					{
						var response = task.Result;

						if (response.IsSuccessStatusCode)
						{
							uploadResult = response.Content.ReadAsAsync<FileUploadResult>().Result;

						}
					}
					fileStream.Dispose();
				});

				taskUpload.Wait();
				httpClient.Dispose();
				// Delete input file 
				if (File.Exists(file))
				{
					File.Delete(file);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return uploadResult;
		}

		public static FileUploadResult UploadFileToFolder(string file, string userEmail, string folder)
		{
			FileUploadResult uploadResult = null;
			try
			{
				HttpClient httpClient = new HttpClient();
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				// Read the files                 
				var fileStream = File.Open(file, FileMode.Open);
				var fileInfo = new FileInfo(file);

				var content = new MultipartFormDataContent();
				content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileInfo.Name)
				);

				System.Threading.Tasks.Task taskUpload = httpClient.PostAsync(Configuration.GroupDocsAppsAPIBasePath + "api/GroupDocsAppsweb/UploadFileToFolder" + "?userEmail=" + userEmail + "&folder=" + folder, content).ContinueWith(task =>
				{
					if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
					{
						var response = task.Result;

						if (response.IsSuccessStatusCode)
						{
							uploadResult = response.Content.ReadAsAsync<FileUploadResult>().Result;

						}
					}
					fileStream.Dispose();
				});

				taskUpload.Wait();
				httpClient.Dispose();
				// Delete input file 
				if (File.Exists(file))
				{
					File.Delete(file);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return uploadResult;
		}

		public static FileUploadResult UploadFile(Stream fileStream, string fileName, string userEmail)
		{
			FileUploadResult uploadResult = null;
			try
			{
				HttpClient httpClient = new HttpClient();
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				// Read the files                 

				var content = new MultipartFormDataContent();
				content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileName));

				System.Threading.Tasks.Task taskUpload = httpClient.PostAsync(Configuration.GroupDocsAppsAPIBasePath + "api/GroupDocsAppsweb/UploadFile" + "?userEmail=" + userEmail, content).ContinueWith(task =>
				{
					if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
					{
						var response = task.Result;

						if (response.IsSuccessStatusCode)
						{
							uploadResult = response.Content.ReadAsAsync<FileUploadResult>().Result;

						}
					}
				});

				try
				{
					taskUpload.Wait((Configuration.ThreadAbortSeconds + 4) * 1000, new CancellationToken(false));
				}
				catch (Exception exc)
				{
					httpClient.Dispose();
					throw exc;// new Exception("We regret to inform you that your file took more than expected time. We cannot process it at the moment.");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return uploadResult;
		}

		public static FileUploadResult UploadFileToFolder(Stream fileStream, string fileName, string userEmail, string folder)
		{
			FileUploadResult uploadResult = null;
			try
			{
				HttpClient httpClient = new HttpClient();
				httpClient.DefaultRequestHeaders.Accept.Clear();
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var content = new MultipartFormDataContent();
				content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileName)
				);

				System.Threading.Tasks.Task taskUpload = httpClient.PostAsync(Configuration.GroupDocsAppsAPIBasePath + "api/GroupDocsAppsweb/UploadFileToFolder" + "?userEmail=" + userEmail + "&folder=" + folder, content).ContinueWith(task =>
				{
					if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
					{
						var response = task.Result;

						if (response.IsSuccessStatusCode)
						{
							uploadResult = response.Content.ReadAsAsync<FileUploadResult>().Result;

						}
					}
				});

				try
				{
					taskUpload.Wait((Configuration.ThreadAbortSeconds + 4) * 1000, new CancellationToken(false));
				}
				catch (Exception exc)
				{
					httpClient.Dispose();
					throw exc;// new Exception("We regret to inform you that your file took more than expected time. We cannot process it at the moment.");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return uploadResult;
		}

		public static HttpResponseMessage DownloadFile(string fileName)
		{
			HttpResponseMessage result = null;
			using (var httpClient = new HttpClient())
			{
				var url = Configuration.GroupDocsAppsAPIBasePath + "api/GroupDocsAppsweb/DownloadFile?outFile=" + fileName;

				result = httpClient.GetAsync(url).Result;

			}
			return result;
		}
	}
}