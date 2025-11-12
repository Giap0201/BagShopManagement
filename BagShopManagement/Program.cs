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
            // === Đăng ký Repositories - Dev2 ===
            services.AddTransient<ILoaiTuiRepository, LoaiTuiRepository>();
            services.AddTransient<IChatLieuRepository, ChatLieuRepository>();
            services.AddTransient<IDanhMucRepository, DanhMucRepository>();
            services.AddTransient<IKichThuocRepository, KichThuocRepository>();
            services.AddTransient<IMauSacRepository, MauSacRepository>();
            services.AddTransient<IThuongHieuRepository, ThuongHieuRepository>();

            // === Đăng ký Repositories - Dev4 ===
            services.AddTransient<ISanPhamRepository, SanPhamRepository>();
            services.AddTransient<IHoaDonBanRepository, HoaDonBanRepository>();

            // === Đăng ký Repositories - Dev6 ===
            services.AddTransient<IHoaDonNhapRepository, HoaDonNhapRepository>();
            services.AddTransient<IChiTietHDNRepository, ChiTietHDNRepository>();
            services.AddTransient<INhaCungCapRepository, NhaCungCapRepository>();
            services.AddTransient<INhanVienRepository, NhanVienRepository>();
            services.AddTransient<IBaoCaoRepository, BaoCaoRepository>();

            // === Đăng ký Services - Dev2 ===
            services.AddTransient<ILoaiTuiService, LoaiTuiService>();
            services.AddTransient<IChatLieuService, ChatLieuService>();
            services.AddTransient<IDanhMucService, DanhMucService>();
            services.AddTransient<IKichThuocService, KichThuocService>();
            services.AddTransient<IMauSacService, MauSacService>();
            services.AddTransient<IThuongHieuService, ThuongHieuService>();
            services.AddTransient<ISanPhamService, SanPhamService>();
            services.AddTransient<INhaCungCapService, NhaCungCapService>();

            // === Đăng ký Services - Dev4 ===
            services.AddTransient<IHoaDonBanService, HoaDonBanService>();
            services.AddTransient<ITonKhoService, TonKhoService>();
            services.AddTransient<IPosService, PosService>();

            // === Đăng ký Services - Dev6 ===
            services.AddTransient<IHoaDonNhapService, HoaDonNhapService>();
            services.AddTransient<IBaoCaoService, BaoCaoService>();

            // === Đăng ký Controllers ===
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

            // === Đăng ký Utils ===
            services.AddTransient(sp => new MaHoaDonGenerator("HDN", 3));

            // === Đăng ký Forms và UserControls ===
            services.AddTransient<QuanLiBanHang>();  // Form chính
            services.AddTransient<SideBarControl>(); // Thanh bên

            // Dev2 Forms
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

            // Dev4 Forms
            services.AddTransient<POSForm>();
            services.AddTransient<HoaDonBanForm>();
            services.AddTransient<UC_POS>();

            // Dev6 Forms
            services.AddTransient<frmHoaDonNhapDetail>();
            services.AddTransient<ucHoaDonNhapList>();
            services.AddTransient<ucBaoCaoThongKe>();
        }
    }
}