using Ecommerce_API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Service.Services
{
    public interface IAddressService
    {
        Task<AddressEntity> CreateAddress(AddressEntity AddressRequestDto);

        Task<List<AddressEntity>> GetAllUsers();

    }
}
