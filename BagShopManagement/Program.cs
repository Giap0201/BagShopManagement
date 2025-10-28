using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
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

            // 🔹 Đăng ký Form
            services.AddScoped<Views.Dev4.Dev4_POS.POSForm>();

            // === XÂY DỰNG PROVIDER ===
            var provider = services.BuildServiceProvider();

            // Lấy Form chính từ DI container
            var mainForm = provider.GetRequiredService<Views.Dev4.Dev4_POS.POSForm>();

            Application.Run(mainForm);
        }
    }
}
