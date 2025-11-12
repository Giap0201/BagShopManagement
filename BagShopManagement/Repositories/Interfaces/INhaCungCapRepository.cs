using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    internal interface INhaCungCapRepository
    {
        public List<NhaCungCap> GetAll();
        public NhaCungCap? GetById(string maNCC);
        public int Add(NhaCungCap NCC);
        public int Update(NhaCungCap NCC);
        public int Delete(string maNCC);
        public List<NhaCungCap> Search(string ten, string sdt, string email);
    }
}