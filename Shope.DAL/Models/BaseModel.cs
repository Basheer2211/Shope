using System.ComponentModel.DataAnnotations.Schema;

namespace Shope.DAL.Models
{
    public class BaseModel
    {
        public enum Statuse
        {
            Active = 1,
            InActive = 2

        }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Column("Statuse")]
        public Statuse statuse { get; set; } = Statuse.Active;
    }
}
