using Mapster;
using Shope.BLL.Services.Interfaces;
using Shope.DAL.data;
using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;

using Shope.DAL.Models;
using Shope.DAL.Repository.Class;
using Shope.DAL.Repository.Interface;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.BLL.Services.Classes
{
   public class BrandsServices:GenarecSevices<BrandRequest, BrandResponse, Brands>,IBrandsServices
    {
        private readonly IBrandRepository brand;
        private readonly IBrandRepository brandRepository;
        private readonly IFileservieces Fileservieces;

        public BrandsServices(IBrandRepository brand, IFileservieces fileservieces,IBrandRepository brandRepository) : base(brand)
        {
            this.brand = brand;
            this.brandRepository = brandRepository;
        }
        public async Task<int> createFile(BrandRequest request)
        {
            var entity = request.Adapt<Brands>();
            entity.CreatedAt = DateTime.UtcNow;
            if (entity.Image != null)
            {
                var path = await Fileservieces.Uploadasync(request.Image);
                entity.Image = path;
            }
            return brandRepository.Add(entity);
        }



    }
}
