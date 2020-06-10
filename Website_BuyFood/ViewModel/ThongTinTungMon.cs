using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_BuyFood.ViewModel
{
    public class ThongTinTungMon
    {       
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public int? DonGia { get; set; }
        public string LinkAnh { get; set; }
        public int? SoLuong { get; set; }
    }
}