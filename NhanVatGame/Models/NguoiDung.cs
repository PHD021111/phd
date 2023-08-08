namespace NhanVatGame.Models
{
    public class NguoiDung:Entity
    {
        public string? TenNguoiDung { get; set; }
        public string? TaiKhoan { get; set; }
        public string? MatKhau { get; set; }
        public string? Email { get; set; }
        public int? SDT { get; set; }

        public virtual ICollection<NhanVat> NhanVats { get; set; }
    }
}
