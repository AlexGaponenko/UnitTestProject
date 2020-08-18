using MongoDB.Bson.IO;
using RestSharp;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.PageObject
{
    class SwapiPlanets
    {
        public void Planets (object sender, EventArgs e)
        {
            RestClient client = new RestClient("https://swapi.co/api/planets/");
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            IRestResponse response = client.Execute(request);

            string stream = response.Content;
            dynamic d = Newtonsoft.Json.JsonConvert.DeserializeObject(stream);


        }
    }
}
