using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.MongoDB.Repositories
{
    public class SalesCartRepository : ISalesCartRepository
    {
        private readonly IMongoCollection<SalesCart> _salesCarts;

        public SalesCartRepository(IOptions<MongoDbSettings> mongoSettings)
        {
            var mongoClient = new MongoClient(mongoSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoSettings.Value.DatabaseName);

            _salesCarts = mongoDatabase.GetCollection<SalesCart>("SalesCart");
        }

        public async Task<SalesCart> CreateAsync(SalesCart salesCart)
        {
            await _salesCarts.InsertOneAsync(salesCart);
            return salesCart;
        }

        public async Task<SalesCart> GetByIdAsync(Guid id)
        {
            return await _salesCarts.Find(sc => sc.Id == id).FirstOrDefaultAsync();
        }

        public async Task<SalesCart> GetBySaleNumberAsync(string saleNumber)
        {
            return await _salesCarts.Find(sc => sc.SaleNumber == saleNumber).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SalesCart>> GetAllAsync()
        {
            return await _salesCarts.Find(_ => true)
                .SortByDescending(sc => sc.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesCart>> GetByCustomerAsync(Guid userId)
        {
            return await _salesCarts.Find(sc => sc.Customer.UserId == userId)
                .SortByDescending(sc => sc.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesCart>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _salesCarts.Find(sc =>
                sc.SaleDate >= startDate && sc.SaleDate <= endDate)
                .SortByDescending(sc => sc.SaleDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesCart>> GetCancelledSalesCartsAsync()
        {
            return await _salesCarts.Find(sc => sc.IsCancelled == true)
                .SortByDescending(sc => sc.CancelledAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesCart>> GetActiveSalesCartsAsync()
        {
            return await _salesCarts.Find(sc => sc.IsCancelled == false)
                .SortByDescending(sc => sc.CreatedAt)
                .ToListAsync();
        }

        public async Task UpdateAsync(SalesCart salesCart)
        {
            await _salesCarts.ReplaceOneAsync(sc => sc.Id == salesCart.Id, salesCart);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _salesCarts.DeleteOneAsync(sc => sc.Id == id);
        }
    }
}
