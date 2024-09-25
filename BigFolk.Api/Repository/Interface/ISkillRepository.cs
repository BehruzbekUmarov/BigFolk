using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO.Skill;

namespace BigFolk.Api.Repository.Interface
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill?> GetByIdAsync(Guid id);
        Task<Skill> CraeteAsync(Skill skill);
        Task<Skill?> UpdateAsync(Guid id, Skill skill);
        Task<Skill?> DeleteAsync(Guid id);
    }
}
