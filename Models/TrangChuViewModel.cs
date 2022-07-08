using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuanAoLite.Models
{
    public class TrangChuViewModel
    {
        public List<SanPham> LayMoi { get; set; }
       // public IEnumerable<SanPham> LayMoi { get; set;  }
       // Tinh da hinh trong OOP
        public List<SanPham> LayHet { get; set; }
    }
    public class DetailedViewModel
    {
        public int Details { get; set; }
        public int SPTheoTheLoai { get; set; }

    }
}