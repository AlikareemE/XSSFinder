using System;
using System.Net.Http;
using System.IO;

namespace XSSFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("________________________________________");
            Console.WriteLine("XSS vulnerability Scan V1");
            Console.WriteLine("Created By Ali kareem ");
            Console.WriteLine("fb.com/Ali.KareemP");
            Console.WriteLine("________________________________________");


            Console.WriteLine("Enter the  Dowmin example : https://xss-game.appspot.com/level1/frame?query=");

            // Define the website you want to test
            string targetWebsite = Console.ReadLine();

            // Read the wordlist of payloads

            string[] payloads = File.ReadAllLines("payloads.txt");

            // Make a GET request to the website for each payload
            foreach (string payload in payloads)
            {
                string url = targetWebsite  + payload;
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(url).Result;

                // Check the response for the payload
                if (response.Content.ReadAsStringAsync().Result.Contains(payload))
                {
                    Console.WriteLine("XSS vulnerability found for payload: " + payload);
                }
                else
                {
                    Console.WriteLine("No XSS vulnerability found for payload: " + payload);
                }
            }
        }
    }
}
