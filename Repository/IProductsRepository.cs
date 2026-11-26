using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IProductsRepository
    {
        Task<(IEnumerable<Product> Items, int TotalCount)> GetAllProducts(int position, int skip,
                string? desc, decimal? minPrice, decimal? maxPrice, int?[] categoryIds);
        Task<Product> GetProductById(int id);
    }
}
