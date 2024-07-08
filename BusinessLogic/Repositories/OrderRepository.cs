using BusinessLogic.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        public async Task AddOrder(Order order)
        {
            await OrderDAO.Instance.AddOrder(order);
        }

        public async Task DeleteOrder(int id)
        {
            await OrderDAO.Instance.DeleteOrder(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await OrderDAO.Instance.GetAllOrders();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await OrderDAO.Instance.GetOrderById(id);
        }

        public async Task UpdateOrder(Order order)
        {
            await OrderDAO.Instance.UpdateOrder(order);
        }
    }
}
