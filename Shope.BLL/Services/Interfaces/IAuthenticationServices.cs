using Microsoft.AspNetCore.Http;
using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.BLL.Services.Interfaces
{
   public interface IAuthenticationServices
    {
        Task<registerResponse> Register(registerRequest request,HttpRequest r);
        Task<registerResponse> Login(LoginRequest request);
        Task<string> confirmedEmail(string token, string userId);
        Task<string> forgetpassward(ForgetPassword request);
    }
}
