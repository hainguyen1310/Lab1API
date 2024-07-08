using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Lab1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailController()
        {
            _orderDetailRepository = new OrderDetailRepository();
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<OrderDetail>> GetOrderDetails()
        {
            return await _orderDetailRepository.GetAllOrderDetails();
        }

        // GET api/<CategoryController>/Order/5
        [HttpGet("Order/{id}")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetail(int id)
        {
            var category = await _orderDetailRepository.GetOrderDetailById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // GET api/<CategoryController>/3/6
        [HttpGet("{Order}/{ProductId}")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetail(int OrderId, int ProductId)
        {
            var category = await _orderDetailRepository.GetOrderDetailByOrderIdProductId(OrderId, ProductId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> Post(OrderDetail orderDetail)
        {
            await _orderDetailRepository.AddOrderDetail(orderDetail);
            return Content("Insert success!");
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{Order}/{ProductId}")]
        public async Task<ActionResult> Put(int OrderId, int ProductId, OrderDetail orderDetail)
        {
            var temp = _orderDetailRepository.GetOrderDetailByOrderIdProductId(OrderId,ProductId);
            if (temp == null)
            {
                return NoContent();
            }
            orderDetail.ProductId = ProductId;
            orderDetail.OrderId = OrderId;
            await _orderDetailRepository.UpdateOrderDetail(orderDetail);
            return Content("Update success!");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{Order}/{ProductId}")]
        public async Task<ActionResult> Delete(int OrderId, int ProductId)
        {
            var temp = _orderDetailRepository.GetOrderDetailByOrderIdProductId(OrderId, ProductId);
            if (temp == null)
            {
                return NoContent();
            }
            await _orderDetailRepository.DeleteOrderDetail(OrderId, ProductId);
            return Content("Delete success!");
        }
    }
}
