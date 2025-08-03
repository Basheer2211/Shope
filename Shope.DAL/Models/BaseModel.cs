using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.Models
{
   public class BaseModel
    {
       public enum Statuse
        {
            Active=1,
            InActive=2

        }
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [Column("Statuse")]
        public Statuse statuse { get; set; } 
    }
}
