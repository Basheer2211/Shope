using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shope.BLL.Services.Interfaces;
using Shope.DAL.DTO.Request;
using System.Threading.Tasks;

namespace Shope.PL.Areas.Admin.controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
   [Authorize(Roles = "admin,Superadmin")]
    public class BrandControllers : ControllerBase
    {
        private readonly IBrandsServices BrandServices;
        public BrandControllers(IBrandsServices categoryservices)
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
        public IActionResult Get([FromRoute] int id)
        {
            if (BrandServices.GetById(id) is null)
            {
                return NotFound();
            }
            return Ok(BrandServices.GetById(id));
        }
        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var category = BrandServices.Delete(id);
            if (category == 0)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Creat([FromForm] BrandRequest cat)
        {
            int id =await BrandServices.createFile(cat);
            return CreatedAtAction(nameof(Get), new { id });
        }
        [HttpPatch("Update/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BrandRequest request)
        {
            var cat = BrandServices.Update(id, request);
            if (cat == 0)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
