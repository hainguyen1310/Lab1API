using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO : SingletonBase<OrderDetailDAO>
    {
        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetails()
        {
            return await _context.OrderDetails.ToListAsync();
        }
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailById(int id)
        {
            var orderdetail = await _context.OrderDetails.Where(c => c.OrderId == id).ToListAsync();
            if (orderdetail == null) return null;

            return orderdetail;
        }
        public async Task<OrderDetail> GetOrderDetailByOrderIdProductId(int orderId, int productId)
        {
            var orderdetail = await _context.OrderDetails.FirstOrDefaultAsync(c => c.ProductId == productId && c.OrderId == orderId);
            if (orderdetail == null) return null;

            return orderdetail;
        }
        public async Task AddOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderDetail(OrderDetail orderDetail)
        {
            var existingItem = await GetOrderDetailByOrderIdProductId(orderDetail.OrderId,orderDetail.ProductId);
            if (existingItem == null) return;
            _context.Entry(existingItem).CurrentValues.SetValues(orderDetail);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteOrderDetail(int orderID, int productID)
        {
            var orderDetail = await GetOrderDetailByOrderIdProductId(orderID, productID);

            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
