# 📘 HƯỚNG DẪN TÍCH HỢP FORMS VÀO BAG SHOP MANAGEMENT

## 📋 MỤC LỤC

1. [Tổng quan kiến trúc](#tổng-quan-kiến-trúc)
2. [Luồng hoạt động hiện tại](#luồng-hoạt-động-hiện-tại)
3. [Hướng dẫn thêm form mới](#hướng-dẫn-thêm-form-mới)
4. [Checklist kiểm tra](#checklist-kiểm-tra)
5. [Troubleshooting](#troubleshooting)

---

## 🏗️ TỔNG QUAN KIẾN TRÚC

### Kiến trúc ứng dụng

```
Program.cs (Entry Point - DI Container Setup)
    ↓
QuanLiBanHang.cs (Main Form - Navigation Hub)
    ├── HeaderControl (Top Bar)
    ├── SideBarControl (Menu Navigation)
    └── panelContent (Content Area - Load Child Forms)
        ├── POSForm (Bán hàng)
        ├── HoaDonBanForm (Quản lý hóa đơn)
        └── [Các forms khác...]
```

### Dependency Injection Flow

```
ServiceCollection → ServiceProvider → Forms
    ↓                    ↓               ↓
Repositories ──────→ Services ────→ Controllers
                                        ↓
                                    Views (Forms)
```

---

## 🔄 LUỒNG HOẠT ĐỘNG HIỆN TẠI

### 1. Khởi động ứng dụng (Program.cs)

```csharp
// Đăng ký Repositories
services.AddScoped<ISanPhamRepository, SanPhamRepository>();
services.AddScoped<IHoaDonBanRepository, HoaDonBanRepository>();

// Đăng ký Services
services.AddScoped<IHoaDonBanService, HoaDonBanService>();
services.AddScoped<ITonKhoService, TonKhoService>();
services.AddScoped<IPosService, PosService>();

// Đăng ký Controllers
services.AddScoped<POSController>();
services.AddScoped<HoaDonBanController>();

// Đăng ký Forms
services.AddTransient<POSForm>();
services.AddTransient<HoaDonBanForm>();
services.AddTransient<QuanLiBanHang>();

// Khởi chạy
var provider = services.BuildServiceProvider();
Application.Run(provider.GetRequiredService<QuanLiBanHang>());
```

### 2. Hiển thị menu (SideBarControl.cs)

```csharp
// SideBarControl tự động tạo 3 nút menu:
// - 🛒 Bán hàng (POS)      → Tag="POS"
// - 📄 Quản lý hóa đơn     → Tag="HoaDon"
// - 📦 Sản phẩm            → Tag="SanPham"

// Khi click, raise event MenuItemClicked với menuKey
public event EventHandler<string>? MenuItemClicked;
```

### 3. Navigation (QuanLiBanHang.cs)

```csharp
// Khi SideBarControl raise event MenuItemClicked:
private void SideBarControl1_MenuItemClicked(object? sender, string menuKey)
{
    switch (menuKey)
    {
        case "POS":
            LoadForm<POSForm>();  // Load form bán hàng
            break;
        case "HoaDon":
            LoadForm<HoaDonBanForm>();  // Load form quản lý hóa đơn
            break;
    }
}

// LoadForm method:
// 1. Đóng form hiện tại
// 2. Lấy instance mới từ DI container
// 3. Cấu hình TopLevel=false, FormBorderStyle=None, Dock=Fill
// 4. Add vào panelContent và Show()
```

### 4. Luồng dữ liệu trong Dev4

#### Module POS (Bán hàng)

```
POSForm
  ↓ (sử dụng)
POSController
  ↓ (gọi)
PosService + HoaDonBanService
  ↓ (truy vấn)
SanPhamRepository + HoaDonBanRepository
  ↓ (kết nối)
DataAccessBase (SqlDataAccess)
  ↓
SQL Server Database
```

#### Module HoaDonBan (Quản lý hóa đơn)

```
HoaDonBanForm (Danh sách hóa đơn)
  ↓ (click Xem chi tiết)
ChiTietHoaDonForm (Chi tiết read-only)
  ↓ (click Chỉnh sửa)
HoaDonBanEditForm (Chỉnh sửa hóa đơn nháp)
  ↓ (Lưu)
HoaDonBanController → HoaDonBanService → Repository
```

---

## ➕ HƯỚNG DẪN THÊM FORM MỚI

### BƯỚC 1: Tạo Repository Layer (nếu cần)

```csharp
// 1. Tạo Interface trong Repositories/Interfaces/
public interface IMyRepository
{
    Task<List<MyModel>> GetAllAsync();
    Task<MyModel?> GetByIdAsync(string id);
    // ... các methods khác
}

// 2. Implement trong Repositories/Implementations/
public class MyRepository : IMyRepository
{
    public async Task<List<MyModel>> GetAllAsync()
    {
        var query = "SELECT * FROM MyTable";
        return await DataAccessBase.ExecuteQueryAsync<MyModel>(query);
    }
    // ... implement các methods
}
```

### BƯỚC 2: Tạo Service Layer (nếu cần)

```csharp
// 1. Tạo Interface trong Services/Interfaces/
public interface IMyService
{
    Task<bool> DoBusinessLogic();
    // ... các methods khác
}

// 2. Implement trong Services/Implementations/
public class MyService : IMyService
{
    private readonly IMyRepository _repo;

    public MyService(IMyRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> DoBusinessLogic()
    {
        // Business logic here
        var data = await _repo.GetAllAsync();
        // Process data...
        return true;
    }
}
```

### BƯỚC 3: Tạo Controller (nếu cần)

```csharp
// Tạo trong Controllers/
public class MyController
{
    private readonly IMyService _service;

    public MyController(IMyService service)
    {
        _service = service;
    }

    public async Task<bool> PerformAction()
    {
        return await _service.DoBusinessLogic();
    }
}
```

### BƯỚC 4: Tạo Form

```csharp
// Trong Views/Dev4/Dev4_MyModule/MyForm.cs
public partial class MyForm : Form
{
    private readonly MyController _controller;

    // ⚠️ QUAN TRỌNG: Constructor phải nhận dependency từ DI
    public MyForm(MyController controller)
    {
        InitializeComponent();
        _controller = controller;
    }

    private async void LoadData()
    {
        var result = await _controller.PerformAction();
        // Update UI...
    }
}
```

### BƯỚC 5: Đăng ký DI trong Program.cs

```csharp
// Thêm vào phương thức Main() trong Program.cs:

// Repository
services.AddScoped<IMyRepository, MyRepository>();

// Service
services.AddScoped<IMyService, MyService>();

// Controller
services.AddScoped<MyController>();

// Form (Transient để mỗi lần load là instance mới)
services.AddTransient<MyForm>();
```

### BƯỚC 6: Thêm nút menu vào SideBarControl.cs

```csharp
// Trong method SetupMenuButtons():

Button btnMyModule = new Button
{
    Text = "📋 Tên Module Của Bạn",
    Width = 280,
    Height = 60,
    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
    BackColor = Color.FromArgb(231, 76, 60),  // Chọn màu khác
    ForeColor = Color.White,
    FlatStyle = FlatStyle.Flat,
    Location = new Point(20, 260),  // Vị trí Y tăng dần (20, 100, 180, 260,...)
    Tag = "MyModule"  // ⚠️ Key để identify trong navigation
};
btnMyModule.Click += MenuItem_Click;

this.Controls.Add(btnMyModule);
```

### BƯỚC 7: Thêm navigation trong QuanLiBanHang.cs

```csharp
// Trong method SideBarControl1_MenuItemClicked():

private void SideBarControl1_MenuItemClicked(object? sender, string menuKey)
{
    switch (menuKey)
    {
        case "POS":
            LoadForm<POSForm>();
            break;
        case "HoaDon":
            LoadForm<HoaDonBanForm>();
            break;
        case "MyModule":  // ⚠️ Phải trùng với Tag trong SideBarControl
            LoadForm<MyForm>();
            break;
    }
}
```

### BƯỚC 8: Build và Test

```powershell
# Build project
dotnet build BagShopManagement.sln

# Chạy ứng dụng
dotnet run --project BagShopManagement/BagShopManagement.csproj
```

---

## ✅ CHECKLIST KIỂM TRA

### Trước khi chạy ứng dụng:

- [ ] Repository interface + implementation đã tạo
- [ ] Service interface + implementation đã tạo
- [ ] Controller đã tạo
- [ ] Form có constructor nhận dependency injection
- [ ] Program.cs đã đăng ký Repository, Service, Controller, Form
- [ ] SideBarControl.cs đã thêm button menu với Tag phù hợp
- [ ] QuanLiBanHang.cs đã thêm case trong switch-case navigation
- [ ] Build thành công không có compilation errors

### Sau khi chạy ứng dụng:

- [ ] Nút menu hiển thị đúng vị trí và màu sắc
- [ ] Click nút menu không bị lỗi
- [ ] Form load đúng trong panelContent (không mở cửa sổ mới)
- [ ] Form hiển thị full màn hình trong content area
- [ ] Chuyển giữa các form không bị crash
- [ ] Dependency injection hoạt động (controller/service được inject)

---

## 🛠️ TROUBLESHOOTING

### Lỗi 1: "No service for type 'MyForm' has been registered"

**Nguyên nhân:** Quên đăng ký form trong Program.cs

**Giải pháp:**

```csharp
// Thêm vào Program.cs:
services.AddTransient<MyForm>();
```

---

### Lỗi 2: Form mở thành cửa sổ mới thay vì load vào panel

**Nguyên nhân:** Không set TopLevel = false

**Giải pháp:** LoadForm method trong QuanLiBanHang.cs đã xử lý:

```csharp
form.TopLevel = false;
form.FormBorderStyle = FormBorderStyle.None;
form.Dock = DockStyle.Fill;
```

---

### Lỗi 3: "Cannot resolve parameter 'controller' of constructor"

**Nguyên nhân:** Constructor của form yêu cầu dependency nhưng chưa đăng ký trong DI

**Giải pháp:** Đảm bảo tất cả dependencies đã đăng ký:

```csharp
// Trong Program.cs, phải đăng ký theo thứ tự:
services.AddScoped<IMyRepository, MyRepository>();
services.AddScoped<IMyService, MyService>();
services.AddScoped<MyController>();
services.AddTransient<MyForm>();
```

---

### Lỗi 4: Database connection failed

**Nguyên nhân:** Connection string trong appsettings.json không đúng

**Giải pháp:** Kiểm tra appsettings.json:

```json
{
  "ConnectionStrings": {
    "Default": "Server=.;Database=BagShopManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Test connection:**

```csharp
// Trong DatabaseTestForm hoặc form khác:
if (DataAccessBase.TestConnection())
{
    MessageBox.Show("Kết nối thành công!");
}
```

---

### Lỗi 5: Nullable reference warnings

**Nguyên nhân:** C# nullable reference types được enable (default .NET 8.0)

**Giải pháp (tùy chọn):**

```csharp
// Trong các model classes, thêm required hoặc ?:
public class MyModel
{
    public required string Id { get; set; }  // Required
    public string? Name { get; set; }        // Nullable
}
```

**Hoặc:** Disable nullable trong .csproj (không khuyến khích):

```xml
<Nullable>disable</Nullable>
```

---

## 📊 SƠ ĐỒ TỔNG THỂ

```
┌─────────────────────────────────────────────────┐
│              Program.cs (Main)                  │
│  - Setup DI Container                           │
│  - Register all dependencies                    │
│  - Launch QuanLiBanHang                         │
└─────────────────┬───────────────────────────────┘
                  │
                  ↓
┌─────────────────────────────────────────────────┐
│           QuanLiBanHang (Main Form)             │
├─────────────────────────────────────────────────┤
│ ┌─────────────────────────────────────────────┐ │
│ │        HeaderControl (Top)                  │ │
│ └─────────────────────────────────────────────┘ │
│ ┌────────────┐ ┌──────────────────────────────┐│
│ │ SideBar    │ │      panelContent            ││
│ │ Control    │ │  ┌────────────────────────┐  ││
│ │            │ │  │   Child Forms Load     │  ││
│ │ 🛒 POS     │ │  │   - POSForm            │  ││
│ │ 📄 HoaDon  │ │  │   - HoaDonBanForm      │  ││
│ │ 📦 SanPham │ │  │   - [Your Forms]       │  ││
│ │            │ │  └────────────────────────┘  ││
│ └────────────┘ └──────────────────────────────┘│
└─────────────────────────────────────────────────┘
```

---

## 🎯 LƯU Ý QUAN TRỌNG

### 1. Lifetime của Services

- **Scoped**: Repository, Service, Controller → Tái sử dụng trong 1 scope (khuyến nghị)
- **Transient**: Forms → Mỗi lần load là instance mới
- **Singleton**: Shared state (không dùng trong project này)

### 2. DataGridView Best Practices

```csharp
// Đã áp dụng trong tất cả forms Dev4:
dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

// Cột số: Right align
column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

// Cột text: Left align (default)
```

### 3. Async/Await Pattern

```csharp
// ✅ ĐÚNG: Sử dụng async/await với database operations
private async void LoadData()
{
    var data = await _controller.GetAllAsync();
    dgvData.DataSource = data;
}

// ❌ SAI: Blocking call
private void LoadData()
{
    var data = _controller.GetAll();  // Blocking!
}
```

### 4. Error Handling

```csharp
// Sử dụng ExceptionHandler utility:
try
{
    await _controller.DoSomething();
}
catch (Exception ex)
{
    ExceptionHandler.Handle(ex, "Thao tác thất bại");
}
```

---

## 📞 HỖ TRỢ

Nếu gặp vấn đề không nằm trong guide này:

1. Kiểm tra logs trong `Logger` class
2. Đọc exception message chi tiết
3. Kiểm tra connection string trong appsettings.json
4. Verify DI registrations trong Program.cs
5. Check nullable reference warnings (chỉ là warnings, không block)

---

**Cập nhật lần cuối:** 2024-12-01  
**Version:** 1.0  
**Tác giả:** Bag Shop Management Team
