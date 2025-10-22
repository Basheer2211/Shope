using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shope.BLL.Services.Interfaces;
using Shope.DAL.DTO.Request;
using System.Security.Claims;

namespace Shope.PL.Areas.custumor.controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("customer")]
    [Authorize(Roles = "customer")]

    public class Carts : ControllerBase
    {
        public Carts(ICartServices cartServices)
        {
            CartServices = cartServices;
        }

        private readonly ICartServices CartServices;
        [HttpPost]
        public IActionResult AddToCart(CartRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = CartServices.AddTocart(request, userId);
            return result ? Ok() : BadRequest();
        }
        [HttpGet("GetUserCarte")]
        public IActionResult GetUserCarte()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = CartServices.Getcart(userId);
            return Ok(result);
        }
    }
}
