using BigFolk.Api.Models.Domain;

namespace BigFolk.Api.Repository.Interface
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllAsync();
        Task<Car?> GetByIdAsync(Guid id);
        Task<Car> CreateAsync(Car car);
        Task<Car?> UpdateAsync(Guid id, Car car);
        Task<Car?> DeleteAsync(Guid id);
    }
}
