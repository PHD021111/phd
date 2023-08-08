namespace NhanVatGame.Models
{
    public class KyNang:Entity
    {
        public string? TenKyNang { get; set; }
        public int? ManaCanDung { get; set; }

        public ICollection<KyNangNhanVat> KyNangNhanVats { get; set; }
    }
}
