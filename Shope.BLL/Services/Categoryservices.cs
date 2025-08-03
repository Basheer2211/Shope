using Mapster;
using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using Shope.DAL.Models;
using Shope.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shope.DAL.Models.BaseModel;

namespace Shope.BLL.Services
{
   public class Categoryservices : Iservices
    {
        public Categoryservices(Irepository CateporyRepository)
        {
            this.CateporyRepository = CateporyRepository;
        }

        private readonly Irepository CateporyRepository;

        public int CreateCategory(CategoryRequest request)
        {
            var category= request.Adapt<Category>();
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

        public IEnumerable<CategoryResponse> GetAllCategories()
        {
            var categories = CateporyRepository.GetallCategory();
            return CateporyRepository.Adapt<IEnumerable<CategoryResponse>>();
        }

        public CategoryResponse GetCategoryById(int id)
        {
            var category = CateporyRepository.GetbyId(id);
            return category is null ? null : category.Adapt<CategoryResponse>();
        }

        public int UpdateCategory(int id,CategoryRequest request)
        {
            var category = CateporyRepository.GetbyId(id);
            if (category is null)
            {
                return 0;
            }
            category.Name = request.Name;
            return CateporyRepository.Update(category);

        }
        public bool togle(int id)
        {
            Category category = CateporyRepository.GetbyId(id);
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
