# Script tự động áp dụng theme GenZ Vibrant vào các Designer.cs files
# Script này sẽ inject màu sắc trực tiếp vào các form Designer

$projectPath = "e:\Project\LTTQ\BagShopManagement\Views"

Write-Host "🎨 BẮT ĐẦU ÁP DỤNG THEME GenZ Vibrant..." -ForegroundColor Cyan
Write-Host ""

# Danh sách các UserControl cần áp dụng theme
$controls = @(
    "$projectPath\Dev2\ChatLieuControl.cs",
    "$projectPath\Dev2\KichThuocControl.cs",
    "$projectPath\Dev2\LoaiTuiControl.cs",
    "$projectPath\Dev2\MauSacControl.cs",
    "$projectPath\Dev2\ThuongHieuControl.cs",
    "$projectPath\Dev2\DanhMucMenuControl.cs",
    "$projectPath\Dev3\NhaCungCapControl.cs",
    "$projectPath\Dev5\TonKhoControl.cs",
    "$projectPath\Dev5\PromotionControl.cs",
    "$projectPath\Dev6\ucHoaDonNhapList.cs",
    "$projectPath\Dev6\ucBaoCaoThongKe.cs"
)

$themeCode = @'

        /// <summary>
        /// Áp dụng theme GenZ Vibrant
        /// </summary>
        private void ApplyTheme()
        {
            // Màu nền
            this.BackColor = BagShopManagement.Utils.ThemeColors.Background;

            // Áp dụng cho DataGridView
            ApplyDataGridViewTheme(this);

            // Áp dụng cho buttons
            ApplyButtonsTheme(this);

            // Áp dụng cho controls khác
            ApplyControlsTheme(this);
        }

        private void ApplyDataGridViewTheme(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is DataGridView dgv)
                {
                    BagShopManagement.Utils.ThemeHelper.ApplyThemeToDataGridView(dgv);
                }
                if (ctrl.HasChildren)
                {
                    ApplyDataGridViewTheme(ctrl);
                }
            }
        }

        private void ApplyButtonsTheme(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Button btn)
                {
                    string text = btn.Text.ToLower();
                    if (text.Contains("thêm") || text.Contains("lưu") || text.Contains("tạo"))
                        BagShopManagement.Utils.ThemeHelper.ApplyPrimaryButtonStyle(btn);
                    else if (text.Contains("sửa") || text.Contains("cập nhật"))
                        BagShopManagement.Utils.ThemeHelper.ApplySecondaryButtonStyle(btn);
                    else if (text.Contains("xóa") || text.Contains("hủy"))
                        BagShopManagement.Utils.ThemeHelper.ApplyErrorButtonStyle(btn);
                    else if (text.Contains("xuất") || text.Contains("in"))
                        BagShopManagement.Utils.ThemeHelper.ApplySuccessButtonStyle(btn);
                    else
                        BagShopManagement.Utils.ThemeHelper.ApplyAccentButtonStyle(btn);
                }
                if (ctrl.HasChildren)
                {
                    ApplyButtonsTheme(ctrl);
                }
            }
        }

        private void ApplyControlsTheme(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is GroupBox gb)
                    BagShopManagement.Utils.ThemeHelper.ApplyGroupBoxStyle(gb);
                else if (ctrl is Panel panel && !(ctrl is DataGridView))
                    panel.BackColor = BagShopManagement.Utils.ThemeColors.Card;
                else if (ctrl is TextBox tb)
                    BagShopManagement.Utils.ThemeHelper.ApplyTextBoxStyle(tb);
                else if (ctrl is ComboBox cb)
                    BagShopManagement.Utils.ThemeHelper.ApplyComboBoxStyle(cb);

                if (ctrl.HasChildren)
                {
                    ApplyControlsTheme(ctrl);
                }
            }
        }
'@

$count = 0
$success = 0

foreach ($file in $controls) {
    $count++
    if (Test-Path $file) {
        Write-Host "[$count/$($controls.Count)] 📝 Xử lý: $file" -ForegroundColor Yellow
        
        try {
            $content = Get-Content $file -Raw -Encoding UTF8
            
            # Kiểm tra xem đã có ApplyTheme chưa
            if ($content -notmatch "private void ApplyTheme\(\)") {
                # Tìm vị trí cuối class (trước dấu } cuối cùng)
                $lastBrace = $content.LastIndexOf("}")
                
                if ($lastBrace -gt 0) {
                    # Chèn code theme
                    $newContent = $content.Insert($lastBrace, $themeCode)
                    
                    # Lưu file
                    Set-Content -Path $file -Value $newContent -Encoding UTF8 -NoNewline
                    
                    Write-Host "   ✅ Đã thêm theme methods" -ForegroundColor Green
                    $success++
                    
                    # Tìm Load event và thêm ApplyTheme()
                    $loadEventPattern = "_Load\(object sender, EventArgs e\)\s*\{([^}]*)\}"
                    if ($newContent -match $loadEventPattern) {
                        Write-Host "   💡 Nhớ gọi ApplyTheme() trong Load event!" -ForegroundColor Cyan
                    }
                }
                else {
                    Write-Host "   ⚠️  Không tìm thấy vị trí chèn code" -ForegroundColor DarkYellow
                }
            }
            else {
                Write-Host "   ⏭️  Đã có theme, bỏ qua" -ForegroundColor Gray
            }
        }
        catch {
            Write-Host "   ❌ Lỗi: $_" -ForegroundColor Red
        }
    }
    else {
        Write-Host "   ❌ Không tìm thấy file" -ForegroundColor Red
    }
    Write-Host ""
}

Write-Host ""
Write-Host "══════════════════════════════════════════" -ForegroundColor Cyan
Write-Host "✨ HOÀN THÀNH!" -ForegroundColor Green
Write-Host "   Đã xử lý: $success/$count files" -ForegroundColor White
Write-Host "══════════════════════════════════════════" -ForegroundColor Cyan
Write-Host ""
Write-Host "📝 BƯỚC TIẾP THEO:" -ForegroundColor Yellow
Write-Host "   1. Mở từng file .cs vừa được xử lý" -ForegroundColor White
Write-Host "   2. Trong Load event, thêm: ApplyTheme();" -ForegroundColor White
Write-Host "   3. Build và test!" -ForegroundColor White
Write-Host ""
Write-Host "📚 Tham khảo: SanPhamControl.cs hoặc KhachHangControl.cs" -ForegroundColor Cyan
Write-Host ""
