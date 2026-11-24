using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
    }
}
