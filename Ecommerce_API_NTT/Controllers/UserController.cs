using Ecommerce_API.Service.Model;
using Ecommerce_API.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API_NTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var allUsers= await _userService.GetAllUsers();
            return Ok(new ResponseModel
            {
                Data = allUsers
            }); ;
        }
    }
}
