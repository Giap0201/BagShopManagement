// ============================================================================
// TEMPLATE CODE: Theme GenZ Vibrant - Copy vào Form/UserControl của bạn
// ============================================================================
// 
// HƯỚNG DẪN:
// 1. Copy toàn bộ code dưới đây vào cuối class của form/usercontrol
// 2. Gọi ApplyTheme() trong Load event
// 3. Thay "dgvYourGrid" bằng tên DataGridView thực tế của bạn
//
// ============================================================================

/// <summary>
/// Áp dụng theme GenZ Vibrant cho form/usercontrol này
/// </summary>
private void ApplyTheme()
{
    // Màu nền tổng thể
    this.BackColor = BagShopManagement.Utils.ThemeColors.Background;

    // Áp dụng theme cho DataGridView (thay tên dgvYourGrid bằng tên thực tế)
    // if (dgvYourGrid != null)
    // {
    //     BagShopManagement.Utils.ThemeHelper.ApplyThemeToDataGridView(dgvYourGrid);
    // }

    // Áp dụng theme cho tất cả buttons
    ApplyThemeToButtons(this);

    // Áp dụng theme cho các control khác
    ApplyThemeToControls(this);
}

/// <summary>
/// Áp dụng theme cho các button theo chức năng
/// </summary>
private void ApplyThemeToButtons(Control parent)
{
    foreach (Control ctrl in parent.Controls)
    {
        if (ctrl is Button btn)
        {
            // Phân loại button dựa trên text hoặc name
            string text = btn.Text.ToLower();
            string name = btn.Name.ToLower();

            // Primary: Thêm, Lưu, Tạo mới
            if (text.Contains("thêm") || text.Contains("lưu") || text.Contains("tạo") ||
                name.Contains("add") || name.Contains("save") || name.Contains("create"))
            {
                BagShopManagement.Utils.ThemeHelper.ApplyPrimaryButtonStyle(btn);
            }
            // Secondary: Sửa, Cập nhật, Chỉnh sửa
            else if (text.Contains("sửa") || text.Contains("cập nhật") || text.Contains("chỉnh sửa") ||
                     name.Contains("edit") || name.Contains("update") || name.Contains("modify"))
            {
                BagShopManagement.Utils.ThemeHelper.ApplySecondaryButtonStyle(btn);
            }
            // Error: Xóa, Hủy (destructive actions)
            else if (text.Contains("xóa") || text.Contains("hủy") ||
                     name.Contains("delete") || name.Contains("remove"))
            {
                BagShopManagement.Utils.ThemeHelper.ApplyErrorButtonStyle(btn);
            }
            // Success: Xuất, Tải xuống, In
            else if (text.Contains("xuất") || text.Contains("tải") || text.Contains("in") || text.Contains("export") ||
                     name.Contains("export") || name.Contains("print") || name.Contains("download"))
            {
                BagShopManagement.Utils.ThemeHelper.ApplySuccessButtonStyle(btn);
            }
            // Accent: Làm mới, Lọc, Tìm kiếm
            else if (text.Contains("làm mới") || text.Contains("refresh") || text.Contains("lọc") ||
                     text.Contains("tìm") || text.Contains("search") ||
                     name.Contains("refresh") || name.Contains("filter") || name.Contains("search"))
            {
                BagShopManagement.Utils.ThemeHelper.ApplyAccentButtonStyle(btn);
            }
            // Default: Secondary
            else
            {
                BagShopManagement.Utils.ThemeHelper.ApplySecondaryButtonStyle(btn);
            }
        }
        // Recursively áp dụng cho control con
        else if (ctrl.HasChildren)
        {
            ApplyThemeToButtons(ctrl);
        }
    }
}

/// <summary>
/// Áp dụng theme cho các control khác (GroupBox, Panel, TextBox, etc.)
/// </summary>
private void ApplyThemeToControls(Control parent)
{
    foreach (Control ctrl in parent.Controls)
    {
        // GroupBox
        if (ctrl is GroupBox gb)
        {
            BagShopManagement.Utils.ThemeHelper.ApplyGroupBoxStyle(gb);
        }
        // Panel (trừ DataGridView vì nó kế thừa Panel)
        else if (ctrl is Panel panel && !(ctrl is DataGridView))
        {
            // Panel thường dùng làm card/container
            BagShopManagement.Utils.ThemeHelper.ApplyCardStyle(panel);
        }
        // TextBox
        else if (ctrl is TextBox tb)
        {
            BagShopManagement.Utils.ThemeHelper.ApplyTextBoxStyle(tb);
        }
        // ComboBox
        else if (ctrl is ComboBox cb)
        {
            BagShopManagement.Utils.ThemeHelper.ApplyComboBoxStyle(cb);
        }
        // Label (chỉ style những label lớn - tiêu đề)
        else if (ctrl is Label lbl && lbl.Font.Size >= 12)
        {
            BagShopManagement.Utils.ThemeHelper.ApplyTitleLabelStyle(lbl);
        }

        // Recursively áp dụng cho control con
        if (ctrl.HasChildren)
        {
            ApplyThemeToControls(ctrl);
        }
    }
}

// ============================================================================
// CÁCH SỬ DỤNG:
// ============================================================================
//
// Trong Load event của form/usercontrol:
//
// private void YourForm_Load(object sender, EventArgs e)
// {
//     ApplyTheme(); // ← Gọi hàm này đầu tiên
//     
//     // ... code khác của bạn
// }
//
// ============================================================================
// LƯU Ý:
// ============================================================================
//
// 1. Nếu có nhiều DataGridView, gọi ApplyThemeToDataGridView cho từng cái:
//    ThemeHelper.ApplyThemeToDataGridView(dgv1);
//    ThemeHelper.ApplyThemeToDataGridView(dgv2);
//
// 2. Nếu muốn custom màu cho button cụ thể, có thể gọi trực tiếp:
//    ThemeHelper.ApplyPrimaryButtonStyle(btnSpecial);
//
// 3. Nếu control không tự động được style, có thể style thủ công:
//    myControl.BackColor = ThemeColors.Card;
//    myControl.ForeColor = ThemeColors.TextPrimary;
//
// ============================================================================
