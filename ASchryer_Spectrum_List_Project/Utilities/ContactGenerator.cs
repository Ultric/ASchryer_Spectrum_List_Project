using ASchryer_Spectrum_List_Project.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ASchryer_Spectrum_List_Project.Utilities
{
    // Class is to generate set of data by utilizing randomuser.me which will be utilized for the items populating the main list view
    public class RandomContactList
    {
        public List<Contact> results { get; set; }
        public string seed { get; set; }

        public RandomContactList()
        {
            this.results = new List<Contact>();
            this.seed = "";
        }

        public static List<Contact> ContactList = new List<Contact>();

        //Actual Generator Function
        public async static Task<RandomContactList> GenerateContactLot(int contactCount = 25)
        {
            var randomContactList = new RandomContactList();

            // Flush whatever is in there
            randomContactList.results.Clear();
            randomContactList.seed = "";

            // generate a new seed
            string newSeed = SeedGenerator.RandomString(8);


            // Generate everything after the base url
            string requestArguments = String.Format("api/1.4?inc=name,picture,dob,gender,email,phone,location&nat=us&results={0}&seed={1}", contactCount, newSeed);

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new System.Uri("https://randomuser.me/");

                var response = await client.GetAsync(requestArguments);

                int i = 0;

                // API has been a bit conistent, retrying a couple times to get a successful result is advisable.
                while(!response.IsSuccessStatusCode && i < 5)
                {
                    Thread.Sleep(500);
                    response = await client.GetAsync(requestArguments);
                    i++;
                }

                response.EnsureSuccessStatusCode();

                var resultJSON = await response.Content.ReadAsStringAsync();
                
                JObject dataObj = JObject.Parse(resultJSON);
                // fetching the seed back was primarily to aid in the development. Kinda just a "yeah, this made it through, it's the rest of your json crap that isn't parsing correctly"
                string dataSeed = (string)dataObj.SelectToken("info.seed");
                JEnumerable<JToken> dataResults = dataObj["results"].Children();

                randomContactList.seed = dataSeed;
                foreach (JToken result in dataResults)
                {
                    Contact newContact = new Contact();

                    newContact.name.first = (string)result.SelectToken("name.first");
                    newContact.name.last = (string)result.SelectToken("name.last");
                    newContact.location.city = (string)result.SelectToken("location.city");
                    newContact.location.state = (string)result.SelectToken("location.state");
                    newContact.email = (string)result.SelectToken("email");
                    newContact.age = (int)result.SelectToken("dob.age");
                    newContact.phone = (string)result.SelectToken("phone");
                    newContact.gender = (string)result.SelectToken("gender");
                    newContact.picture.large = (string)result.SelectToken("picture.large");
                    newContact.picture.thumbnail = (string)result.SelectToken("picture.thumbnail");
                    randomContactList.results.Add(newContact);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return await Task.FromResult(randomContactList);
        }

        public static List<Contact> FilterContactList(string filterString)
        {
            var lowerCasedFilter = filterString?.ToLower() ?? "";
            return ContactList.Where(c => c.nameString.ToLowerInvariant().Contains(lowerCasedFilter)).ToList();
        }
    }

    // simple seed generator
    public class SeedGenerator
    {

        private static Random randSeed = new Random();
        public static string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(seed => seed[randSeed.Next(seed.Length)]).ToArray());
        }
    }
}
