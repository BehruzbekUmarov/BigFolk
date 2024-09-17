using BigFolk.Api.Data;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigFolk.Api.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly BigFolkDbContext _dbContext;

        public PortfolioRepository(BigFolkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Portfolio> Craete(Portfolio portfolio)
        {
            await _dbContext.AddAsync(portfolio);
            await _dbContext.SaveChangesAsync();
            return portfolio;
        }

        public async Task<Portfolio> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Portfolio>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Portfolio?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Portfolio> Update(Guid id, Portfolio portfolio)
        {
            throw new NotImplementedException();
        }
    }
}
