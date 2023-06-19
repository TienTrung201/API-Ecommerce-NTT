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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        //createUser
        public async Task<UserResponseDto> CreateUser(UserRequestDto userRequestDto)
        {
            var newUser = _mapper.Map<UserEntity>(userRequestDto);
            newUser.UserId = Guid.NewGuid().ToString();
            var createUser = await _userRepository.CreateUser(newUser);

            var userResponse= _mapper.Map<UserResponseDto>(createUser);
            return userResponse;
        }
        //getAllUsers
        public async Task<List<UserResponseDto>> GetAllUsers()
        {
            var users= await _userRepository.GetAllUsers();
            var usersResponse = _mapper.Map<List<UserResponseDto>>(users);
            return usersResponse;
        }

        public async Task<UserResponseDto> UpdateUser(UserRequestDto userRequestDto)
        {
            var existuser = await _userRepository.GetUserByUserName(userRequestDto.UserName);

            _mapper.Map(userRequestDto, existuser);
            var updateUser= await _userRepository.UpdateUser(existuser);

            var userResponse = _mapper.Map<UserResponseDto>(updateUser);

            return userResponse;
        }
    }
}
