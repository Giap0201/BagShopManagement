# ============================================
# Script: Chạy Hash Password SQL bằng PowerShell
# ============================================

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "HASH TẤT CẢ MẬT KHẨU TRONG DATABASE" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Thông tin kết nối
$serverName = "DESKTOP-862VN9A"
$databaseName = "BagStoreDB"

Write-Host "Server: $serverName" -ForegroundColor Yellow
Write-Host "Database: $databaseName" -ForegroundColor Yellow
Write-Host ""

# Đọc SQL script
$scriptPath = Join-Path $PSScriptRoot "HashAllPasswords.sql"

if (-not (Test-Path $scriptPath)) {
    Write-Host "KHÔNG TÌM THẤY FILE: $scriptPath" -ForegroundColor Red
    Write-Host "Vui lòng đảm bảo file HashAllPasswords.sql nằm cùng thư mục với script này!" -ForegroundColor Red
    Read-Host "Nhấn Enter để thoát"
    exit
}

Write-Host "Đang đọc SQL script..." -ForegroundColor Green
$sqlScript = Get-Content $scriptPath -Raw

try {
    Write-Host "Đang kết nối đến SQL Server..." -ForegroundColor Green
    
    # Kết nối và thực thi
    $connectionString = "Server=$serverName;Database=$databaseName;Integrated Security=True;TrustServerCertificate=True;"
    $connection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
    $connection.Open()
    
    Write-Host "✓ Kết nối thành công!" -ForegroundColor Green
    Write-Host ""
    Write-Host "Đang thực thi script..." -ForegroundColor Green
    Write-Host ""
    
    $command = $connection.CreateCommand()
    $command.CommandText = $sqlScript
    $command.CommandTimeout = 60
    
    # Thực thi và đọc kết quả
    $reader = $command.ExecuteReader()
    
    # Hiển thị tất cả result sets
    do {
        if ($reader.HasRows) {
            # In header
            $columns = @()
            for ($i = 0; $i -lt $reader.FieldCount; $i++) {
                $columns += $reader.GetName($i)
            }
            Write-Host ($columns -join "`t") -ForegroundColor Cyan
            Write-Host ("-" * 80) -ForegroundColor Cyan
            
            # In rows
            while ($reader.Read()) {
                $values = @()
                for ($i = 0; $i -lt $reader.FieldCount; $i++) {
                    $values += $reader.GetValue($i)
                }
                Write-Host ($values -join "`t")
            }
            Write-Host ""
        }
    } while ($reader.NextResult())
    
    $reader.Close()
    $connection.Close()
    
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Green
    Write-Host "✓ HOÀN THÀNH THÀNH CÔNG!" -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Green
    Write-Host ""
    Write-Host "Tất cả mật khẩu đã được hash sang SHA-256!" -ForegroundColor Green
    Write-Host "Bây giờ bạn có thể đăng nhập vào app với:" -ForegroundColor Yellow
    Write-Host "  - admin / admin123" -ForegroundColor White
    Write-Host "  - binh_nv / 123456" -ForegroundColor White
    Write-Host "  - cuong_kho / 123456" -ForegroundColor White
    
} catch {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Red
    Write-Host "✗ LỖI KHI THỰC THI!" -ForegroundColor Red
    Write-Host "========================================" -ForegroundColor Red
    Write-Host $_.Exception.Message -ForegroundColor Red
    Write-Host ""
    Write-Host "Kiểm tra lại:" -ForegroundColor Yellow
    Write-Host "1. SQL Server đã chạy chưa?" -ForegroundColor White
    Write-Host "2. Tên server đúng chưa? ($serverName)" -ForegroundColor White
    Write-Host "3. Database BagStoreDB đã tạo chưa?" -ForegroundColor White
    Write-Host "4. Windows account của bạn có quyền truy cập SQL Server?" -ForegroundColor White
}

Write-Host ""
Read-Host "Nhấn Enter để thoát"
