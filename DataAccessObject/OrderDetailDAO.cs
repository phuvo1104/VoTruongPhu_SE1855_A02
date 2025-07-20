using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class OrderDetailDAO
    {
        private readonly LucySalesDataContext context = new LucySalesDataContext();

        // ============================================
        // 1. Lấy danh sách chi tiết đơn hàng
        // ============================================
        public List<OrderDetail> GetOrderDetails()
        {
            return context.OrderDetails.ToList();
        }

        // Lấy chi tiết đơn hàng theo OrderId
        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return context.OrderDetails
                          .Where(od => od.OrderId == orderId)
                          .ToList();
        }

        // ============================================
        // 2. Thêm chi tiết đơn hàng
        // ============================================
        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi khi thêm chi tiết đơn hàng: {ex.Message}");
                return false;
            }
        }

        // ============================================
        // 3. Cập nhật chi tiết đơn hàng
        // ============================================
        public bool UpOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                var eOrderDetail = context.OrderDetails
                                                 .Find(orderDetail.OrderId, orderDetail.ProductId);
                if (eOrderDetail != null)
                {
                    eOrderDetail.UnitPrice = orderDetail.UnitPrice;
                    eOrderDetail.Quantity = orderDetail.Quantity;
                    eOrderDetail.Discount = orderDetail.Discount;

                    context.SaveChanges();
                    return true;
                }

                Console.WriteLine("⚠ Không tìm thấy chi tiết đơn hàng để cập nhật.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi khi cập nhật chi tiết đơn hàng: {ex.Message}");
                return false;
            }
        }

        // ============================================
        // 4. Xoá chi tiết đơn hàng
        // ============================================
        public bool DelOrderDetail(int orderId, int productId)
        {
            try
            {
                var orderDetail = context.OrderDetails
                                         .FirstOrDefault(p => p.OrderId == orderId && p.ProductId == productId);
                if (orderDetail == null)
                {
                    Console.WriteLine("⚠ Không tìm thấy chi tiết đơn hàng cần xoá.");
                    return false;
                }

                context.OrderDetails.Remove(orderDetail);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi khi xoá chi tiết đơn hàng: {ex.Message}");
                return false;
            }
        }
    }
}
