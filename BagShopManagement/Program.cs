using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using BagShopManagement.Views.Common;
using BagShopManagement.Views.Dev6;
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

            // 1️⃣ Tạo bộ sưu tập dịch vụ (DI container)
            var services = new ServiceCollection();
            ConfigureServices(services);

            // 2️⃣ Xây dựng provider
            using (var serviceProvider = services.BuildServiceProvider())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // 🔸 CÁCH 1: Chạy Form chính như bình thường
                // var mainForm = serviceProvider.GetRequiredService<QuanLiBanHang>();
                // Application.Run(mainForm);

                // 🔸 CÁCH 2: Chạy trực tiếp UserControl báo cáo để test nhanh
                var baoCaoController = serviceProvider.GetRequiredService<BaoCaoController>();
                var testForm = new Form
                {
                    Text = "Báo cáo doanh thu - Test",
                    Width = 1000,
                    Height = 800
                };

                var view = new ucBaoCaoNhapHang(baoCaoController);
                view.Dock = DockStyle.Fill;
                testForm.Controls.Add(view);

                Application.Run(testForm);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // ===== Đăng ký Repositories =====
            services.AddTransient<IHoaDonNhapRepository, HoaDonNhapImpl>();
            services.AddTransient<IChiTietHDNRepository, ChiTietHDNImpl>();
            services.AddTransient<INhaCungCapRepository, NhaCungCapImpl>();
            services.AddTransient<INhanVienRepository, NhanVienImpl>();
            services.AddTransient<ISanPhamRepository, SanPhamImpl>();

            // ⚙️ Đăng ký repository cho báo cáo
            services.AddTransient<IBaoCaoRepository, BaoCaoImpl>();

            // ===== Đăng ký Services =====
            services.AddTransient<IHoaDonNhapService, HoaDonNhapService>();
            services.AddTransient<IBaoCaoService, BaoCaoService>();

            // ===== Đăng ký Controllers =====
            services.AddTransient<HoaDonNhapController>();
            services.AddTransient<BaoCaoController>();

            // ===== Đăng ký tiện ích (Utils) =====
            services.AddTransient<MaHoaDonGenerator>(sp => new MaHoaDonGenerator("HDN", 3));

            // ===== Đăng ký Forms & UserControls =====
            services.AddTransient<QuanLiBanHang>();       // Form chính
            services.AddTransient<frmHoaDonNhapDetail>(); // Form chi tiết
            services.AddTransient<ucHoaDonNhapList>();    // UC 1
            services.AddTransient<ucBaoCaoDoanhThu>();    // UC Báo cáo doanh thu
        }
    }
}