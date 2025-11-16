using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Implementations
{
    public class FakeEmailService : IEmailService
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            // Thay vì gọi SMTP, chúng ta hiển thị một MessageBox
            // để xác nhận logic đã chạy đúng.
            string message = $"--- EMAIL GIẢ LẬP ---\n\n" +
                             $"Gửi tới: {toEmail}\n" +
                             $"Chủ đề: {subject}\n" +
                             $"Nội dung:\n{body}";

            MessageBox.Show(message, "Email Service (Fake)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
