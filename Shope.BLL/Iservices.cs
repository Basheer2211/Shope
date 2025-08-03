using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.BLL
{
    public interface Iservices
    {
        public int CreateCategory(CategoryRequest request);
        public IEnumerable<CategoryResponse> GetAllCategories();
        public CategoryResponse GetCategoryById(int id);
        public int UpdateCategory(int id,CategoryRequest request);
        public int Delete(int id);
        public bool togle(int id);
    }
}
