using BigFolk.Api.Models.Domain;

namespace BigFolk.Api.Repository.Interface
{
    public interface IHouseSystemRepository
    {
        Task<List<HouseSystem>> GetAllAsync();
        Task<HouseSystem?> GetByIdAsync(Guid id);
        Task<HouseSystem> CreateAsync(HouseSystem houseSystem);
        Task<HouseSystem?> UpdateAsync(Guid id, HouseSystem houseSystem);
        Task<HouseSystem?> DeleteAsync(Guid id);
    }
}
