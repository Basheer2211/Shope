using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.BLL.Services.Interfaces
{
   public interface IFileservieces
    {
        Task<string> Uploadasync(IFormFile file);
    }
} 
