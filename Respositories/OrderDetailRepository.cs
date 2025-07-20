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
        OrderDetailDAO OrderDetailDAO = new OrderDetailDAO();
        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            return OrderDetailDAO.AddOrderDetail(orderDetail);
        }
        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return OrderDetailDAO.GetOrderDetailsByOrderId(orderId);
        }

        public bool DelOrderDetail(int orderId, int productId)
        {
            return OrderDetailDAO.DelOrderDetail(orderId, productId);
        }

        public List<OrderDetail> GetOrderDetails()
        {
            return OrderDetailDAO.GetOrderDetails();
        }

        public bool UpOrderDetail(OrderDetail orderDetail)
        {
            return OrderDetailDAO.UpOrderDetail(orderDetail);
        }
    }
}
