using Mapster;
using Shope.BLL.Services.Interfaces;
using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using Shope.DAL.Models;
using Shope.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shope.DAL.Models.BaseModel;

namespace Shope.BLL.Services.Classes
{
   public class GenarecSevices<Trequest, Tresponse, TEntity> : IGenarecServices<Trequest, Tresponse, TEntity>
        where TEntity : BaseModel
    {
        public GenarecSevices(IGenarecRepositry<TEntity> CateporyRepository)
        {
            this.CateporyRepository = CateporyRepository;
        }

        private readonly IGenarecRepositry<TEntity> CateporyRepository;

        public int Create(Trequest request)
        {
            var category = request.Adapt<TEntity>();
            return CateporyRepository.Add(category);
        }

        public int Delete(int id)
        {
            var category = CateporyRepository.GetbyId(id);
            if (category is null)
            {
                return 0;
            }
            CateporyRepository.Delete(category);
            return 1;

        }

        public IEnumerable<Tresponse> GetAll(bool state=false)
        {
            var categories = CateporyRepository.GetallEntity();
            if (state)
            {
                categories= categories.Where(e => e.statuse == Statuse.Active);
                return categories.Adapt<IEnumerable<Tresponse>>();
            }
            
            return categories.Adapt<IEnumerable<Tresponse>>();
        }

        public Tresponse? GetById(int id)
        {
            var category = CateporyRepository.GetbyId(id);
            return category is null ? default : category.Adapt<Tresponse>();
        }

        public int Update(int id, Trequest request)
        {
            var category = CateporyRepository.GetbyId(id);
            if (category is null)
            {
                return 0;
            }
             
            var UpdateEntity = request.Adapt(category);
            return CateporyRepository.Update(UpdateEntity);

        }
        public bool togle(int id)
        {
            var category = CateporyRepository.GetbyId(id);
            if (category is null)
            {
                return false;
            }
            category.statuse = category.statuse == Statuse.Active ? Statuse.InActive : Statuse.Active;
            CateporyRepository.Update(category);
            return true;

        }
    }
}
