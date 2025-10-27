using BagShopManagement.DTOs.Responses;
using BagShopManagement.Models;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using BagShopManagement.Views.Common;
using BagShopManagement.Views.Dev6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagShopManagement.Controllers
{
    // Controller cần biết Service và View mà nó điều khiển
    public class HoaDonNhapController
    {
        private readonly IHoaDonNhapView _view;
        private readonly IHoaDonNhapService _service;

        public HoaDonNhapController(IHoaDonNhapView view, IHoaDonNhapService service)
        {
            _view = view;
            _service = service;
        }

        public void LoadHoaDonNhap()
        {
            try
            {
                var list = _service.GetAllHoaDonNhap();
                _view.DisplayHoaDonNhap(list);
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }
    }
}