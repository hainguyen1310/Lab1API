using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDao : SingletonBase<CategoryDao>
    {

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            if (category == null) return null;

            return category;
        }
        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCategory(Category category)
        {
            var existingItem = await GetCategoryById(category.CategoryId);
            if (existingItem == null) return;
            _context.Entry(existingItem).CurrentValues.SetValues(category);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCategory(int id)
        {
            var category = await GetCategoryById(id);

            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Category>> GetCategoryByName(string name)
        {
            var category = _context.Categories;
            return await category.Where(u => u.CategoryName.Contains(name)).ToListAsync();
        }
    }
}
