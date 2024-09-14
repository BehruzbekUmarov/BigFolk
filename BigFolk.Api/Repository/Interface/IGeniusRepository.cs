using BigFolk.Api.Models.Domain;

namespace BigFolk.Api.Repository.Interface
{
    public interface IGeniusRepository
    {
        Task<List<Genius>> GetAllAsync();
        Task<Genius?> GetByIdAsync(Guid id);
        Task<Genius> CreateAsync(Genius genius);
        Task<Genius?> UpdateAsync(Guid id, Genius genius);
        Task<Genius?> DeleteAsync(Guid id);
    }
}
