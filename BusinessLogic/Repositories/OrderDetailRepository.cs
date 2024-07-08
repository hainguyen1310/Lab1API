using BusinessLogic.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public async Task AddOrderDetail(OrderDetail orderDetail)
        {
            await OrderDetailDAO.Instance.AddOrderDetail(orderDetail);
        }

        public async Task DeleteOrderDetail(int orderId, int productId)
        {
            await OrderDetailDAO.Instance.DeleteOrderDetail(orderId, productId);
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetails()
        {
            return await OrderDetailDAO.Instance.GetAllOrderDetails();
        }

        public async Task<OrderDetail> GetOrderDetailByOrderIdProductId(int orderId, int productId)
        {
            return await OrderDetailDAO.Instance.GetOrderDetailByOrderIdProductId(orderId, productId);
        }

        public async Task UpdateOrderDetail(OrderDetail orderDetail)
        {
            await OrderDetailDAO.Instance.UpdateOrderDetail(orderDetail);
        }
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailById(int id)
        {
            return await OrderDetailDAO.Instance.GetOrderDetailById(id);
        }
    }
}
