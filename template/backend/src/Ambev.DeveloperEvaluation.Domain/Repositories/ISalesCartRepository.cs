using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISalesCartRepository
    {
        Task<SalesCart> CreateAsync(SalesCart salesCart);
        Task<SalesCart> GetByIdAsync(Guid id);
        Task<SalesCart> GetBySaleNumberAsync(string saleNumber);
        Task<IEnumerable<SalesCart>> GetAllAsync();
        Task<IEnumerable<SalesCart>> GetByCustomerAsync(Guid userId);       
        Task<IEnumerable<SalesCart>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<SalesCart>> GetCancelledSalesCartsAsync();
        Task<IEnumerable<SalesCart>> GetActiveSalesCartsAsync();
        Task UpdateAsync(SalesCart salesCart);
        Task DeleteAsync(Guid id);
    }
}
