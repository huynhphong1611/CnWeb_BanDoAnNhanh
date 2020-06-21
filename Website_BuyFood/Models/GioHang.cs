namespace Website_BuyFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GioHang()
        {
            ChiTiet_GioHang = new HashSet<ChiTiet_GioHang>();
        }

        [Key]
        public int MaGioHang { get; set; }

        public DateTime? NgayTao { get; set; }

        public int? MaKH { get; set; }

        public int? TinhTrang { get; set; }
        public int ThanhToan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_GioHang> ChiTiet_GioHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
