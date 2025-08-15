using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using Shope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.BLL.Services.Interfaces
{
   public interface IGenarecServices<Trequest,Tresponse,TEntity>where TEntity:BaseModel
    {
        public int Create(Trequest request);
        public IEnumerable<Tresponse> GetAll();
        public Tresponse GetById(int id);
        public int Update(int id, Trequest request);
        public int Delete(int id);
        public bool togle(int id);
    }
}
