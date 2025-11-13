# Dev4 - Quản lý Bán hàng & Hóa đơn (User Control Version)

## 📋 Tổng quan

Đã chuyển đổi thành công từ Windows Form sang User Control cho module Dev4, bao gồm:

- ✅ **UC_POS**: User Control cho chức năng bán hàng tại quầy (Point of Sale)
- ✅ **UC_HoaDonBan**: User Control cho quản lý danh sách hóa đơn
- ✅ **ChiTietHoaDonForm**: Dialog Form xem chi tiết hóa đơn (giữ nguyên Form)
- ✅ **HoaDonBanEditForm**: Dialog Form sửa hóa đơn (giữ nguyên Form)

---

## 1️⃣ UC_POS - Bán hàng tại quầy

### 📁 Files

- `Views/Dev4/UC_POS.cs`
- `Views/Dev4/UC_POS.Designer.cs`
- `Views/Dev4/UC_POS.resx`

### ✨ Chức năng đã implement

#### ✅ Tạo hóa đơn (Ưu tiên: CAO)

- [x] Chọn khách hàng (hoặc khách lẻ)
- [x] Thêm sản phẩm vào giỏ hàng
- [x] Tìm kiếm sản phẩm nhanh theo mã
- [x] Nhập số lượng, tự động tính tiền
- [x] Áp dụng giảm giá cho từng sản phẩm
- [x] Lưu hóa đơn tạm (TrangThaiHD = 1)
- [x] Hoàn thành thanh toán (TrangThaiHD = 2)

#### ✅ Cập nhật kho (Ưu tiên: CAO)

- [x] Kiểm tra tồn kho trước khi thêm vào giỏ
- [x] Cảnh báo sản phẩm sắp hết hàng (≤ 10)
- [x] Tự động giảm tồn kho khi thanh toán hoàn thành
- [x] Hiển thị tồn kho còn lại sau khi thêm

#### ✅ Lưu tạm hóa đơn (Ưu tiên: Trung bình)

- [x] Lưu hóa đơn chưa thanh toán (TrangThaiHD = 1)
- [x] Có thể chỉnh sửa sau bằng HoaDonBanEditForm

#### ✅ In hóa đơn (Ưu tiên: Trung bình)

- [x] Xuất hóa đơn cho khách ngay sau bán
- [x] Sử dụng InvoicePrintService

### 🎯 Cải tiến đã thêm

- **Cảnh báo tồn kho thông minh**: Hiển thị popup warning khi sản phẩm sắp hết
- **Thông báo tồn kho realtime**: Sau mỗi lần thêm sản phẩm
- **Validation tăng cường**: Kiểm tra số lượng hợp lệ, mã sản phẩm tồn tại
- **UI/UX cải thiện**: Thông báo thành công với emoji và thông tin chi tiết

---

## 2️⃣ UC_HoaDonBan - Quản lý hóa đơn

### 📁 Files

- `Views/Dev4/Dev4_HoaDonBan/UC_HoaDonBan.cs`
- `Views/Dev4/Dev4_HoaDonBan/UC_HoaDonBan.Designer.cs`
- `Views/Dev4/Dev4_HoaDonBan/UC_HoaDonBan.resx`

### ✨ Chức năng đã implement

#### ✅ Danh sách hóa đơn (Ưu tiên: CAO)

- [x] Hiển thị tất cả hóa đơn
- [x] Lọc theo ngày (từ ngày - đến ngày)
- [x] Lọc theo nhân viên (MaNV)
- [x] Lọc theo trạng thái:
  - Tạm (1)
  - Hoàn thành (2)
  - Hủy (3)
- [x] Hiển thị tổng số hóa đơn

#### ✅ Xem chi tiết hóa đơn (Ưu tiên: CAO)

- [x] Mở ChiTietHoaDonForm (Dialog)
- [x] Hiển thị sản phẩm, số lượng, giá, giảm giá, tổng tiền
- [x] Thông tin khách hàng, nhân viên, ngày bán

#### ✅ Hủy / hoàn tiền hóa đơn (Ưu tiên: CAO)

- [x] Thay đổi trạng thái hóa đơn sang "Hủy" (3)
- [x] Cập nhật tồn kho trả lại (nếu hóa đơn đã thanh toán)
- [x] Ghi log thao tác (Logger.Log)
- [x] Xác nhận trước khi hủy

#### ✅ Sửa hóa đơn (Ưu tiên: Trung bình - Admin)

- [x] Chỉ cho phép sửa hóa đơn tạm (TrangThaiHD = 1)
- [x] Mở HoaDonBanEditForm (Dialog)
- [x] Cập nhật thông tin hóa đơn và chi tiết

### 🎯 Tính năng nâng cao

- **Filter linh hoạt**: Có thể bật/tắt từng điều kiện lọc
- **Refresh dễ dàng**: Button làm mới để reset filter
- **Trạng thái rõ ràng**: Hiển thị text thay vì số (Tạm/Hoàn thành/Hủy)

---

## 3️⃣ ChiTietHoaDonForm - Xem chi tiết (Dialog)

### 📁 Files

- `Views/Dev4/Dev4_HoaDonBan/ChiTietHoaDonForm.cs`
- `Views/Dev4/Dev4_HoaDonBan/ChiTietHoaDonForm.Designer.cs`
- `Views/Dev4/Dev4_HoaDonBan/ChiTietHoaDonForm.resx`

### ✨ Chức năng

- Hiển thị thông tin header hóa đơn
- DataGridView chi tiết sản phẩm với:
  - Mã sản phẩm
  - Tên sản phẩm
  - Số lượng
  - Đơn giá
  - Giảm giá/SP
  - Thành tiền
- Tổng thành tiền (sum)
- Ghi chú (readonly)

---

## 4️⃣ HoaDonBanEditForm - Sửa hóa đơn (Dialog)

### 📁 Files

- `Views/Dev4/Dev4_HoaDonBan/HoaDonBanEditForm.cs`
- `Views/Dev4/Dev4_HoaDonBan/HoaDonBanEditForm.Designer.cs`
- `Views/Dev4/Dev4_HoaDonBan/HoaDonBanEditForm.resx`

### ✨ Chức năng

- Chỉ cho phép sửa hóa đơn tạm (TrangThaiHD = 1)
- Load dữ liệu hóa đơn vào giỏ hàng
- Thêm/xóa sản phẩm
- Áp dụng giảm giá
- Chỉnh sửa số lượng trực tiếp trên DataGridView
- Kiểm tra tồn kho khi thêm/sửa
- Lưu cập nhật với validation

---

## 🏗️ Kiến trúc & Dependencies

### Controllers

- `POSController`: Điều khiển logic POS
- `HoaDonBanController`: Quản lý hóa đơn

### Services

- `PosService`: Xử lý giỏ hàng, checkout
- `HoaDonBanService`: CRUD hóa đơn
- `TonKhoService`: Quản lý tồn kho

### Repositories

- `SanPhamRepository`: Truy vấn sản phẩm
- `HoaDonBanRepository`: Truy vấn hóa đơn

### Utils

- `Logger`: Ghi log hệ thống
- `InvoicePrintService`: In hóa đơn
- `TransactionHelper`: Quản lý transaction
- `InputValidator`: Validate input

---

## 📊 Database Schema liên quan

### HoaDonBan

- `MaHDB` (PK): Mã hóa đơn (format: HDByyyyMMddHHmmss)
- `MaKH` (FK, nullable): Mã khách hàng (null = khách lẻ)
- `MaNV` (FK): Mã nhân viên
- `NgayBan`: Ngày bán
- `TongTien`: Tổng tiền
- `PhuongThucTT`: Phương thức thanh toán
- `GhiChu`: Ghi chú
- `TrangThaiHD`: Trạng thái (1=Tạm, 2=Hoàn thành, 3=Hủy)

### ChiTietHoaDonBan

- `MaHDB` (PK, FK): Mã hóa đơn
- `MaSP` (PK, FK): Mã sản phẩm
- `SoLuong`: Số lượng
- `DonGia`: Đơn giá
- `GiamGiaSP`: Giảm giá cho sản phẩm

### SanPham

- `MaSP` (PK): Mã sản phẩm
- `TenSP`: Tên sản phẩm
- `GiaBan`: Giá bán
- `SoLuongTon`: Số lượng tồn kho

---

## 🔧 Cách sử dụng User Control

### Trong Form chính

```csharp
// Tạo instance UC_POS
var ucPOS = new UC_POS();
ucPOS.Dock = DockStyle.Fill;

// Thêm vào Panel hoặc Form
panelMain.Controls.Clear();
panelMain.Controls.Add(ucPOS);
```

### Hoặc trong TabControl

```csharp
// Tab POS
var tabPOS = new TabPage("Bán hàng");
var ucPOS = new UC_POS { Dock = DockStyle.Fill };
tabPOS.Controls.Add(ucPOS);
tabControl.TabPages.Add(tabPOS);

// Tab Quản lý hóa đơn
var tabHoaDon = new TabPage("Quản lý hóa đơn");
var ucHoaDon = new UC_HoaDonBan { Dock = DockStyle.Fill };
tabHoaDon.Controls.Add(ucHoaDon);
tabControl.TabPages.Add(tabHoaDon);
```

---

## ✅ Checklist hoàn thành

### Bảng nhiệm vụ 1: Phần Bán hàng – POS

| Chức năng       | Ưu tiên    | Trạng thái    |
| --------------- | ---------- | ------------- |
| Tạo hóa đơn     | Cao        | ✅ Hoàn thành |
| Cập nhật kho    | Cao        | ✅ Hoàn thành |
| Lưu tạm hóa đơn | Trung bình | ✅ Hoàn thành |
| In hóa đơn      | Trung bình | ✅ Hoàn thành |

### Bảng nhiệm vụ 2: Phần Quản lý hóa đơn – Admin

| Chức năng               | Ưu tiên    | Trạng thái    |
| ----------------------- | ---------- | ------------- |
| Danh sách hóa đơn       | Cao        | ✅ Hoàn thành |
| Xem chi tiết hóa đơn    | Cao        | ✅ Hoàn thành |
| Hủy / hoàn tiền hóa đơn | Cao        | ✅ Hoàn thành |
| Sửa hóa đơn             | Trung bình | ✅ Hoàn thành |

---

## 🎨 Tính năng nâng cao đã thêm

### UC_POS

✅ Kiểm tra tồn kho realtime  
✅ Cảnh báo sản phẩm sắp hết (≤ 10)  
✅ Hiển thị tồn kho sau khi thêm  
✅ Validation mã sản phẩm  
✅ Xác nhận trước khi xóa giỏ/xóa sản phẩm

### UC_HoaDonBan

✅ Filter đa điều kiện (ngày, nhân viên, trạng thái)  
✅ Checkbox bật/tắt filter  
✅ Hiển thị tổng số hóa đơn  
✅ Xác nhận trước khi hủy  
✅ Log thao tác hủy/hoàn tiền

### HoaDonBanEditForm

✅ Validation chỉ sửa hóa đơn tạm  
✅ Kiểm tra tồn kho khi thêm/sửa  
✅ Chỉnh sửa số lượng trực tiếp trên grid  
✅ Áp dụng giảm giá cho tất cả sản phẩm

---

## 🐛 Known Issues (Đã fix)

- ~~Nullable warning trong POSController~~ ✅ Fixed
- ~~Nullable warning trong IPosService~~ ✅ Fixed
- ~~DataAccessBase warning~~ ⚠️ Not our code, ignore

---

## 📝 Notes

- **User Control** được dùng cho các view chính (POS, Quản lý hóa đơn)
- **Dialog Form** được giữ lại cho popup (Chi tiết, Sửa) để dễ quản lý và UX tốt hơn
- Tất cả chức năng đều có log ghi lại thao tác quan trọng
- Transaction được sử dụng để đảm bảo tính nhất quán dữ liệu

---

## 🚀 Hướng dẫn test

### Test UC_POS

1. Mở UC_POS
2. Nhập mã sản phẩm và thêm vào giỏ
3. Kiểm tra cảnh báo khi sản phẩm sắp hết
4. Áp dụng giảm giá cho 1 sản phẩm
5. Thử lưu tạm và thanh toán
6. Kiểm tra tồn kho sau khi thanh toán

### Test UC_HoaDonBan

1. Mở UC_HoaDonBan
2. Xem danh sách hóa đơn
3. Lọc theo ngày, nhân viên, trạng thái
4. Xem chi tiết 1 hóa đơn
5. Sửa 1 hóa đơn tạm
6. Hủy 1 hóa đơn và kiểm tra tồn kho được hoàn trả

---

## 📞 Contact & Support

Nếu có vấn đề, liên hệ team Dev4 hoặc tạo issue trong repository.

**Last updated**: 2025-01-12  
**Version**: 2.0 (User Control)
