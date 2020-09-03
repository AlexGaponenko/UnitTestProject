using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Core.RestHelper
{
    internal class SwaggerApiHelper
    {
        public IRestResponse CreatesUserBody(string apiUrl, string userName)
        {
            RestClient client = new RestClient(apiUrl);
            RestRequest request = new RestRequest("/user", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("id", "01");
            jObjectbody.Add("username", userName);
            jObjectbody.Add("firstName", "Vasya");
            jObjectbody.Add("lastName", "Karapet");
            jObjectbody.Add("email", "abcdafsad@hotmail.com");
            jObjectbody.Add("password", "VasgenKrasava");
            jObjectbody.Add("phone", "697848");
            jObjectbody.Add("userStatus", "12");
            request.AddHeader("accept", "application/json");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            IRestResponse restResponse = client.Execute(request);
            return restResponse;
        }
        public IRestResponse GetUser(string apiUrl, string userName )
        {
            RestClient clientUser = new RestClient(apiUrl);
            RestRequest requestUser = new RestRequest("/user/{userName}", Method.GET);
            requestUser.AddUrlSegment("userName", userName);
            requestUser.AddHeader("accept", "application/json");
            IRestResponse restResponseUser = clientUser.Execute(requestUser);
            return restResponseUser;
        }
        public IRestResponse GetUserPassword(string apiUrl)
        {
            RestClient clientUser = new RestClient(apiUrl);
            RestRequest requestUser = new RestRequest("/user/login", Method.GET);
            requestUser.AddParameter("username", "Vasya");
            requestUser.AddParameter("password", "VasgenKrasava");
            requestUser.AddHeader("accept", "application/json");
            IRestResponse restResponseUser = clientUser.Execute(requestUser);
            return restResponseUser;
        }

        public IRestResponse CreatesUserList(string apiUrl, string name)
        {
            RestClient client = new RestClient(apiUrl);
            RestRequest request = new RestRequest("/user/createWithArray", Method.POST);
            JArray array = new JArray();
            JObject jObjectbody = new JObject();
            jObjectbody.Add("id", "01");
            jObjectbody.Add("username", name);
            jObjectbody.Add("firstName", "Vasya");
            jObjectbody.Add("lastName", "Karapet");
            jObjectbody.Add("email", "abcdafsad@hotmail.com");
            jObjectbody.Add("password", "VasgenKrasava");
            jObjectbody.Add("phone", "697848");
            jObjectbody.Add("userStatus", "12");
            JObject jObjectbody2 = new JObject();
            jObjectbody2.Add("id", "02");
            jObjectbody2.Add("username", name);
            jObjectbody2.Add("firstName", "Vasya");
            jObjectbody2.Add("lastName", "Karapet");
            jObjectbody2.Add("email", "abcdafsad@hotmail.com");
            jObjectbody2.Add("password", "VasgenKrasava");
            jObjectbody2.Add("phone", "697848");
            jObjectbody2.Add("userStatus", "12");
            object[] parameterNames = new object[] { jObjectbody, jObjectbody2 };
            foreach (object parameterName in parameterNames)
            {
                array.Add(parameterName);
            }
            //List<KeyValuePair<string, string>> Vasya = new List<KeyValuePair<string, string>>();
            //Vasya.Add(new KeyValuePair<string, string>("id", "0"));
            //Vasya.Add(new KeyValuePair<string, string>("username", name));
            //Vasya.Add(new KeyValuePair<string, string>("firstName", "Vasgen"));
            //Vasya.Add(new KeyValuePair<string, string>("lastName", "string"));
            //Vasya.Add(new KeyValuePair<string, string>("email", "abcdafsad@hotmail.com"));
            //Vasya.Add(new KeyValuePair<string, string>("password", "12345"));
            //Vasya.Add(new KeyValuePair<string, string>("phone", "666666"));
            //Vasya.Add(new KeyValuePair<string, string>("userStatus", "0"));
            //request.AddJsonBody(array);
            request.AddParameter("application/json", array, ParameterType.RequestBody);
            IRestResponse restResponse = client.Execute(request);
            return restResponse;
        }
        public IRestResponse DeleteUser(string apiUrl, string nameUser)
        {
            RestClient clientUser = new RestClient(apiUrl);
            RestRequest requestUser = new RestRequest("/user/{userName}", Method.DELETE);
            requestUser.AddUrlSegment("userName", nameUser);
            requestUser.AddHeader("accept", "application/json");
            IRestResponse restResponseUser = clientUser.Execute(requestUser);
            return restResponseUser;
        }
    }
}
