using System.ComponentModel.DataAnnotations;

namespace BigFolk.Api.Models.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsUnicorn { get; set; } = false;

        public Guid GeniusId { get; set; }
        public Genius Genius { get; set; } = null!;
    }
}
