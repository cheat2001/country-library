using CountryLibrary.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;

namespace CountryLibrary.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;
        public CountryService() {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri("https://restcountries.com/v2/");
        }

        public async Task<CountryInfo> GetCountryByName(string countryName)
        {
            var response = await _httpClient.GetAsync($"name/{countryName}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            //return JsonSerializer.Deserialize<List<CountryInfo>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })[0];
            
            return JsonConvert.DeserializeObject<List<CountryInfo>>(json)[0];
        }
        public async Task<List<CountryInfo>> GetCountryByArea(AreaInfo areaInfo)
        {
      
           var response = await _httpClient.GetAsync($"region/{areaInfo.Region}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CountryInfo>>(json);
        }

        
    }
}
