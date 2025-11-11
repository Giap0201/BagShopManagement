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
using BagShopManagement.Views.Controls;
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

        // === CẤU HÌNH TOÀN BỘ DEPENDENCY ===
        private static void ConfigureServices(IServiceCollection services)
        {
            // === Đăng ký Repositories - Dev4 ===
            services.AddTransient<ISanPhamRepository, SanPhamRepository>();
            services.AddTransient<IHoaDonBanRepository, HoaDonBanRepository>();

            // === Đăng ký Repositories - Dev6 ===
            services.AddTransient<IHoaDonNhapRepository, HoaDonNhapRepository>();
            services.AddTransient<IChiTietHDNRepository, ChiTietHDNRepository>();
            services.AddTransient<INhaCungCapRepository, NhaCungCapRepository>();
            services.AddTransient<INhanVienRepository, NhanVienRepository>();

            // === Đăng ký Services - Dev4 ===
            services.AddTransient<IHoaDonBanService, HoaDonBanService>();
            services.AddTransient<ITonKhoService, TonKhoService>();
            services.AddTransient<IPosService, PosService>();

            // === Đăng ký Services - Dev6 ===
            services.AddTransient<IHoaDonNhapService, HoaDonNhapService>();

            // === Đăng ký Controllers ===
            services.AddTransient<POSController>();
            services.AddTransient<HoaDonBanController>();
            services.AddTransient<HoaDonNhapController>();

            // === Đăng ký Utils ===
            services.AddTransient(sp => new MaHoaDonGenerator("HDN", 3));

            // === Đăng ký Forms và UserControls ===
            services.AddTransient<QuanLiBanHang>();  // Form chính
            services.AddTransient<SideBarControl>(); // Thanh bên

            // Dev4 Forms
            services.AddTransient<POSForm>();
            services.AddTransient<HoaDonBanForm>();
            services.AddTransient<UC_POS>();

            // Dev6 Forms
            services.AddTransient<frmHoaDonNhapDetail>();
            services.AddTransient<ucHoaDonNhapList>();
            services.AddTransient<TEST>();
        }
    }
}