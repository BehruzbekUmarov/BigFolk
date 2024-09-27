using BigFolk.Api.Data;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigFolk.Api.Repository
{
    public class HouseSystemRepository : IHouseSystemRepository
    {
        private readonly BigFolkDbContext _context;

        public HouseSystemRepository(BigFolkDbContext context)
        {
            _context = context;
        }

        public async Task<HouseSystem> CreateAsync(HouseSystem houseSystem)
        {
            await _context.HouseSystems.AddAsync(houseSystem);
            await _context.SaveChangesAsync();
            return houseSystem;
        }

        public async Task<HouseSystem?> DeleteAsync(Guid id)
        {
            var existingHouseSystem = await _context.HouseSystems.FirstOrDefaultAsync(x => x.Id == id);
            if (existingHouseSystem == null) return null;

            _context.HouseSystems.Remove(existingHouseSystem);
            await _context.SaveChangesAsync();

            return existingHouseSystem;
        }

        public async Task<List<HouseSystem>> GetAllAsync()
        {
            return await _context.HouseSystems.ToListAsync();
        }

        public async Task<HouseSystem?> GetByIdAsync(Guid id)
        {
            return await _context.HouseSystems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<HouseSystem?> UpdateAsync(Guid id, HouseSystem houseSystem)
        {
            var existingDomain = await _context.HouseSystems.FirstOrDefaultAsync(x =>x.Id == id);
            if (existingDomain == null) return null;

            existingDomain.Name = houseSystem.Name;
            await _context.SaveChangesAsync();

            return existingDomain;
        }
    }
}
