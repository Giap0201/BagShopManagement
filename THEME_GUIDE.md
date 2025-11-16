# 🎨 Hướng Dẫn Áp Dụng Theme GenZ Vibrant

## 📋 Tổng Quan

Theme **GenZ Vibrant** là bảng màu rực rỡ, tươi trẻ được thiết kế dành riêng cho BagShop Management, phù hợp với đối tượng sinh viên và GenZ.

## 🎨 Bảng Màu

### Màu Chính

- **Primary** (`#FF6B9D`): 🌸 Pink Coral - Màu hồng san hô nổi bật
  - Sử dụng cho: Header, nút chính, tiêu đề quan trọng
- **Secondary** (`#6C63FF`): 💜 Vivid Purple - Tím sống động

  - Sử dụng cho: Sidebar, nút phụ, accent

- **Accent** (`#FFD93D`): ☀️ Sunny Yellow - Vàng rạng rỡ

  - Sử dụng cho: Highlight, warning, dashboard button

- **Success** (`#6BCF7F`): 🌿 Fresh Green - Xanh tươi mát
  - Sử dụng cho: Success messages, badges thành công

### Màu Nền

- **Background** (`#F8F9FA`): Trắng mềm mại - Nền tổng thể
- **Card** (`#FFFFFF`): Trắng tinh khiết - Card, panel

### Màu Text

- **TextPrimary** (`#2D3748`): Xám đậm - Text chính
- **TextSecondary** (`#718096`): Xám vừa - Text phụ

### Màu Bổ Sung

- **PrimaryLight** (`#FFB3CC`): Hồng nhạt - Hover effect
- **SecondaryLight** (`#A5A0FF`): Tím nhạt - Hover effect
- **Error** (`#FF5757`): Đỏ cảnh báo
- **Border** (`#E2E8F0`): Xám viền nhẹ

## 🚀 Cách Sử Dụng

### 1. Áp Dụng Theme Cho Form/UserControl

Thêm method `ApplyTheme()` vào form hoặc usercontrol của bạn:

```csharp
using BagShopManagement.Utils;

public partial class YourControl : UserControl
{
    private void YourControl_Load(object sender, EventArgs e)
    {
        ApplyTheme();
        // ... code khác
    }

    private void ApplyTheme()
    {
        // Màu nền
        this.BackColor = ThemeColors.Background;

        // DataGridView
        if (dgvYourGrid != null)
        {
            ThemeHelper.ApplyThemeToDataGridView(dgvYourGrid);
        }

        // Buttons
        ApplyThemeToButtons(this);

        // Controls khác
        ApplyThemeToControls(this);
    }

    private void ApplyThemeToButtons(Control parent)
    {
        foreach (Control ctrl in parent.Controls)
        {
            if (ctrl is Button btn)
            {
                // Chọn style phù hợp
                if (btn.Text.Contains("Thêm") || btn.Text.Contains("Lưu"))
                    ThemeHelper.ApplyPrimaryButtonStyle(btn);
                else if (btn.Text.Contains("Sửa"))
                    ThemeHelper.ApplySecondaryButtonStyle(btn);
                else if (btn.Text.Contains("Xóa"))
                    ThemeHelper.ApplyErrorButtonStyle(btn);
                else if (btn.Text.Contains("Xuất"))
                    ThemeHelper.ApplySuccessButtonStyle(btn);
                else
                    ThemeHelper.ApplyAccentButtonStyle(btn);
            }
            else if (ctrl.HasChildren)
            {
                ApplyThemeToButtons(ctrl);
            }
        }
    }

    private void ApplyThemeToControls(Control parent)
    {
        foreach (Control ctrl in parent.Controls)
        {
            if (ctrl is GroupBox gb)
                ThemeHelper.ApplyGroupBoxStyle(gb);
            else if (ctrl is Panel panel)
                panel.BackColor = ThemeColors.Card;
            else if (ctrl is TextBox tb)
                ThemeHelper.ApplyTextBoxStyle(tb);
            else if (ctrl is ComboBox cb)
                ThemeHelper.ApplyComboBoxStyle(cb);
            else if (ctrl is Label lbl && lbl.Font.Size >= 12)
                ThemeHelper.ApplyTitleLabelStyle(lbl);

            if (ctrl.HasChildren)
                ApplyThemeToControls(ctrl);
        }
    }
}
```

### 2. Áp Dụng Trực Tiếp Trong Designer

Nếu muốn đặt màu trực tiếp trong Designer.cs:

```csharp
// Trong InitializeComponent()
this.BackColor = BagShopManagement.Utils.ThemeColors.Background;
btnThem.BackColor = BagShopManagement.Utils.ThemeColors.Primary;
btnThem.ForeColor = BagShopManagement.Utils.ThemeColors.Card;
```

### 3. Sử Dụng Helper Methods

```csharp
// DataGridView
ThemeHelper.ApplyThemeToDataGridView(dgvData);

// Buttons
ThemeHelper.ApplyPrimaryButtonStyle(btnSave);
ThemeHelper.ApplySecondaryButtonStyle(btnEdit);
ThemeHelper.ApplyErrorButtonStyle(btnDelete);
ThemeHelper.ApplySuccessButtonStyle(btnExport);
ThemeHelper.ApplyAccentButtonStyle(btnRefresh);

// Controls
ThemeHelper.ApplyCardStyle(panel1);
ThemeHelper.ApplyGroupBoxStyle(groupBox1);
ThemeHelper.ApplyTitleLabelStyle(lblTitle);
ThemeHelper.ApplyTextBoxStyle(txtInput);
ThemeHelper.ApplyComboBoxStyle(cboFilter);
```

## 📝 Checklist Cho Từng Form

- [ ] BackColor của form/usercontrol = `ThemeColors.Background`
- [ ] Tất cả DataGridView đã áp dụng `ThemeHelper.ApplyThemeToDataGridView()`
- [ ] Các nút chính đã được style theo chức năng:
  - [ ] Nút Thêm/Lưu → Primary (Hồng)
  - [ ] Nút Sửa → Secondary (Tím)
  - [ ] Nút Xóa → Error (Đỏ)
  - [ ] Nút Xuất → Success (Xanh)
  - [ ] Nút Làm mới/Lọc → Accent (Vàng)
- [ ] GroupBox và Panel đã được style
- [ ] TextBox và ComboBox đã được style
- [ ] Label tiêu đề (size lớn) đã được style

## 🎯 Ví Dụ Hoàn Chỉnh

Xem file `SanPhamControl.cs` để tham khảo cách implement đầy đủ.

## 💡 Tips

1. **Consistency**: Giữ nhất quán màu sắc theo chức năng

   - Thêm/Lưu → Hồng
   - Sửa/Cập nhật → Tím
   - Xóa → Đỏ
   - Xuất/Export → Xanh
   - Làm mới/Lọc → Vàng

2. **DataGridView**: Luôn áp dụng theme để có giao diện đồng nhất

3. **Hover Effects**: Các button đã có hover effect tự động

4. **Font**: Sử dụng Segoe UI với size phù hợp:

   - Tiêu đề: 14-18pt Bold
   - Button: 10pt Bold
   - Text thường: 9.5-10pt Regular

5. **Icons**: Có thể thêm emoji vào text button để tăng tính sinh động 🎨✨

## 🐛 Troubleshooting

### Màu không hiển thị đúng

- Kiểm tra `UseVisualStyleBackColor = false` cho Button
- Đảm bảo `EnableHeadersVisualStyles = false` cho DataGridView

### Theme không áp dụng cho control con

- Kiểm tra đã gọi recursively cho `ctrl.HasChildren`
- Đảm bảo `ApplyTheme()` được gọi trong `Load` event

## 📞 Liên Hệ

Nếu có thắc mắc về theme, liên hệ team để được hỗ trợ!

---

💖 **Happy Coding with GenZ Vibrant Theme!** 💜
