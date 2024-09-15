using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BigFolk.Api.Models.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsUnicorn { get; set; } = false;

        public Guid GeniusId { get; set; }
        [JsonIgnore]
        public Genius Genius { get; set; } = null!;
    }
}
