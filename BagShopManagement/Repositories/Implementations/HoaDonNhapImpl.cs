using BagShopManagement.DataAccess;
using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Implementations
{
    public class HoaDonNhapImpl : BaseRepository, IHoaDonNhapRepository
    {
        public List<HoaDonNhap> GetAll()
        {
            string query = "SELECT MaHD, NgayNhap, MaNCC, MaNV, TongTien FROM HoaDonNhap";

            DataTable dt = DataAccessBase.ExecuteQuery(query);

            List<HoaDonNhap> list = new List<HoaDonNhap>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new HoaDonNhap
                {
                    MaHDN = row["MaHD"].ToString(),
                    NgayNhap = Convert.ToDateTime(row["NgayNhap"]),
                    MaNCC = row["MaNCC"].ToString(),
                    MaNV = row["MaNV"].ToString(),
                    TongTien = Convert.ToDecimal(row["TongTien"])
                });
            }

            return list;
        }
    }
}