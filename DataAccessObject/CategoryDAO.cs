using BusinessObject; // Dùng để truy cập các lớp dữ liệu, ví dụ: Category
using System;
using System.Collections.Generic; // Dùng cho List<T>
using System.Linq; // Dùng cho LINQ như ToList(), Where(), v.v.
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer // Lớp này thuộc tầng truy cập dữ liệu
{
    public class CategoryDAO // DAO = Data Access Object, chuyên xử lý dữ liệu cho bảng Categories
    {
        // Khởi tạo ngữ cảnh kết nối tới cơ sở dữ liệu
        LucySalesDataContext context = new LucySalesDataContext();

        /// <summary>
        /// Truy xuất toàn bộ danh sách Category từ cơ sở dữ liệu
        /// </summary>
        /// <returns>Danh sách các đối tượng Category</returns>
        public List<Category> GetCategories()
        {
            // Lấy tất cả Category trong bảng Categories và chuyển sang List
            return context.Categories.ToList();
        }
    }
}
