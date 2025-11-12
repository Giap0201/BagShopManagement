using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using BagShopManagement.Views; // Dùng cho LoginForm cũ (nếu có)
using BagShopManagement.Views.Common;
using BagShopManagement.Views.Dev1; // <== BỔ SUNG: Cho LoginForm, ucProfile...
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

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    // Yêu cầu LoginForm từ DI
                    var loginForm = serviceProvider.GetRequiredService<LoginForm>();
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

            // === Đăng ký Repositories ===
            services.AddTransient<IHoaDonNhapRepository, HoaDonNhapImpl>();
            //services.AddTransient<IChiTietHDNRepository, ChiTietHDNImpl>();
            //services.AddTransient<INhaCungCapRepository, NhaCungCapImpl>();
            services.AddTransient<INhanVienRepository, NhanVienImpl>();
            //services.AddTransient<ISanPhamRepository, SanPhamImpl>();
            services.AddTransient<ITaiKhoanRepository, TaiKhoanImpl>();
            services.AddTransient<IQuyenRepository, QuyenImpl>();
            services.AddTransient<IVaiTroRepository, VaiTroImpl>();

            // === Đăng ký Services ===
            services.AddTransient<IHoaDonNhapService, HoaDonNhapService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<INhanVienService, NhanVienService>();
            services.AddTransient<IEmailService, FakeEmailService>(); // <== Đăng ký dịch vụ email giả

            // === Đăng ký Controllers ===
            services.AddTransient<HoaDonNhapController>();
            services.AddTransient<LoginController>();
            services.AddTransient<NhanVienController>();
            services.AddTransient<ProfileController>();

            // === Đăng ký Utils ===
            //services.AddTransient<MaHoaDonGenerator>(sp => new MaHoaDonGenerator("HDN", 3));

            // === Đăng ký Forms và UserControls ===

            // --- THAY ĐỔI CHỖ NÀY ---
            // Đăng ký QuanLiBanHang (MainForm) bằng factory
            // Nó cần các controller của các UC mà nó sẽ host
            services.AddTransient<QuanLiBanHang>(provider =>
            {
                return new QuanLiBanHang(
                    // Lấy các controller cần thiết cho các UC của Dev1, Dev2...
                    //provider.GetRequiredService<NhanVienController>(),
                    //provider.GetRequiredService<ProfileController>()
                // (Thêm các controller/service khác mà MainForm cần ở đây)
                );
            });

            // Đăng ký LoginForm (Form khởi chạy) bằng factory
            // Nó cần LoginController VÀ một "hàm" (Func) để tạo QuanLiBanHang
            services.AddTransient<LoginForm>(provider =>
            {
                var loginController = provider.GetRequiredService<LoginController>();
                Func<QuanLiBanHang> mainFormFactory = () => provider.GetRequiredService<QuanLiBanHang>();

                // Tiêm 3 thứ vào constructor của LoginForm
                return new LoginForm(
                    loginController,
                    mainFormFactory,
                    provider // <== THÊM DÒNG NÀY
                );
            });
            // --- KẾT THÚC THAY ĐỔI ---


            // Đăng ký các Form/UC còn lại của Dev1
            //services.AddTransient<ucProfile>();
            //services.AddTransient<ucEmployeeManagement>();
            //services.AddTransient<EmployeeEditForm>();
            services.AddTransient<ForgotPasswordForm>();

            // Đăng ký các Form/UC của Dev6
            //services.AddTransient<frmHoaDonNhapDetail>();
            //services.AddTransient<ucHoaDonNhapList>();
        }
    }
}