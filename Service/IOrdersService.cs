using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task<Order> AddOrder(Order order);
    }
}
