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
                if (!endpoint.StartsWith("h"))
                {
                    string url = Path.Combine(baseUrl, endpoint);
                    var restClient = new RestClient(url);
                    return restClient;
                }
                else
                {
                    var restClient = new RestClient(endpoint);
                    return restClient;
                }
   
            }

            public RestRequest CreateGetRequest()
            {
                var restRequest = new RestRequest(Method.GET);
                restRequest.AddHeader("cache-control", "no-cache");
                restRequest.AddHeader("content-type", "application/json");
                return restRequest;
            }

            public IRestResponse GetResponse(RestClient client, RestRequest request)
            {
                return client.Execute(request);
            }

            public dynamic DeSeriolizeObj(IRestResponse response)
            {
                var stream = response.Content;
                dynamic vol = JObject.Parse(stream);
                return vol;
            }

            //public string GetUrlPlanet(IRestResponse response)
            //{
            //    dynamic vol = restAPI.DeSeriolizeObj(response);
            //    string urlPlanet = vol.results[0].url;
            //    return urlPlanet;
            //}

            public int GetStatusCode(IRestResponse response)
            {
                HttpStatusCode statusCode = response.StatusCode;
                int numericStatusCode = (int)statusCode;
                return numericStatusCode;
            }

        }

    }
}
