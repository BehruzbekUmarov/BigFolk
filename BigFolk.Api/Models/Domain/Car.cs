using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BigFolk.Api.Models.Domain
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public Guid GeniusId { get; set; }
        [JsonIgnore]
        public Genius Genius { get; set; } = null!;
    }
}
