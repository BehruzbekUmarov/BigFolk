using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BigFolk.Api.Models.Domain
{
    public class SmartHouse
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string State { get; set; }
        public string? ImageUrl { get; set; }

        public Guid GeniusId { get; set; }
        [JsonIgnore]
        public Genius Genius { get; set; } = null!;
        [JsonIgnore]
        public HouseSystem? HouseSystem { get; set; }
    }
}
