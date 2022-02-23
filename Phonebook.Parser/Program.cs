using System;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Phonebook.EF;

namespace Phonebook.Parser
{
    class Program
    {
        public const string ApiUrl = "https://randomuser.me/api/?results=1000";
        public const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=phonebook;Trusted_Connection=True;MultipleActiveResultSets=true";

        static void Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                var httpClientResponse = httpClient.GetAsync(ApiUrl).Result;
                var deserializedResponse = 
                    JsonConvert.DeserializeObject<RandomUserApiResponse>(httpClientResponse.Content.ReadAsStringAsync().Result);
            }

            //using (var context = new PhonebookContext(ConnectionString))
            //{

            //    var std = new PhonebookContext.UserDb()
            //    {
            //        Email = "Bill"
            //    };

            //    context.Users.Add(std);
            //    context.SaveChanges();
            //}
        }
    }
}
