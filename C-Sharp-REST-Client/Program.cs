using System;
using RestSharp;
using Newtonsoft.Json;

namespace C_Sharp_REST_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //GET_Ex();
            POST_Ex();

            Console.ReadLine();
        }

        private static void GET_Ex()
        {
            var client = new RestClient("http://localhost:8080/");           
            IRestRequest request = new RestRequest("user/json", Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine("raw content : " + content);
            Console.WriteLine("response.ContentType : " + response.ContentType);

            User[] Users = JsonConvert.DeserializeObject<User[]>(content);
            Console.WriteLine("user : " + Users);
            foreach (var user in Users)
            {
                Console.WriteLine("user : " + user);
            }
        }

        private static void POST_Ex()
        {
            var client = new RestClient("http://localhost:8080/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);
            IRestRequest request = new RestRequest("user", Method.POST);
            request.AddJsonBody(new User { id = 5, name = "User 5", email = "user5@infomail.com", phone = "0 555", role = 2 });
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            Console.WriteLine("raw content : " + content);
            Console.WriteLine("response.ContentType : " + response.ContentType);            
        }
    }
}
