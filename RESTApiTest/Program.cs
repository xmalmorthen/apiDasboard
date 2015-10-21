using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string query = "select count(id) Enero from [apiDashboard].[dbo].[maFlow]   where DATEPART(month, payDatetime) = 01; select count(id) Febrero from [apiDashboard].[dbo].[maFlow]   where DATEPART(month, payDatetime) = 02";

            var client = new RestClient("http://localhost:64412/apiV1/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest(string.Format("select?query={0}", query.Trim()), Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("CnnString", "RGF0YSBTb3VyY2U9Llxtc3NxbDIwMTQ7SW5pdGlhbCBDYXRhbG9nPWFwaURhc2hib2FyZDtQZXJzaXN0IFNlY3VyaXR5IEluZm89VHJ1ZTtVc2VyIElEPXNhO1Bhc3N3b3JkPWFz");
            request.AddHeader("Provider", "sqlserver");

            try
            {
                RestResponse response = client.Execute(request) as RestResponse;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    dynamic data = JValue.Parse(response.Content);

                    if (data.REST_Service.Status_code.ToString() == "1")
                    {
                        foreach (dynamic item in data.Response)
                        {
                            Console.WriteLine("Command : {0}", item.Command.ToString());
                            JArray result = new JArray(item.Result);

                            foreach (JObject content in result.Children<JObject>())
                            {
                                foreach (JProperty prop in content.Properties())
                                {
                                    Console.WriteLine("{0} : {1}", prop.Name.ToString().Trim(), prop.Value.ToString().Trim());
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception(data.REST_Service.Message.ToString());
                    }
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Ocurrió un error [ {0} ]", ex.Message));
            }

            Console.ReadKey();
        }
    }
}
