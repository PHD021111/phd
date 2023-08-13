using System.ComponentModel.DataAnnotations.Schema;

namespace Game.Models
{
    public class KyNangNhanVat
    {
        [ForeignKey("NhanVat")]
        public string? NhanVatID { get; set; }
        public virtual NhanVat? NhanVat { get; set; }
        [ForeignKey("KyNang")]
        public string? KyNangID { get; set; }
        public virtual KyNang? KyNang { get; set; }
    }
}
