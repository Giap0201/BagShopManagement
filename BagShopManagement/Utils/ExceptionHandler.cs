using System;
using System.Windows.Forms;

namespace BagShopManagement.Utils
{
    public static class ExceptionHandler
    {
        /// <summary>
        /// Xử lý lỗi chung, trả về message thân thiện cho client
        /// </summary>
        /// <param name="ex">Exception xảy ra</param>
        /// <param name="userMessage">Thông báo mặc định nếu lỗi không xác định</param>
        /// <returns>Message thân thiện cho client</returns>
        public static string Handle(Exception ex, string userMessage = "Đã xảy ra lỗi không mong muốn.")
        {
            if (ex is ArgumentException)
            {
                // Lỗi đầu vào: hiển thị chi tiết
                return ex.Message;
            }
            else if (ex is ApplicationException)
            {
                // Lỗi nghiệp vụ/DB: hiển thị thông báo chung
                return "Đã xảy ra lỗi trong quá trình xử lý. Vui lòng thử lại.";
            }
            else
            {
                // Lỗi không xác định
                return userMessage;
            }
        }

        /// <summary>
        /// Hiển thị lỗi trực tiếp cho client
        /// </summary>
        public static void Show(Exception ex, string userMessage = "Đã xảy ra lỗi không mong muốn.")
        {
            MessageBox.Show(Handle(ex, userMessage), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}