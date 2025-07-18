using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessObject;
namespace Repositories
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetails();
        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId);
        public bool AddOrderDetail(OrderDetail orderDetail);
        public bool DelOrderDetail(int orderId, int productId);
        public bool UpOrderDetail(OrderDetail orderDetail);

    }
}
