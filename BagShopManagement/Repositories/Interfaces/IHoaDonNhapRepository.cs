using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IHoaDonNhapRepository
    {
        //kiem tra hoa don nhap ton tai
        bool Exists(string maHDN);

        List<HoaDonNhap> GetAll();

        HoaDonNhap GetById(string maHDN);

        List<HoaDonNhap> GetByDateRange(DateTime fromDate, DateTime toDate);

        void Add(HoaDonNhap hoaDonNhap);

        void Update(HoaDonNhap hoaDonNhap);

        void Delete(string maHDN);
    }
}