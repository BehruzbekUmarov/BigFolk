using System.ComponentModel.DataAnnotations;

namespace BigFolk.Api.Models.Domain
{
    public class HouseSystem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SmartHouseId { get; set; }
        public SmartHouse SmartHouse { get; set; } = null!;
    }
}
