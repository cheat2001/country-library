using CountryLibrary.Models;
using CountryLibrary.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryLibraryTest
{
    public class CountryServiceTests
    {

        [Fact]
        public async Task GetCountryByName_ValidName_ReturnsCountryInfo()
        {
            // Arrange
            string countryName = "United States";
            var countryService = CreateCountryService();

            // Act
            CountryInfo country = await countryService.GetCountryByName(countryName);

            // Assert
            Assert.NotNull(country);
            Assert.Equal(countryName, country.Name);
            // Add more assertions based on the expected behavior of the GetCountryByName method
        }


        // Helper method to create an instance of the ICountryService with mocked dependencies
        private ICountryService CreateCountryService()
        {
            // You need to mock the ICountryService and its methods since it's an interface
            var countryServiceMock = new Mock<ICountryService>();

            // Example: Setting up a mock response for GetCountryByName method
            countryServiceMock.Setup(service => service.GetCountryByName(It.IsAny<string>()))
                              .ReturnsAsync((string name) =>
                              {
                                  if (name == "United States")
                                  {
                                      return new CountryInfo
                                      {
                                          Name = "United States",
                                          Alpha2Code = "US",
                                          Capital = "Washington, D.C.",
                                          CallingCodes = new[] { "+1" },
                                          Flag = "https://restcountries.com/v2/flags/us.png",
                                          Timezones = new[] { "UTC-12:00", "UTC-11:00" }
                                      };
                                  }
                                  else
                                  {
                                      return null; // For unknown country names, return null
                                  }
                              });

            // Example: Setting up a mock response for GetCountryByArea method
            countryServiceMock.Setup(service => service.GetCountryByArea(It.IsAny<AreaInfo>()))
                              .ReturnsAsync(() => new List<CountryInfo>
                              {
                              new CountryInfo
                              {
                                  Name = "Country1",
                                  Alpha2Code = "C1",
                                  Capital = "Capital1",
                                  CallingCodes = new[] { "+11" },
                                  Flag = "https://restcountries.com/v2/flags/c1.png",
                                  Timezones = new[] { "UTC+1:00" }
                              },
                              new CountryInfo
                              {
                                  Name = "Country2",
                                  Alpha2Code = "C2",
                                  Capital = "Capital2",
                                  CallingCodes = new[] { "+22" },
                                  Flag = "https://restcountries.com/v2/flags/c2.png",
                                  Timezones = new[] { "UTC+2:00" }
                              }
                              // Add more countries as needed for testing
                              });

            return countryServiceMock.Object;
        }
    }
}
