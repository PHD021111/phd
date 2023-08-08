using System.ComponentModel.DataAnnotations;

namespace NhanVatGame.Models
{
    public abstract class Entity
    {
        

        [Key]
        public string Id { get; set; }
    }
}
