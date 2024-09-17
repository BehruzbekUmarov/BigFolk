using BigFolk.Api.Models.Domain;

namespace BigFolk.Api.Repository.Interface
{
    public interface IHabitRepository
    {
        Task<List<Habit>> GetAllAsync();
        Task<Habit?> GetByIdAsync(Guid id);
        Task<Habit> CreateAsync(Habit habit);
        Task<Habit?> UpdateAsync(Guid id, Habit habit);
        Task<Habit?> DeleteAsync(Guid id);
    }
}
