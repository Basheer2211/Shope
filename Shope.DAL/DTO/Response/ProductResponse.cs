using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shope.DAL.DTO.Response
{
   public class ProductResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public string NameImage { get; set; }

        public string MainImageUrl => $"https://localhost:7283/images/{NameImage}";
    }
}
