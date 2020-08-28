using MongoDB.Bson.IO;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject.Core.RestHelper;
using UnitTestProject.PageObject;
using static UnitTestProject.Core.RestHelper.RestAPIHelper;
using Newtonsoft.Json;
using RestSharp.Extensions;
using System.Diagnostics;
using System.Web.Configuration;
using System.Net;
using RestSharp.Serialization.Json;
using NUnitTestProject1.Test;

namespace UnitTestProject.Test
{
    class APItest : ExtentSetUpFixture
    {

        APIHelper restAPI = new APIHelper();

        public string planetUrl = "planets/";
        public string filmsUrl = "films/";
        public string firstFilms = "A New Hope";
        public string urlAppCentrApi = "https://api.appcenter.ms/v0.1/user/metadata/optimizely";
        public string urlWithToken = "https://api.appcenter.ms/v0.1/user/invitations/orgs/js2kgp/accept";
        public string tokenApp = "js2kgp";
        public int correctStatusCode = 200;
        public int correctStatusCodeApp = 401;
        public int planetsCount = 60;

        [Test]
        public void TestAPI()
        {

            var restUrl = restAPI.SetUrl(planetUrl);
            var request = restAPI.CreateGetRequest();
            var response = restAPI.ObjectParseOne(restUrl, request, "count");
            Assert.AreEqual((int)response, planetsCount);
        }

        [Test]
        public void TestAPI2()
        {
            var restUrl = restAPI.SetUrl(planetUrl);
            var request = restAPI.CreateGetRequest();
            var response = restAPI.ObjectParse(restUrl, request, "results", "url");
            var restUrlPlanet = restAPI.SetUrl(Convert.ToString(response));
            var requestPlanet = restAPI.CreateGetRequest();
            var responsePlanet = restAPI.ObjectParseOne(restUrlPlanet, requestPlanet, "name");
            var responseStatus = restAPI.GetResponse(restUrlPlanet, requestPlanet);
            var actualStatusCode = restAPI.GetStatusCode(responseStatus);
            Assert.AreEqual(actualStatusCode, correctStatusCode);
            Assert.AreEqual("Tatooine", Convert.ToString(responsePlanet));
            
        }
           
        [Test]
        public void TestAPI3()
        {
            var restUrl = restAPI.SetUrl(filmsUrl);
            var request = restAPI.CreateGetRequest();
            var response = restAPI.ObjectParse(restUrl, request, "results", "title"); 
            Assert.AreEqual(firstFilms, Convert.ToString(response));
        }
  
        [Test]
        public void TestAPI4()
        {
            var apiUrl = restAPI.SetUrl(urlAppCentrApi);
            var request = restAPI.CreateGetRequestToken(tokenApp);
            var response = restAPI.GetResponse(apiUrl, request);
            var actualStatusCode = restAPI.GetStatusCode(response);
            Assert.AreEqual(actualStatusCode, correctStatusCodeApp);
        }


         [Test]
         public void TestAPI5()
         {
             var apiUrl = restAPI.SetUrl(urlWithToken);
             var request = restAPI.CreatePostRequestToken();
             var response = restAPI.GetResponse(apiUrl, request);
             var actualStatusCode = restAPI.GetStatusCode(response);
             Assert.AreEqual(actualStatusCode, correctStatusCodeApp);

         }
        /*
                    [Test]
                    public void HardCoding()
                    {
                        RestClient client = new RestClient("https://swapi.dev/api/planets");
                        RestRequest request = new RestRequest(Method.GET);
                        request.AddHeader("cache-control", "no-cache");
                        request.AddHeader("content-type", "application/json");
                        var response = client.Execute(request);
                        var deserialize = new JsonDeserializer();
                        var output = deserialize.Deserialize<Dictionary<string, string>>(response);
                        var result = output["count"];
                        Assert.AreEqual(int.Parse(result), planetsCount);
                    }

                            [Test]

                            public void HardCodingHTTPie()
                            {
                                RestClient client = new RestClient("https://swapi.dev/api/planets/1");
                                RestRequest request = new RestRequest(Method.GET);
                                request.AddHeader("cache-control", "no-cache");
                                request.AddHeader("content-type", "application/json");
                                IRestResponse response = client.Execute(request);
                                HttpStatusCode statusCode = response.StatusCode;
                                int numericStatusCode = (int)statusCode;
                            }*/
    }
}
