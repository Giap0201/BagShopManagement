using BagShopManagement.Models;
using BagShopManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagShopManagement.Controllers
{
    public class ChatLieuController
    {
        private readonly IChatLieuService _service;
        public ChatLieuController(IChatLieuService service) { _service = service; }

        public List<ChatLieu> GetAll() => _service.GetAll();
        public ChatLieu GetById(string ma) => _service.GetById(ma);
        public bool Add(ChatLieu item) => _service.Add(item);
        public bool Update(ChatLieu item) => _service.Update(item);
        public bool Delete(string ma) => _service.Delete(ma);
        public List<ChatLieu> Search(string kw) => _service.Search(kw);

        // expose generate next code to UI
        public string GenerateNextCode() => _service.GenerateNextCode();
    }
}
