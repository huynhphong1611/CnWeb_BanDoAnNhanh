using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_BuyFood.Models
{
    public class DonHangAdmin
    {
       
        
        public string HoTen { get; set; }
        public string TenMonAn { get; set; }
        public string TenDangNhap { get; set; }
        public int? Soluong { get; set; }
        public int? DonGia { get; set; }
        public int TrangThaiThanhToan { get; set; }
        public int MaGH { get; set; }

    }
}