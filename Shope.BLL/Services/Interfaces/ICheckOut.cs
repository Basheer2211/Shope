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
   public interface ICheckOut
    {
        public Task<CheckOutResponse> ProcessPayment(CheckOutRequest request, String userId,HttpRequest Request);
        public Task<bool> HandleSuccessPaymentasync(int userId);
    }
}
