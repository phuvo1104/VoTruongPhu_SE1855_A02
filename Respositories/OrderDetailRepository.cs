using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessObject;
namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        OrderDetailDAO od = new OrderDetailDAO();
        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            return od.AddOrderDetail(orderDetail);
        }
        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return od.GetOrderDetailsByOrderId(orderId);
        }

        public bool DelOrderDetail(int orderId, int productId)
        {
            return od.DelOrderDetail(orderId, productId);
        }

        public List<OrderDetail> GetOrderDetails()
        {
            return od.GetOrderDetails();
        }

        public bool UpOrderDetail(OrderDetail orderDetail)
        {
            return od.UpOrderDetail(orderDetail);
        }
    }
}
