using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Repositories.Interfaces
{
    public interface IChatLieuRepository
    {
        List<ChatLieu> GetAll();
        ChatLieu GetById(string ma);
        bool Add(ChatLieu item);
        bool Update(ChatLieu item);
        bool Delete(string ma);
        List<ChatLieu> Search(string keyword);

        // trả về mã lớn nhất hiện có (vd "CL005") hoặc null nếu bảng rỗng
        string GetMaxCode();
    }
}
