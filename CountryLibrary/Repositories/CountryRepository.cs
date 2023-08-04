using CountryLibrary.Models;
using System.Text.Json;

namespace CountryLibrary.Repositories
{
    public class CountryRepository : ICountryRepository
    {

         private readonly HttpClient _httpClient;
        public CountryRepository() {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri("https://restcountries.com/v2/");
        }

        public async Task<CountryInfo> GetCountryByName(string countryName)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"name/{countryName}");
           if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var countries = JsonSerializer.Deserialize<List<CountryInfo>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return countries[0];
            }
            return null;
        }

        public async Task<List<CountryInfo>> GetCountryByRegion(string area)
            {
            HttpResponseMessage response = await _httpClient.GetAsync($"region/{area}");
           if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var allCountries = JsonSerializer.Deserialize<List<CountryInfo>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return allCountries;
            }
            return null;
        }

       
    }
}
