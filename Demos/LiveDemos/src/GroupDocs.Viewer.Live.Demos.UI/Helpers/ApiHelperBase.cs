using System.Net.Http;
using System.Net.Http.Headers;
using GroupDocs.Viewer.Live.Demos.UI.Config;
using GroupDocs.Viewer.Live.Demos.UI.Models;
using System.Collections.Generic;

namespace GroupDocs.Viewer.Live.Demos.UI.Helpers
{
    public abstract class ApiHelperBase
    {
        protected static Response CallGroupDocsAppsAPI(string controllerName, string apiName, string fileName, string folderName, string userEmail)
        {
            Response convertResponse = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //System.Threading.Tasks.Task taskUpload = client.GetAsync(Configuration.GroupDocsAppsAPIBasePath + "api/" + controllerName + "/" + apiName + "?fileName=" + fileName + "&folderName=" + folderName + "&userEmail=" + userEmail).ContinueWith(task =>
                System.Threading.Tasks.Task taskUpload = client.GetAsync("api/" + controllerName + "/" + apiName + "?fileName=" + fileName + "&folderName=" + folderName + "&userEmail=" + userEmail).ContinueWith(task =>
                {
                    if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                    {
                        HttpResponseMessage response = task.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            convertResponse = response.Content.ReadAsAsync<Response>().Result;
                        }
                    }
                });
                taskUpload.Wait();
            }

            return convertResponse;
        }       
        
        protected static Response CallGroupDocsAppsAPI(string controllerName, string apiName, string fileName, string folderName, string userEmail, Dictionary<string, string> apiParams)
        {
            Response convertResponse = null;
            
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //string requestURI = Configuration.GroupDocsAppsAPIBasePath + "api/" + controllerName + "/" + apiName + "?fileName=" + fileName + "&folderName=" + folderName + "&userEmail=" + userEmail;
                string requestURI = "api/" + controllerName + "/" + apiName + "?fileName=" + fileName + "&folderName=" + folderName + "&userEmail=" + userEmail;

                foreach (var paramValuePair in apiParams)
                {
                    requestURI = requestURI + "&" + paramValuePair.Key + "=" + paramValuePair.Value;
                }
                System.Threading.Tasks.Task taskUpload = client.GetAsync(requestURI).ContinueWith(task =>
                {
                    if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                    {
                        HttpResponseMessage response = task.Result;
                        if (response.IsSuccessStatusCode)
                        {
                            convertResponse = response.Content.ReadAsAsync<Response>().Result;
                        }
                    }
                });
                taskUpload.Wait();
            }

            return convertResponse;
        }
    }
}