using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Lab1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCategory : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderCategory()
        {
            _orderRepository = new OrderRepository();
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Order>> GetCategories()
        {
            var listCategory = await _orderRepository.GetAllOrders();
            return listCategory;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetCategory(int id)
        {
            var category = await _orderRepository.GetOrderById(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> PostCategory(Order order)
        {
            await _orderRepository.AddOrder(order);
            return Content("Insert success!");
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(int id, Order order)
        {
            var temp = _orderRepository.GetOrderById(id);
            if (temp == null)
            {
                return NoContent();
            }
            order.OrderId = id;
            await _orderRepository.UpdateOrder(order);
            return Content("Update success!");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var temp = _orderRepository.GetOrderById(id);
            if (temp == null)
            {
                return NoContent();
            }
            await _orderRepository.DeleteOrder(id);
            return Content("Delete success!");
        }
    }
}
