using BigFolk.Api.Models.Domain;

namespace BigFolk.Api.Repository.Interface
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(Guid id);
        Task<Company> CreateAsync(Company company);
        Task<Company?> UpdateAsync(Guid id, Company company);
        Task<Company?> DeleteAsync(Guid id);
    }
}
