using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shope.BLL.Services.Interfaces;
using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using Shope.DAL.Models;
using Microsoft.AspNetCore.Identity.UI;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Http;
using Stripe;

namespace Shope.BLL.Services.Classes
{
    public class AutenticationServices : IAuthenticationServices
    {
        public AutenticationServices(UserManager<ApplicationUser> User,IConfiguration configuration, IEmailSender sender, SignInManager<ApplicationUser> signIn)
        {
            _User = User;
            this.configuration = configuration;
            this.sender = sender;
            _signIn = signIn;
        }

        private readonly UserManager<ApplicationUser> _User;
        private readonly IConfiguration configuration;
        private readonly IEmailSender sender;
        private readonly SignInManager<ApplicationUser> _signIn;

        public async Task<registerResponse> Login(LoginRequest request)
        {
          var user=await _User.FindByEmailAsync(request.Email);
            if (user is null)
            {
                throw   new Exception("inValid Email or Password");
            }
            else
            {
                var isValid = await _User.CheckPasswordAsync(user, request.Password);
                var result = await _signIn.CheckPasswordSignInAsync(user, request.Password,true);
                if (result.Succeeded)
                {
                    return new registerResponse()
                    {
                        Token = await CreateTokenAsync(user)
                    };
                }
                else if (result.IsLockedOut)
                {
                    throw new Exception("this account is locked");
                }
                if (!await _User.IsEmailConfirmedAsync(user))
                {
                    throw new Exception("please confirme your email");
                }
                if ( result.IsNotAllowed)
                {
                    throw new Exception("please confirme your email");
                }

                else
                {
                    throw new Exception("inValid Email or Password");
                }
                
                 

            }

        }
        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.fullName),
                new Claim(ClaimTypes.NameIdentifier,user.Id)
            };
            var roles = await _User.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("jwtOption")["secretkey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires:DateTime.Now.AddDays(15),
                signingCredentials: credentials
                );
            

            return  new JwtSecurityTokenHandler().WriteToken(token); ;
        }
        public async Task<string>confirmedEmail(string token,string userId)
        {
            var user = await _User.FindByIdAsync(userId);
            if (user is null)
            {
                throw new Exception("the user is not found");
            }
            var result = await _User.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return "confirmation email";
            }
            return "confirm email failed";
        }
        public async Task<registerResponse> Register(registerRequest request, HttpRequest r)
        {
            var user = new ApplicationUser() {
             UserName = request.Email,
             Email =request.Email,
            fullName=request.fullName,
            PhoneNumber=request.PhoneNumber,//ما منحط الباسوورد هان
            };
           var result= await _User.CreateAsync(user,request.Password);//منقدر ما نبعث كلمه السر بس احنا منبعثها عشان انشفرها
            if (result.Succeeded)
            {
                var token = await _User.GenerateEmailConfirmationTokenAsync(user);
                var escapToken =Uri.EscapeDataString(token) ;
                var Emailurl = $"{r.Scheme}://{r.Host}/api/Identity/Account/ConfirmEmail?token={escapToken}&userId={user.Id}";
                await _User.AddToRoleAsync(user, "customer");
               await sender.SendEmailAsync(request.Email,"welcome",$"<H1>hello</h1>"+
                   $"<a href='{Emailurl}'>confirm</a>" );
                return new registerResponse()
                {
                    Token = request.Email
                };
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                throw new Exception(string.Join(", ", errors));
            }
        }
        public async Task<string> forgetpassward(ForgetPassword request)
        {
            var user = await _User.FindByEmailAsync(request.Email);
            if (user is null)
            {
                throw new Exception("user not found");
            }
            var random = new Random();
            var code = random.Next(1000, 9999).ToString();
            user.codeResetPassword = code;
            user.ExpiryCode = DateTime.UtcNow.AddMinutes(15);//utcNow تتعامل حسب توقيت غرينتش مش ساعه الجهاز
            await _User.UpdateAsync(user);
            await sender.SendEmailAsync(request.Email, "resetEmail", $"<h2>the code is{code}</h2>");
            return "Check your email";
            
        }
    }
}
