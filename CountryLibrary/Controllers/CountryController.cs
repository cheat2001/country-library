using CountryLibrary.Models;
using CountryLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CountryLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService) { 
         _countryService = countryService;
        }

        [HttpPost("GetCountryByName")]
        public async Task<ActionResult<CountryInfo>> GetCountryByName(string name)
        {
            var country = await _countryService.GetCountryByName(name);
      
            if(country == null)
            {
                return NotFound("Data is not found.");
            }
            return Ok(country);
        }


        [HttpPost("GetCountryByArea")]
        public async Task<ActionResult<CountryInfo>> GetCountryByArea([FromBody] AreaInfo areaInfo)
        {
            var countryInfos = await _countryService.GetCountryByArea(areaInfo);

            if(countryInfos == null)
            {
                return NotFound("Data is not found.");
            }
            return Ok(countryInfos);
        }

    }
}
