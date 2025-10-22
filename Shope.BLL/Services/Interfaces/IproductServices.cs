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
namespace Shope.BLL.Services.Interfaces
{
    public interface IproductServices: IGenarecServices<ProductRequest, ProductResponse, Product>
    {
        Task<int> createFile(ProductRequest request);
    }
}
