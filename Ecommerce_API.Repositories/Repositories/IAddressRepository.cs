using Ecommerce_API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Repositories.Repositories
{
    public interface IAddressRepository
    {
        //get
        
        Task<List<AddressEntity>> GetAllAddress();
        //add
        Task<AddressEntity> CreateAddress(AddressEntity address);
    }
}
