using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly storeDBContext _dbContext;

        public ProductsRepository(storeDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<(IEnumerable<Product> Items, int TotalCount)> GetAllProducts(int position, int skip,
    string? desc, decimal? minPrice, decimal? maxPrice, int?[] categoryIds)
        {
            var query = _dbContext.Products.Where(product =>
                (desc == null ? true : product.Description.Contains(desc))
                && (minPrice == null ? true : product.Price >= minPrice)
                && (maxPrice == null ? true : product.Price <= maxPrice)
                && (categoryIds.Length == 0 ? true : categoryIds.Contains(product.CategoryId)))
                .OrderBy(product => product.Price);

            Console.WriteLine(query.ToQueryString());

            IEnumerable<Product> products = await query.Skip((position - 1) * skip)
                .Take(skip).Include(product => product.Category).ToListAsync();
            var total = await query.CountAsync();
            return (products, total);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }
    }
}
