using BigFolk.Api.Data;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigFolk.Api.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly BigFolkDbContext _context;

        public CarRepository(BigFolkDbContext context)
        {
            _context = context;
        }

        public async Task<Car> CreateAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car?> DeleteAsync(Guid id)
        {
            var existingCar = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCar == null) return null;

            _context.Cars.Remove(existingCar);
            await _context.SaveChangesAsync();

            return existingCar;
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public Task<Car?> GetByIdAsync(Guid id)
        {
            return _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Car?> UpdateAsync(Guid id, Car car)
        {
            var existingCar = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if(existingCar == null) return null;

            existingCar.State = car.State;
            existingCar.ImageUrl = car.ImageUrl;
            existingCar.Type = car.Type;
            existingCar.Name = car.Name;
            existingCar.GeniusId = car.GeniusId;

            await _context.SaveChangesAsync();
            return existingCar;
        }
    }
}
