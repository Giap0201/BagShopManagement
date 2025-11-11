using System;
using System.IO;

namespace BagShopManagement.Utils
{
    /// <summary>
    /// Utility class để ghi log ra file
    /// File log: bagshop_logs.txt tại thư mục gốc của ứng dụng
    /// </summary>
    public static class Logger
    {
        private static readonly string LogFile = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory ?? ".",
            "bagshop_logs.txt"
        );

        /// <summary>
        /// Ghi log message với timestamp vào file
        /// </summary>
        /// <param name="message">Nội dung log cần ghi</param>
        /// <remarks>
        /// - Format: yyyy-MM-dd HH:mm:ss {message}
        /// - Nếu ghi log thất bại, lỗi sẽ bị bỏ qua để không ảnh hưởng luồng chính
        /// </remarks>
        public static void Log(string message)
        {
            try
            {
                File.AppendAllText(LogFile, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {message}{Environment.NewLine}");
            }
            catch
            {
                // Intentionally swallow logging errors to prevent cascading failures
            }
        }
    }
}
