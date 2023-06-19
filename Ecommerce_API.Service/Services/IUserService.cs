using Ecommerce_API.Core.Entities;
using Ecommerce_API.Service.Model;


namespace Ecommerce_API.Service.Services
{
    public interface IUserService
    {
        //create
        Task<UserResponseDto> CreateUser(UserRequestDto userRequestDto);
        //get
        Task<List<UserResponseDto>> GetAllUsers();
        Task<UserResponseDto> GetUserById(string id);
        //update
        Task<UserResponseDto> UpdateUser(string id,UserRequestDto userRequestDto);
        //remove
        Task<UserResponseDto> RemoveUser(string id);
    }
}
