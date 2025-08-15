using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shope.DAL.Models.BaseModel;

namespace Shope.DAL.DTO.Response
{
   public class BrandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Statuse statuse { get; set; }

    }
}
