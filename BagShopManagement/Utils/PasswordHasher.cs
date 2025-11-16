using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Utils
{
    public static class PasswordHasher
    {
        /// <summary>
        /// Băm một mật khẩu thô sử dụng SHA256.
        /// </summary>
        /// <param name="password">Mật khẩu thô.</param>
        /// <returns>Chuỗi hash (dạng hex).</returns>
        public static string Hash(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                // Chuyển mật khẩu sang byte array
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Chuyển byte array thành chuỗi Hex
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // "x2" là định dạng hex
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Xác thực một mật khẩu thô so với một chuỗi hash.
        /// </summary>
        /// <param name="password">Mật khẩu thô (người dùng nhập).</param>
        /// <param name="hashedPassword">Chuỗi hash (lưu trong DB).</param>
        /// <returns>True nếu mật khẩu khớp.</returns>
        public static bool Verify(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
                return false;

            // Băm mật khẩu người dùng nhập vào
            string hashOfInput = Hash(password);

            MessageBox.Show($"Hash of input: {hashOfInput}\nStored hash: {hashedPassword}");

            // So sánh (không phân biệt chữ hoa/thường) chuỗi hash vừa tạo với chuỗi hash trong DB
            return StringComparer.OrdinalIgnoreCase.Compare(hashOfInput, hashedPassword) == 0;
        }
    }
}
