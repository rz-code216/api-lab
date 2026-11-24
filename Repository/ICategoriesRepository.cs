using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
    }
}
