using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;

namespace Game.Models
{
    public abstract class Entity
    {

        protected Entity()
        {
            Id = Guid.NewGuid().ToString();

        }
        [Key]
        public string Id { get; set; }

        
    }
}
