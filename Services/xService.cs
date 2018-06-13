using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Security.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using MongoDB.Driver;
using oneie_ai_ml_service.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace oneie_ai_ml_service.Services
{
    public static class XService
    {
        static HttpClient client = new HttpClient();

        public static async Task<string> RunMe2()
        {
            HttpResponseMessage response = await client.GetAsync(
                "https://oneie-ai-ml-function-app.azurewebsites.net/api/HttpTriggerPython31?code=T5ZNlCxh9HmVMM9WmcxXJE7qz8ynfinmUngwUESYaRYUNDAhjXJADw==&name=jj");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

            return "python function data";
        }

        public static async Task<string> RunMe()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            var config = builder.Build();
            var client = new CosmosClient();
            var db = client.ConnectAndGetDatabase(config);

            Console.WriteLine("Grabbing the list of food groups...");
            var groups = await db.GetCollection<FoodGroup>(Collections.GetCollectionName<FoodGroup>()).AsQueryable().ToListAsync();

            Console.WriteLine($"Found {groups.Count} groups. Listing them...");
            foreach(var group in groups) 
            {
                Console.WriteLine($"{group.Description}");
            }

            Console.WriteLine("Trying to grab a food item...");

            try 
            {
                var foodItem = await db.GetCollection<FoodItem>(Collections.GetCollectionName<FoodItem>()).AsQueryable().FirstOrDefaultAsync();
                foodItem.DeserializeNutrients();
                Console.WriteLine($"Mmmm. Found some {foodItem.Description} in a portion of {foodItem.Weights[0].Amount} {foodItem.Weights[0].Description}");
                Console.WriteLine($"First nutrient is {foodItem.Nutrients[0].Definition.Description} at {foodItem.Nutrients[0].AmountInHundredGrams}");
                Console.WriteLine($"of {foodItem.Nutrients[0].Definition.UnitOfMeasure} per hundred grams.");
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"No soup for you! Message: {ex.Message}");
                Console.ReadLine();
                throw;
            }

            return "db datum";
        }
    }

    // Call me
    //  RunMe().Wait();
}