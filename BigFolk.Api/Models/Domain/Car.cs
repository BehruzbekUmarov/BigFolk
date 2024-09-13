using System.ComponentModel.DataAnnotations;

namespace BigFolk.Api.Models.Domain
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }

        public Guid GeniusId { get; set; }
        public Genius Genius { get; set; } = null!;
    }
}
