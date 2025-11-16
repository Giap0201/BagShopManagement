-- ======================================
-- MIGRATION SCRIPT: Add Missing Columns to HoaDonNhap Table
-- Date: 2025-11-11
-- Description: Add NgayDuyet, NgayHuy, GhiChu, TrangThai columns if they don't exist
-- ======================================

USE BagShopManagementDB;
GO

-- Check if columns exist and add them if missing
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('HoaDonNhap') AND name = 'NgayDuyet')
BEGIN
    ALTER TABLE HoaDonNhap ADD NgayDuyet DATETIME NULL;
    PRINT 'Column NgayDuyet added successfully.';
END
ELSE
BEGIN
    PRINT 'Column NgayDuyet already exists.';
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('HoaDonNhap') AND name = 'NgayHuy')
BEGIN
    ALTER TABLE HoaDonNhap ADD NgayHuy DATETIME NULL;
    PRINT 'Column NgayHuy added successfully.';
END
ELSE
BEGIN
    PRINT 'Column NgayHuy already exists.';
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('HoaDonNhap') AND name = 'GhiChu')
BEGIN
    ALTER TABLE HoaDonNhap ADD GhiChu NVARCHAR(500) NULL;
    PRINT 'Column GhiChu added successfully.';
END
ELSE
BEGIN
    PRINT 'Column GhiChu already exists.';
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('HoaDonNhap') AND name = 'TrangThai')
BEGIN
    ALTER TABLE HoaDonNhap ADD TrangThai TINYINT DEFAULT 0;
    PRINT 'Column TrangThai added successfully.';
    
    -- Update existing records to have default status (0 = TamLuu or 1 = HoatDong as needed)
    UPDATE HoaDonNhap SET TrangThai = 1 WHERE TrangThai IS NULL;
    PRINT 'Updated existing records with default TrangThai.';
END
ELSE
BEGIN
    PRINT 'Column TrangThai already exists.';
END
GO

-- Verify the changes
SELECT 
    c.name AS ColumnName,
    t.name AS DataType,
    c.max_length AS MaxLength,
    c.is_nullable AS IsNullable
FROM sys.columns c
INNER JOIN sys.types t ON c.user_type_id = t.user_type_id
WHERE c.object_id = OBJECT_ID('HoaDonNhap')
    AND c.name IN ('NgayDuyet', 'NgayHuy', 'GhiChu', 'TrangThai')
ORDER BY c.name;
GO

PRINT 'Migration completed successfully!';
GO
