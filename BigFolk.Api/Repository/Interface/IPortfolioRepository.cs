using BigFolk.Api.Models.Domain;

namespace BigFolk.Api.Repository.Interface
{
    public interface IPortfolioRepository
    {
        Task<List<Portfolio>> GetAll();
        Task<Portfolio?> GetById(Guid id);
        Task<Portfolio> Craete(Portfolio portfolio);
        Task<Portfolio?> Update(Guid id, Portfolio portfolio);
        Task<Portfolio?> Delete(Guid id);
    }
}
