using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_BuyFood.Models
{
    public class MonAnDao
    {
        MyDBContext db = null;
        
        public MonAnDao()
        {
            db = new MyDBContext();
        }

        public List<MonAn> DanhSachMonAn()
        {
            return db.MonAns.Select(p => p).ToList();
        }
        public List<MonAn> KetQuaTimKiem(string TenMon)
        {
            var model = db.MonAns.Where(x => x.TenMon.Contains(TenMon)).ToList();
            return model;
        }
    }

}