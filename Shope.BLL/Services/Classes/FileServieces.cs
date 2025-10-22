using Microsoft.AspNetCore.Http;
using Shope.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shope.BLL.Services.Classes
{
   public class FileServieces : IFileservieces
    {
        public async Task<string> Uploadasync(IFormFile file)
        {
            if (file != null & file.Length>0)
            {
                var fileName = Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using (var stream = File.Create(filepath))
                {
                    await file.CopyToAsync(stream);
                }
                    return fileName;
            }
            throw new Exception("error");
        }
    }
}
