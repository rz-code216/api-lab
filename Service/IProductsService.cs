using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IProductsService
    {
        Task<(IEnumerable<Product> Items, int TotalCount)> GetAllProducts(int position, int skip,
     string? desc, decimal? minPrice, decimal? maxPrice, int?[] categoryIds);
        Task<Product> GetProductById(int id);
    }
}
