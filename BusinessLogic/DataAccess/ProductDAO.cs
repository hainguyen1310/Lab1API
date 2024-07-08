using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO : SingletonBase<ProductDAO>
    {
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.Include(c => c.Category).ToListAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.ProductId == id);
            if (product == null) return null;

            return product;
        }
        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProduct(Product product)
        {
            var existingItem = await GetProductById(product.ProductId);
            if (existingItem == null) return;
            _context.Entry(existingItem).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProduct(int id)
        {
            var product = await GetProductById(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            var product = _context.Products;
            return await product.Where(u => u.ProductName.Contains(name)).ToListAsync();
        }
    }
}
