using Ecommerce_API.Core.Entities;
using Ecommerce_API.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Service.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<AddressEntity> CreateAddress(AddressEntity AddressRequestDto)
        {
            var createAddress = await _addressRepository.CreateAddress(AddressRequestDto);
            return createAddress;
        }

        public async Task<List<AddressEntity>> GetAllUsers()
        {
            return await _addressRepository.GetAllAddress();
        }
    }
}
