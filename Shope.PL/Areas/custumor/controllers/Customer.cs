using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Shope.BLL.Services;
using Shope.BLL.Services.Interfaces;

namespace Shope.PL.Areas.custumor.controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("customer")]
    [Authorize(Roles = "customer")]
    public class Customer : ControllerBase
    {
        private readonly IBrandsServices BrandServices;
        public Customer(IBrandsServices categoryservices )
        {
            this.BrandServices = categoryservices;
        }
        [HttpGet("GetAllCategories")]

        public IActionResult GetAll()
        {
            var cat = BrandServices.GetAll(true);
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
      
    }
}
