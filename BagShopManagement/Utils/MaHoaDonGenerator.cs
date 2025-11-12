using BagShopManagement.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Utils
{
    public class MaHoaDonGenerator : BaseRepository
    {
        private readonly string _prefix;
        private readonly int _length;

        public MaHoaDonGenerator(string prefix = "HDN", int length = 3) : base() // THÊM : base() vào đây
        {
            if (string.IsNullOrWhiteSpace(prefix))
                throw new ArgumentException("Tiền tố không được để trống.", nameof(prefix));

            if (length <= 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Độ dài số thứ tự phải lớn hơn 0.");

            _prefix = prefix;
            _length = length;
        }

        public string GenerateNewMaHDN(DateTime ngayLap)
        {
            string datePart = ngayLap.ToString("yyMMdd");
            string newMaHDN = "";
            int serialNumber = 1; // Bắt đầu từ 1
            try
            {
                string query = $"select max(MaHDN) from HoaDonNhap where MaHDN like @Pattern";
                var parameter = new SqlParameter("@Pattern", $"{_prefix}-{datePart}-%");
                object result = ExecuteScalar(query, parameter);
                if (result != null && result != DBNull.Value)
                {
                    string lastMaHDN = result.ToString();

                    int minLength = _prefix.Length + 1 + datePart.Length + 1 + 1;

                    if (lastMaHDN.Length >= minLength && lastMaHDN.LastIndexOf('-') > (_prefix.Length + datePart.Length))
                    {
                        string serialStr = lastMaHDN.Substring(lastMaHDN.LastIndexOf('-') + 1);
                        if (int.TryParse(serialStr, out int lastSerial))
                        {
                            serialNumber = lastSerial + 1;
                        }
                    }
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("Lỗi khi tạo mã hóa đơn từ DB: " + ex.Message);
                return null;
            }
            catch (Exception ex) // Bắt các lỗi khác
            {
                Console.WriteLine("Lỗi không xác định khi tạo mã hóa đơn: " + ex.Message);
                return null;
            }

            // Định dạng số thứ tự
            string formatString = serialNumber.ToString($"D{_length}");
            newMaHDN = $"{_prefix}-{datePart}-{formatString}";
            return newMaHDN;
        }
    }
}