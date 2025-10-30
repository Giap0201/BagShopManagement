using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    internal interface IKhachHangRepository
    {
        public List<KhachHang> GetAll();
        public KhachHang? GetById(string maKH);
        public int Add(KhachHang kh);
        public int Update(KhachHang kh);
        public int Delete(string maKH);
        public List<KhachHang> Search(string ten, string sdt, string email);
    }
}
