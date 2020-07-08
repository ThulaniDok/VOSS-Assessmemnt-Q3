using System;
using System.IO;
using RestSharp;
using RestSharp.Serialization.Json;

namespace Assessment_Question_3
{
    class Program
    {
        
        /// <summary>
        /// Representing service endpoint
        /// </summary>
        private const string Service = "/api/users";
        
        static void Main(string[] args)
        {
            var client = new RestClient("https://reqres.in");
            var request = new RestRequest(Service, Method.GET);
            
            var response = client.Execute(request);
            var obj = new JsonDeserializer().Deserialize<dynamic>(response);
            var users = obj["data"];

            foreach (var user in users)
            {
                var id = user["id"];
                var firstName = user["first_name"];
                var lastName = user["last_name"];
                
                var path = @"\home\" + id + firstName + lastName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Console.WriteLine(user);
            }
        }
    }
}