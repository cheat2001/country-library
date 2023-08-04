using System.Text.Json.Serialization;

namespace CountryLibrary.Models
{
    public class CountryInfo
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Alpha2Code")]
        public string Alpha2Code { get; set; }

        [JsonPropertyName("Capital")]
        public string Capital { get; set; }

        [JsonPropertyName("CallingCodes")]
        public string[] CallingCodes { get; set; }

        [JsonPropertyName("Flag")]
        public string Flag { get; set; }

        [JsonPropertyName("Timezones")]
        public string[] Timezones { get; set; }

        [JsonPropertyName("Region")]
        public string Region { get; set; }


    }
}
