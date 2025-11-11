using BagShopManagement.Models;
using BagShopManagement.Repositories.Interfaces;
using BagShopManagement.Services.Implementations;
using BagShopManagement.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace BagShopManagement.Tests.Services
{
    public class PosServiceTests
    {
        [Fact]
        public void Checkout_ShouldRollback_WhenInsufficientStock()
        {
            // Arrange
            var mockSanPhamRepo = new Mock<ISanPhamRepository>();
            var mockHoaDonRepo = new Mock<IHoaDonBanRepository>();
            var tonKhoService = new TonKhoService(mockSanPhamRepo.Object);
            var hoaDonService = new HoaDonBanService(mockHoaDonRepo.Object);
            var posService = new PosService(mockSanPhamRepo.Object, hoaDonService, tonKhoService);

            var sp = new SanPham { MaSP = "SP001", TenSP = "Balo", SoLuongTon = 5, GiaBan = 100000 };
            mockSanPhamRepo.Setup(r => r.GetByMaSP("SP001")).Returns(sp);

            // Act
            var add = posService.AddProductToCart("SP001", 10); // yêu cầu vượt tồn kho
            var result = posService.Checkout("KH001", "NV001");

            // Assert
            Assert.False(add.ok); // không thể thêm vào giỏ
            Assert.False(result.ok); // không thể thanh toán
            Assert.Equal("Không đủ tồn kho", result.message);

            // Đảm bảo không có thay đổi kho
            mockSanPhamRepo.Verify(r => r.Update(It.IsAny<SanPham>()), Times.Never);
            // Đảm bảo hóa đơn không được insert
            mockHoaDonRepo.Verify(r => r.Insert(It.IsAny<HoaDonBan>(), It.IsAny<List<ChiTietHoaDonBan>>()), Times.Never);
        }
    }
}
