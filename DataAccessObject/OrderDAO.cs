using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class OrderDAO
    {
        // Kết nối đến cơ sở dữ liệu
        private readonly LucySalesDataContext context = new LucySalesDataContext();

        // ============================================
        // 1. Lấy toàn bộ đơn hàng
        // ============================================
        public List<Order> GetOrders()
        {
            return context.Orders.ToList();
        }

        // ============================================
        // 2. Thêm đơn hàng mới
        // ============================================
        public bool AddOrder(Order order)
        {
            try
            {
                context.Orders.Add(order);      // Thêm đơn hàng vào DbSet
                context.SaveChanges();          // Lưu thay đổi xuống database
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi khi thêm đơn hàng: {ex.Message}");
                return false;
            }
        }

        // ============================================
        // 3. Xoá đơn hàng
        // ============================================
        public bool DelOrder(Order order)
        {
            try
            {
                context.Orders.Remove(order);   // Xoá khỏi DbSet
                context.SaveChanges();          // Lưu thay đổi
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi khi xoá đơn hàng: {ex.Message}");
                return false;
            }
        }

        // ============================================
        // 4. Cập nhật đơn hàng
        // ============================================
        public bool UpOrder(Order order)
        {
            try
            {
                var eOrder = context.Orders.Find(order.OrderId);  // Tìm đơn hàng theo ID
                if (eOrder != null)
                {
                    // Cập nhật thông tin
                    eOrder.CustomerId = order.CustomerId;
                    eOrder.EmployeeId = order.EmployeeId;
                    eOrder.OrderDate = order.OrderDate;

                    context.SaveChanges();  // Lưu xuống CSDL
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi khi cập nhật đơn hàng: {ex.Message}");
                return false;
            }
        }
    }
}
