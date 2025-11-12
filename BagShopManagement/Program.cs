using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Views.Common;
using BagShopManagement.Views.Controls; // Giả sử QuanLiBanHang nằm ở đây
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace BagShopManagement
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            // Sử dụng QuanLiBanHang làm Form chính (bạn có thể đổi tên nếu cần)
            var mainForm = ServiceProvider.GetRequiredService<QuanLiBanHang>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // SỬA ĐỔI: Đổi Scoped thành Transient để an toàn hơn trong WinForms.
            // Transient đảm bảo một instance mới được tạo mỗi khi cần, tránh chia sẻ state không mong muốn.

            // 1. Đăng ký Repositories
            services.AddTransient<IChuongTrinhGiamGiaRepository, ChuongTrinhGiamGiaRepository>();
            services.AddTransient<IChiTietGiamGiaRepository, ChiTietGiamGiaRepository>();
            services.AddTransient<ISanPhamRepository, SanPhamRepository>(); // <-- BỔ SUNG

            // 2. Đăng ký Services
            services.AddTransient<IChuongTrinhGiamGiaService, ChuongTrinhGiamGiaService>();
            services.AddTransient<IChiTietGiamGiaService, ChiTietGiamGiaService>(); // <-- BỔ SUNG

            // 3. Đăng ký Controllers
            services.AddTransient<ChuongTrinhGiamGiaController>();
            services.AddTransient<ChiTietGiamGiaController>(); // <-- BỔ SUNG

            // 4. Đăng ký Forms và UserControls (Luôn là Transient)
            services.AddTransient<QuanLiBanHang>(); // Form chính của bạn
            services.AddTransient<PromotionControl>();
        }
    }
}