using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BigFolk.Api.Models.Domain
{
    public class Habit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Frequency { get; set; }

        public Guid GeniusId { get; set; }
        [JsonIgnore]
        public Genius Genius { get; set; } = null!;
    }
}
