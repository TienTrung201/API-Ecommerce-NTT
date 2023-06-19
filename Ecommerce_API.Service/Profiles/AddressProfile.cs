using AutoMapper;
using Ecommerce_API.Core.Entities;
using Ecommerce_API.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Service.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressRequestDto, AddressEntity>();
            CreateMap<AddressEntity, AddressResponseDto>();
        }
    }
}
