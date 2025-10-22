using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shope.BLL.Services.Classes;
using Shope.BLL.Services.Interfaces;
using Shope.DAL.DTO.Request;
using System.Threading.Tasks;

namespace Shope.PL.Areas.Admin.controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Products")]
   [Authorize(Roles = "admin,Superadmin")]
    public class ProductsController : ControllerBase
    {
        public ProductsController(IproductServices prducts)
        {
            Prducts = prducts;
        }

        private readonly IproductServices Prducts;
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> Create([FromForm]ProductRequest request)//fromform مش body عشان في حقل مسجل انه file
        {
            var result =await Prducts.createFile(request);
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var cat = Prducts.GetAll();
            return Ok(cat);
        }
    }
}
