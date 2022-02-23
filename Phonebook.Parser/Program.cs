using System;
using System.Collections.Generic;
using System.Net.Http;
using AutoMapper;
using Newtonsoft.Json;
using Phonebook.EF;
using Phonebook.EF.DbModels;
using Phonebook.Parser.Models;
using Serilog;

namespace Phonebook.Parser
{
    class Program
    {
        public const string ApiUrl = "https://randomuser.me/api/?results=1000";
        public const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=phonebook;Trusted_Connection=True;MultipleActiveResultSets=true";

        static void Main(string[] args)
        {
            IEnumerable<UserDb> dbItems;
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new PhonebookJsonToDbProfile()));
            var mapper = new Mapper(config);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            Log.Information($"Requesting test users from API: {ApiUrl}...");

            try
            {
                using var httpClient = new HttpClient();
                var httpClientResponse = httpClient.GetAsync(ApiUrl).Result;
                var deserializedResponse =
                    JsonConvert.DeserializeObject<RandomUserApiResponse>(httpClientResponse.Content.ReadAsStringAsync()
                        .Result);
                dbItems = mapper.Map<IEnumerable<UserDb>>(deserializedResponse.results);
            }
            catch (Exception e)
            {
                Log.Error(e, "Unable to retrieve users from API");
                Console.ReadKey();
                return;
            }

            Log.Information("Attempting to save users into DB...");

            try
            {
                using var context = new PhonebookContext(ConnectionString);
                context.Users.AddRange(dbItems);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Log.Error(e, "Unable to save users");
                Console.ReadKey();
                return;
            }

            Log.Information("All operations done");
            Console.ReadKey();
        }
    }
}
