using BigFolk.Api.Data;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigFolk.Api.Repository
{
    public class GeniusRepository : IGeniusRepository
    {
        private readonly BigFolkDbContext _dbContext;

        public GeniusRepository(BigFolkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Genius> CreateAsync(Genius genius)
        {
            await _dbContext.Geniuses.AddAsync(genius);
            await _dbContext.SaveChangesAsync();

            return genius;
        }

        public async Task<Genius?> DeleteAsync(Guid id)
        {
            var existingGenius = await _dbContext.Geniuses.FirstOrDefaultAsync(x => x.Id == id);
            if (existingGenius == null) return null;

            _dbContext.Remove(existingGenius);
            await _dbContext.SaveChangesAsync();

            return existingGenius;
        }

        public async Task<List<Genius>> GetAllAsync()
        {
            return await _dbContext.Geniuses.ToListAsync();
        }

        public async Task<Genius?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Geniuses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Genius?> UpdateAsync(Guid id, Genius genius)
        {
            var existingGenius = await _dbContext.Geniuses.FirstOrDefaultAsync(x => x.Id == id);
            if (existingGenius == null) return null;

            existingGenius.Name = genius.Name;
            existingGenius.ImageUrl = genius.ImageUrl;

            await _dbContext.SaveChangesAsync();

            return existingGenius;
        }
    }
}
