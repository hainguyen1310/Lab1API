using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ProductWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            var p = await _productService.GetProducts();
            return View(p);
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var p = await _productService.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product p)
        {
            if (ModelState.IsValid)
            {
                await _productService.Create(p);
                return RedirectToAction(nameof(Index));
            }
            return View(p);

        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var p = await _productService.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product p)
        {
            if (id != p.ProductId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _productService.Update(p);
                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var p = await _productService.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Product p)
        {
            try
            {
                await _productService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
