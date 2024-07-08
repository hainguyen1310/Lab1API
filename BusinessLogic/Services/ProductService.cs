using BusinessLogic.Models;
using ShopDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient) 
        {
            _httpClient = httpClient ;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProductDTO>>("api/Product");
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/Product/{id}");
        }
        public async Task Create(Product p)
        {
            await _httpClient.PostAsJsonAsync("api/Product", p);
        }

        public async Task Update(Product p)
        {
            await _httpClient.PutAsJsonAsync($"api/Product/{p.ProductId}",p);
        }
        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Product/{id}");
        }
    }
}
