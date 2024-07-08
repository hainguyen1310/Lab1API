using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Lab1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var listCategory = await _categoryRepository.GetAllCategories();
            return listCategory;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> PostCategory(Category category)
        {
            await _categoryRepository.AddCategory(category);
            return Content("Insert success!");
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(int id, Category category)
        {
            var temp = _categoryRepository.GetCategoryById(id);
            if (temp == null)
            {
                return NoContent();
            }
            category.CategoryId = id;
            await _categoryRepository.UpdateCategory(category);
            return Content("Update success!");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var temp = _categoryRepository.GetCategoryById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _categoryRepository.DeleteCategory(id);
            return Content("Delete success!");
        }
    }
}
