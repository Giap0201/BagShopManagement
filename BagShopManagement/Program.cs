using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;
using BagShopManagement.Views.Dev4.Dev4_POS;
using BagShopManagement.Views.Common;
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

            // 🔹 Đăng ký Forms (các form con và form chính)
            services.AddTransient<POSForm>();
            services.AddTransient<HoaDonBanForm>();
            services.AddTransient<QuanLiBanHang>();

            // === XÂY DỰNG PROVIDER ===
            var provider = services.BuildServiceProvider();

            // === CHẠY FORM CHÍNH ===
            var mainForm = provider.GetRequiredService<QuanLiBanHang>();

            Application.Run(mainForm);
        }
    }
}
