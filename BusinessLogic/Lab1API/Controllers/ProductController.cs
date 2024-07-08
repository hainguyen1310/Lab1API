using AutoMapper;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using ShopDTO;

namespace Lab1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper)
        {
            _productRepository = new ProductRepository();
            _mapper = mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetCategories()
        {
            var products = await _productRepository.GetAllProducts();
            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return Ok(productDTO);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetCategory(int id)
        {
            var category = await _productRepository.GetProductById(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> PostCategory(Product product)
        {
            await _productRepository.AddProduct(product);
            return Content("Insert success!");
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(int id, Product product)
        {
            var temp = _productRepository.GetProductById(id);
            if (temp == null)
            {
                return NoContent();
            }
            product.ProductId = id;
            await _productRepository.UpdateProduct(product);
            return Content("Update success!");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var temp = _productRepository.GetProductById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _productRepository.DeleteProduct(id);
            return Content("Delete success!");
        }
    }
}
