using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace BagShopManagement
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            // === TẠO SERVICE CONTAINER ===
            var services = new ServiceCollection();

            // 🔹 Đăng ký Repository
            services.AddScoped<ISanPhamRepository, SanPhamRepository>();
            services.AddScoped<IHoaDonBanRepository, HoaDonBanRepository>();

            // 🔹 Đăng ký Service
            services.AddScoped<IHoaDonBanService, HoaDonBanService>();
            services.AddScoped<ITonKhoService, TonKhoService>();
            services.AddScoped<IPosService, PosService>();

            // 🔹 Đăng ký Controller
            services.AddScoped<POSController>();
            services.AddScoped<HoaDonBanController>();

            // 🔹 Đăng ký Form (chỉ form chính có thể dùng DI)
            services.AddScoped<Views.Dev4.Dev4_POS.POSForm>();
            services.AddScoped<Views.Dev4.Dev4_HoaDonBan.HoaDonBanForm>();

            // === XÂY DỰNG PROVIDER ===
            var provider = services.BuildServiceProvider();

            // === CHỌN FORM MUỐN CHẠY ===
            
            // Option 1: Chạy POSForm (Bán hàng)
            //var mainForm = provider.GetRequiredService<Views.Dev4.Dev4_POS.POSForm>();
            
            // Option 2: Chạy HoaDonBanForm (Quản lý hóa đơn) - từ đây có thể mở ChiTietHoaDonForm
             var mainForm = provider.GetRequiredService<Views.Dev4.Dev4_HoaDonBan.HoaDonBanForm>();
            
            // Option 3: Test ChiTietHoaDonForm trực tiếp (CẦN CÓ MÃ HÓA ĐƠN HỢP LỆ TRONG DB)
            // var controller = provider.GetRequiredService<HoaDonBanController>();
            // var testMaHDB = "HDB20241201120000"; // ⚠️ Thay bằng mã hóa đơn thực tế trong DB
            // var mainForm = new Views.Dev4.Dev4_HoaDonBan.ChiTietHoaDonForm(testMaHDB, controller);

            Application.Run(mainForm);
        }
    }
}
