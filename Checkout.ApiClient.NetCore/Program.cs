using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Checkout.ApiClient.NetCore
{
  class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting connection...");

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");

            // Gets all the products (starts as empty list)
            var response = client.GetAsync("api/product").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine("GET api/product => " + stringData);

            // Adds some products
            var pairs = new Dictionary<string,string>();
            pairs.Add("Name", "Orangina");
            pairs.Add("Quantity", "1");
            var formContent = new FormUrlEncodedContent(pairs);
            response = client.PostAsync("api/product", formContent).Result;

            pairs.Clear();
            pairs.Add("Name", "Coca Cola");
            pairs.Add("Quantity", "2");
            formContent = new FormUrlEncodedContent(pairs);
            response = client.PostAsync("api/product", formContent).Result;

            // Gets all the products (2 products)
            response = client.GetAsync("api/product").Result;
            stringData = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine("GET api/product => " + stringData);

            // Modifies a product
            pairs.Clear();
            pairs.Add("Name", "Orangina");
            pairs.Add("Quantity", "3");
            formContent = new FormUrlEncodedContent(pairs);
            response = client.PutAsync("api/product", formContent).Result;

            // Gets the Orangina product
            response = client.GetAsync("api/product/Orangina").Result;
            stringData = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine("GET api/product/Orangina => " + stringData);

            // Deletes Coca Cola
            response = client.DeleteAsync("api/product/Coca Cola").Result;

            // Gets all the products (only Orangina left)
            response = client.GetAsync("api/product").Result;
            stringData = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine("GET api/product => " + stringData);
            
            Console.WriteLine("The End");
            Console.ReadLine();
        }
    }
}