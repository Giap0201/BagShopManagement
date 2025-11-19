using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IVaiTroRepository
    {
        /// <summary>
        /// Lấy thông tin vai trò bằng Mã vai trò.
        /// </summary>
        /// <param name="maVaiTro">Mã vai trò.</param>
        /// <returns>Đối tượng VaiTro hoặc null nếu không tìm thấy.</returns>
        VaiTro GetById(string maVaiTro);

        /// <summary>
        /// Lấy tất cả các vai trò trong hệ thống.
        /// </summary>
        /// <returns>Danh sách các vai trò.</returns>
        List<VaiTro> GetAll();

        bool Add(VaiTro vaiTro);
    }
}
