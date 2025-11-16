# 🎨 Quick Start - Theme GenZ Vibrant

## 🚀 Cách Áp Dụng Theme Nhanh Nhất

### Bước 1: Thêm code vào form/usercontrol

Mở file `.cs` của form/usercontrol, thêm 3 hàm này vào cuối class (trước dấu `}` cuối):

```csharp
private void ApplyTheme()
{
    this.BackColor = BagShopManagement.Utils.ThemeColors.Background;

    // Nếu có DataGridView, uncomment và sửa tên
    // BagShopManagement.Utils.ThemeHelper.ApplyThemeToDataGridView(dgvTenCuaBan);

    ApplyThemeToButtons(this);
    ApplyThemeToControls(this);
}

private void ApplyThemeToButtons(Control parent)
{
    foreach (Control ctrl in parent.Controls)
    {
        if (ctrl is Button btn)
        {
            string text = btn.Text.ToLower();
            if (text.Contains("thêm") || text.Contains("lưu"))
                BagShopManagement.Utils.ThemeHelper.ApplyPrimaryButtonStyle(btn);
            else if (text.Contains("sửa"))
                BagShopManagement.Utils.ThemeHelper.ApplySecondaryButtonStyle(btn);
            else if (text.Contains("xóa"))
                BagShopManagement.Utils.ThemeHelper.ApplyErrorButtonStyle(btn);
            else if (text.Contains("xuất"))
                BagShopManagement.Utils.ThemeHelper.ApplySuccessButtonStyle(btn);
            else
                BagShopManagement.Utils.ThemeHelper.ApplyAccentButtonStyle(btn);
        }
        else if (ctrl.HasChildren)
            ApplyThemeToButtons(ctrl);
    }
}

private void ApplyThemeToControls(Control parent)
{
    foreach (Control ctrl in parent.Controls)
    {
        if (ctrl is DataGridView dgv)
            BagShopManagement.Utils.ThemeHelper.ApplyThemeToDataGridView(dgv);
        else if (ctrl is GroupBox gb)
            BagShopManagement.Utils.ThemeHelper.ApplyGroupBoxStyle(gb);
        else if (ctrl is Panel panel)
            panel.BackColor = BagShopManagement.Utils.ThemeColors.Card;
        else if (ctrl is TextBox tb)
            BagShopManagement.Utils.ThemeHelper.ApplyTextBoxStyle(tb);
        else if (ctrl is ComboBox cb)
            BagShopManagement.Utils.ThemeHelper.ApplyComboBoxStyle(cb);

        if (ctrl.HasChildren)
            ApplyThemeToControls(ctrl);
    }
}
```

### Bước 2: Gọi trong Load event

```csharp
private void YourControl_Load(object sender, EventArgs e)
{
    ApplyTheme(); // ← Thêm dòng này

    // ... code khác
}
```

### Bước 3: Done! 🎉

Build và chạy để xem kết quả.

---

## 🎨 Màu Sắc Theme

- 🌸 **Pink** `#FF6B9D` - Thêm, Lưu
- 💜 **Purple** `#6C63FF` - Sửa, Cập nhật
- ❤️ **Red** `#FF5757` - Xóa, Hủy
- 🌿 **Green** `#6BCF7F` - Xuất, Tải
- ☀️ **Yellow** `#FFD93D` - Làm mới, Lọc

---

## 📚 Chi Tiết Hơn?

Xem file `THEME_GUIDE.md` để biết thêm chi tiết!

---

## ✨ Tham Khảo

File `SanPhamControl.cs` có implementation đầy đủ để tham khảo.
