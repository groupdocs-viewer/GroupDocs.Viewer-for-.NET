using System.Net.Http;
using System.Net.Http.Headers;
using GroupDocs.Viewer.Live.Demos.UI.Config;
using GroupDocs.Viewer.Live.Demos.UI.Models;

namespace GroupDocs.Viewer.Live.Demos.UI.Helpers
{
	public class GroupDocsViewerApiHelper
	{
		public static Response GetAllViewerSupportedFormats()
		{
			Response viewerResponse = null;

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				System.Threading.Tasks.Task taskUpload = client.GetAsync(Configuration.GroupDocsAppsAPIBasePath + "api/GroupDocsViewer/GetAllViewerSupportedFormats").ContinueWith(task =>
				{
					if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
					{
						HttpResponseMessage response = task.Result;
						if (response.IsSuccessStatusCode)
						{
							viewerResponse = response.Content.ReadAsAsync<Response>().Result;
						}
					}
				});
				taskUpload.Wait();
			}

			return viewerResponse;
		}
	}
}