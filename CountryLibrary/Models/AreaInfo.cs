using System.ComponentModel.DataAnnotations;

namespace CountryLibrary.Models
{
    public class AreaInfo
    {
        [Required]
        public string Region { get; set; } = string.Empty;
        [Required]
        public string TimeZones { get; set; } = string.Empty;
    }
}
