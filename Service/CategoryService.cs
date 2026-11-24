using Entity;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepository repository;
        public CategoryService(ICategoriesRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await repository.GetAllCategories();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await repository.GetCategoryById(id);
        }
    }
}
