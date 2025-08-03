using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shope.BLL;
using Shope.BLL.Services;
using Shope.DAL.DTO.Request;
using Shope.DAL.Models;

namespace Shope.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Iservices Categoryservices;
        public CategoryController(Iservices categoryservices)
        {
            this.Categoryservices = categoryservices;
        }
        [HttpGet("GetAllCategories")]
        public IActionResult GetAll()
        {
            var cat = Categoryservices.GetAllCategories();
            return Ok(cat);
        }
        [HttpGet("GetCategory/{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            if (Categoryservices.GetCategoryById(id) is null)
            {
                return NotFound();
            }
            return Ok(Categoryservices.GetCategoryById(id));
        }
        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var category = Categoryservices.Delete(id);
            if (category==0)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Creat([FromBody] CategoryRequest cat)
        {
         int id= Categoryservices.CreateCategory(cat);
            return CreatedAtAction(nameof(Get), new {id});
        }
        [HttpPatch("Update/{id}")]
        public IActionResult Update([FromRoute]int id,[FromBody] CategoryRequest request)
        {
            var cat = Categoryservices.UpdateCategory(id, request);
            if (cat==0)
            {
                return NotFound();
            }
            return Ok();
        }
    }
    
}
