using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IQuyenRepository
    {
        /// <summary>
        /// Lấy danh sách tất cả các quyền (Quyen) mà một vai trò (VaiTro) sở hữu.
        /// </summary>
        /// <param name="maVaiTro">Mã vai trò cần kiểm tra.</param>
        /// <returns>Danh sách các quyền.</returns>
        List<Quyen> GetQuyenByMaVaiTro(string maVaiTro);

        /// <summary>
        /// Lấy tất cả các quyền có trong hệ thống.
        /// </summary>
        /// <returns>Danh sách tất cả các quyền.</returns>
        List<Quyen> GetAll();
    }
}
