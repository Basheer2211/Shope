using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shope.DAL.SeedData.Interface
{
   public interface ISeedData
    {
        Task DataSeedAsync();//منحط task عشان يصير Async ,هيك ما برجع اشي اذا بدي اياه يرجع بحط|Task<data type>
        Task IdentityDataSeedAsync();
    }
}
