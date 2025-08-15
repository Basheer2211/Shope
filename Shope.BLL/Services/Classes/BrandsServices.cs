using Shope.BLL.Services.Interfaces;
using Shope.DAL.data;
using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using Shope.DAL.Models;
using Shope.DAL.Repository.Interface;
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
        public BrandsServices(IBrandRepository brand) : base(brand)
        {
            this.brand = brand;
        }


    }
}
