using CountryLibrary.Models;

namespace CountryLibrary.Repositories
{
    public interface ICountryRepository
    {
        public Task<CountryInfo> GetCountryByName(string countryName);
        public Task<List<CountryInfo>> GetCountryByRegion(string area);
    }
}
