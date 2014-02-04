using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodTrackerWebApi
{
    public class EndpointRegistrationWorker : BackgroundWorker
    {
        private readonly int _millisecondsToSleep;

        public EndpointRegistrationWorker()
        {
            WorkerSupportsCancellation = true;
            _millisecondsToSleep = int.Parse(ConfigurationManager.AppSettings["SecondsToSleep"]) * 1000;
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            Console.WriteLine("Starting the EndpointRegistrationWorker");
            while (true)
            {
                if (CancellationPending)
                {
                    Console.WriteLine("Shutting down the EndpointRegistrationWorker");
                    e.Cancel = true;
                    return;
                }

                using (var client = new HttpClient())
                {
                    int port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                    string applicationRouterBaseURL = ConfigurationManager.AppSettings["ApplicationRouterBaseURL"];
                    string applicationRouterRegistrationPath = ConfigurationManager.AppSettings["ApplicationRouterRegistrationPath"];
                    string versionNumber = ConfigurationManager.AppSettings["VersionNumber"];

                    client.BaseAddress = new Uri(applicationRouterBaseURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var foodUrl = string.Format("http://{0}:{1}/api/{2}", Environment.MachineName, port, "Foods");
                    Console.WriteLine("Registering URL: " + foodUrl);
                    var foodResponse = client.PostAsJsonAsync(
                        applicationRouterRegistrationPath, 
                        new Endpoint { 
                            Name = "Food", 
                            URL =  foodUrl,
                            Version = versionNumber
                        }).Result;
                    Console.WriteLine("Registering Response: " + foodResponse.StatusCode);

                    var userUrl = string.Format("http://{0}:{1}/api/{2}", Environment.MachineName, port, "Users");
                    Console.WriteLine("Registering URL: " + userUrl);
                    var userResponse = client.PostAsJsonAsync(
                        applicationRouterRegistrationPath,
                        new Endpoint
                        {
                            Name = "User",
                            URL = userUrl,
                            Version = versionNumber
                        }).Result;
                    Console.WriteLine("Registering Response: " + userResponse.StatusCode);

                    var mealUrl = string.Format("http://{0}:{1}/api/{2}", Environment.MachineName, port, "Meals");
                    Console.WriteLine("Registering URL: " + mealUrl);
                    var mealResponse = client.PostAsJsonAsync(
                        applicationRouterRegistrationPath,
                        new Endpoint
                        {
                            Name = "Meals",
                            URL = mealUrl,
                            Version = versionNumber
                        }).Result;
                    Console.WriteLine("Registering Response: " + mealResponse.StatusCode);
                }

                Thread.Sleep(_millisecondsToSleep);
            }
        }

        private class Endpoint
        {
            public string Name { get; set; }
            public string Version { get; set; }
            public string URL { get; set; }
        }
    }
}
