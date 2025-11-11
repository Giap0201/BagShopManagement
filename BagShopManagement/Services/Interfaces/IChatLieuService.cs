using BagShopManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Services.Interfaces
{
    public interface IChatLieuService
    {
        List<ChatLieu> GetAll();
        ChatLieu GetById(string ma);
        bool Add(ChatLieu item);
        bool Update(ChatLieu item);
        bool Delete(string ma);
        List<ChatLieu> Search(string keyword);

        // generate next code e.g. "CL006"
        string GenerateNextCode();
    }
}
