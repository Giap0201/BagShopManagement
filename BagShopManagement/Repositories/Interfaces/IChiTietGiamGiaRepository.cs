using BagShopManagement.DTOs;
using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IChiTietGiamGiaRepository
    {
        List<ChiTietGiamGiaDto> GetAppliedProducts(string maCTGG);
        void Add(ChiTietGiamGia chiTiet);
        void Remove(string maCTGG, string maSP);
        void RemoveByMaCTGG(string maCTGG);
    }
}
