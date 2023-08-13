namespace Game.Models
{
    public class Class:Entity
    {
        public string? TenClass { get; set; }
        public ICollection<NhanVat> NhanVatEntities { get; set; }
    }
}
