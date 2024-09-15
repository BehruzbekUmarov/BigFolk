namespace BigFolk.Api.Models.DTO.SmartHouse
{
    public class UpdateSmartHouseRequestDto
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string State { get; set; }
        public string? ImageUrl { get; set; }

        public Guid GeniusId { get; set; }
    }
}
