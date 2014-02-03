using Microsoft.Owin.Hosting;
using System;
using System.Configuration;
using System.Net.Http;

namespace ApplicationRouter
{
    class Program
    {
        static void Main()
        {
            var port = int.Parse(ConfigurationManager.AppSettings["port"]);
            var baseAddress = string.Format("http://localhost:{0}/", port);

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                var client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        } 
    }
}
