using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessBase = BagShopManagement.DataAccess.BaseRepository;

namespace BagShopManagement.Repositories.Implementations
{
    public class NhanVienImpl : DataAccessBase, INhanVienRepository
    {
        public List<NhanVien> GetAll()
        {
            string query = "SELECT MaNV, HoTen FROM NhanVien WHERE TrangThai = 1 ORDER BY HoTen";
            DataTable dt = base.ExecuteQuery(query);

            var list = new List<NhanVien>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new NhanVien
                {
                    MaNV = row["MaNV"].ToString(),
                    HoTen = row["HoTen"].ToString()
                });
            }
            return list;
        }
    }
}