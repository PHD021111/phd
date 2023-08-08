using System.ComponentModel.DataAnnotations.Schema;

namespace NhanVatGame.Models
{
    public class NhanVat:Entity
    {
        public string? TenNhanVat { get; set; }
        public string? GioiTinh { get; set; }
        public int? HP { get; set; }
        public int? Mana { get; set; }
        public int? Level { get; set; }

        [ForeignKey("NguoiDung")]
        public string? NguoiDungID { get; set; }
        public virtual NguoiDung? NguoiDung { get; set; }

        [ForeignKey("Class")]
        public string? ClassID { get; set; }

        public virtual Class? Class { get; set; }

        [ForeignKey("VuKhi")]
        public string? VuKhiID { get; set; }
        public virtual VuKhi? VuKhi { get; set; }

        public virtual ICollection<KyNangNhanVat>? KyNangNhanVats { get; set; }
    }
}
