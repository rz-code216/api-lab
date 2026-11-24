using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    internal class ProductsRepository : IProductsRepository
    {
        private readonly storeDBContext _dbContext;

        public ProductsRepository(storeDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }
    }
}
