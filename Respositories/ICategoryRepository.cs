using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;  // Chứa định nghĩa entity Category
using DataAccessLayer; // (Không bắt buộc trong interface, nhưng giữ nguyên theo yêu cầu)

namespace Repositories
{
    /// <summary>
    /// Giao diện Repository cho danh mục sản phẩm (Category).
    /// Triển khai bởi các lớp trung gian giữa tầng nghiệp vụ và tầng truy cập dữ liệu.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Lấy danh sách tất cả các Category.
        /// </summary>
        /// <returns>Danh sách đối tượng <see cref="Category"/>.</returns>
        List<Category> GetCategories();
    }
}
