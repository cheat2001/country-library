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
        public async Task<ActionResult> GetCountryByName(string name)
        {
            var country = await _countryService.GetCountryByName(name);
            return Ok(country);
        }

        [HttpPost("GetCountryByArea")]
        public async Task<IActionResult> GetCountryByArea([FromBody] AreaInfo areaInfo)
        {
            var countryInfos = await _countryService.GetCountryByArea(areaInfo);
            if (countryInfos == null || countryInfos.Count == 0)
            {
                return NotFound();
            }

            return Ok(countryInfos);
        }

    }
}
