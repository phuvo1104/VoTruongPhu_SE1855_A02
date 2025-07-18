using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;
using Repositories;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _orderRepository;
        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }
        public bool AddOrder(Order order)
        {
            return _orderRepository.AddOrder(order);
        }

        public bool DelOrder(Order order)
        {
            return _orderRepository.DelOrder(order);
        }

        public List<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        public bool UpOrder(Order order)
        {
            return _orderRepository.UpOrder(order);
        }
    }
}
