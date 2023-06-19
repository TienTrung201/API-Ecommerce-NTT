using Ecommerce_API.Core.Entities;
using Ecommerce_API.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Service.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUser(UserRequestDto userRequestDto);

        Task<List<UserResponseDto>> GetAllUsers();

        Task<UserResponseDto> UpdateUser(UserRequestDto userRequestDto);
    }
}
