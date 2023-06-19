using Ecommerce_API.Core.Entities;
using Ecommerce_API.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Service.Services
{
    public interface IAddressService
    {
        //get
        Task<List<AddressResponseDto>> GetAllAddress();

        Task<AddressResponseDto> GetAddressById(int id);
        //add
        Task<AddressResponseDto> CreateAddress(AddressRequestDto AddressRequestDto);
        //update
        Task<AddressResponseDto> UpdateAddress(int id, AddressRequestDto addressRequestDto);
        //remove
        Task<AddressResponseDto> RemoveAddress(int id);

    }
}
