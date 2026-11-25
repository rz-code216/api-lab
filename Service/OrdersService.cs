using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository repository;
        public OrdersService(IOrdersRepository   repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await repository.GetAllOrders();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await repository.GetOrderById(id);
        }

        public async Task<Order> AddOrder(Order order)
        {
            return await repository.AddOrder(order);
        }
    }
}
