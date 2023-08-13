namespace Game.Models.ResponseModels
{
    public class NhanVatResponse
    {
        public string Id { get; set; }
        public string? TenNhanVat { get; set; }
        public string? GioiTinh { get; set; }
        public int? HP { get; set; }
        public int? Mana { get; set; }
        public int? Level { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public VuKhi VuKhi { get; set; }
        public Class Class { get; set; }
    }
}
