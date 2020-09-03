using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using UnitTestProject.Core.RestHelper;
using ZendeskApi_v2.Requests.HelpCenter;
using static UnitTestProject.Core.RestHelper.RestAPIHelper;

namespace UnitTestProject.Test
{
    class SwaggerTest
    {
        protected readonly string apiUrl = "https://petstore.swagger.io/v2";
        protected readonly int corretStatusCode = 200;
        protected readonly string messageFounUser = "User not found";
        SwaggerApiHelper swApiHelper = new SwaggerApiHelper();
        APIHelper restAPI2 = new APIHelper();

        [Test]
        public void CreateSwwagerUser()
        {
            IRestResponse response = swApiHelper.CreatesUserBody(apiUrl, "Vasya");
            Assert.AreEqual(corretStatusCode, restAPI2.GetStatusCode(response));
            IRestResponse userAdd = swApiHelper.GetUser(apiUrl, "Vasya");
            JObject parsFirstUser =  restAPI2.GetObj(userAdd);
            string firstUser = Convert.ToString(parsFirstUser["username"]);
            Assert.AreEqual("Vasya", firstUser);
            swApiHelper.DeleteUser(apiUrl, "Vasya");
            IRestResponse userDell = swApiHelper.GetUser(apiUrl, "Vasya");
            JObject parsFirstUserDell = restAPI2.GetObj(userDell);
            string firstUserDell = Convert.ToString(parsFirstUserDell["message"]);
            Assert.AreEqual(messageFounUser, firstUserDell);
        }

        [Test]
        public void CreateSwwagerUserPswrd()
        {
            IRestResponse response = swApiHelper.CreatesUserBody(apiUrl, "Vasya");
            Assert.AreEqual(corretStatusCode, restAPI2.GetStatusCode(response));
            IRestResponse userAdd = swApiHelper.GetUserPassword(apiUrl);
            JObject parsFirstUser = restAPI2.GetObj(userAdd);
            string token = Convert.ToString(parsFirstUser["message"]);
            swApiHelper.DeleteUser(apiUrl, "Vasya");
            IRestResponse userDell = swApiHelper.GetUser(apiUrl, "Vasya");
            JObject parsFirstUserDell = restAPI2.GetObj(userDell);
            string firstUserDell = Convert.ToString(parsFirstUserDell["message"]);
            Assert.AreEqual(messageFounUser, firstUserDell);
        }
        [Test]
        public void CreateSwwagerUserList()
        {
            IRestResponse response = swApiHelper.CreatesUserList(apiUrl, "Ass");
            Assert.AreEqual(corretStatusCode, restAPI2.GetStatusCode(response));
            IRestResponse checkUserAdd = swApiHelper.GetUser(apiUrl, "Ass");
            JObject parsFirstUser = restAPI2.GetObj(checkUserAdd);
            string firstUser = Convert.ToString(parsFirstUser["username"]);
            Assert.AreEqual("Ass", firstUser);
            swApiHelper.DeleteUser(apiUrl, "Ass");
            IRestResponse userDell = swApiHelper.GetUser(apiUrl, "Ass");
            JObject parsFirstUserDell = restAPI2.GetObj(userDell);
            string firstUserDell = Convert.ToString(parsFirstUserDell["message"]);
            Assert.AreEqual(messageFounUser, firstUserDell);

        }
        [Test]
        public void CreatesUser()
        {
            RestClient client = new RestClient(apiUrl);
            RestRequest request = new RestRequest("/user/createWithList", Method.POST);
            List<KeyValuePair<string, string>> Vasya = new List<KeyValuePair<string, string>>();
            Vasya.Add(new KeyValuePair<string, string>("id", "0"));
            Vasya.Add(new KeyValuePair<string, string>("username", "Vasgen2"));
            Vasya.Add(new KeyValuePair<string, string>("firstName", "Vasgen"));
            Vasya.Add(new KeyValuePair<string, string>("lastName", "string"));
            Vasya.Add(new KeyValuePair<string, string>("email", "abcdafsad@hotmail.com"));
            Vasya.Add(new KeyValuePair<string, string>("password", "12345"));
            Vasya.Add(new KeyValuePair<string, string>("phone", "666666"));
            Vasya.Add(new KeyValuePair<string, string>("userStatus", "0"));
            //JObject jObjectbody = new JObject();
            //jObjectbody.Add("id", "6");
            //jObjectbody.Add("username", "Dolbic");
            //jObjectbody.Add("firstName", "01");
            //jObjectbody.Add("lastName", "Karapet");
            //jObjectbody.Add("email", "abcdafsad@hotmail.com");
            //jObjectbody.Add("password", "VasgenKrasava");
            //jObjectbody.Add("phone", "697848");
            //jObjectbody.Add("userStatus", "12");
            //request.AddHeader("accept", "application/json");
            //request.AddHeader("content-type", "application/json");
            //request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(Vasya);
            request.AddParameter("application/json", Vasya, ParameterType.RequestBody);
            IRestResponse restResponse = client.Execute(request);
            HttpStatusCode statusCode = restResponse.StatusCode;
            int numericStatusCode = (int)statusCode;
            RestClient clientUser = new RestClient(apiUrl);
            RestRequest requestUser = new RestRequest("/user/{userName}", Method.GET);
            requestUser.AddUrlSegment("userName", "Vasgen2");
            requestUser.AddHeader("accept", "application/json");
            IRestResponse restResponseUser = clientUser.Execute(requestUser);
        }


    }
}
