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
    public class NhaCungCapImpl : BaseRepository, INhaCungCapRepository
    {
        public List<NhaCungCap> GetAll()
        {
            string query = "SELECT MaNCC, TenNCC FROM NhaCungCap ORDER BY TenNCC";
            DataTable dt = base.ExecuteQuery(query);

            var list = new List<NhaCungCap>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new NhaCungCap
                {
                    MaNCC = row["MaNCC"].ToString(),
                    TenNCC = row["TenNCC"].ToString()
                });
            }
            return list;
        }
    }
}