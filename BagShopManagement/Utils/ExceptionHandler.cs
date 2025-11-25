using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Utils
{
    /// <summary>
    /// Xử lý exception tập trung cho toàn hệ thống
    /// Phân loại exception và hiển thị thông báo phù hợp cho user
    /// </summary>
    public static class ExceptionHandler
    {
        /// <summary>
        /// Xử lý exception và hiển thị thông báo lỗi cho người dùng
        /// </summary>
        /// <param name="ex">Exception cần xử lý</param>
        /// <param name="userMessage">Thông báo custom cho user (mặc định: "Đã xảy ra lỗi không mong muốn")</param>
        /// <remarks>
        /// Phân loại exception:
        /// - ArgumentException: Lỗi nhập liệu → hiển thị chi tiết
        /// - ApplicationException: Lỗi nghiệp vụ/DB → hiển thị thông báo chung
        /// - Các lỗi khác: Hiển thị userMessage
        /// </remarks>
        public static void Handle(Exception ex, string userMessage = "Đã xảy ra lỗi không mong muốn.")
        {
            // Log exception để phục vụ debug
            Logger.Log($"[ERROR] {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");

            // Phân loại và hiển thị thông báo phù hợp
            if (ex is ArgumentException)
            {
                // Lỗi nhập liệu → hiển thị chi tiết cho user
                MessageBox.Show(ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ex is ApplicationException)
            {
                // Lỗi nghiệp vụ/DB → hiển thị thông báo chung, không expose chi tiết
                MessageBox.Show(ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Lỗi chưa xác định → hiển thị userMessage
                MessageBox.Show(userMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}