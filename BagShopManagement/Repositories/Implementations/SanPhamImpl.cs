using BagShopManagement.DataAccess;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Implementations
{
    public class SanPhamImpl : BaseRepository, ISanPhamRepository
    {
        public List<SanPham> GetAll()
        {
            string query = "SELECT MaSP, TenSP FROM SanPham ORDER BY TenSP";
            DataTable dt = base.ExecuteQuery(query);

            var list = new List<SanPham>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SanPham
                {
                    MaSP = row["MaSP"].ToString(),
                    TenSP = row["TenSP"].ToString()
                });
            }
            return list;
        }
    }
}