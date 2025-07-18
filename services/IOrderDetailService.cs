using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Services
{
    public interface IOrderDetailService
    {
        public List<OrderDetail> GetOrderDetails();
        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId);
        public bool AddOrderDetail(OrderDetail newOrderDetail);
        public bool DelOrderDetail(int orderId, int productId);
        public bool UpOrderDetail(OrderDetail updatedOrderDetail);
    }
}
