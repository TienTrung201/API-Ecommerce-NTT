using Ecommerce_API.Core.Entities;
using Ecommerce_API.Service.Model;
using Ecommerce_API.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API_NTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        //get
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await _userService.GetAllUsers();
            return Ok(new ResponseModel
            {
                Data = allUsers
            }); ;
        }
        //post

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserRequestDto userRequestDto)
        {
            if (userRequestDto == null)
            {
                return BadRequest(new ResponseModel() { Status = 400, Title = "user is required" });
            }
            try
            {
                var newUser = await _userService.CreateUser(userRequestDto);
                return Ok(new ResponseModel
                {
                    Status = 201,
                    Data = newUser
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ResponseModel() { Status = 500, Title = ex.Message }
                );
            }


        }

    }
}
