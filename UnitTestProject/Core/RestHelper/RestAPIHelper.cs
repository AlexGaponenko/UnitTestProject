using RestSharp;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;


namespace UnitTestProject.Core.RestHelper
{
    public class RestAPIHelper
    {
       

        public class APIHelper
        {
            public RestClient restClient;
            public RestRequest restRequest;
            public string baseUrl = "https://swapi.dev/api/";


            internal RestClient SetUrl(string endpoint)
            {
                if ((endpoint.IndexOf("http")) == 0)
                {
                    var restClient = new RestClient(endpoint);
                    return restClient;
                }
                else
                {
                    string url = Path.Combine(baseUrl, endpoint);
                    var restClient = new RestClient(url);
                    return restClient;
                }
            }

            internal JObject GetObj(IRestResponse response)
            {
                JObject output = JObject.Parse(response.Content);
                return output;
            }
            internal IRestResponse GetReesponse(string endpoint)
            {
                string url = GetUrl(endpoint);
                RestClient restClient = new RestClient(url);
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("cache-control", "no-cache");
                restRequest.AddHeader("content-type", "application/json");
                IRestResponse response = restClient.Execute(restRequest);
                return response;
            }
            internal int GetStatusCode(IRestResponse response)
            {
                HttpStatusCode statusCode = response.StatusCode;
                int numericStatusCode = (int)statusCode;
                return numericStatusCode;
            }

            internal string GetUrl(string endpoint)
            {
                if ((endpoint.IndexOf("http")) == 0)
                {
                    string url = endpoint;
                    return url;
                }
                else
                {
                    string url = Path.Combine(baseUrl, endpoint);
                    return url;
                }
            }

            public RestRequest CreateGetRequest()
            {
                var restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("cache-control", "no-cache");
                restRequest.AddHeader("content-type", "application/json");
                return restRequest;
            }

            public RestRequest CreateGetRequestToken(string token)
            {
                RestRequest restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("cache-control", "no-cache");
                restRequest.AddHeader("content-type", "application/json");
                restRequest.AddHeader("content-type", "charset=utf-8");
                restRequest.AddHeader("Authorization", token);
                return restRequest;
            }

            public RestRequest CreatePostRequestToken()
            {
                RestRequest restRequest = new RestRequest(Method.POST);
                restRequest.AddHeader("cache-control", "no-cache");
                restRequest.AddHeader("content-type", "application/json");
                //restRequest.AddHeader("accept", "application/json");
                //restRequest.AddHeader("X-API-Token", "js2kgp");
                //restRequest.AddHeader("Authorization", "js2kgp");
                return restRequest;
            }

        }

    }
}
