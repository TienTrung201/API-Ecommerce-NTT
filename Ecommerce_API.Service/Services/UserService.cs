using AutoMapper;
using Ecommerce_API.Core.Entities;
using Ecommerce_API.Repositories.Repositories;
using Ecommerce_API.Service.Model;


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

        //get User
        public async Task<List<UserResponseDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            var usersResponse = _mapper.Map<List<UserResponseDto>>(users);
            return usersResponse;
        }
        public async Task<UserResponseDto> GetUserById(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var usersResponse = _mapper.Map<UserResponseDto>(user);
            return usersResponse;
        }
        //create User
        public async Task<UserResponseDto> CreateUser(UserRequestDto userRequestDto)
        {
            var newUser = _mapper.Map<UserEntity>(userRequestDto);
            newUser.UserId = Guid.NewGuid().ToString();
            var createUser = await _userRepository.CreateUser(newUser);

            var userResponse= _mapper.Map<UserResponseDto>(createUser);
            return userResponse;
        }
       
         
        //update User
        public async Task<UserResponseDto> UpdateUser(string id,UserRequestDto userRequestDto)
        {
            var existuser = await _userRepository.GetUserById(id);
           

            _mapper.Map(userRequestDto, existuser);
            var updateUser= await _userRepository.UpdateUser(existuser);

            var userResponse = _mapper.Map<UserResponseDto>(updateUser);

            return userResponse;
        }
        //Remove User
        public async Task<UserResponseDto> RemoveUser(string id)
        {
            var existuser = await _userRepository.GetUserById(id);

            var userDelete= await _userRepository.RemoveUser(existuser);

            var userResponse = _mapper.Map<UserResponseDto>(userDelete);

            return userResponse;
        }
    }
}
