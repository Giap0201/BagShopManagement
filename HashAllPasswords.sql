-- ============================================
-- Script: Hash tất cả mật khẩu plaintext sang SHA-256
-- Database: BagStoreDB
-- Mô tả: Chuyển đổi tất cả mật khẩu plaintext (độ dài != 64) 
--         sang dạng hash SHA-256 (64 ký tự hex)
-- ============================================

USE BagStoreDB;
GO

-- Kiểm tra trước khi update
PRINT '========================================';
PRINT 'KIỂM TRA TRƯỚC KHI UPDATE';
PRINT '========================================';

SELECT 
    TenDangNhap,
    MatKhau AS MatKhau_HienTai,
    LEN(MatKhau) AS DoDai_HienTai,
    CASE 
        WHEN LEN(MatKhau) = 64 THEN 'DA_HASH' 
        ELSE 'PLAINTEXT (SE_DUOC_HASH)' 
    END AS TrangThai
FROM TaiKhoan
WHERE MatKhau IS NOT NULL;

PRINT '';
PRINT 'Tổng số tài khoản cần hash:';
SELECT COUNT(*) AS SoLuong
FROM TaiKhoan
WHERE MatKhau IS NOT NULL AND LEN(MatKhau) <> 64;

PRINT '';
PRINT '========================================';
PRINT 'BẮT ĐẦU UPDATE MẬT KHẨU...';
PRINT '========================================';

-- Update tất cả mật khẩu chưa được hash
UPDATE TaiKhoan
SET MatKhau = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', MatKhau), 2)
WHERE MatKhau IS NOT NULL AND LEN(MatKhau) <> 64;

-- Hiển thị kết quả
PRINT '';
PRINT CAST(@@ROWCOUNT AS VARCHAR) + ' tài khoản đã được cập nhật!';

PRINT '';
PRINT '========================================';
PRINT 'KIỂM TRA SAU KHI UPDATE';
PRINT '========================================';

SELECT 
    TenDangNhap,
    MatKhau AS MatKhau_Sau_Hash,
    LEN(MatKhau) AS DoDai,
    CASE 
        WHEN LEN(MatKhau) = 64 THEN '✓ DA_HASH' 
        ELSE '✗ CHUA_HASH' 
    END AS TrangThai
FROM TaiKhoan
WHERE MatKhau IS NOT NULL;

PRINT '';
PRINT '========================================';
PRINT 'HOÀN THÀNH!';
PRINT '========================================';
GO
