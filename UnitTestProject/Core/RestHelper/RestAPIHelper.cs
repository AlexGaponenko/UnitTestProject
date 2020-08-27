using MongoDB.Bson.IO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using RestSharp.Serialization.Json;
using Microsoft.Extensions.Primitives;

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
                    string url = Path.Combine(baseUrl, endpoint);
                    var restClient = new RestClient(url);
                    return restClient;
            }

            internal RestClient SetUrlHttp(string endpoint)
            {
                var restClient = new RestClient(endpoint);
                return restClient;
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
 //               restRequest.AddHeader("content-type", "charset=utf-8");
                //               restRequest.AddHeader("Authorization", token);
                return restRequest;
            }

            internal object SetUrlHttp(object p)
            {
                throw new NotImplementedException();
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
            public dynamic ObjectParse(RestClient client, RestRequest request, string name, string url)
            {
                var response = client.Execute(request);
                JObject output = JObject.Parse(response.Content);
                dynamic arg = output[name][0][url];
                return arg;
            }

            public dynamic ObjectParseOne(RestClient client, RestRequest request, string name)
            {
                var response = client.Execute(request);
                JObject output = JObject.Parse(response.Content);
                dynamic arg = output[name];
                return arg;
            }

            public dynamic DeSeriolizeObj(IRestResponse response)
            {
                var stream = response.Content;
                dynamic vol = JObject.Parse(stream);
                return vol;
            }


            public int GetStatusCode(IRestResponse response)
            {
                HttpStatusCode statusCode = response.StatusCode;
                int numericStatusCode = (int)statusCode;
                return numericStatusCode;
            }
            public dynamic GetResponse(RestClient client, RestRequest request)
            {
                var response = client.Execute(request);
                return response;
            }
        }

    }
}
