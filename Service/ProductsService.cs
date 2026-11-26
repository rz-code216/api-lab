using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository repository;
        public ProductsService(IProductsRepository repository)
        {
            this.repository = repository;
        }
        public async Task<(IEnumerable<Product> Items, int TotalCount)> GetAllProducts(int position, int skip,
                string? desc, decimal? minPrice, decimal? maxPrice, int?[] categoryIds)
        {
            return await repository.GetAllProducts(position, skip, desc, minPrice, maxPrice, categoryIds);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await repository.GetProductById(id);
        }
    }
}
