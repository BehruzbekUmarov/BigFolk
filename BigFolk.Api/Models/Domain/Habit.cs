using System.ComponentModel.DataAnnotations;

namespace BigFolk.Api.Models.Domain
{
    public class Habit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Frequency { get; set; }

        public Guid GeniusId { get; set; }
        public Genius Genius { get; set; } = null!;
    }
}
