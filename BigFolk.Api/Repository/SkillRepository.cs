using BigFolk.Api.Data;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigFolk.Api.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly BigFolkDbContext _context;

        public SkillRepository(BigFolkDbContext context)
        {
            _context = context;
        }

        public async Task<Skill> CraeteAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<Skill?> DeleteAsync(Guid id)
        {
            var existingDomain = await _context.Skills.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDomain == null) return null;

            _context.Skills.Remove(existingDomain);
            await _context.SaveChangesAsync();

            return existingDomain;
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill?> GetByIdAsync(Guid id)
        {
            var existingDomain = await _context.Skills.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDomain == null) return null;

            return existingDomain;
        }

        public async Task<Skill?> UpdateAsync(Guid id, Skill skill)
        {
            var existingDomain = await _context.Skills.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDomain == null) return null;

            return existingDomain;
        }
    }
}
