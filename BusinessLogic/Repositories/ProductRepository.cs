using BusinessLogic.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        public async Task AddProduct(Product product)
        {
            await ProductDAO.Instance.AddProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            await ProductDAO.Instance.DeleteProduct(id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await ProductDAO.Instance.GetAllProducts();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await ProductDAO.Instance.GetProductById(id);   
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await ProductDAO.Instance.GetProductByName(name);
        }

        public async Task UpdateProduct(Product product)
        {
            await ProductDAO.Instance.UpdateProduct(product);
        }
    }
}
