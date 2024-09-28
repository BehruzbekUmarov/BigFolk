using BigFolk.Api.Models.DTO.Genius;
using BigFolk.Api.Models.DTO.Skill;

namespace BigFolk.Api.Models.DTO.Portfolio
{
    public class PortfolioDto
    {
        public Guid GeniusId { get; set; }
        public GeniusDto Genius { get; set; }
        public Guid SkillId { get; set; }
        public SkillDto Skill { get; set; }
    }
}
