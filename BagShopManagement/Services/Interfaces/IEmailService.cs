using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        /// Gửi một email.
        /// </summary>
        void SendEmail(string toEmail, string subject, string body);
    }
}
