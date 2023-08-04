using CountryLibrary.Models;
using CountryLibrary.Services;
using Moq;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryLibrary.Repositories;

namespace CountryLibraryApiTest
{
    public class CountryServicesTests
    {

        [Test]
        public async Task GetCountryArea_ShouldReturnListOfCountryInfo()
        {
            // Arrange
            var areaInfo = new AreaInfo
            {
                Region = "Asia",
                TimeZones = "UTC+07:00"
            };

            var countryInfo = new List<CountryInfo>
            {
            new CountryInfo
            {
                Name = "Cambodia",
                Alpha2Code = "KH",
                Region = "Asia",
                Capital = "Phnom Penh",
                CallingCodes = new string[] { "855" },
                Flag = "https://flagcdn.com/kh.svg",
                Timezones = new string[] { "UTC+07:00" }
            },
             new CountryInfo
            {
                Name = "Germany",
                Alpha2Code = "DE",
                 Region = "Europe",
                Capital = "Berlin",
                CallingCodes = new string[] { "49" },
                Flag = "https://flagcdn.com/de.svg",
                Timezones = new string[] { "UTC+01:00" }
            },
        };


            var mockRepository = new Mock<ICountryRepository>();
            mockRepository.Setup(repo => repo.GetCountryByRegion(areaInfo.Region)).ReturnsAsync(countryInfo);

            var countryService = new CountryService(mockRepository.Object);

            // Act
            var actual = await countryService.GetCountryByArea(areaInfo);

            
            // Assert
            Assert.That(actual, Has.Count.EqualTo(1));
            Assert.That(actual, Is.Not.Null);


        }




        //[Test]
        //public async Task GetCountryByName_ShouldReturnTheCorrectCountry()
        //{
        //    //Arrange
        //    string countryName = "Cambodia";
        //    var country  = new CountryInfo
        //    {
        //        Name = "Cambodia",
        //        Alpha2Code = "KH",
        //        Region = "Asia",
        //        Capital = "Phnom Penh",
        //        CallingCodes = new string[] { "855" },
        //        Flag = "https://flagcdn.com/kh.svg",
        //        Timezones = new string[] { "UTC+07:00" }
        //    };

        //    var mockRepository = new Mock<ICountryRepository>();
        //    mockRepository.Setup(repo => repo.GetCountryByName(countryName)).ReturnsAsync(country);

        //    var countryService = new CountryService(mockRepository.Object);

        //    // Act
        //    var actual = await countryService.GetCountryByName(countryName);

        //    //Assert

        //    Assert.IsNotNull(actual);
        //    Assert.AreEqual("Cambodia", actual.Name);


        //}




    }
}
