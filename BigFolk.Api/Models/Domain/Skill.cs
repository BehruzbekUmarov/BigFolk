using System.ComponentModel.DataAnnotations;

namespace BigFolk.Api.Models.Domain
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Type { get; set; }

        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
