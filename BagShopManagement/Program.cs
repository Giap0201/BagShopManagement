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

            // 1. Tạo bộ sưu tập dịch vụ
            var services = new ServiceCollection();
            ConfigureServices(services);

            // 2. Build ServiceProvider
            // Chúng ta dùng 'using' để đảm bảo mọi thứ được giải phóng khi app tắt
            using (var serviceProvider = services.BuildServiceProvider())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // 3. Yêu cầu Form chính từ DI container
                var mainForm = serviceProvider.GetRequiredService<QuanLiBanHang>();

                // 4. Chạy Form chính
                Application.Run(mainForm);
            }
        }

        // Hàm cấu hình tất cả các Dependency
        private static void ConfigureServices(IServiceCollection services)
        {
            // === Cung cấp IServiceProvider cho chính nó ===
            // Điều này cần thiết để Form cha (QuanLiBanHang)
            // và UC (ucHoaDonNhapList) có thể yêu cầu các dịch vụ khác
            services.AddSingleton<IServiceProvider>(sp => sp.CreateScope().ServiceProvider);

            // === Đăng ký Repositories ===
            services.AddTransient<IHoaDonNhapRepository, HoaDonNhapImpl>();
            services.AddTransient<IChiTietHDNRepository, ChiTietHDNImpl>();
            services.AddTransient<INhaCungCapRepository, NhaCungCapImpl>();
            services.AddTransient<INhanVienRepository, NhanVienImpl>();
            services.AddTransient<ISanPhamRepository, SanPhamImpl>();

            // === Đăng ký Services ===
            services.AddTransient<IHoaDonNhapService, HoaDonNhapService>();

            // === Đăng ký Controllers ===
            services.AddTransient<HoaDonNhapController>();

            // === Đăng ký Utils ===
            // Đăng ký MaHoaDonGenerator để frmHoaDonNhapDetail có thể nhận
            services.AddTransient<MaHoaDonGenerator>(sp => new MaHoaDonGenerator("HDN", 3));

            // === Đăng ký Forms và UserControls ===
            services.AddTransient<QuanLiBanHang>();       // Form chính (Shell)
            services.AddTransient<frmHoaDonNhapDetail>(); // Form chi tiết (Popup)
            services.AddTransient<ucHoaDonNhapList>();    // UC 1

            // (Khi bạn tạo UC mới, ví dụ ucSanPhamList, chỉ cần thêm vào đây)
            // services.AddTransient<ucSanPhamList>();
        }
    }
}