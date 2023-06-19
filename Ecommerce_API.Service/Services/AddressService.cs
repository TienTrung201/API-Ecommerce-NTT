using AutoMapper;
using Ecommerce_API.Core.Entities;
using Ecommerce_API.Repositories.Repositories;
using Ecommerce_API.Service.Model;
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
        private readonly IMapper _mapper;
        public AddressService(IAddressRepository addressRepository,IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        //get Address

        public async Task<List<AddressResponseDto>> GetAllAddress()
        {
            var addresses = await _addressRepository.GetAllAddress();
            var addressResponse = _mapper.Map<List<AddressResponseDto>>(addresses);
            return addressResponse;
        }

        public async Task<AddressResponseDto> GetAddressById(int id)
        {
            var address = await _addressRepository.GetAddressById(id);
            var addressResponse = _mapper.Map<AddressResponseDto>(address);
            return addressResponse;
        }
        //create Address
        public async Task<AddressResponseDto> CreateAddress(AddressRequestDto AddressRequestDto)
        {
            var newAddress = _mapper.Map<AddressEntity>(AddressRequestDto);

            var createAddress = await _addressRepository.CreateAddress(newAddress);

            var addressResponse = _mapper.Map<AddressResponseDto>(createAddress);
            return addressResponse;
        }
        //Update Address
        public async Task<AddressResponseDto> UpdateAddress(int id, AddressRequestDto addressRequestDto)
        {
            var existAddress = await _addressRepository.GetAddressById(id);


            _mapper.Map(addressRequestDto, existAddress);
            var updateAddress = await _addressRepository.UpdateAddress(existAddress);

            var AddressResponse = _mapper.Map<AddressResponseDto>(updateAddress);

            return AddressResponse;
        }
        //remove Address
        public async Task<AddressResponseDto> RemoveAddress(int id)
        {
            var existAddress = await _addressRepository.GetAddressById(id);

            var addressDelete = await _addressRepository.RemoveAddress(existAddress);

            var AddressResponse = _mapper.Map<AddressResponseDto>(addressDelete);

            return AddressResponse;
        }

    }
}
