using BusinessLogic.Models;
using ShopDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<Product> GetProductById(int id);
        Task Create(Product p);
        Task Update(Product p);
        Task Delete(int id);
    }
}
