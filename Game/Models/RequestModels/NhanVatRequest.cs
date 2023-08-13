namespace Game.Models.RequestModels
{
    public class NhanVatRequest
    {
        public string? TenNhanVat { get; set; }
        public string? GioiTinh { get; set; }
        public int? HP { get; set; }
        public int? Mana { get; set; }
        public int? Level { get; set; }
        public string? NguoiDungID { get; set; }
        public string? ClassID { get; set; }
        public string? VuKhiID { get; set; }
    }
}
