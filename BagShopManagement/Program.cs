// --- Các using của Dev4/Dev6 ---
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

// --- Using Bổ sung cho Dev1 ---
using BagShopManagement.Views; // Cho LoginForm
using BagShopManagement.Views.Dev1; // Cho Forms/UCs của Dev1

namespace BagShopManagement
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var provider = services.BuildServiceProvider())
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    // === CHẠY LOGINFORM ĐẦU TIÊN ===
                    var loginForm = provider.GetRequiredService<LoginForm>();
                    Application.Run(loginForm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khởi động ứng dụng: {ex.Message}\n\nChi tiết: {ex.InnerException?.Message}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // === Cung cấp IServiceProvider cho chính nó ===
            services.AddSingleton<IServiceProvider>(sp => sp.CreateScope().ServiceProvider);

            // === Đăng ký Repositories (Dev4, Dev6, Dev1) ===
            services.AddTransient<ISanPhamRepository, SanPhamRepository>();
            services.AddTransient<IHoaDonBanRepository, HoaDonBanRepository>();
            services.AddTransient<IHoaDonNhapRepository, HoaDonNhapImpl>();
            services.AddTransient<IChiTietHDNRepository, ChiTietHDNImpl>();
            services.AddTransient<INhaCungCapRepository, NhaCungCapImpl>();
            services.AddTransient<INhanVienRepository, NhanVienImpl>();
            services.AddTransient<ITaiKhoanRepository, TaiKhoanImpl>();
            services.AddTransient<IQuyenRepository, QuyenImpl>();
            services.AddTransient<IVaiTroRepository, VaiTroImpl>();

            // === Đăng ký Services (Dev4, Dev6, Dev1) ===
            services.AddTransient<IHoaDonBanService, HoaDonBanService>();
            services.AddTransient<ITonKhoService, TonKhoService>();
            services.AddTransient<IPosService, PosService>();
            services.AddTransient<IHoaDonNhapService, HoaDonNhapService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<INhanVienService, NhanVienService>();
            services.AddTransient<IEmailService, FakeEmailService>();

            // === Đăng ký Controllers (Dev4, Dev6, Dev1) ===
            services.AddTransient<POSController>();
            services.AddTransient<HoaDonBanController>();
            services.AddTransient<HoaDonNhapController>();
            services.AddTransient<LoginController>();
            services.AddTransient<NhanVienController>();
            services.AddTransient<ProfileController>();

            // === Đăng ký Utils ===
            services.AddTransient(sp => new MaHoaDonGenerator("HDN", 3));

            // === Đăng ký Forms và UserControls ===

            // 1. Đăng ký QuanLiBanHang (MainForm)
            // Constructor của nó chỉ cần IServiceProvider
            services.AddTransient<QuanLiBanHang>(provider =>
            {
                return new QuanLiBanHang(
                    provider.GetRequiredService<IServiceProvider>()
                );
            });

            // 2. Đăng ký LoginForm (Form khởi chạy)
            // Nó cần 3 thứ
            services.AddTransient<LoginForm>(provider =>
            {
                return new LoginForm(
                    provider.GetRequiredService<LoginController>(),
                    // Factory (hàm tạo) để tạo QuanLiBanHang
                    () => provider.GetRequiredService<QuanLiBanHang>(),
                    provider // Cần IServiceProvider để mở ForgotPasswordForm
                );
            });

            // 3. Đăng ký các Form/UC còn lại
            services.AddTransient<SideBarControl>();
            services.AddTransient<POSForm>();
            services.AddTransient<HoaDonBanForm>();
            services.AddTransient<UC_POS>();
            services.AddTransient<frmHoaDonNhapDetail>();
            services.AddTransient<ucHoaDonNhapList>();
            services.AddTransient<TEST>();
            services.AddTransient<ForgotPasswordForm>();
            services.AddTransient<EmployeeEditForm>();
            services.AddTransient<ucProfile>();
            services.AddTransient<ucEmployeeManagement>();
        }
    }
}