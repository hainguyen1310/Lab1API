using BusinessLogic.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task AddCategory(Category category)
        {
            await CategoryDao.Instance.AddCategory(category);
        }

        public async Task DeleteCategory(int id)
        {
            await CategoryDao.Instance.DeleteCategory(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await CategoryDao.Instance.GetAllCategories();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await CategoryDao.Instance.GetCategoryById(id);
        }

        public async Task UpdateCategory(Category category)
        {
            await CategoryDao.Instance.UpdateCategory(category);
        }
        public async Task<IEnumerable<Category>> GetCategoryByName(string name)
        {
            return await CategoryDao.Instance.GetCategoryByName(name);
        }
    }
}
