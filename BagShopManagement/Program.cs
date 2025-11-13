// --- Các using của Dev2, 3, 4, 6 (Từ file cơ sở) ---
using BagShopManagement.Controllers;
using BagShopManagement.Repositories.Implementations;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using BagShopManagement.Utils;
using BagShopManagement.Views.Common;
using BagShopManagement.Views.Controls;
using BagShopManagement.Views.Dev2;
using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;
using BagShopManagement.Views.Dev4.Dev4_POS;
using BagShopManagement.Views.Dev4;
using BagShopManagement.Views.Dev6;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using BagShopManagement.Views.Dev3;

// --- Using Bổ sung cho Dev1 (từ Snippet 2) ---
using BagShopManagement.Views; // Cần cho LoginForm
using BagShopManagement.Views.Dev1; // Cần cho Forms/UCs của Dev1

namespace BagShopManagement
{
    internal static class Program
    {
        [STAThread]
        // === HÀM MAIN() ĐÃ CẬP NHẬT THEO DEV1 (Login-First) ===
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            // Dùng 'using' và 'try-catch' để quản lý lỗi
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

        // === HÀM CONFIGURESERVICES ĐÃ HỢP NHẤT ===
        private static void ConfigureServices(IServiceCollection services)
        {
            // === Cung cấp IServiceProvider (Bổ sung từ Dev1) ===
            services.AddSingleton<IServiceProvider>(sp => sp.CreateScope().ServiceProvider);

            // === Đăng ký Repositories - Dev2 (Giữ nguyên) ===
            services.AddTransient<ILoaiTuiRepository, LoaiTuiRepository>();
            services.AddTransient<IChatLieuRepository, ChatLieuRepository>();
            services.AddTransient<IDanhMucRepository, DanhMucRepository>();
            services.AddTransient<IKichThuocRepository, KichThuocRepository>();
            services.AddTransient<IMauSacRepository, MauSacRepository>();
            services.AddTransient<IThuongHieuRepository, ThuongHieuRepository>();

            // === Đăng ký Repositories - Dev3 (Giữ nguyên) ===
            services.AddTransient<IKhachHangRepository, KhachHangRepository>();

            // === Đăng ký Repositories - Dev4 (Giữ nguyên) ===
            services.AddTransient<ISanPhamRepository, SanPhamRepository>();
            services.AddTransient<IHoaDonBanRepository, HoaDonBanRepository>();

            // === Đăng ký Repositories - Dev6 (Giữ nguyên) ===
            services.AddTransient<IHoaDonNhapRepository, HoaDonNhapRepository>();
            services.AddTransient<IChiTietHDNRepository, ChiTietHDNRepository>();
            services.AddTransient<INhaCungCapRepository, NhaCungCapRepository>();
            services.AddTransient<IBaoCaoRepository, BaoCaoRepository>();

            // === Đăng ký Repositories - Dev1 (Bổ sung và Thay thế) ===
            services.AddTransient<INhanVienRepository, NhanVienImpl>(); // <-- Thay thế NhanVienRepository bằng NhanVienImpl
            services.AddTransient<ITaiKhoanRepository, TaiKhoanImpl>();
            services.AddTransient<IQuyenRepository, QuyenImpl>();
            services.AddTransient<IVaiTroRepository, VaiTroImpl>();

            // === Đăng ký Services - Dev2 (Giữ nguyên) ===
            services.AddTransient<ILoaiTuiService, LoaiTuiService>();
            services.AddTransient<IChatLieuService, ChatLieuService>();
            services.AddTransient<IDanhMucService, DanhMucService>();
            services.AddTransient<IKichThuocService, KichThuocService>();
            services.AddTransient<IMauSacService, MauSacService>();
            services.AddTransient<IThuongHieuService, ThuongHieuService>();
            services.AddTransient<ISanPhamService, SanPhamService>();
            services.AddTransient<INhaCungCapService, NhaCungCapService>();

            // === Đăng ký Services - Dev3 (Giữ nguyên) ===
            services.AddTransient<IKhachHangService, KhachHangService>();

            // === Đăng ký Services - Dev4 (Giữ nguyên) ===
            services.AddTransient<IHoaDonBanService, HoaDonBanService>();
            services.AddTransient<ITonKhoService, TonKhoService>();
            services.AddTransient<IPosService, PosService>();

            // === Đăng ký Services - Dev6 (Giữ nguyên) ===
            services.AddTransient<IHoaDonNhapService, HoaDonNhapService>();
            services.AddTransient<IBaoCaoService, BaoCaoService>();

            // === Đăng ký Services - Dev1 (Bổ sung) ===
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<INhanVienService, NhanVienService>();
            services.AddTransient<IEmailService, FakeEmailService>(); // Dùng FakeEmailService

            // === Đăng ký Controllers (Giữ nguyên Dev2, 3, 4, 6) ===
            services.AddTransient<KhachHangController>();
            services.AddTransient<NhaCungCapController>();
            services.AddTransient<POSController>();
            services.AddTransient<HoaDonBanController>();
            services.AddTransient<HoaDonNhapController>();
            services.AddTransient<BaoCaoController>();
            services.AddTransient<ChatLieuController>();
            services.AddTransient<KichThuocController>();
            services.AddTransient<LoaiTuiController>();
            services.AddTransient<MauSacController>();
            services.AddTransient<SanPhamController>();
            services.AddTransient<ThuongHieuController>();

            // === Đăng ký Controllers - Dev1 (Bổ sung) ===
            services.AddTransient<LoginController>();
            services.AddTransient<NhanVienController>();
            services.AddTransient<ProfileController>();

            // === Đăng ký Utils (Giữ nguyên) ===
            services.AddTransient(sp => new MaHoaDonGenerator("HDN", 3));

            // === Đăng ký Forms và UserControls ===

            // (Thay thế 'AddTransient<QuanLiBanHang>()' bằng Factory của Dev1)
            services.AddTransient<QuanLiBanHang>(provider =>
            {
                return new QuanLiBanHang(
                    provider.GetRequiredService<IServiceProvider>()
                );
            });

            // (Bổ sung Factory cho LoginForm của Dev1)
            services.AddTransient<LoginForm>(provider =>
            {
                return new LoginForm(
                    provider.GetRequiredService<LoginController>(),
                    () => provider.GetRequiredService<QuanLiBanHang>(),
                    provider
                );
            });

            // (Giữ nguyên các đăng ký Forms/UCs của Dev2, 3, 4, 6)
            services.AddTransient<SideBarControl>();
            services.AddTransient<ChatLieuControl>();
            services.AddTransient<ChatLieuEditForm>();
            services.AddTransient<DanhMucMenuControl>();
            services.AddTransient<KichThuocControl>();
            services.AddTransient<KichThuocEditForm>();
            services.AddTransient<LoaiTuiControl>();
            services.AddTransient<LoaiTuiEditForm>();
            services.AddTransient<MauSacControl>();
            services.AddTransient<MauSacEditForm>();
            services.AddTransient<SanPhamControl>();
            services.AddTransient<SanPhamDetailForm>();
            services.AddTransient<SanPhamEditForm>();
            services.AddTransient<ThuongHieuControl>();
            services.AddTransient<ThuongHieuEditForm>();
            services.AddTransient<KhachHangControl>();
            services.AddTransient<NhaCungCapControl>();
            services.AddTransient<Views.Dev3.ThemKhachHangForm2>();
            services.AddTransient<ThemNhaCungCapForm>();
            services.AddTransient<POSForm>();
            services.AddTransient<HoaDonBanForm>();
            services.AddTransient<UC_POS>();
            services.AddTransient<UC_HoaDonBan>();
            services.AddTransient<frmHoaDonNhapDetail>();
            services.AddTransient<ucHoaDonNhapList>();
            services.AddTransient<ucBaoCaoThongKe>();

            // (Bổ sung các Forms/UCs của Dev1)
            services.AddTransient<ForgotPasswordForm>();
            services.AddTransient<EmployeeEditForm>();
            services.AddTransient<ucProfile>();
            services.AddTransient<ucEmployeeManagement>();
        }
    }
}