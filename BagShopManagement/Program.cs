using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;
using BagShopManagement.Views.Dev4.Dev4_POS;
using BagShopManagement.Views.Dev6;
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
            ConfigureServices(services);

            // === XÂY DỰNG PROVIDER ===
            var provider = services.BuildServiceProvider();

            // === CHẠY FORM CHÍNH ===
            var mainForm = provider.GetRequiredService<QuanLiBanHang>();
            Application.Run(mainForm);
        }

        // Hàm cấu hình tất cả các Dependency
        private static void ConfigureServices(IServiceCollection services)
        {
            // === Cung cấp IServiceProvider cho chính nó ===
            services.AddSingleton<IServiceProvider>(sp => sp.CreateScope().ServiceProvider);

            // === Đăng ký Repositories - Dev4 ===
            services.AddScoped<ISanPhamRepository, SanPhamRepository>();
            services.AddScoped<IHoaDonBanRepository, HoaDonBanRepository>();

            // === Đăng ký Repositories - Dev6 ===
            services.AddTransient<IHoaDonNhapRepository, HoaDonNhapImpl>();
            services.AddTransient<IChiTietHDNRepository, ChiTietHDNImpl>();
            services.AddTransient<INhaCungCapRepository, NhaCungCapImpl>();
            services.AddTransient<INhanVienRepository, NhanVienImpl>();

            // === Đăng ký Services - Dev4 ===
            services.AddScoped<IHoaDonBanService, HoaDonBanService>();
            services.AddScoped<ITonKhoService, TonKhoService>();
            services.AddScoped<IPosService, PosService>();

            // === Đăng ký Services - Dev6 ===
            services.AddTransient<IHoaDonNhapService, HoaDonNhapService>();

            // === Đăng ký Controllers ===
            services.AddScoped<POSController>();
            services.AddScoped<HoaDonBanController>();
            services.AddTransient<HoaDonNhapController>();

            // === Đăng ký Utils ===
            services.AddTransient<MaHoaDonGenerator>(sp => new MaHoaDonGenerator("HDN", 3));

            // === Đăng ký Forms và UserControls ===
            services.AddTransient<QuanLiBanHang>();       // Form chính (Shell)

            // Dev4 Forms
            services.AddTransient<POSForm>();
            services.AddTransient<HoaDonBanForm>();

            // Dev6 Forms
            services.AddTransient<frmHoaDonNhapDetail>();
            services.AddTransient<ucHoaDonNhapList>();
        }
    }
}
