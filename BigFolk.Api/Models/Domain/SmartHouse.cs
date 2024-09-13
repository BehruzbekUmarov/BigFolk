using System.ComponentModel.DataAnnotations;

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
        public Genius Genius { get; set; } = null!;
        public HouseSystem? HouseSystem { get; set; }
    }
}
