using BigFolk.Api.Data;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigFolk.Api.Repository
{
    public class HabitRepository : IHabitRepository
    {
        private readonly BigFolkDbContext _context;

        public HabitRepository(BigFolkDbContext context)
        {
            _context = context;
        }

        public async Task<Habit> CreateAsync(Habit habit)
        {
            await _context.AddAsync(habit);
            await _context.SaveChangesAsync();

            return habit;
        }

        public async Task<Habit?> DeleteAsync(Guid id)
        {
            var existingDomain = await _context.Habits.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDomain == null) return null;

            _context.Habits.Remove(existingDomain);
            await _context.SaveChangesAsync();

            return existingDomain;
        }

        public async Task<List<Habit>> GetAllAsync()
        {
            return await _context.Habits.ToListAsync();
        }

        public async Task<Habit?> GetByIdAsync(Guid id)
        {
            return await _context.Habits.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Habit?> UpdateAsync(Guid id, Habit habit)
        {
            var existingDomain = await _context.Habits.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDomain == null) return null;

            existingDomain.Frequency = habit.Frequency;
            existingDomain.GeniusId = habit.GeniusId;
            existingDomain.Name = habit.Name;

            await _context.SaveChangesAsync();

            return existingDomain;
        }
    }
}
