namespace Game.Models
{
    public class VuKhi:Entity
    {
        public string? TenVuKhi { get; set; }
        public string? ThuocTinhVuKhi { get; set; }

        public ICollection<NhanVat> NhanVats { get; set; }
    }
}
