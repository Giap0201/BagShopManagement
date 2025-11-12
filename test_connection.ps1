# Test Connection Script
# Kiểm tra kết nối đến BagStoreDB

Write-Host "====================================" -ForegroundColor Cyan
Write-Host "Testing Database Connection" -ForegroundColor Cyan
Write-Host "====================================" -ForegroundColor Cyan
Write-Host ""

$server = "."
$database = "BagStoreDB"
$username = "sa"
$password = "Ndtrung@3605"

Write-Host "Server: $server" -ForegroundColor Yellow
Write-Host "Database: $database" -ForegroundColor Yellow
Write-Host "Authentication: SQL Authentication (sa)" -ForegroundColor Yellow
Write-Host ""

# Test query
$query = @"
SELECT 
    'Connection Successful!' AS Status,
    DB_NAME() AS DatabaseName,
    COUNT(*) AS TotalInvoices
FROM HoaDonNhap;

SELECT 
    MaHDN, 
    MaNCC, 
    NgayNhap,
    TongTien,
    TrangThai,
    CASE TrangThai
        WHEN 0 THEN 'Tạm lưu'
        WHEN 1 THEN 'Hoạt động'
        WHEN 2 THEN 'Đã hủy'
        ELSE 'Unknown'
    END AS TrangThaiText
FROM HoaDonNhap
ORDER BY NgayNhap DESC;
"@

Write-Host "Executing test query..." -ForegroundColor Green
sqlcmd -S $server -U $username -P $password -d $database -Q $query

Write-Host ""
Write-Host "====================================" -ForegroundColor Cyan
Write-Host "Test Complete!" -ForegroundColor Green
Write-Host "====================================" -ForegroundColor Cyan
