using BusinessObject;       // Import lớp Category từ tầng Business Object
using DataAccessLayer;      // Import lớp CategoryDAO từ tầng truy cập dữ liệu
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    /// <summary>
    /// Repository cho danh mục sản phẩm (Category).
    /// Đóng vai trò trung gian giữa tầng Business và tầng DataAccess.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        // Khởi tạo đối tượng DAO để thao tác dữ liệu
        CategoryDAO cd = new CategoryDAO();

        /// <summary>
        /// Trả về danh sách tất cả các danh mục sản phẩm từ DAO
        /// </summary>
        /// <returns>List<Category></returns>
        public List<Category> GetCategories()
        {
            return cd.GetCategories();
        }
    }
}
