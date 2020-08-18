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

namespace UnitTestProject.Test
{
    class APItest
    {
        //private static SwapiPlanets planets;
        //public RestClient _restClient;

        //[SetUp]
        //public static SetupPlanets()
        //{
        //    planets = new SwapiPlanets;
        //}

        APIHelper restAPI = new APIHelper();
        int planetsCount = 60;

        public string endpoint = "planets/";
        public int correctStatusCode = 200;

        [Test]
        public void Test()
        {

            var restUrl = restAPI.SetUrl(endpoint);
            var request = restAPI.CreateGetRequest();
            var response = restAPI.GetResponse(restUrl, request);
            var vol = restAPI.DeSeriolizeObj(response);
            Assert.AreEqual((int)vol.count, planetsCount);
        }

        [Test]
        public void Test2()
        {
            var restUrl = restAPI.SetUrl(endpoint);
            var request = restAPI.CreateGetRequest();
            var response = restAPI.GetResponse(restUrl, request);
            dynamic vol = restAPI.DeSeriolizeObj(response);
            string urlPlanet = vol.results[0].url;
            var restUrlPlanet = restAPI.SetUrl(urlPlanet);
            var requestPlanet = restAPI.CreateGetRequest();
            var responsePlanet = restAPI.GetResponse(restUrlPlanet, requestPlanet);
            dynamic volPlanet = restAPI.DeSeriolizeObj(responsePlanet);
            var actuakStatusCode = restAPI.GetStatusCode(responsePlanet);
            Assert.AreEqual(actuakStatusCode, correctStatusCode);

        }

        [Test]
        public void HardCoding()
        {
            RestClient client = new RestClient("https://swapi.dev/api/planets");
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);
            string stream = response.Content;
            dynamic vol = Newtonsoft.Json.JsonConvert.DeserializeObject(stream);
            Assert.AreEqual((int)vol.count, planetsCount);
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
        }
    }
}
