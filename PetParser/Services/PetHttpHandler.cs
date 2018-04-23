using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PetParser.Models;

namespace PetParser.Services
{
    public class PetHttpHandler : IPetHttpHandler
    {
        private HttpClient _httpClient;

        public PetHttpHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<Person>> GetPetsAsync()
        {
            var task = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var jsonString = await task.Content.ReadAsStringAsync();
            var rtnVar = JsonConvert.DeserializeObject<List<Person>>(jsonString);

            return rtnVar;
        }

    }
}
