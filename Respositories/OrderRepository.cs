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
        OrderDAO od = new OrderDAO();

        public bool AddOrder(Order order)
        {
            return od.AddOrder(order);
        }

        public bool DelOrder(Order order)
        {
            return od.DelOrder(order);
        }

        public List<Order> GetOrders()
        {
            return od.GetOrders();
        }

        public bool UpOrder(Order order)
        {
            return od.UpOrder(order);
        }
    }
}
