using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetails();
        Task<OrderDetail> GetOrderDetailByOrderIdProductId(int orderId, int productId);
        Task AddOrderDetail(OrderDetail orderDetail);
        Task UpdateOrderDetail(OrderDetail orderDetail);
        Task DeleteOrderDetail(int orderId, int productId);
        Task<IEnumerable<OrderDetail>> GetOrderDetailById(int id);
    }
}
