using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shope.BLL.Services;
using Shope.BLL.Services.Interfaces;
using Shope.DAL.DTO.Request;
using Shope.DAL.Models;

namespace Shope.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]//ما حدا بقدر يجيب البراند كله الا اذا كان مسجل دخوله

    public class BrandController : ControllerBase
    {
        private readonly IBrandsServices BrandServices;
        public BrandController(IBrandsServices categoryservices)
        {
            this.BrandServices = categoryservices;
        }
        [HttpGet("GetAllCategories")]

        public IActionResult GetAll()
        {
            var cat = BrandServices.GetAll();
            return Ok(cat);
        }
        [HttpGet("GetCategory/{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            if (BrandServices.GetById(id) is null)
            {
                return NotFound();
            }
            return Ok(BrandServices.GetById(id));
        }
        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var category = BrandServices.Delete(id);
            if (category==0)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Creat([FromBody] BrandRequest cat)
        {
         int id= BrandServices.Create(cat);
            return CreatedAtAction(nameof(Get), new {id});
        }
        [HttpPatch("Update/{id}")]
        public IActionResult Update([FromRoute]int id,[FromBody] BrandRequest request)
        {
            var cat = BrandServices.Update(id, request);
            if (cat==0)
            {
                return NotFound();
            }
            return Ok();
        }
    }
    
}
