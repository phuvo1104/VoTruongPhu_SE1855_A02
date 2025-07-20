using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessObject;
namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        OrderDAO OrderDAO = new OrderDAO();

        public bool AddOrder(Order order)
        {
            return OrderDAO.AddOrder(order);
        }

        public bool DelOrder(Order order)
        {
            return OrderDAO.DelOrder(order);
        }

        public List<Order> GetOrders()
        {
            return OrderDAO.GetOrders();
        }

        public bool UpOrder(Order order)
        {
            return OrderDAO.UpOrder(order);
        }
    }
}
