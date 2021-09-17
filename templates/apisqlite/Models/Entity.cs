using System.ComponentModel.DataAnnotations;

namespace ApiSqlite.Models
{
    public class Entity {
        [Key]
        public int ID { get; set; }
    }
}