using BigFolk.Api.Data;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BigFolk.Api.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly BigFolkDbContext _dbContext;

        public CompanyRepository(BigFolkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Company> CreateAsync(Company company)
        {
            await _dbContext.AddAsync(company); 
            await _dbContext.SaveChangesAsync();

            return company;
        }

        public async Task<Company?> DeleteAsync(Guid id)
        {
            var existingCompany = await _dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCompany == null) return null;

             _dbContext.Remove(existingCompany);
            await _dbContext.SaveChangesAsync();

            return existingCompany;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _dbContext.Companies.ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Company?> UpdateAsync(Guid id, Company company)
        {
            var existingCompany = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCompany == null) return null;

            existingCompany.Name = company.Name;
            existingCompany.IsUnicorn = company.IsUnicorn;
            existingCompany.GeniusId = company.GeniusId;

            await _dbContext.SaveChangesAsync();
            return existingCompany;
        }
    }
}
