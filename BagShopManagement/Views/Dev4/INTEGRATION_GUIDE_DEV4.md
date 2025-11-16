# 🔧 Hướng dẫn tích hợp Dev4 vào Form chính

## Cách 1: Sử dụng TabControl (Recommended)

### Bước 1: Thêm TabControl vào Form chính

```csharp
// MainForm.Designer.cs
private TabControl tabControlMain;

private void InitializeComponent()
{
    tabControlMain = new TabControl();

    // ... other initialization

    tabControlMain.Dock = DockStyle.Fill;
    tabControlMain.Name = "tabControlMain";
    this.Controls.Add(tabControlMain);
}
```

### Bước 2: Thêm UserControl vào TabControl

```csharp
// MainForm.cs
using BagShopManagement.Views.Dev4;
using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;

private void MainForm_Load(object sender, EventArgs e)
{
    // Tab 1: POS - Bán hàng tại quầy
    var tabPOS = new TabPage("🛒 Bán hàng (POS)");
    var ucPOS = new UC_POS
    {
        Dock = DockStyle.Fill
    };
    tabPOS.Controls.Add(ucPOS);
    tabControlMain.TabPages.Add(tabPOS);

    // Tab 2: Quản lý hóa đơn
    var tabHoaDon = new TabPage("📋 Quản lý hóa đơn");
    var ucHoaDon = new UC_HoaDonBan
    {
        Dock = DockStyle.Fill
    };
    tabHoaDon.Controls.Add(ucHoaDon);
    tabControlMain.TabPages.Add(tabHoaDon);
}
```

---

## Cách 2: Sử dụng Panel với Menu/Button

### Bước 1: Thêm Panel container

```csharp
// MainForm.Designer.cs
private Panel panelMenu;
private Panel panelMain;

private void InitializeComponent()
{
    panelMenu = new Panel();
    panelMain = new Panel();

    // Panel Menu (Left/Top)
    panelMenu.Dock = DockStyle.Left; // hoặc Top
    panelMenu.Width = 200; // hoặc Height = 80

    // Panel Main (Fill)
    panelMain.Dock = DockStyle.Fill;

    this.Controls.Add(panelMain);
    this.Controls.Add(panelMenu);
}
```

### Bước 2: Thêm Button trong Menu

```csharp
// MainForm.cs
private Button btnPOS;
private Button btnHoaDon;

private void InitializeComponent()
{
    // ... previous code

    btnPOS = new Button
    {
        Text = "🛒 Bán hàng",
        Dock = DockStyle.Top,
        Height = 50
    };
    btnPOS.Click += btnPOS_Click;

    btnHoaDon = new Button
    {
        Text = "📋 Hóa đơn",
        Dock = DockStyle.Top,
        Height = 50
    };
    btnHoaDon.Click += btnHoaDon_Click;

    panelMenu.Controls.Add(btnHoaDon);
    panelMenu.Controls.Add(btnPOS);
}

private void btnPOS_Click(object sender, EventArgs e)
{
    ShowUserControl(new UC_POS());
}

private void btnHoaDon_Click(object sender, EventArgs e)
{
    ShowUserControl(new UC_HoaDonBan());
}

private void ShowUserControl(UserControl uc)
{
    panelMain.Controls.Clear();
    uc.Dock = DockStyle.Fill;
    panelMain.Controls.Add(uc);
}
```

---

## Cách 3: Sử dụng MenuStrip

### Bước 1: Thêm MenuStrip

```csharp
// MainForm.Designer.cs
private MenuStrip menuStrip;
private ToolStripMenuItem menuBanHang;
private ToolStripMenuItem menuQuanLy;
private ToolStripMenuItem menuPOS;
private ToolStripMenuItem menuHoaDon;
private Panel panelMain;

private void InitializeComponent()
{
    menuStrip = new MenuStrip();
    menuBanHang = new ToolStripMenuItem("Bán hàng");
    menuQuanLy = new ToolStripMenuItem("Quản lý");
    menuPOS = new ToolStripMenuItem("POS - Bán tại quầy");
    menuHoaDon = new ToolStripMenuItem("Danh sách hóa đơn");

    panelMain = new Panel { Dock = DockStyle.Fill };

    // Menu hierarchy
    menuBanHang.DropDownItems.Add(menuPOS);
    menuQuanLy.DropDownItems.Add(menuHoaDon);
    menuStrip.Items.Add(menuBanHang);
    menuStrip.Items.Add(menuQuanLy);

    this.MainMenuStrip = menuStrip;
    this.Controls.Add(panelMain);
    this.Controls.Add(menuStrip);
}
```

### Bước 2: Handle menu click events

```csharp
// MainForm.cs
private void MainForm_Load(object sender, EventArgs e)
{
    menuPOS.Click += (s, ev) => ShowUserControl(new UC_POS());
    menuHoaDon.Click += (s, ev) => ShowUserControl(new UC_HoaDonBan());
}

private void ShowUserControl(UserControl uc)
{
    panelMain.Controls.Clear();
    uc.Dock = DockStyle.Fill;
    panelMain.Controls.Add(uc);
}
```

---

## Cách 4: Mở trong Form riêng (Window mới)

```csharp
// MainForm.cs
private void btnPOS_Click(object sender, EventArgs e)
{
    var form = new Form
    {
        Text = "Bán hàng - POS",
        Size = new Size(1600, 1000),
        StartPosition = FormStartPosition.CenterScreen
    };

    var uc = new UC_POS { Dock = DockStyle.Fill };
    form.Controls.Add(uc);
    form.ShowDialog(); // hoặc form.Show() để không block
}

private void btnHoaDon_Click(object sender, EventArgs e)
{
    var form = new Form
    {
        Text = "Quản lý hóa đơn",
        Size = new Size(1400, 850),
        StartPosition = FormStartPosition.CenterScreen
    };

    var uc = new UC_HoaDonBan { Dock = DockStyle.Fill };
    form.Controls.Add(uc);
    form.ShowDialog();
}
```

---

## 💡 Recommended: TabControl với Icon

```csharp
// MainForm.cs
using BagShopManagement.Views.Dev4;
using BagShopManagement.Views.Dev4.Dev4_HoaDonBan;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        InitializeDev4Tabs();
    }

    private void InitializeDev4Tabs()
    {
        // Tạo TabControl nếu chưa có
        var tabControl = new TabControl
        {
            Dock = DockStyle.Fill,
            Name = "tabControlDev4"
        };

        // Tab POS
        var tabPOS = new TabPage
        {
            Text = "🛒 Bán hàng",
            Name = "tabPOS"
        };
        var ucPOS = new UC_POS { Dock = DockStyle.Fill };
        tabPOS.Controls.Add(ucPOS);

        // Tab Quản lý hóa đơn
        var tabHoaDon = new TabPage
        {
            Text = "📋 Quản lý hóa đơn",
            Name = "tabHoaDon"
        };
        var ucHoaDon = new UC_HoaDonBan { Dock = DockStyle.Fill };
        tabHoaDon.Controls.Add(ucHoaDon);

        // Thêm tabs vào TabControl
        tabControl.TabPages.Add(tabPOS);
        tabControl.TabPages.Add(tabHoaDon);

        // Thêm TabControl vào Form
        this.Controls.Add(tabControl);
    }
}
```

---

## ⚙️ Cấu hình Size & Layout

### Size đề xuất cho UC_POS

- **Minimum Size**: 1200 x 800
- **Recommended Size**: 1600 x 1000

### Size đề xuất cho UC_HoaDonBan

- **Minimum Size**: 1200 x 700
- **Recommended Size**: 1400 x 850

### Dock Style

- Luôn dùng `Dock = DockStyle.Fill` để UserControl tự động resize theo container

---

## 🎨 Tuỳ chỉnh giao diện

### Thay đổi màu sắc TabControl

```csharp
tabControl.BackColor = Color.WhiteSmoke;
tabControl.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

// Hoặc custom draw (advanced)
tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
tabControl.DrawItem += TabControl_DrawItem;
```

### Thêm Icon cho Tab

```csharp
// Cần ImageList
ImageList imageList = new ImageList();
imageList.Images.Add("pos", Image.FromFile("pos_icon.png"));
imageList.Images.Add("invoice", Image.FromFile("invoice_icon.png"));

tabControl.ImageList = imageList;
tabPOS.ImageIndex = 0;
tabHoaDon.ImageIndex = 1;
```

---

## 🔍 Debugging & Testing

### Kiểm tra UserControl load đúng

```csharp
private void ShowUserControl(UserControl uc)
{
    try
    {
        panelMain.Controls.Clear();
        uc.Dock = DockStyle.Fill;
        panelMain.Controls.Add(uc);

        MessageBox.Show($"Loaded: {uc.GetType().Name}", "Debug");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error loading UserControl: {ex.Message}",
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

### Log khi switch tab

```csharp
private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
{
    var selectedTab = tabControl.SelectedTab;
    Logger.Log($"Switched to tab: {selectedTab?.Text}");
}
```

---

## ✅ Checklist tích hợp

- [ ] Thêm references đến Views/Dev4
- [ ] Khởi tạo UserControl trong Form chính
- [ ] Set Dock = DockStyle.Fill
- [ ] Test resize Form → UserControl resize theo
- [ ] Test chức năng POS: thêm sản phẩm, thanh toán
- [ ] Test quản lý hóa đơn: xem, sửa, hủy
- [ ] Test Dialog forms (ChiTiet, Edit) mở đúng
- [ ] Kiểm tra log file có ghi thao tác

---

## 📞 Nếu gặp lỗi

### "Type or namespace not found"

→ Thêm `using BagShopManagement.Views.Dev4;`

### "UserControl không hiển thị"

→ Kiểm tra Dock = Fill và container có size > 0

### "Database connection error"

→ Kiểm tra App.config connection string

### "Null reference exception"

→ Kiểm tra Services/Repositories đã khởi tạo đúng

---

**Happy Coding! 🚀**
