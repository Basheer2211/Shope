using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shope.BLL.Services.Interfaces;
using Shope.DAL.DTO.Request;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shope.PL.Areas.custumor.controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("customer")]
    [Authorize(Roles = "customer")]
    public class CheckOutController : ControllerBase
    {
        public CheckOutController(ICheckOut checkOut)
        {
            CheckOut = checkOut;
        }

        private readonly ICheckOut CheckOut; 

        [HttpPost]
        public async Task<IActionResult> Payment([FromBody]CheckOutRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await CheckOut.ProcessPayment(request, userId, Request);
            return Ok(response);
        }
        [HttpGet("success/{orderId}")]
        [AllowAnonymous]
        public async Task<IActionResult> success([FromRoute]int orderId)
        {
            var result =await CheckOut.HandleSuccessPaymentasync(orderId);
            return Ok(result);
        }
        [HttpGet("cancel")]
        public IActionResult cancel()
        {
            return Ok("faild");
        }
    }
}
