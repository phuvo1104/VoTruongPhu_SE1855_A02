using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Services
{
    public interface IOrderService
    {
        public List<Order> GetOrders();
        public bool AddOrder(Order order);
        public bool DelOrder(Order order);
        public bool UpOrder(Order order);
    }
}
