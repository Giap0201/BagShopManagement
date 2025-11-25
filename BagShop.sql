-- ======================================
-- BAG STORE DATABASE - VERSION 2.0 (NO IDENTITY)
-- Description: Schema for BagStore Desktop Management System
-- ======================================

--CREATE DATABASE BagStoreDB;
--GO
--USE BagStoreDB;
--GO

-- =========================
-- 1. DANH MỤC CƠ BẢN
-- =========================
CREATE TABLE DanhMucLoaiTui (
    MaLoaiTui VARCHAR(10) PRIMARY KEY, -- LT001
    TenLoaiTui NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);

CREATE TABLE ThuongHieu (
    MaThuongHieu VARCHAR(10) PRIMARY KEY, -- TH001
    TenThuongHieu NVARCHAR(100) NOT NULL,
    QuocGia NVARCHAR(100)
);

CREATE TABLE ChatLieu (
    MaChatLieu VARCHAR(10) PRIMARY KEY, -- CL001
    TenChatLieu NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);

CREATE TABLE MauSac (
    MaMau VARCHAR(10) PRIMARY KEY, -- MS001
    TenMau NVARCHAR(50) NOT NULL
);

CREATE TABLE KichThuoc (
    MaKichThuoc VARCHAR(10) PRIMARY KEY, -- KT001
    TenKichThuoc NVARCHAR(50) NOT NULL,
    ChieuDai DECIMAL(5,2),
    ChieuRong DECIMAL(5,2),
    ChieuCao DECIMAL(5,2)
);
CREATE TABLE NhaCungCap (
    MaNCC VARCHAR(10) PRIMARY KEY, -- NCC001
    TenNCC NVARCHAR(150) NOT NULL,
    DiaChi NVARCHAR(200),
    SoDienThoai VARCHAR(15),
    Email NVARCHAR(100),
    NguoiLienHe NVARCHAR(100)
);
-- =========================
-- 2. SẢN PHẨM
-- =========================
CREATE TABLE SanPham (
    MaSP VARCHAR(10) PRIMARY KEY, -- SP001
    TenSP NVARCHAR(150) NOT NULL,
    GiaNhap DECIMAL(18,2) NOT NULL,
    GiaBan DECIMAL(18,2) NOT NULL,
    SoLuongTon INT DEFAULT 0,
    MoTa NVARCHAR(500),
    AnhChinh VARCHAR(500),
    MaLoaiTui VARCHAR(10) NULL,
    MaThuongHieu VARCHAR(10) NULL,
    MaChatLieu VARCHAR(10) NULL,
    MaMau VARCHAR(10) NULL,
    MaKichThuoc VARCHAR(10) NULL,
    MaNCC VARCHAR(10) NULL, -- Nhà cung cấp mặc định
    TrangThai BIT DEFAULT 1, -- 1: Hoạt động, 0: Ngừng bán
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaLoaiTui) REFERENCES DanhMucLoaiTui(MaLoaiTui),
    FOREIGN KEY (MaThuongHieu) REFERENCES ThuongHieu(MaThuongHieu),
    FOREIGN KEY (MaChatLieu) REFERENCES ChatLieu(MaChatLieu),
    FOREIGN KEY (MaMau) REFERENCES MauSac(MaMau),
    FOREIGN KEY (MaKichThuoc) REFERENCES KichThuoc(MaKichThuoc),
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);

-- =========================
-- 3. KHÁCH HÀNG, NHÂN VIÊN, NHÀ CUNG CẤP
-- =========================
CREATE TABLE KhachHang (
    MaKH VARCHAR(10) PRIMARY KEY, -- KH001
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(200),
    DiemTichLuy INT DEFAULT 0 -- Điểm tích lũy
);

CREATE TABLE NhanVien (
    MaNV VARCHAR(10) PRIMARY KEY, -- NV001
    HoTen NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50),
    SoDienThoai VARCHAR(15),
    Email NVARCHAR(100),
    MatKhau NVARCHAR(50) NOT NULL, -- Mật khẩu đơn giản
    NgayVaoLam DATETIME DEFAULT GETDATE(),
    TrangThai BIT DEFAULT 1 -- 1: Hoạt động, 0: Nghỉ
);



-- =========================
-- 4. HÓA ĐƠN NHẬP & BÁN
-- =========================
CREATE TABLE HoaDonNhap (
    MaHDN VARCHAR(20) PRIMARY KEY, -- HDN001
    MaNCC VARCHAR(10) NOT NULL,
    MaNV VARCHAR(10) NOT NULL,
    NgayNhap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,2) DEFAULT 0,
    GhiChu NVARCHAR(500),
    NgayDuyet DATETIME ,
    NgayHuy DATETIME ,
    TrangThai TINYINT,
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietHoaDonNhap (
    MaHDN VARCHAR(20),
    MaSP VARCHAR(10),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    ThanhTien DECIMAL(18,2) ,
    PRIMARY KEY (MaHDN, MaSP),
    FOREIGN KEY (MaHDN) REFERENCES HoaDonNhap(MaHDN) ON DELETE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

CREATE TABLE HoaDonBan (
    MaHDB VARCHAR(10) PRIMARY KEY, -- HDB001
    MaKH VARCHAR(10) NULL, -- Khách lẻ có thể NULL
    MaNV VARCHAR(10) NOT NULL,
    NgayBan DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,2) DEFAULT 0,
    PhuongThucTT NVARCHAR(50), -- Tiền mặt, chuyển khoản, thẻ
    GhiChu NVARCHAR(500),
    TrangThaiHD TINYINT DEFAULT 0, -- 0: Chờ, 1: Hoàn thành, 2: Hủy
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietHoaDonBan (
    MaHDB VARCHAR(10),
    MaSP VARCHAR(10),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    GiamGiaSP DECIMAL(18,2) DEFAULT 0, -- Giảm giá từng sản phẩm
    PRIMARY KEY (MaHDB, MaSP),
    FOREIGN KEY (MaHDB) REFERENCES HoaDonBan(MaHDB) ON DELETE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

-- =========================
-- 5. CHƯƠNG TRÌNH GIẢM GIÁ
-- =========================
CREATE TABLE ChuongTrinhGiamGia (
    MaCTGG VARCHAR(10) PRIMARY KEY, -- GG001
    TenChuongTrinh NVARCHAR(150) NOT NULL,
    NgayBatDau DATETIME NOT NULL,
    NgayKetThuc DATETIME NOT NULL,
    MoTa NVARCHAR(255),
    TrangThai BIT DEFAULT 1 -- 1: Đang áp dụng, 0: Hết hạn
);

CREATE TABLE ChiTietGiamGia (
    MaCTGG VARCHAR(10),
    MaSP VARCHAR(10),
    PhanTramGiam INT CHECK (PhanTramGiam BETWEEN 0 AND 100),
    PRIMARY KEY (MaCTGG, MaSP),
    FOREIGN KEY (MaCTGG) REFERENCES ChuongTrinhGiamGia(MaCTGG) ON DELETE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
-- =========================
-- 6. HỆ THỐNG PHÂN QUYỀN (AUTH & PERMISSIONS)
-- =========================

CREATE TABLE VaiTro (
    MaVaiTro VARCHAR(10) PRIMARY KEY, -- VT001
    TenVaiTro NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);

CREATE TABLE Quyen (
    MaQuyen VARCHAR(10) PRIMARY KEY, -- Q001
    TenQuyen NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);

CREATE TABLE VaiTro_Quyen (
    MaVaiTro VARCHAR(10),
    MaQuyen VARCHAR(10),
    PRIMARY KEY (MaVaiTro, MaQuyen),
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro) ON DELETE CASCADE,
    FOREIGN KEY (MaQuyen) REFERENCES Quyen(MaQuyen) ON DELETE CASCADE
);

CREATE TABLE TaiKhoan (
    TenDangNhap VARCHAR(50) PRIMARY KEY, -- admin
    MatKhau NVARCHAR(100) NOT NULL,
    MaNV VARCHAR(10) NULL,
    MaVaiTro VARCHAR(10) NULL,
    TrangThai BIT DEFAULT 1, -- 1: hoạt động, 0: khóa
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro)
);




-- =========================
-- DỮ LIỆU MẪU (SEEDING DATA)
-- =========================

-- DanhMucLoaiTui
INSERT INTO DanhMucLoaiTui (MaLoaiTui, TenLoaiTui, MoTa) VALUES
('LT001', N'Túi xách tay', N'Túi cầm tay thời trang cho nữ'),
('LT002', N'Túi đeo chéo', N'Túi đeo vai tiện lợi'),
('LT003', N'Balo', N'Balo học sinh, nhân viên văn phòng'),
('LT004', N'Túi tote', N'Túi vải đi chợ hoặc đi chơi'),
('LT005', N'Ví cầm tay', N'Ví nhỏ gọn đựng tiền');

-- ThuongHieu
INSERT INTO ThuongHieu (MaThuongHieu, TenThuongHieu, QuocGia) VALUES
('TH001', N'Gucci', N'Ý'),
('TH002', N'Chanel', N'Pháp'),
('TH003', N'MCM', N'Đức'),
('TH004', N'Charles & Keith', N'Singapore'),
('TH005', N'Anello', N'Nhật Bản');

-- ChatLieu
INSERT INTO ChatLieu (MaChatLieu, TenChatLieu, MoTa) VALUES
('CL001', N'Da thật', N'Bền, sang trọng'),
('CL002', N'Da PU', N'Giá rẻ, nhẹ'),
('CL003', N'Vải Canvas', N'Bền, chống nước'),
('CL004', N'Vải Nylon', N'Nhẹ, chống bẩn'),
('CL005', N'Vải Polyester', N'Đa dụng, giá rẻ');

-- MauSac
INSERT INTO MauSac (MaMau, TenMau) VALUES
('MS001', N'Đen'),
('MS002', N'Nâu'),
('MS003', N'Trắng'),
('MS004', N'Xanh dương'),
('MS005', N'Hồng phấn');

-- KichThuoc
INSERT INTO KichThuoc (MaKichThuoc, TenKichThuoc, ChieuDai, ChieuRong, ChieuCao) VALUES
('KT001', N'Nhỏ', 20.00, 10.00, 15.00),
('KT002', N'Trung bình', 30.00, 15.00, 20.00),
('KT003', N'Lớn', 40.00, 20.00, 25.00),
('KT004', N'Cực lớn', 50.00, 25.00, 30.00),
('KT005', N'Mini', 15.00, 8.00, 10.00);

-- NhaCungCap
INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SoDienThoai, Email, NguoiLienHe) VALUES
('NCC001', N'Công ty Da Thật ABC', N'123 Lê Lợi, TP.HCM', '0901234567', 'abc@company.com', N'Nguyễn Văn T'),
('NCC002', N'Nhà phân phối Gucci VN', N'45 Nguyễn Huệ, TP.HCM', '0902345678', 'gucci@vn.com', N'Trần Thị H'),
('NCC003', N'Công ty Vải XYZ', N'789 Trần Hưng Đạo, Hà Nội', '0913456789', 'xyz@company.com', N'Lê Văn K'),
('NCC004', N'Đại lý Anello', N'56 Hai Bà Trưng, Đà Nẵng', '0908765432', 'anello@vn.com', N'Phạm Thị M'),
('NCC005', N'CTy Thời Trang Z', N'12 Phạm Ngọc Thạch, TP.HCM', '0932145678', 'z@company.com', N'Hoàng Văn P');

-- NhanVien
INSERT INTO NhanVien (MaNV, HoTen, ChucVu, SoDienThoai, Email, MatKhau, TrangThai) VALUES
('NV001', N'Nguyễn Văn An', N'Quản lý', '0912345678', 'an@bagstore.com', 'password123', 1),
('NV002', N'Trần Thị Bình', N'Nhân viên bán hàng', '0923456789', 'binh@bagstore.com', 'password456', 1),
('NV003', N'Lê Văn Cường', N'Nhân viên kho', '0934567890', 'cuong@bagstore.com', 'password789', 1),
('NV004', N'Phạm Thị Dung', N'Kế toán', '0945678901', 'dung@bagstore.com', 'password101', 1),
('NV005', N'Hoàng Văn Em', N'Nhân viên bán hàng', '0956789012', 'em@bagstore.com', 'password202', 1);

-- KhachHang
INSERT INTO KhachHang (MaKH, HoTen, SoDienThoai, Email, DiaChi, DiemTichLuy) VALUES
('KH001', N'Lê Thị Cẩm', '0987654321', 'cam@gmail.com', N'123 Nguyễn Trãi, TP.HCM', 100),
('KH002', N'Phạm Văn Đức', '0976543210', 'duc@gmail.com', N'456 Láng Hạ, Hà Nội', 50),
('KH003', N'Trần Thị Hoa', '0965432109', 'hoa@gmail.com', N'789 Lê Duẩn, Đà Nẵng', 200),
('KH004', N'Nguyễn Văn Hùng', '0954321098', 'hung@gmail.com', N'12 Trần Phú, Huế', 0),
('KH005', N'Võ Thị Lan', '0943210987', 'lan@gmail.com', N'34 Hai Bà Trưng, TP.HCM', 150);

-- SanPham
INSERT INTO SanPham (MaSP, TenSP, GiaNhap, GiaBan, SoLuongTon, MoTa, MaLoaiTui, MaThuongHieu, MaChatLieu, MaMau, MaKichThuoc, MaNCC, TrangThai) VALUES
('SP001', N'Túi xách da thật Gucci', 1500000.00, 3000000.00, 10, N'Túi cao cấp nhập khẩu', 'LT001', 'TH001', 'CL001', 'MS001', 'KT002', 'NCC001', 1),
('SP002', N'Balo MCM Canvas', 800000.00, 1500000.00, 25, N'Balo thời trang cho giới trẻ', 'LT003', 'TH003', 'CL003', 'MS004', 'KT003', 'NCC002', 1),
('SP003', N'Túi đeo chéo Chanel', 2000000.00, 4000000.00, 5, N'Túi sang trọng cho sự kiện', 'LT002', 'TH002', 'CL001', 'MS002', 'KT001', 'NCC001', 1),
('SP004', N'Ví cầm tay Anello', 300000.00, 600000.00, 50, N'Ví nhỏ gọn tiện lợi', 'LT005', 'TH005', 'CL004', 'MS005', 'KT005', 'NCC004', 1),
('SP005', N'Túi tote Charles & Keith', 500000.00, 1000000.00, 20, N'Túi vải thời trang', 'LT004', 'TH004', 'CL003', 'MS003', 'KT004', 'NCC003', 1),
('SP006', N'Túi xách da PU Gucci', 700000.00, 1400000.00, 15, N'Túi giá rẻ nhưng sang trọng', 'LT001', 'TH001', 'CL002', 'MS001', 'KT002', 'NCC001', 1),
('SP007', N'Balo Anello Nylon', 400000.00, 800000.00, 30, N'Balo nhẹ, chống nước', 'LT003', 'TH005', 'CL004', 'MS004', 'KT003', 'NCC004', 1),
('SP008', N'Túi đeo chéo MCM', 900000.00, 1800000.00, 10, N'Túi đeo thời thượng', 'LT002', 'TH003', 'CL003', 'MS002', 'KT002', 'NCC002', 1);

-- ChuongTrinhGiamGia
INSERT INTO ChuongTrinhGiamGia (MaCTGG, TenChuongTrinh, NgayBatDau, NgayKetThuc, MoTa, TrangThai) VALUES
('GG001', N'Black Friday 2025', '2025-11-28', '2025-11-30', N'Giảm giá toàn bộ sản phẩm', 1),
('GG002', N'Tết Nguyên Đán 2026', '2026-01-25', '2026-02-05', N'Khuyến mãi đầu năm', 1),
('GG003', N'Sale Hè 2025', '2025-06-01', '2025-06-30', N'Giảm giá balo và túi vải', 1);

-- ChiTietGiamGia
INSERT INTO ChiTietGiamGia (MaCTGG, MaSP, PhanTramGiam) VALUES
('GG001', 'SP001', 20),
('GG001', 'SP002', 15),
('GG002', 'SP003', 30),
('GG002', 'SP004', 10),
('GG003', 'SP005', 25),
('GG003', 'SP007', 20);

-- HoaDonNhap
INSERT INTO HoaDonNhap (MaHDN, MaNCC, MaNV, NgayNhap, TongTien, GhiChu) VALUES
('HDN001', 'NCC001', 'NV001', '2025-10-01', 15000000.00, N'Nhập lô túi Gucci'),
('HDN002', 'NCC002', 'NV002', '2025-10-05', 20000000.00, N'Nhập balo MCM'),
('HDN003', 'NCC003', 'NV003', '2025-10-10', 5000000.00, N'Nhập túi vải'),
('HDN004', 'NCC004', 'NV001', '2025-10-15', 3000000.00, N'Nhập ví Anello'),
('HDN005', 'NCC005', 'NV002', '2025-10-20', 10000000.00, N'Nhập túi Charles & Keith');

-- ChiTietHoaDonNhap
INSERT INTO ChiTietHoaDonNhap (MaHDN, MaSP, SoLuong, DonGia) VALUES
('HDN001', 'SP001', 10, 1500000.00),
('HDN001', 'SP003', 5, 2000000.00),
('HDN002', 'SP002', 25, 800000.00),
('HDN003', 'SP005', 20, 500000.00),
('HDN004', 'SP004', 50, 300000.00),
('HDN005', 'SP005', 20, 500000.00);

-- HoaDonBan
INSERT INTO HoaDonBan (MaHDB, MaKH, MaNV, NgayBan, TongTien, PhuongThucTT, TrangThaiHD, GhiChu) VALUES
('HDB001', 'KH001', 'NV002', '2025-10-10', 3000000.00, N'Tiền mặt', 1, N'Khách VIP'),
('HDB002', 'KH002', 'NV003', '2025-10-12', 1500000.00, N'Chuyển khoản', 1, N'Khách lẻ'),
('HDB003', NULL, 'NV001', '2025-10-15', 600000.00, N'Thẻ', 1, N'Khách vãng lai'),
('HDB004', 'KH003', 'NV002', '2025-10-18', 4000000.00, N'Tiền mặt', 1, N'Khách VIP'),
('HDB005', 'KH004', 'NV004', '2025-10-20', 1800000.00, N'Chuyển khoản', 1, N'Đơn hàng online');

-- ChiTietHoaDonBan
INSERT INTO ChiTietHoaDonBan (MaHDB, MaSP, SoLuong, DonGia, GiamGiaSP) VALUES
('HDB001', 'SP001', 1, 3000000.00, 0),
('HDB002', 'SP002', 1, 1500000.00, 0),
('HDB003', 'SP004', 1, 600000.00, 0),
('HDB004', 'SP003', 1, 4000000.00, 0),
('HDB005', 'SP002', 1, 1500000.00, 15);

-- =========================
-- KẾT THÚC
-- =========================
PRINT '✅ SEEDING DATA HOÀN THÀNH!';

-- =========================
-- 7. DỮ LIỆU MẪU PHÂN QUYỀN
-- =========================

-- VaiTro
INSERT INTO VaiTro (MaVaiTro, TenVaiTro, MoTa) VALUES
('VT001', N'Quản trị viên', N'Quản lý toàn bộ hệ thống'),
('VT002', N'Nhân viên bán hàng', N'Quản lý bán hàng, hóa đơn, khách hàng'),
('VT003', N'Nhân viên kho', N'Quản lý nhập hàng và tồn kho');

-- Quyen
INSERT INTO Quyen (MaQuyen, TenQuyen, MoTa) VALUES
('Q001', N'Quản lý sản phẩm', N'Tạo, sửa, xóa và xem sản phẩm'),
('Q002', N'Quản lý hóa đơn', N'Tạo và xử lý hóa đơn bán hàng'),
('Q003', N'Quản lý nhập hàng', N'Tạo phiếu nhập và cập nhật tồn kho'),
('Q004', N'Quản lý khách hàng', N'Thêm, sửa, xóa khách hàng'),
('Q005', N'Quản lý nhân viên', N'Thêm, sửa, phân quyền nhân viên'),
('Q006', N'Xem báo cáo', N'Truy cập báo cáo doanh thu và kho hàng');

-- VaiTro_Quyen
INSERT INTO VaiTro_Quyen (MaVaiTro, MaQuyen) VALUES
-- Quản trị viên có tất cả quyền
('VT001', 'Q001'),
('VT001', 'Q002'),
('VT001', 'Q003'),
('VT001', 'Q004'),
('VT001', 'Q005'),
('VT001', 'Q006'),
-- Nhân viên bán hàng
('VT002', 'Q001'),
('VT002', 'Q002'),
('VT002', 'Q004'),
-- Nhân viên kho
('VT003', 'Q001'),
('VT003', 'Q003');

-- Tài khoản người dùng
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNV, MaVaiTro, TrangThai) VALUES
('admin', 'admin123', 'NV001', 'VT001', 1),
('binh_nv', '123456', 'NV002', 'VT002', 1),
('cuong_kho', '123456', 'NV003', 'VT003', 1);

-- =========================
-- 8. CẬP NHẬT ẢNH SẢN PHẨM (THÊM ANHCHINH)
-- =========================

UPDATE SanPham SET AnhChinh = 'images/sp001.jpg' WHERE MaSP = 'SP001';
UPDATE SanPham SET AnhChinh = 'images/sp002.jpg' WHERE MaSP = 'SP002';
UPDATE SanPham SET AnhChinh = 'images/sp003.jpg' WHERE MaSP = 'SP003';
UPDATE SanPham SET AnhChinh = 'images/sp004.jpg' WHERE MaSP = 'SP004';
UPDATE SanPham SET AnhChinh = 'images/sp005.jpg' WHERE MaSP = 'SP005';
UPDATE SanPham SET AnhChinh = 'images/sp006.jpg' WHERE MaSP = 'SP006';
UPDATE SanPham SET AnhChinh = 'images/sp007.jpg' WHERE MaSP = 'SP007';
UPDATE SanPham SET AnhChinh = 'images/sp008.jpg' WHERE MaSP = 'SP008';

-- =========================
-- 9. KẾT THÚC TOÀN BỘ DATABASE
-- =========================
PRINT '✅ BAG STORE DATABASE VERSION 2.0 - FULL PERMISSIONS CREATED SUCCESSFULLY!';
GO