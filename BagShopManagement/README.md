## DBHelper và ExceptionHandler
### DBHelper
- Lớp `DBHelper` trong `BagShopManagement.Utils` cung cấp các phương thức truy cập cơ sở dữ liệu:
  - `GetConnection`: Tạo kết nối SQL.
  - `ExecuteQuery`: Thực thi SELECT, trả về DataTable.
  - `ExecuteNonQuery`: Thực thi INSERT/UPDATE/DELETE, trả về số dòng ảnh hưởng.
  - `ExecuteScalar`: Trả về giá trị đơn.
  - `TestConnection`: Kiểm tra kết nối.
- Luôn sử dụng `SqlParameter` để tránh SQL Injection.
- Kiểm tra giá trị trả về (`null` hoặc `-1`) để xử lý lỗi.

### ExceptionHandler
- Xử lý lỗi toàn hệ thống, hiển thị thông báo cho người dùng.
- Phân loại lỗi:
  - `ArgumentException`: Lỗi nhập liệu, hiển thị chi tiết.
  - `ApplicationException`: Lỗi nghiệp vụ/database, hiển thị thông báo chung.
  - Lỗi khác: Hiển thị thông điệp mặc định.
- Không cần gọi `ExceptionHandler` thủ công trong `DBHelper` vì đã được tích hợp.