namespace BigFolk.Api.Models.Domain
{
    public class Portfolio
    {
        public Guid GeniusId { get; set; }
        public Guid SkillId { get; set; }
        public Genius Genius { get; set; } = null!;
        public Skill Skill { get; set; } = null!;
    }
}
