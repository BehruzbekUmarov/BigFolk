using BigFolk.Api.Models.Domain;

namespace BigFolk.Api.Repository.Interface
{
    public interface ISmartHouseRepository
    {
        Task<List<SmartHouse>> GetAllAsync();
        Task<SmartHouse?> GetByIdAsync(Guid id);
        Task<SmartHouse> CreateAsync(SmartHouse smartHouse);
        Task<SmartHouse?> UpdateAsync(Guid id, SmartHouse smartHouse);
        Task<SmartHouse?> DeleteAsync(Guid id);
    }
}
