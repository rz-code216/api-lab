using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    internal class ProductsService : IProductsService
    {
        private readonly IProductsRepository repository;
        public ProductsService(IProductsRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await repository.GetAllProducts();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await repository.GetProductById(id);
        }
    }
}
