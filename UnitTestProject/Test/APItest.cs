using NUnit.Framework;
using RestSharp;
using System;
using static UnitTestProject.Core.RestHelper.RestAPIHelper;
using NUnitTestProject1.Test;
using Newtonsoft.Json.Linq;

namespace UnitTestProject.Test
{
    class APItest : ExtentSetUpFixture
    {

        APIHelper restAPI = new APIHelper();

        protected readonly string planetUrl = "planets/";
        protected readonly string filmsUrl = "films/";
        protected readonly string firstFilms = "A New Hope";
        protected readonly string urlAppCentrApi = "https://api.appcenter.ms/v0.1/user/metadata/optimizely";
        protected readonly string tokenApp = "js2kgp";
        protected readonly int correctStatusCode = 200;
        protected readonly int correctStatusCodeApp = 401;
        protected readonly int planetsCount = 60;


        [Test]
        public void TestAPI0()
        {
            IRestResponse response = restAPI.GetReesponse(planetUrl);
            JObject parsRequest = restAPI.GetObj(response);
            int countPlanet = Convert.ToInt32(parsRequest["count"]);
            Assert.AreEqual(planetsCount, countPlanet);
        }
        [Test, Order(2)]
        public void TestAPI1()
        {
            IRestResponse response = restAPI.GetReesponse(planetUrl);
            JObject parsRequest = restAPI.GetObj(response);
            string urlFirstPlanet = Convert.ToString(parsRequest["results"][0]["url"]);
            IRestResponse responseFirstPlanet = restAPI.GetReesponse(urlFirstPlanet);
            JObject parsRequestFirstPlanet = restAPI.GetObj(responseFirstPlanet);
            string nameFirstPlanet = Convert.ToString(parsRequestFirstPlanet["name"]);
            int actualStatusCode = restAPI.GetStatusCode(responseFirstPlanet);
            Assert.AreEqual(correctStatusCode, actualStatusCode);
            Assert.AreEqual("Tatooine", nameFirstPlanet);
        }
           
        [Test, Order(3)]
        public void TestAPI2()
        {
            IRestResponse response = restAPI.GetReesponse(filmsUrl);
            JObject parsRequest = restAPI.GetObj(response);
            string firsPilm = Convert.ToString(parsRequest["results"][0]["title"]);
            Assert.AreEqual(firstFilms, firsPilm);
        }
  
        [Test, Order(4)]
        public void TestAPI4()
        {
            IRestResponse response = restAPI.GetReesponse(urlAppCentrApi);
            int actualStatusCode = restAPI.GetStatusCode(response);
            Assert.AreEqual(correctStatusCodeApp, actualStatusCode);
        }

    }
}
