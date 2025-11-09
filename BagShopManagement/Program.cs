using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Views.Common;
using BagShopManagement.Views.Dev6;
using Microsoft.Extensions.DependencyInjection;

namespace BagShopManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            var services = new ServiceCollection();

            // Đăng ký tất cả dependencies
            services.AddTransient<IHoaDonNhapRepository, HoaDonNhapImpl>();
            services.AddTransient<IChiTietHDNRepository, ChiTietHDNImpl>();
            services.AddTransient<INhaCungCapRepository, NhaCungCapImpl>();
            services.AddTransient<INhanVienRepository, NhanVienImpl>();
            services.AddTransient<ISanPhamRepository, SanPhamImpl>();

            services.AddTransient<IHoaDonNhapService, HoaDonNhapService>();
            services.AddTransient<HoaDonNhapController>();

            // Đăng ký Form
            services.AddTransient<frmHoaDonNhapDetail>();

            var serviceProvider = services.BuildServiceProvider();

            // Mở Form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = serviceProvider.GetRequiredService<frmHoaDonNhapDetail>();
            Application.Run(mainForm);
        }
    }
}