# Script tự động thêm ApplyTheme() vào các UserControl
# Chạy script này để áp dụng theme cho tất cả các form

$projectPath = "e:\Project\LTTQ\BagShopManagement"

# Danh sách các file .cs cần áp dụng theme (UserControl và Form)
$files = @(
    "$projectPath\Views\Dev1\ucProfile.cs",
    "$projectPath\Views\Dev1\ucEmployeeManagement.cs",
    "$projectPath\Views\Dev2\ChatLieuControl.cs",
    "$projectPath\Views\Dev2\KichThuocControl.cs",
    "$projectPath\Views\Dev2\LoaiTuiControl.cs",
    "$projectPath\Views\Dev2\MauSacControl.cs",
    "$projectPath\Views\Dev2\ThuongHieuControl.cs",
    "$projectPath\Views\Dev2\DanhMucMenuControl.cs",
    "$projectPath\Views\Dev3\KhachHangControl.cs",
    "$projectPath\Views\Dev3\NhaCungCapControl.cs"
)

$templateCode = @'

        /// <summary>
        /// Áp dụng theme GenZ Vibrant
        /// </summary>
        private void ApplyTheme()
        {
            this.BackColor = BagShopManagement.Utils.ThemeColors.Background;
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
                    else if (text.Contains("sửa") || text.Contains("cập nhật"))
                        BagShopManagement.Utils.ThemeHelper.ApplySecondaryButtonStyle(btn);
                    else if (text.Contains("xóa"))
                        BagShopManagement.Utils.ThemeHelper.ApplyErrorButtonStyle(btn);
                    else if (text.Contains("xuất"))
                        BagShopManagement.Utils.ThemeHelper.ApplySuccessButtonStyle(btn);
                    else
                        BagShopManagement.Utils.ThemeHelper.ApplyAccentButtonStyle(btn);
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
                if (ctrl is DataGridView dgv)
                    BagShopManagement.Utils.ThemeHelper.ApplyThemeToDataGridView(dgv);
                else if (ctrl is GroupBox gb)
                    BagShopManagement.Utils.ThemeHelper.ApplyGroupBoxStyle(gb);
                else if (ctrl is Panel panel)
                    BagShopManagement.Utils.ThemeHelper.ApplyCardStyle(panel);
                else if (ctrl is TextBox tb)
                    BagShopManagement.Utils.ThemeHelper.ApplyTextBoxStyle(tb);
                else if (ctrl is ComboBox cb)
                    BagShopManagement.Utils.ThemeHelper.ApplyComboBoxStyle(cb);
                else if (ctrl is Label lbl && lbl.Font.Size >= 12)
                    BagShopManagement.Utils.ThemeHelper.ApplyTitleLabelStyle(lbl);

                if (ctrl.HasChildren)
                {
                    ApplyThemeToControls(ctrl);
                }
            }
        }
'@

Write-Host "🎨 Bắt đầu áp dụng theme GenZ Vibrant..." -ForegroundColor Cyan

foreach ($file in $files) {
    if (Test-Path $file) {
        Write-Host "📝 Xử lý: $file" -ForegroundColor Yellow
        
        $content = Get-Content $file -Raw
        
        # Kiểm tra xem đã có ApplyTheme chưa
        if ($content -notmatch "private void ApplyTheme\(\)") {
            # Tìm vị trí cuối class (trước dấu } cuối cùng)
            $lastBrace = $content.LastIndexOf("}")
            
            if ($lastBrace -gt 0) {
                # Chèn code template vào trước dấu } cuối
                $newContent = $content.Insert($lastBrace, $templateCode)
                
                # Lưu file
                Set-Content -Path $file -Value $newContent -Encoding UTF8
                Write-Host "   ✅ Đã thêm theme methods" -ForegroundColor Green
            }
        }
        else {
            Write-Host "   ⏭️  Đã có theme, bỏ qua" -ForegroundColor Gray
        }
    }
    else {
        Write-Host "   ❌ Không tìm thấy file" -ForegroundColor Red
    }
}

Write-Host "`n✨ Hoàn thành! Hãy thêm ApplyTheme() vào Load event của các form." -ForegroundColor Green
Write-Host "📖 Xem THEME_GUIDE.md để biết thêm chi tiết." -ForegroundColor Cyan
