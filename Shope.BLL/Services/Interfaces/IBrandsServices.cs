using Shope.DAL.DTO.Request;
using Shope.DAL.DTO.Response;
using Shope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.BLL.Services.Interfaces
{
    public interface  IBrandsServices:IGenarecServices<BrandRequest, BrandResponse,Brands>
    {
        Task<int> createFile(BrandRequest request);
    }
}
