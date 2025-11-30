using BagShopManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    /// <summary>
    /// Interface cho nghiệp vụ liên quan đến Khách Hàng
    /// </summary>
    public interface IKhachHangRepository
    {
        public List<KhachHang> GetAll();

        public KhachHang? GetById(string maKH);

        public int Add(KhachHang kh);

        public int Update(KhachHang kh);

        public int Delete(string maKH);

        bool Exists(string maKH);

        string GetMaxCode();

        public List<KhachHang> Search(string keyword);



    }
}
