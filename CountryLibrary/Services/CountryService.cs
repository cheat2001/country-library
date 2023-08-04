using Azure;
using CountryLibrary.Models;
using CountryLibrary.Repositories;
using System.Text.Json;

namespace CountryLibrary.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository) {

            _countryRepository = countryRepository;
        }

        public async Task<CountryInfo> GetCountryByName(string countryName)
        {
           var country = await _countryRepository.GetCountryByName(countryName);
           return country;
        }

        public async Task<List<CountryInfo>> GetCountryByArea(AreaInfo areaInfo)
        {
            var allCountries = await _countryRepository.GetCountryByRegion(areaInfo.Region);
            if (allCountries != null)
            {
                var filterCountries = allCountries.Where(country => country.Timezones.Contains(areaInfo.TimeZones)).ToList();
                if(filterCountries.Count() > 0) {
                    return filterCountries;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        
    }
}
