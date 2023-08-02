using CountryLibrary.Models;

namespace CountryLibrary.Services
{
    public interface ICountryService
    {
        public Task<CountryInfo> GetCountryByName(string name);
        public Task<List<CountryInfo>> GetCountryByArea(AreaInfo areaInfo);
    }
}
