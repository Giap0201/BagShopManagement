using BagShopManagement.Models;
using BagShopManagement.Repositories;
using BagShopManagement.Repositories.Implementations;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BagShopManagement.Views.Dev2
{
    public partial class SanPhamDetailForm : Form
    {
        private readonly SanPham _sp;

        private readonly LoaiTuiRepository _loaiTuiRepo = new LoaiTuiRepository();
        private readonly ThuongHieuRepository _thuongHieuRepo = new ThuongHieuRepository();
        private readonly ChatLieuRepository _chatLieuRepo = new ChatLieuRepository();
        private readonly MauSacRepository _mauRepo = new MauSacRepository();
        private readonly KichThuocRepository _kichThuocRepo = new KichThuocRepository();
        private readonly NhaCungCapRepository _nccRepo = new NhaCungCapRepository();

        public SanPhamDetailForm(SanPham sp)
        {
            InitializeComponent();
            _sp = sp;
        }

        private void SanPhamDetailForm_Load(object sender, EventArgs e)
        {
            if (_sp == null)
            {
                MessageBox.Show("Không có dữ liệu sản phẩm để hiển thị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // --- Gán giá trị ---
            txtMaSP.Text = _sp.MaSP;
            txtTenSP.Text = _sp.TenSP;
            txtGiaNhap.Text = _sp.GiaNhap.ToString("N0");
            txtGiaBan.Text = _sp.GiaBan.ToString("N0");
            txtSoLuong.Text = _sp.SoLuongTon.ToString();
            txtMoTa.Text = _sp.MoTa ?? "";

            txtLoaiTui.Text = _loaiTuiRepo.GetById(_sp.MaLoaiTui)?.TenLoaiTui ?? "(Không xác định)";
            txtThuongHieu.Text = _thuongHieuRepo.GetById(_sp.MaThuongHieu)?.TenThuongHieu ?? "(Không xác định)";
            txtChatLieu.Text = _chatLieuRepo.GetById(_sp.MaChatLieu)?.TenChatLieu ?? "(Không xác định)";
            txtMau.Text = _mauRepo.GetById(_sp.MaMau)?.TenMau ?? "(Không xác định)";
            txtKichThuoc.Text = _kichThuocRepo.GetById(_sp.MaKichThuoc)?.TenKichThuoc ?? "(Không xác định)";
            txtNCC.Text = _nccRepo.GetById(_sp.MaNCC)?.TenNCC ?? "(Không xác định)";

            txtTrangThai.Text = _sp.TrangThai ? "Đang kinh doanh" : "Ngừng kinh doanh";
            txtNgayTao.Text = _sp.NgayTao.ToString("dd/MM/yyyy HH:mm");

            // --- Ảnh ---
            try
            {
                if (!string.IsNullOrEmpty(_sp.AnhChinh))
                {
                    string imagePath = Path.Combine(Application.StartupPath, "Resources", "AnhSanPham", _sp.AnhChinh);
                    if (File.Exists(imagePath))
                    {
                        using (var bmpTemp = new Bitmap(imagePath))
                        {
                            picAnhChinh.Image = new Bitmap(bmpTemp);
                        }
                    }
                    else
                    {
                        picAnhChinh.Image = Properties.Resources.no_image;
                    }
                }
                else
                {
                    picAnhChinh.Image = Properties.Resources.no_image;
                }
            }
            catch
            {
                picAnhChinh.Image = Properties.Resources.no_image;
            }

            picAnhChinh.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
