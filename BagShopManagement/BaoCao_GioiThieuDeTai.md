BÁO CÁO ĐỒ ÁN MÔN HỌC

HỆ THỐNG QUẢN LÝ CỬA HÀNG TÚI XÁCH

(BAG SHOP MANAGEMENT SYSTEM)

Giảng viên hướng dẫn: [Tên giảng viên]

Nhóm sinh viên thực hiện:

- [Tên SV 1] - MSSV: [...]
- [Tên SV 2] - MSSV: [...]
- [Tên SV 3] - MSSV: [...]
- [Tên SV 4] - MSSV: [...]
- [Tên SV 5] - MSSV: [...]
- [Tên SV 6] - MSSV: [...]

Lớp: [Tên lớp]

Học kỳ: [Học kỳ - Năm học]

PHẦN 1: GIỚI THIỆU VỀ ĐỀ TÀI

1.1. Tổng quan về đề tài

Trong bối cảnh thương mại hiện đại, việc quản lý hiệu quả các hoạt động kinh doanh là yếu tố then chốt quyết định sự thành công của doanh nghiệp. Đặc biệt đối với các cửa hàng bán lẻ túi xách - một lĩnh vực kinh doanh đang phát triển mạnh mẽ tại Việt Nam, việc áp dụng công nghệ thông tin vào quản lý là nhu cầu thiết yếu.

Hệ thống "Quản lý cửa hàng túi xách (Bag Shop Management System)" được phát triển nhằm giải quyết các bài toán quản lý toàn diện cho cửa hàng kinh doanh túi xách, balo và các sản phẩm thời trang liên quan. Đây là một ứng dụng desktop được xây dựng trên nền tảng .NET 8.0 với Windows Forms, cung cấp giao diện thân thiện và các tính năng quản lý chuyên nghiệp.

## 1.2. Lý do chọn đề tài

1.2.1. Nhu cầu thực tế

- Thị trường phát triển: Ngành kinh doanh túi xách, phụ kiện thời trang đang có tốc độ tăng trưởng cao tại Việt Nam.
- Quản lý thủ công: Nhiều cửa hàng vẫn sử dụng phương pháp truyền thống (sổ sách, Excel) dẫn đến:

  - Khó kiểm soát tồn kho
  - Dễ xảy ra sai sót trong tính toán
  - Mất thời gian tra cứu thông tin
  - Khó theo dõi doanh thu, lợi nhuận

  1.2.2. Ý nghĩa thực tiễn

- Tự động hóa quy trình: Giảm thiểu thao tác thủ công, tăng hiệu suất làm việc.
- Quản lý tập trung: Tất cả thông tin được lưu trữ và quản lý trên một hệ thống duy nhất.
- Hỗ trợ ra quyết định: Cung cấp báo cáo, thống kê chi tiết giúp chủ cửa hàng đưa ra quyết định kinh doanh chính xác.
- Nâng cao trải nghiệm khách hàng: Tra cứu nhanh chóng, thanh toán chính xác.

  1.2.3. Ý nghĩa học tập

- Áp dụng kiến thức lập trình C# và .NET vào bài toán thực tế.
- Làm quen với kiến trúc phần mềm phân tầng (Layered Architecture).
- Thực hành thiết kế cơ sở dữ liệu quan hệ với SQL Server.
- Rèn luyện kỹ năng làm việc nhóm, quản lý thời gian và lập kế hoạch.

  1.3. Mục tiêu đề tài

Mục tiêu chung: Xây dựng hệ thống quản lý cửa hàng túi xách hỗ trợ đầy đủ các nghiệp vụ chính: quản lý danh mục, kho, bán hàng, nhập hàng, khuyến mãi, nhân sự và báo cáo.

Mục tiêu cụ thể:

- Quản lý danh mục sản phẩm: loại túi, thương hiệu, chất liệu, màu sắc, kích thước.
- Quản lý sản phẩm chi tiết, bao gồm giá nhập, giá bán, số lượng tồn và hình ảnh.
- Quản lý nhập hàng: phiếu nhập, chi tiết nhập, tự động cập nhật tồn kho.
- Hệ thống POS bán hàng: giỏ hàng, tính tiền, áp dụng khuyến mãi, in hóa đơn.
- Quản lý khách hàng, nhà cung cấp và điểm tích lũy.
- Quản lý nhân viên, tài khoản đăng nhập và phân quyền chức năng.
- Cung cấp các báo cáo doanh thu, tồn kho, sản phẩm bán chạy, xuất Excel/PDF.

  1.4. Phạm vi và đối tượng sử dụng

Đối tượng sử dụng:

- Chủ cửa hàng/quản lý: xem tổng quan, báo cáo, phân quyền.
- Nhân viên bán hàng: sử dụng POS, quản lý khách hàng.
- Nhân viên kho: nhập hàng, điều chỉnh tồn kho.

Phạm vi hệ thống:

- Là ứng dụng desktop chạy trên Windows, dùng nội bộ trong cửa hàng (một máy hoặc LAN nhỏ).
- Tập trung vào nghiệp vụ quản lý trong cửa hàng, chưa giải quyết kênh bán online/phân tán nhiều chi nhánh.

Giới hạn:

- Chưa tích hợp cổng thanh toán điện tử (Momo, ZaloPay,...).
- Chưa có phiên bản Web/Mobile.
  PHẦN 2: KẾ HOẠCH LÀM ĐỀ TÀI

  2.1. Các giai đoạn chính

Nhóm triển khai đề tài theo 4 giai đoạn chính:

1. Giai đoạn 1 – Phân tích và thiết kế (Tuần 1–4):

- Khảo sát nghiệp vụ quản lý cửa hàng túi xách.
- Xác định yêu cầu chức năng và phi chức năng.
- Thiết kế kiến trúc theo mô hình phân tầng (View – Controller – Service – Repository).
- Thiết kế cơ sở dữ liệu SQL Server (bảng sản phẩm, khách hàng, hóa đơn, khuyến mãi, phân quyền...).

2. Giai đoạn 2 – Phát triển chức năng (Tuần 5–11):

- Xây dựng lần lượt các module: đăng nhập và phân quyền, danh mục sản phẩm, khách hàng/NCC, POS bán hàng, nhập hàng, tồn kho, khuyến mãi, báo cáo.
- Hoàn thiện giao diện WinForms và kết nối với tầng Service/Repository.

3. Giai đoạn 3 – Tích hợp và kiểm thử (Tuần 12–13):

- Tích hợp các module lại thành một hệ thống thống nhất.
- Kiểm thử chức năng, kiểm thử luồng nghiệp vụ tổng thể (nhập hàng → bán hàng → báo cáo).
- Sửa lỗi, tối ưu giao diện và trải nghiệm người dùng.

4. Giai đoạn 4 – Hoàn thiện và báo cáo (Tuần 14–15):

- Chuẩn hóa dữ liệu demo, viết tài liệu hướng dẫn sử dụng.
- Hoàn thiện báo cáo, slide thuyết trình, chuẩn bị demo.

  2.2. Phân công công việc (tóm tắt)

Nhóm gồm 6 thành viên, chia theo module nghiệp vụ:

- Thành viên 1 – Đăng nhập và nhân sự: Auth, quản lý nhân viên, tài khoản, phân quyền, màn hình hồ sơ cá nhân.
- Thành viên 2 – Danh mục và sản phẩm: Loại túi, thương hiệu, chất liệu, màu sắc, kích thước, quản lý sản phẩm, hình ảnh.
- Thành viên 3 – Khách hàng và nhà cung cấp: Quản lý thông tin, thêm/sửa/xóa, hỗ trợ tìm kiếm.
- Thành viên 4 – POS và hóa đơn bán: Màn hình bán hàng, giỏ hàng, thanh toán, lưu và in hóa đơn.
- Thành viên 5 – Khuyến mãi và tồn kho: Chương trình giảm giá, chi tiết giảm giá cho sản phẩm, màn hình tồn kho, điều chỉnh tồn.
- Thành viên 6 – Nhập hàng và báo cáo: Hóa đơn nhập, chi tiết nhập, báo cáo doanh thu, thống kê tồn kho.

Trong quá trình thực hiện, các thành viên phối hợp để thống nhất giao diện, chuẩn hóa code và cùng nhau kiểm thử.

PHẦN 3: CÁC CÔNG NGHỆ SỬ DỤNG

3.1. Nền tảng và ngôn ngữ

- .NET 8.0 (Windows Desktop): Nền tảng chính để xây dựng ứng dụng, hỗ trợ hiệu năng và bảo mật tốt.
- C#: Ngôn ngữ lập trình hướng đối tượng, sử dụng cho toàn bộ logic ứng dụng.
- Windows Forms: Công nghệ giao diện người dùng (UI) để xây dựng các Form, UserControl cho màn hình quản lý và POS.

  3.2. Cơ sở dữ liệu và truy cập dữ liệu

- Microsoft SQL Server: Lưu trữ dữ liệu sản phẩm, khách hàng, hóa đơn, nhập hàng, khuyến mãi, tài khoản, vai trò, quyền.
- ADO.NET + SqlClient: Thực hiện truy vấn, thêm, sửa, xóa dữ liệu qua các lớp Repository, dùng parameterized queries để tránh SQL Injection.

  3.3. Kiến trúc và mẫu thiết kế

- Kiến trúc phân tầng (Layered Architecture):

  - Tầng giao diện (Views – WinForms).
  - Tầng Controller: nhận yêu cầu từ UI và gọi Service.
  - Tầng Service (Business Logic): xử lý nghiệp vụ, kiểm tra dữ liệu.
  - Tầng Repository: truy cập cơ sở dữ liệu.

- Service Layer và Repository Pattern:

  - Service tập trung logic nghiệp vụ (tính tiền, áp giảm giá, cập nhật tồn kho...).
  - Repository trừu tượng hóa việc truy cập database cho từng bảng.

- Dependency Injection (DI):

  - Sử dụng Microsoft.Extensions.DependencyInjection để đăng ký Services, Controllers, Repositories.
  - Giúp code dễ bảo trì, dễ test hơn.

- DTO (Data Transfer Object):

  - Các lớp như LoginRequest, LoginResponse, HoaDonBanDTO,… để truyền dữ liệu giữa tầng UI – Controller – Service.

  3.4. Thư viện hỗ trợ

- Microsoft.Data.SqlClient: Kết nối và làm việc với SQL Server.
- EPPlus: Xuất dữ liệu (sản phẩm, báo cáo doanh thu, tồn kho) ra file Excel.
- QuestPDF: Tạo và in hóa đơn bán hàng dạng PDF, trình bày đẹp, dễ lưu trữ.
- WinForms.DataVisualization: Hiển thị các biểu đồ thống kê doanh thu, sản phẩm bán chạy trong phần báo cáo.
- FontAwesome: Sử dụng icon cho các nút, menu, giúp giao diện trực quan hơn.

  3.5. Công nghệ bảo mật và tiện ích

- Mã hóa mật khẩu (SHA-256):

  - Lớp PasswordHasher băm mật khẩu người dùng trước khi lưu vào cơ sở dữ liệu.

- Phân quyền theo vai trò (RBAC):

  - Bảng VaiTro, Quyen, VaiTro_Quyen và lớp UserContext giúp kiểm soát quyền thao tác của từng tài khoản.

- TransactionHelper:

  - Hỗ trợ chạy nhiều thao tác cơ sở dữ liệu trong cùng một giao dịch, đảm bảo dữ liệu nhất quán khi tạo hóa đơn, nhập hàng.

Kết luận ngắn:

Đề tài “Hệ thống Quản lý Cửa hàng Túi xách” giúp nhóm sinh viên áp dụng kiến thức lập trình, cơ sở dữ liệu và kiến trúc phần mềm vào một bài toán thực tế. Hệ thống hỗ trợ đầy đủ các nghiệp vụ cốt lõi của một cửa hàng túi xách, có kiến trúc rõ ràng, dễ mở rộng, và có thể tiếp tục phát triển lên phiên bản Web/Mobile trong tương lai.

Báo cáo này được soạn thảo ngày 23/11/2025.

```

```
