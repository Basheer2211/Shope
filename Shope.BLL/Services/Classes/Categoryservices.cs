using Mapster;
using Shope.BLL.Services.Classes;
using Shope.BLL.Services.Interfaces;
using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using Shope.DAL.Models;
using Shope.DAL.Repository;
using Shope.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shope.DAL.Models.BaseModel;

namespace Shope.BLL.Services
{
   public class Categoryservices : GenarecSevices<CategoryRequest, CategoryResponse,Category>, ICategoryServieces
    {
        public Categoryservices(Irepository CateporyRepository):base(CateporyRepository)
        {
            this.CateporyRepository = CateporyRepository;
        }

        private readonly Irepository CateporyRepository;

       
    }
}
