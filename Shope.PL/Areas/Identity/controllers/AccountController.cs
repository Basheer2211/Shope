using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shope.BLL.Services.Interfaces;
using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;


namespace Shope.PL.Areas.Identity.controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Identity")]
    public class AccountController : ControllerBase
    {
        public AccountController(IAuthenticationServices authenticationServices)
        {
            _AuthenticationServices = authenticationServices;
        }

        private readonly IAuthenticationServices _AuthenticationServices;
        [HttpPost("register")]
        public async Task<ActionResult<registerResponse>> register([FromBody]  registerRequest registerRequest)
        {
         var result=  await _AuthenticationServices.Register(registerRequest, Request);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<registerResponse>> Login([FromBody]LoginRequest request)
        {
            var account = await _AuthenticationServices.Login(request);
            return Ok(account);
        }
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery]string userId, [FromQuery]string token)
        {
            var result = await _AuthenticationServices.confirmedEmail(token, userId);
            return Ok(result);
        }
        [HttpPost("forget-password")]
        public async Task<IActionResult> forgetpassword(ForgetPassword request)
        {
            var result = await _AuthenticationServices.forgetpassward(request);
            return Ok(result);
        }
    }
}
