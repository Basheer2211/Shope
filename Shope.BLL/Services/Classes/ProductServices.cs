using Azure.Core;
using Azure;
using Shope.DAL.data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using Shope.DAL.Models;
using Shope.BLL.Services.Interfaces;
using Shope.DAL.Repository.Interface;
using Mapster;

namespace Shope.BLL.Services.Classes
{
  public  class ProductServices: GenarecSevices<ProductRequest, ProductResponse, Product>, IproductServices
    {
        public ProductServices(IproductRepository ProductRepository,IFileservieces fileservieces) : base(ProductRepository)
        {
            this.ProductRepository = ProductRepository;
            Fileservieces = fileservieces;
        }

        private readonly IproductRepository ProductRepository;

        private readonly IFileservieces Fileservieces;

        public async Task<int> createFile(ProductRequest request)
        {
            var entity = request.Adapt<Product>();
            entity.CreatedAt = DateTime.UtcNow;
            if (entity.NameImage !=null)
            {
                var path = await Fileservieces.Uploadasync(request.NameImage);
                entity.NameImage = path;
            }
            return ProductRepository.Add(entity);
        }
    }
}
