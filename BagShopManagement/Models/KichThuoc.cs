using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Models
{
    public class KichThuoc
    {
        public string MaKichThuoc { get; set; }
        public string TenKichThuoc { get; set; }
        public decimal? ChieuDai { get; set; }
        public decimal? ChieuRong { get; set; }
        public decimal? ChieuCao { get; set; }
    }
}