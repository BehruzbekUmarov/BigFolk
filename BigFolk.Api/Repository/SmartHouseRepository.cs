using BigFolk.Api.Data;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigFolk.Api.Repository
{
    public class SmartHouseRepository : ISmartHouseRepository
    {
        private readonly BigFolkDbContext _context;

        public SmartHouseRepository(BigFolkDbContext context)
        {
            _context = context;
        }

        public async Task<SmartHouse> CreateAsync(SmartHouse smartHouse)
        {
            await _context.SmartHouses.AddAsync(smartHouse);
            await _context.SaveChangesAsync();

            return smartHouse;
        }

        public async Task<SmartHouse?> DeleteAsync(Guid id)
        {
            var existingDomain = await _context.SmartHouses
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingDomain == null) return null;

            _context.SmartHouses.Remove(existingDomain);
            await _context.SaveChangesAsync();

            return existingDomain;
        }

        public async Task<List<SmartHouse>> GetAllAsync()
        {
            return await _context.SmartHouses.ToListAsync();
        }

        public async Task<SmartHouse?> GetByIdAsync(Guid id)
        {
            return await _context.SmartHouses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SmartHouse?> UpdateAsync(Guid id, SmartHouse smartHouse)
        {
            var existingDomain = await _context.SmartHouses.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDomain == null) return null;

            existingDomain.State = smartHouse.State;
            existingDomain.ImageUrl = smartHouse.ImageUrl;
            existingDomain.Region = smartHouse.Region;
            existingDomain.Country = smartHouse.Country;
            existingDomain.GeniusId = smartHouse.GeniusId;

            await _context.SaveChangesAsync();

            return existingDomain;
        }
    }
}
